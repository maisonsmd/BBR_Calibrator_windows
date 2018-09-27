using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Threading;

using BBR_Calibrator.MathHelpers;

namespace BBR_Calibrator {

    internal class SerialCommunication {
        private const string Tag = "SerialCommunication";

        private SerialPort serial;

        public delegate void OnValidPortFound ( string portName );

        public delegate void OnDataReceivedHandler ( string data );

        public delegate void OnInfoReceivedHandler ( string tag, string errorString, LoggerClass.EventType eventType );

        public event OnDataReceivedHandler DataReceived;

        public event OnInfoReceivedHandler InfoReceived;

        public event OnValidPortFound ValidPortFound;

        private TimeCounter Millis = TimeCounter.Instance;

        private bool IsFindingPort = false;

        /// <summary>
        /// create a new instance
        /// </summary>
        private SerialCommunication ( ) {
            serial = new SerialPort {
                BaudRate = 115200,
                RtsEnable = true,
                DtrEnable = true,
                ReadTimeout = 3
            };
            //serial.DataReceived += Serial_DataReceived;
        }

        private void PrintInfo ( string info ) {
            InfoReceived?.BeginInvoke(Tag, info, LoggerClass.EventType.Info, InfoReceivedInvokeCallback, null);
        }

        private void PrintWarning ( string warning ) {
            InfoReceived?.BeginInvoke(Tag, warning, LoggerClass.EventType.Warning, InfoReceivedInvokeCallback, null);
        }

        private void PrintError ( string error ) {
            InfoReceived?.BeginInvoke(Tag, error, LoggerClass.EventType.Error, InfoReceivedInvokeCallback, null);
        }

        public bool IsOpen {
            get { return serial.IsOpen; }
        }

        public bool FindPort ( ) {
            if (IsFindingPort)
                return false;

            IsFindingPort = true;

            string [] portNames = SerialPort.GetPortNames();

            if (portNames.Length != 0) {
                string allPorts = "";
                foreach (string s in portNames)
                    allPorts += s + ", ";

                PrintInfo("available ports: " + allPorts);

                int totalWorks = portNames.Length;
                int completedWorks = 0;
                bool isValidPortFound = false;

                foreach (string portName in portNames) {
                    SerialPort currentPort = new SerialPort {
                        BaudRate = serial.BaudRate,
                        DtrEnable = serial.DtrEnable,
                        ReadTimeout = 3,
                        PortName = portName
                    };

                    BackgroundWorker backgroundWorker = new BackgroundWorker();

                    backgroundWorker.DoWork += new DoWorkEventHandler(delegate ( object o, DoWorkEventArgs e ) {
                        e.Result = TryOpen(currentPort);
                    });

                    backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                        delegate ( object o, RunWorkerCompletedEventArgs e ) {
                            completedWorks++;
                            if ((bool)e.Result == true) {
                                serial = currentPort;
                                isValidPortFound = true;
                            }
                            if (completedWorks == totalWorks) {
                                IsFindingPort = false;
                                if (isValidPortFound) {
                                    serial.DataReceived += Serial_DataReceived;
                                    ValidPortFound?.BeginInvoke(serial.PortName, ValidPortFoundInvokeCallback, null);
                                }
                                else {
                                    PrintWarning("no valid port found!");
                                }
                            }
                        });
                    backgroundWorker.RunWorkerAsync();
                }
            }
            else {
                PrintInfo("no available port");
            }

            return true;
        }

        /// <summary>
        /// try opening and validating a port
        /// </summary>
        /// <param name="port">the port to try</param>
        /// <returns>if the port is valid</returns>
        private bool TryOpen ( SerialPort port ) {
            PrintInfo("trying connecting to: " + port.PortName);

            bool portIsValid = false;
            try {
                byte [] queryBytes = new byte [2];
                byte [] responseBytes = new byte [2];
                queryBytes [0] = 0x0D;
                queryBytes [1] = 0xFD;

                port.Open();
                //arduino AVR usually resets in 2s when COM port opened, STM USBSerial doesn't
                Thread.Sleep(100);
                port.Write(queryBytes, 0, queryBytes.Length);
                long startMillis = Millis.Millis();

                while (Millis.Millis() - startMillis < 1000) {
                    if (port.BytesToRead != 0)
                        break;
                }
                //wait for the rest of data
                Thread.Sleep(10);

                if (port.BytesToRead == 0)
                    PrintWarning(port.PortName + " not responding");
                else if (port.BytesToRead == 2) {
                    byte [] response = new byte [2];
                    port.BaseStream.Read(response, 0, 2);
                    if (response [0] == 0xE5
                     && response [1] == 0x56) {
                        PrintInfo(port.PortName + " is OK, use it!");
                        portIsValid = true;
                        return true;
                    }
                    else {
                        string text = string.Format("{0}: invalid response [0x{1:X2} 0x{2:X2}]", port.PortName, response [0], response [1]);
                        PrintWarning(text);
                    }
                }
                else {
                    string text = string.Format("{0}: invalid response [{1} byte]", port.PortName, port.BytesToRead);
                    PrintWarning(text);
                }
            }
            catch {
                PrintWarning("cannot open " + port.PortName);
            }
            port.Close();
            return portIsValid;
        }

        private void Serial_DataReceived ( object sender, SerialDataReceivedEventArgs e ) {
            if (serial.BytesToRead < 1) {
                return;
            }
            int size = serial.ReadByte();
            Console.WriteLine(size);
            byte [] buffer = new byte [size + 1];

            int index = 0;
            try {
                while (index < size && serial.IsOpen) {
                    buffer [index++] = (byte)serial.ReadByte();
                }
                ProcessData(buffer, size);
            }
            catch (Exception exception) {
                Console.WriteLine(exception.ToString());
                PrintError(exception.ToString());
                //ErrorOccurred?.BeginInvoke("Exception caused the SerialPort to close!", ErrorOccurredInvokeCallback, null);
                return;
            }
        }

        private void InfoReceivedInvokeCallback ( IAsyncResult ar ) {
            InfoReceived?.EndInvoke(ar);
        }

        private void DataReceivedInvokeCallback ( IAsyncResult ar ) {
            DataReceived?.EndInvoke(ar);
        }

        private void ValidPortFoundInvokeCallback ( IAsyncResult ar ) {
            ValidPortFound?.EndInvoke(ar);
        }

        private int errorCount = 0;

        private void ProcessData ( byte [] buffer, int size ) {
            byte [] tempBuffer = new byte [size];
            Buffer.BlockCopy(buffer, 0, tempBuffer, 0, size);
            if (tempBuffer [size - 1] != 0xFF) {
                Console.WriteLine("Error");
                errorCount++;
                return;
            }
            string data = string.Format("{0} ", size);
            for (int i = 0; i < size; i++) {
                data += string.Format("{0:X2} ", tempBuffer [i]);
            }
            data += string.Format("{0}\n", errorCount);
            DataReceived?.BeginInvoke(data, DataReceivedInvokeCallback, null);
        }

        public bool Close ( ) {
            try {
                if (serial.IsOpen) {
                    serial.Close();
                    PrintInfo(serial.PortName + " closed!");
                }
                else
                    PrintWarning(serial.PortName + " is not opened yet!");
            }
            catch (Exception exception) {
                PrintError(exception.ToString());
                return false;
            }
            return true;
        }

        public bool Open ( ) {
            //Console.WriteLine(Millis.Millis());
            try {
                if (!serial.IsOpen) {
                    serial.Open();
                    PrintInfo(serial.PortName + " opened successfully!");
                }
                else
                    PrintWarning(serial.PortName + " is already opened!");
            }
            catch (Exception exception) {
                PrintError(exception.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// for singleton uses, which shares the same instance between classes/forms
        /// </summary>
        /// <returns></returns>
        public static SerialCommunication Instance { get; } = new SerialCommunication();
    }
}
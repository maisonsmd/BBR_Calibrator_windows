using BBR_Calibrator.MathHelpers;

using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Threading;

namespace BBR_Calibrator
//TODO:
//Add "Destination" and "ContentType" bytes
{
    public enum ConnectionState
    {
        Connected,
        Disconnected
    }

    public class SerialCommunication
    {
        private const string TAG = "SerialCommunication";
        private const int PackageLength = 30;
        private static readonly byte[] BeginBytes = { 0xAA, 0xCD };
        private static readonly byte[] EndBytes = { 0xBB, 0xFA };
        private static readonly byte[] InBuffer = new byte[PackageLength];
        private static readonly byte[] OutBuffer = new byte[PackageLength];

        private static readonly byte[] ConnectionQueryBytes = { 0xAA, 0xBB };
        private static readonly byte[] ConnectionQueryResponseBytes = { 0xCC, 0xDD };

        private ConnectionState currentConnectionState;

        private SerialPort serial;

        public delegate void OnConnectionChangedHandler(string portName, ConnectionState connectionState);

        public delegate void OnDataReceivedHandler(string portName, byte[] data);

        public delegate void OnDataSentHandler(string portName, byte[] data);

        public delegate void OnInfoReceivedHandler(string tag, string text, EventType eventType);

        public event OnDataReceivedHandler DataReceived;

        public event OnDataSentHandler DataSent;

        public event OnInfoReceivedHandler InfoReceived;

        public event OnConnectionChangedHandler ConnectionStateChanged;

        private ConnectionState CurrentConnectionState {
            get { return currentConnectionState; }
            set {
                if (value != currentConnectionState)
                {
                    currentConnectionState = value;
                    ConnectionStateChanged?.BeginInvoke(serial.PortName, currentConnectionState, ConnectionStateChangedInvokeCallback, null);
                }
            }
        }

        private bool IsFindingPort = false;

        private SerialCommunication()
        {
            serial = new SerialPort
            {
                BaudRate = 115200,
                RtsEnable = true,
                DtrEnable = true,
                ReadTimeout = 3
            };
            //serial.DataReceived += Serial_DataReceived;
            currentConnectionState = ConnectionState.Disconnected;
        }

        private void PrintInfo(string format, params object[] args)
        {
            InfoReceived?.BeginInvoke(TAG, string.Format(format, args), EventType.Info, InfoReceivedInvokeCallback, null);
        }

        private void PrintWarning(string format, params object[] args)
        {
            InfoReceived?.BeginInvoke(TAG, string.Format(format, args), EventType.Warning, InfoReceivedInvokeCallback, null);
        }

        private void PrintError(string format, params object[] args)
        {
            InfoReceived?.BeginInvoke(TAG, string.Format(format, args), EventType.Error, InfoReceivedInvokeCallback, null);
        }

        private void WriteRaw(SerialPort port, byte[] src, int srcOffset, int count)
        {
            if (!port.IsOpen)
                return;
            try
            {
                port.BaseStream.Write(src, srcOffset, count);
                byte[] sent = new byte[count];
                Buffer.BlockCopy(src, srcOffset, sent, 0, count);
                DataSent?.BeginInvoke(port.PortName, sent, DataSentInvokeCallback, null);
            }
            catch (Exception exception)
            {
                PrintError(exception.ToString());
                Close();
                PrintInfo($"{serial.PortName} closed!");
            }
        }

        public bool IsOpen {
            get { return serial.IsOpen; }
        }

        public bool FindPort()
        {
            if (IsFindingPort)
            {
                PrintWarning("requested to find ports, but busy!");
                return false;
            }

            IsFindingPort = true;

            string[] portNames = SerialPort.GetPortNames();

            if (portNames.Length != 0)
            {
                string allPorts = "";
                foreach (string s in portNames)
                    allPorts += s + ", ";

                PrintInfo($"available ports: {allPorts}");

                int totalWorks = portNames.Length;
                int completedWorks = 0;
                bool isValidPortFound = false;

                foreach (string portName in portNames)
                {
                    SerialPort currentPort = new SerialPort
                    {
                        BaudRate = serial.BaudRate,
                        DtrEnable = serial.DtrEnable,
                        ReadTimeout = 3,
                        PortName = portName
                    };

                    BackgroundWorker backgroundWorker = new BackgroundWorker();

                    backgroundWorker.DoWork += new DoWorkEventHandler(delegate (object o, DoWorkEventArgs e)
                    {
                        e.Result = TryOpen(currentPort);
                    });

                    backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                        delegate (object o, RunWorkerCompletedEventArgs e)
                        {
                            completedWorks++;
                            if ((bool)e.Result == true)
                            {
                                serial = currentPort;
                                isValidPortFound = true;
                            }
                            if (completedWorks != totalWorks)
                                return;

                            IsFindingPort = false;
                            if (isValidPortFound)
                            {
                                CurrentConnectionState = ConnectionState.Connected;
                                serial.DataReceived += Serial_DataReceived;
                            }
                            else
                            {
                                PrintWarning("no valid port found!");
                            }
                        });
                    backgroundWorker.RunWorkerAsync();
                }
            }
            else
            {
                PrintInfo("no available port");
                IsFindingPort = false;
            }

            return true;
        }

        public void TestRequest()
        {
            byte[] CmdRead = { 0xFA, 0x01 };
            Buffer.BlockCopy(CmdRead, 0, OutBuffer, 0, CmdRead.Length);
            WriteRaw(serial, OutBuffer, 0, PackageLength);
        }

        /// <summary>
        /// try opening and validating a port
        /// </summary>
        /// <param name="port">the port to try</param>
        /// <returns>if the port is valid</returns>
        private bool TryOpen(SerialPort port)
        {
            PrintInfo($"trying connecting to: {port.PortName}");

            try
            {
                port.Open();
            }
            catch
            {
                PrintWarning($"cannot open {port.PortName}");
                return false;
            }

            //arduino AVR usually resets in 2s when COM port opened, STM USBSerial doesn't
            ulong startMillis = TimeCounter.Millis();

            Thread.Sleep(200);
            Buffer.BlockCopy(ConnectionQueryBytes, 0, OutBuffer, 0, ConnectionQueryBytes.Length);

            WriteRaw(port, OutBuffer, 0, ConnectionQueryBytes.Length);

            startMillis = TimeCounter.Millis();

            while (TimeCounter.Millis() - startMillis < 1000)
            {
                if (port.BytesToRead != 0)
                    break;
            }
            //wait for the rest of data
            Thread.Sleep(10);

            if (port.BytesToRead == 0)
                PrintWarning($"{port.PortName} not responding");

            else if (port.BytesToRead == ConnectionQueryResponseBytes.Length)
            {
                byte[] response = new byte[ConnectionQueryResponseBytes.Length];
                port.BaseStream.Read(response, 0, ConnectionQueryResponseBytes.Length);

                if (Compare(response, 0, ConnectionQueryResponseBytes, 0, ConnectionQueryResponseBytes.Length))
                {
                    PrintInfo($"{port.PortName} is OK, use it!");
                    return true;
                }
                else
                {
                    PrintWarning($"{port.PortName}: invalid response [0x{response[0]:X2} 0x{response[1]:X2}]");
                }
            }
            else
            {
                PrintWarning($"{port.PortName}: invalid response [{port.BytesToRead} byte]");
            }
            port.Close();
            return false;
        }

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serial.BytesToRead < 1)
            {
                return;
            }

            int index = 0;
            try
            {
                while (index < PackageLength && serial.IsOpen)
                {
                    InBuffer[index++] = (byte)serial.ReadByte();
                }
                ProcessData();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                PrintError(exception.ToString());
                //ErrorOccurred?.BeginInvoke("Exception caused the SerialPort to close!", ErrorOccurredInvokeCallback, null);
                return;
            }
        }

        private void InfoReceivedInvokeCallback(IAsyncResult ar)
        {
            try
            {
                InfoReceived?.EndInvoke(ar);
            }
            catch {
                //"can not access disposed object: FrmMain"
            }
        }

        private void DataReceivedInvokeCallback(IAsyncResult ar)
        {
            try
            {
                DataReceived?.EndInvoke(ar);
            }
            catch
            {

            }
        }

        private void DataSentInvokeCallback(IAsyncResult ar)
        {
            try
            {
                DataSent?.EndInvoke(ar);
            }
            catch
            {

            }
        }

        private void ConnectionStateChangedInvokeCallback(IAsyncResult ar)
        {
            try
            {
                ConnectionStateChanged?.EndInvoke(ar);
            }
            catch { }
        }

        private void ProcessData()
        {
            if (!Compare(InBuffer, 0, BeginBytes, 0, BeginBytes.Length))
            {
                PrintError("data heading mismatch");
                return;
            }
            if (!Compare(InBuffer, PackageLength - EndBytes.Length, EndBytes, 0, EndBytes.Length))
            {
                PrintError("data ending mismatch");
                return;
            }
            if (!Checksum())
            {
                PrintError("Checksum error");
            }

            byte[] dataPiece = new byte[PackageLength - BeginBytes.Length - EndBytes.Length - 2];
            Buffer.BlockCopy(InBuffer, 0 + BeginBytes.Length, dataPiece, 0, dataPiece.Length);
            DataReceived?.BeginInvoke(serial.PortName, dataPiece, DataReceivedInvokeCallback, null);
        }

        private bool Checksum()
        {
            UInt16 sumCalulated = 0;
            int dataStartIndex = 0 + BeginBytes.Length;
            int dataEndIndex = PackageLength - EndBytes.Length - sizeof(UInt16);

            for (int i = dataStartIndex; i < dataEndIndex; i++)
                sumCalulated += (UInt16)InBuffer[i];

            byte[] checksumBytes = new byte[sizeof(UInt16)];
            Buffer.BlockCopy(InBuffer, dataEndIndex, checksumBytes, 0, sizeof(UInt16));

            UInt16 sumReceived = (UInt16)BitConverter.ToInt16(checksumBytes, 0);
            return sumCalulated.Equals(sumReceived);
        }

        /// <summary>
        /// compare 2 arrays
        /// </summary>
        /// <param name="src">source array</param>
        /// <param name="srcOffset">source offset</param>
        /// <param name="dst">destination array</param>
        /// <param name="dstOffset">destination offset</param>
        /// <param name="count">number of bytes to compare</param>
        /// <returns></returns>
        private bool Compare(byte[] src, int srcOffset, byte[] dst, int dstOffset, int count)
        {
            if (srcOffset + count > src.Length)
                return false;
            if (dstOffset + count > dst.Length)
                return false;

            for (int i = 0; i < count; i++)
            {
                if (src[srcOffset + i] != dst[dstOffset + i])
                    return false;
            }
            return true;
        }

        public bool Close()
        {
            CurrentConnectionState = ConnectionState.Disconnected;
            try
            {
                if (serial.IsOpen)
                {
                    serial.Close();
                    PrintInfo($"{serial.PortName} closed!");
                }
                else
                {
                    PrintWarning($"{serial.PortName} is not opened yet!");
                    return true;
                }
            }
            catch (Exception exception)
            {
                PrintError(exception.ToString());
                return false;
            }
            return true;
        }

        public bool Open()
        {
            try
            {
                if (!serial.IsOpen)
                {
                    serial.Open();
                    PrintInfo($"{serial.PortName} opened successfully!");
                    CurrentConnectionState = ConnectionState.Connected;
                }
                else
                    PrintWarning($"{serial.PortName} is already opened!");
            }
            catch (Exception exception)
            {
                CurrentConnectionState = ConnectionState.Disconnected;
                PrintError(exception.ToString());
                return false;
            }
            return true;
        }

        public static SerialCommunication Instance { get; } = new SerialCommunication();
    }
}
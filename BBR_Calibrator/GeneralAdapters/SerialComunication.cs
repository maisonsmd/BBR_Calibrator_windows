using System;
using System.IO.Ports;

namespace GeneralAdapters {

    public class SerialComunication {
        private SerialPort serial;

        public delegate void OnDataReceivedHandler ( string data );

        public delegate void OnErrorOccurredHandler ( string errorString );

        public event OnDataReceivedHandler DataReceived;

        public event OnErrorOccurredHandler ErrorOccurred;

        /// <summary>
        /// create a new instance
        /// </summary>
        private SerialComunication ( ) {
            serial = new SerialPort();
            serial.BaudRate = int.Parse(Resources.GeneralAdaptersResources.SerialPortBaud);
            serial.RtsEnable = true;
            serial.DtrEnable = true;
            serial.PortName = "COM9";
            serial.ReadTimeout = 3;
            serial.DataReceived += Serial_DataReceived;
            serial.Open();
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
                ErrorOccurred?.BeginInvoke(exception.ToString(), ErrorOccurredInvokeCallback, null);
                //ErrorOccurred?.BeginInvoke("Exception caused the SerialPort to close!", ErrorOccurredInvokeCallback, null);
                return;
            }
        }

        private void ErrorOccurredInvokeCallback ( IAsyncResult ar ) {
            ErrorOccurred?.EndInvoke(ar);
        }

        private void DataReceivedInvokeCallback ( IAsyncResult ar ) {
            DataReceived?.EndInvoke(ar);
        }

        private int errorCount = 0;

        private void ProcessData ( byte [] buffer, int size ) {
            byte [] tempBuffer = new byte [size];
            Buffer.BlockCopy(buffer, 0, tempBuffer, 0, size);
            if (tempBuffer [size - 1] != 0xFF) {
                //Console.WriteLine("Error");
                errorCount++;
                return;
            }
            string data = string.Format("{0} ", size);
            for (int i = 0; i < size; i++) {
                if (tempBuffer [i] < 0x10)
                    data += string.Format("0{0:X} ", tempBuffer [i]);
                else
                    data += string.Format("{0:X} ", tempBuffer [i]);
            }
            data += string.Format("{0}\n", errorCount);
            DataReceived?.BeginInvoke(data, DataReceivedInvokeCallback, null);
        }

        public void Close ( ) {
            if (serial.IsOpen)
                serial.Close();
        }

        public void Open ( ) {
            if (!serial.IsOpen)
                serial.Open();
        }

        /// <summary>
        /// for singleton uses, which shares the same instance between classes/forms
        /// </summary>
        /// <returns></returns>
        public static SerialComunication Instance { get; } = new SerialComunication();
    }
}
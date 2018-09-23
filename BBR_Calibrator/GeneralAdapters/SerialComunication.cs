using System;
using System.IO.Ports;
using System.Threading;

namespace GeneralAdapters {

    public class SerialComunication {
        private SerialPort serial;

        public delegate void OnDataReceivedHandler ( string myString );

        private OnDataReceivedHandler OnDataReceived;

        public event OnDataReceivedHandler DataReceived;

        /// <summary>
        /// create a new instance
        /// </summary>
        private SerialComunication ( ) {
            serial = new SerialPort();
            OnDataReceived = new OnDataReceivedHandler(ProcessData);
            //OnDataReceived = new OnDataReceivedHandler(DumpCallback);

            serial.BaudRate = int.Parse(Resources.GlobalResources.SerialPortBaud);
            serial.RtsEnable = true;
            serial.DtrEnable = true;
            serial.PortName = "COM9";
            serial.DataReceived += Serial_DataReceived;
            serial.Open();
        }
        
        private void Serial_DataReceived ( object sender, SerialDataReceivedEventArgs e ) {
            //syncronous call
            //OnDataReceived?.Invoke(serial.ReadLine());
            //asyncronous call
            OnDataReceived?.BeginInvoke(serial.ReadLine(), HandlerResult, null);
        }

        private void HandlerResult ( IAsyncResult ar ) {
            Console.Write("result: ");
            Console.WriteLine(ar.IsCompleted);
        }

        private void ProcessData ( string data ) {
            Console.Write("\ndata: ");
            Thread.Sleep(500);
            Console.WriteLine(data);
            DataReceived?.BeginInvoke(data, HandlerResult, null);
        }

        /// <summary>
        /// for singleton uses, which shares the same instance between classes/forms
        /// </summary>
        /// <returns></returns>
        public static SerialComunication Instance { get; } = new SerialComunication();
    }
}
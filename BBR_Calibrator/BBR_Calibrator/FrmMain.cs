using MaterialSkin;
using MaterialSkin.Controls;

using System;
using System.Drawing;

namespace BBR_Calibrator
{
    internal enum SerialDestinations : byte
    {
        IMU,
        ServoA,
        ServoB,
        ServoC,
        General
    }

    public partial class FrmMain : MaterialForm
    {
        private const string TAG = "Main";
        private readonly MaterialSkinManager MaterialSkinManager;
        private SerialCommunication Serial;

        public LoggerClass Logger;
        public IMUClass IMU;

        public FrmMain()
        {
            InitializeComponent();
            Logger = new LoggerClass(this);
            IMU = new IMUClass(this);
            IMU.HeadingChanged += IMU_HeadingChanged;

            MaterialSkinManager = MaterialSkinManager.Instance;
            MaterialSkinManager.AddFormToManage(this);
            MaterialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            ForeColor = Color.White;
            //MaterialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.Red100, TextShade.WHITE);
            MaterialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            Serial = SerialCommunication.Instance;
            Serial.DataReceived += Serial_DataReceived;
            Serial.InfoReceived += Serial_InfoReceived;
            Serial.ConnectionStateChanged += Serial_ConnectionChanged;
            Serial.DataSent += Serial_DataSent;

            Logger.PrintLogo();
            Logger.LogEvent(TAG, "Program started!", EventType.Info);

            Size = new System.Drawing.Size(1000, 600);

            TextViewDataOut.Location = TextViewEvents.Location;
            TextViewDataIn.Location = TextViewEvents.Location;
            TextViewDataOut.Size = TextViewEvents.Size;
            TextViewDataIn.Size = TextViewEvents.Size;
            BtnClearDataIn.Location = BtnClearEvents.Location;
            BtnClearDataOut.Location = BtnClearEvents.Location;
            CheckBoxEnableDataOutLogging.Location = CheckBoxEnableDataInLogging.Location;

            CheckBoxEnableDataOutLogging.Checked = true;
            CheckBoxEnableDataInLogging.Checked = true;

            RadioBoxDarkTheme.Select();
        }

        private void Serial_DataSent(string portName, byte[] data)
        {
            if (CheckBoxEnableDataOutLogging.Checked)
            {
                Invoke(new EventHandler(delegate { Logger.LogDataOut(portName, data); }));
            }
        }

        private void IMU_HeadingChanged(double angle)
        {
            Invoke(new EventHandler(delegate { LblHeading.Text = angle.ToString("0.00"); }));
        }

        private void Serial_ConnectionChanged(string portName, ConnectionState connectionState)
        {
            if (connectionState == ConnectionState.Connected)
                Invoke(new EventHandler(delegate { BtnConnect.Text = $"Disconnect ({portName}"; }));
            else
                Invoke(new EventHandler(delegate { BtnConnect.Text = "Connect"; }));
        }

        private void Serial_InfoReceived(string tag, string infoString, EventType eventType)
        {
            Invoke(new EventHandler(delegate { Logger.LogEvent(tag, infoString, eventType); }));
        }

        private void Serial_DataReceived(string portName, byte[] data)
        {
            IMU.Interpret(data);
            if (CheckBoxEnableDataInLogging.Checked)
            {
                Invoke(new EventHandler(delegate { Logger.LogDataIn(portName, data); }));
            }
        }

        private void SerialComunication_ErrorOccurred(string tag, string data)
        {
            Invoke(new EventHandler(delegate { Logger.LogEvent(tag, data, EventType.Error); }));
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            Serial.FindPort();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (Serial.IsOpen)
            {
                Serial.Close();
            }
            else
            {
                Serial.FindPort();
            }
        }

        private void BtnRequest_Click(object sender, EventArgs e)
        {
            Serial.TestRequest();
        }

        private void BtnClearEvents_Click(object sender, EventArgs e)
        {
            Logger.ClearEvents();
        }

        private void BtnClearDataIn_Click(object sender, EventArgs e)
        {
            Logger.ClearDataIn();
        }

        private void BtnClearIMU_Click(object sender, EventArgs e)
        {
            IMU.Clear();
        }

        private void BtnStartIMU_Click(object sender, EventArgs e)
        {
            TimerRequestIMU.Enabled = true;
            TimerRequestIMU.Start();
        }

        private void BtnStopIMU_Click(object sender, EventArgs e)
        {
            TimerRequestIMU.Stop();
        }

        private void TimerRequestIMU_Tick(object sender, EventArgs e)
        {
            Serial.TestRequest();
        }

        private void CheckBoxScaled_CheckedChanged(object sender, EventArgs e)
        {
            IMU.DisplayScaled(CheckBoxScaled.Checked);
        }

        private void BtnClearScale_Click(object sender, EventArgs e)
        {
            IMU.ClearScale();
        }

        private void RadioBoxLightTheme_CheckedChanged(object sender, EventArgs e)
        {
            //TODO:
            //Update labels color
            if (RadioBoxLightTheme.Checked)
            {
                MaterialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                ForeColor = Color.Black;
            }
            else
            {
                MaterialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                ForeColor = Color.White;
            }
        }

        private void BtnClearDataOut_Click(object sender, EventArgs e)
        {
            Logger.ClearDataOut();
        }

        private void FrmMain_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (Serial.IsOpen)
                Serial.Close();
        }
    }
}
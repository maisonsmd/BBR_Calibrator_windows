using System;
using System.Windows.Forms;

using MaterialSkin;
using MaterialSkin.Controls;

namespace BBR_Calibrator {

    public partial class FrmMain : MaterialForm {
        private const string TAG = "Main";
        private readonly MaterialSkinManager MaterialSkinManager;
        private SerialCommunication Serial;

        public LoggerClass Logger;
        public IMUClass IMU;

        public FrmMain ( ) {
            InitializeComponent();
            Logger = new LoggerClass(this);
            IMU = new IMUClass(this);
            IMU.HeadingChanged += IMU_HeadingChanged;

            MaterialSkinManager = MaterialSkinManager.Instance;
            MaterialSkinManager.AddFormToManage(this);
            MaterialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            MaterialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.Red100, TextShade.WHITE);

            Serial = SerialCommunication.Instance;
            Serial.DataReceived += Serial_DataReceived;
            Serial.InfoReceived += Serial_InfoReceived;
            Serial.ValidPortFound += Serial_ValidPortFound;

            Logger.PrintLogo();
            Logger.LogEvent(TAG, "Program started!", LoggerClass.EventType.Info);

            Size = new System.Drawing.Size(1000, 600);
        }

        private void IMU_HeadingChanged ( double angle ) {
            Invoke(new EventHandler(delegate { LblHeading.Text = angle.ToString("0.00"); }));
        }

        private void Serial_ValidPortFound ( string portName ) {
            Invoke(new EventHandler(delegate{ BtnConnect.Text = "Disconnect (" + portName + ")"; }));
        }

        private void Serial_InfoReceived ( string tag, string infoString , LoggerClass.EventType eventType) {
            Invoke(new EventHandler(delegate { Logger.LogEvent(tag, infoString, eventType); }));
        }

        private void FlipLightTheme ( ) {
            MaterialSkinManager.Theme = MaterialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
        }

        private void Serial_DataReceived ( byte[] data ) {

            IMU.Interpret(data);
            if (CheckBoxEnableDataInLogging.Checked) {
                string dataString = "";
                for (int i = 0; i < data.Length; i++) {
                    dataString += string.Format("{0:X2} ", data [i]);
                }
                Invoke(new EventHandler(delegate { Logger.LogDataIn(dataString); }));
            }
        }

        private void SerialComunication_ErrorOccurred ( string tag, string data ) {
            Invoke(new EventHandler(delegate { Logger.LogEvent(tag, data, LoggerClass.EventType.Error); }));
        }

        private int colorSchemeIndex;

        private void ChangeTheme ( ) {
            colorSchemeIndex++;
            if (colorSchemeIndex > 2)
                colorSchemeIndex = 0;

            //These are just example color schemes
            switch (colorSchemeIndex) {
                case 0:
                    MaterialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
                    break;

                case 1:
                    MaterialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
                    break;

                case 2:
                    MaterialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.Red100, TextShade.WHITE);
                    break;
            }
        }

        private void MaterialFlatButton1_Click ( object sender, EventArgs e ) {
        }

        private void FrmMain_Load ( object sender, EventArgs e ) {
            Serial.FindPort();
        }

        private void BtnConnect_Click ( object sender, EventArgs e ) {
            if (Serial.IsOpen) {
                Serial.Close();
                BtnConnect.Text = "Connect";
            }
            else {
                Serial.FindPort();
            }
        }

        private void BtnRequest_Click ( object sender, EventArgs e ) {
            Serial.Request();
        }

        private void BtnClearEvents_Click ( object sender, EventArgs e ) {
            Logger.ClearEvents();
        }

        private void BtnClearDataIn_Click ( object sender, EventArgs e ) {
            Logger.ClearDataIn();
        }

        private void BtnClearIMU_Click ( object sender, EventArgs e ) {
            IMU.Clear();
        }

        private void BtnStartIMU_Click ( object sender, EventArgs e ) {
            TimerRequestIMU.Enabled = true;
            TimerRequestIMU.Start();
        }

        private void BtnStopIMU_Click ( object sender, EventArgs e ) {
            TimerRequestIMU.Stop();
        }

        private void TimerRequestIMU_Tick ( object sender, EventArgs e ) {
            Serial.Request();
        }

        private void CheckBoxScaled_CheckedChanged ( object sender, EventArgs e ) {
            IMU.DisplayScaled(CheckBoxScaled.Checked);
        }

        private void BtnClearScale_Click ( object sender, EventArgs e ) {
            IMU.ClearScale();
        }
    }
}
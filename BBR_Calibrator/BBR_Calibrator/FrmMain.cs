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
            IMU.Randomize();

            Size = new System.Drawing.Size(1000, 600);
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

        private void Serial_DataReceived ( string data ) {
            if (CheckBoxEnableDataInLogging.Checked)
                Invoke(new EventHandler(delegate { Logger.LogDataIn(data); }));
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
    }
}
using System;
using System.Drawing;

using GeneralAdapters;

using MaterialSkin;
using MaterialSkin.Controls;

namespace BBR_Calibrator {

    public partial class FrmMain : MaterialForm {

        public enum EventType {
            Info,
            Warning,
            Error
        };

        private readonly MaterialSkinManager MaterialSkinManager;
        private SerialComunication SerialComunication;
        //private SerialComunication.OnDataReceivedHandler OnDataReceivedDelegate;
        //private SerialComunication.OnErrorOccurredHandler OnErrorOccurredDelegate;

        public FrmMain ( ) {
            InitializeComponent();

            MaterialSkinManager = MaterialSkinManager.Instance;
            MaterialSkinManager.AddFormToManage(this);
            MaterialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            MaterialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.Red100, TextShade.WHITE);

            //OnDataReceivedDelegate = WriteLogData;
            //OnErrorOccurredDelegate = WriteEvent;

            SerialComunication = SerialComunication.Instance;
            SerialComunication.DataReceived += OnSerialDataReceived;
            SerialComunication.ErrorOccurred += OnSerialErrorOccurred;

            WriteEvent("Program started!", EventType.Info);
        }

        private void flipLightTheme ( object sender, EventArgs e ) {
            MaterialSkinManager.Theme = MaterialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
        }

        private void OnSerialDataReceived ( string data ) {
            if (CheckBoxEnableLogging.Checked)
                Invoke(new EventHandler(delegate { WriteLogData(data); }));
            //OnDataReceivedDelegate?.BeginInvoke(data, SerialDataReceivedInvokeCallback, null);
        }

        private void OnSerialErrorOccurred ( string data ) {
            Invoke(new EventHandler(delegate { WriteEvent(data, EventType.Error); }));
            //BeginInvoke(new EventHandler(delegate { WriteEvent(data, "error"); }), null);
            //OnErrorOccurredDelegate?.BeginInvoke(data, eventType, SerialErrorOccurredInvokeCallback, null);
            //Invoke(WriteEvent, data, eventType);
        }

        //private void SerialDataReceivedInvokeCallback ( IAsyncResult ar ) {
        //    OnDataReceivedDelegate?.EndInvoke(ar);
        //}

        //private void SerialErrorOccurredInvokeCallback ( IAsyncResult ar ) {
        //    OnErrorOccurredDelegate?.EndInvoke(ar);
        //}

        private void WriteLogData ( string text ) {
            int maxLines = int.Parse(Resources.MainResources.MaxLogDataLines);

            if (TextViewLogData.Lines.Length > maxLines) {
                TextViewLogData.Select(0, TextViewLogData.GetFirstCharIndexFromLine(1));
                TextViewLogData.SelectedText = string.Empty;
            }

            TextViewLogData.AppendText(text);
            TextViewLogData.SelectionStart = TextViewLogData.Text.Length;
            TextViewLogData.ScrollToCaret();
        }

        private void WriteEvent ( string text, EventType eventType ) {
            int maxLines = int.Parse(Resources.MainResources.MaxLogEventLines);
            string time = DateTime.Now.ToString("[HH:mm:ss.fff] ");
            if (TextViewEvents.Lines.Length > maxLines) {
                //2: include new 2 new line character
                TextViewEvents.Select(0, TextViewEvents.GetFirstCharIndexFromLine(2));
                TextViewEvents.SelectedText = string.Empty;
            }
            Color textColor = Color.White;
            switch (eventType) {
                case EventType.Info:
                    textColor = Color.White;
                    break;

                case EventType.Warning:
                    textColor = Color.Yellow;
                    break;

                case EventType.Error:
                    textColor = Color.Red;
                    break;
            }

            if (text.EndsWith("\n"))
                text += "\n";
            else
                text += "\n\n";

            int selectionStartIndex = TextViewEvents.Text.Length;
            TextViewEvents.AppendText(time);
            int selectionEndIndex = TextViewEvents.Text.Length;
            TextViewEvents.Select(selectionStartIndex, selectionEndIndex);
            TextViewEvents.SelectionColor = Color.Orange;

            selectionStartIndex = TextViewEvents.Text.Length;
            TextViewEvents.AppendText(text);
            selectionEndIndex = TextViewEvents.Text.Length;

            TextViewEvents.Select(selectionStartIndex, selectionEndIndex);
            TextViewEvents.SelectionColor = textColor;

            TextViewEvents.SelectionStart = TextViewEvents.Text.Length;
            TextViewEvents.ScrollToCaret();
        }

        private int colorSchemeIndex;

        private void changeTheme ( object sender, EventArgs e ) {
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

        private void materialFlatButton1_Click ( object sender, EventArgs e ) {
            TextViewLogData.Select(0, TextViewLogData.GetFirstCharIndexFromLine(1)); // select the first line
            TextViewLogData.SelectedText = "";
        }

        private void FrmMain_Load ( object sender, EventArgs e ) {
        }

        private void btnClosePort_Click ( object sender, EventArgs e ) {
            SerialComunication.Instance.Close();
            WriteEvent("Serial port closed", EventType.Info);
        }

        private void btnOpenPort_Click ( object sender, EventArgs e ) {
            SerialComunication.Instance.Open();
            WriteEvent("Serial port opened", EventType.Info);
        }
    }
}
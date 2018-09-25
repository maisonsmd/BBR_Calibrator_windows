using System;
using System.Drawing;
using System.Windows.Forms;

using ExtensionMethods;

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

            PrintLogoToEventTextView();
            WriteEvent("Program started!", EventType.Info);
        }

        private void PrintLogoToEventTextView ( ) {
            Bitmap logo = new Bitmap(Properties.Resources.msIcon);
            // Copy the bitmap to the clipboard.
            Clipboard.SetDataObject(logo);
            DataFormats.Format format = DataFormats.GetFormat(DataFormats.Bitmap);
            // After verifying that the data can be pasted, paste
            if (true || TextViewEvents.CanPaste(format)) {
                TextViewEvents.AppendText("\n ");
                TextViewEvents.Paste(format);
                TextViewEvents.AppendText("\n\n");
            }
        }

        private void FlipLightTheme ( object sender, EventArgs e ) {
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

            TextViewLogData.LimitLines(maxLines);

            TextViewLogData.AppendText(text);
            TextViewLogData.SelectionStart = TextViewLogData.Text.Length;
            TextViewLogData.ScrollToCaret();
        }

        private void WriteEvent ( string text, EventType eventType ) {
            int maxLines = int.Parse(Resources.MainResources.MaxLogEventLines);
            string time = DateTime.Now.ToString("[HH:mm:ss.fff] ");

            TextViewEvents.LimitLines(maxLines);

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
            //to make sure there is an one-line spacer
            if (text.EndsWith("\n"))
                text += "\n";
            else
                text += "\n\n";

            TextViewEvents.AppendTextWithHightlight(time, Color.Orange);
            TextViewEvents.AppendTextWithHightlight(text, textColor);

            TextViewEvents.SelectionStart = TextViewEvents.Text.Length;
            TextViewEvents.ScrollToCaret();
        }

        private int colorSchemeIndex;

        private void ChangeTheme ( object sender, EventArgs e ) {
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
            TextViewLogData.Select(0, TextViewLogData.GetFirstCharIndexFromLine(1)); // select the first line
            TextViewLogData.SelectedText = "";
        }

        private void FrmMain_Load ( object sender, EventArgs e ) {
        }

        private void BtnClosePort_Click ( object sender, EventArgs e ) {
            SerialComunication.Instance.Close();
            WriteEvent("Serial port closed", EventType.Info);
        }

        private void BtnOpenPort_Click ( object sender, EventArgs e ) {
            SerialComunication.Instance.Open();
            WriteEvent("Serial port opened", EventType.Info);
        }
    }
}
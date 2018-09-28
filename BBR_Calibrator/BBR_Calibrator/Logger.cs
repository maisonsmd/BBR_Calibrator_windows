using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using ExtensionMethods;

namespace BBR_Calibrator {

    /// <summary>
    /// this class is used to 'pack' handler purpose only
    /// </summary>
    public class LoggerClass {

        public enum EventType {
            Info,
            Warning,
            Error
        };

        private RichTextBox TextViewEvents;
        private RichTextBox TextViewDataIn;
        private RichTextBox TextViewDataOut;
        private CheckBox CheckBoxEnableDataInLogging;
        private CheckBox CheckBoxEnableDataOutLogging;

        private List<string> DataInCache;
        private Timer TimerDataInUpdate;

        public LoggerClass ( FrmMain parent ) {
            TextViewDataIn = parent.TextViewData;
            TextViewDataOut = parent.TextViewDataOut;
            TextViewEvents = parent.TextViewEvents;
            CheckBoxEnableDataInLogging = parent.CheckBoxEnableDataInLogging;
            CheckBoxEnableDataOutLogging = parent.CheckBoxEnableDataOutLogging;

            DataInCache = new List<string>();
            TimerDataInUpdate = new Timer();
            TimerDataInUpdate.Interval = 100;
            TimerDataInUpdate.Tick += TimerDataInUpdate_Tick;
            TimerDataInUpdate.Stop();
        }

        private void TimerDataInUpdate_Tick ( object sender, EventArgs e ) {
            TimerDataInUpdate.Stop();
            if (DataInCache.Count == 0)
                return;
            int maxLines = int.Parse(Resources.MainResources.MaxLogDataLines);
            int startIndex = 0;

            if (DataInCache.Count >= maxLines) {
                TextViewDataIn.Clear();
                startIndex = DataInCache.Count - maxLines;
            }
            else
                TextViewDataIn.LimitLines(maxLines - DataInCache.Count);

            for (int i = startIndex; i < DataInCache.Count; i++) {
                LogDataInSilently(DataInCache [i]);
            }
            DataInCache.Clear();
            TextViewDataIn.LimitLines(maxLines);
            TextViewDataIn.ScrollToEnd();
        }

        public void LogEvent ( string tag, string text, EventType eventType ) {
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
                    textColor = Color.OrangeRed;
                    break;
            }
            //to make sure there is an one-line spacer
            /*if (text.EndsWith("\n"))
                text += "\n";
            else
                text += "\n\n";*/

            text += "\n";

            TextViewEvents.AppendTextWithHightlight(time, Color.Orange);
            TextViewEvents.AppendTextWithHightlight("[" + tag + "] ", Color.ForestGreen);
            TextViewEvents.AppendTextWithHightlight(text, textColor);

            TextViewEvents.ScrollToEnd();
        }

        internal void PrintLogo ( ) {
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

        public void LogDataIn ( string data ) {
            if (!CheckBoxEnableDataInLogging.Checked)
                return;
            DataInCache.Add(data);
            TimerDataInUpdate.Start();
        }

        public void ClearDataIn ( ) {
            TextViewDataIn.Clear();
        }

        public void ClearEvents ( ) {
            TextViewEvents.Clear();
        }

        private void LogDataInSilently ( string data ) {
            string time = DateTime.Now.ToString("[HH:mm:ss.fff] ");
            TextViewDataIn.AppendTextWithHightlight(time, Color.Orange);
            TextViewDataIn.AppendTextWithHightlight($"{data}\n", Color.White);
        }

        public void LogDataOut ( string data ) {
            int maxLines = int.Parse(Resources.MainResources.MaxLogDataLines);
            string time = DateTime.Now.ToString("[HH:mm:ss.fff] ");
            TextViewDataOut.AppendTextWithHightlight(time, Color.Orange);
            TextViewDataOut.AppendTextWithHightlight(data, Color.White);
            TextViewDataOut.LimitLines(maxLines);
            TextViewDataOut.ScrollToEnd();
        }
    }
}
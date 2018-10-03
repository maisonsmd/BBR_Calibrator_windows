using ExtensionMethods;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BBR_Calibrator
{
    public enum EventType
    {
        Info,
        Warning,
        Error
    };

    /// <summary>
    /// this class is used to 'pack' handler purpose only
    /// </summary>
    public class LoggerClass
    {
        private struct DataSet
        {
            public DateTime timestamp;
            public string portName;
            public byte[] data;

            public DataSet(DateTime timestamp, string portName, byte[] data) : this()
            {
                this.timestamp = timestamp;
                this.portName = portName;
                this.data = data;
            }
        }

        private RichTextBox TextViewEvents;
        private RichTextBox TextViewDataIn;
        private RichTextBox TextViewDataOut;
        private CheckBox CheckBoxEnableDataInLogging;
        private CheckBox CheckBoxEnableDataOutLogging;

        private List<DataSet> DataInCache;
        private Timer TimerDataInUpdate;

        public LoggerClass(FrmMain parent)
        {
            TextViewDataIn = parent.TextViewDataIn;
            TextViewDataOut = parent.TextViewDataOut;
            TextViewEvents = parent.TextViewEvents;
            CheckBoxEnableDataInLogging = parent.CheckBoxEnableDataInLogging;
            CheckBoxEnableDataOutLogging = parent.CheckBoxEnableDataOutLogging;

            DataInCache = new List<DataSet>();
            TimerDataInUpdate = new Timer();
            TimerDataInUpdate.Interval = 100;
            TimerDataInUpdate.Tick += TimerDataInUpdate_Tick;
            TimerDataInUpdate.Stop();
        }

        private void TimerDataInUpdate_Tick(object sender, EventArgs e)
        {
            TimerDataInUpdate.Stop();
            if (DataInCache.Count == 0)
                return;
            int maxLines = int.Parse(Resources.MainResources.MaxLogDataLines);
            int startIndex = 0;

            if (DataInCache.Count >= maxLines)
            {
                TextViewDataIn.Clear();
                startIndex = DataInCache.Count - maxLines;
            }
            else
                TextViewDataIn.LimitLines(maxLines - DataInCache.Count);

            for (int i = startIndex; i < DataInCache.Count; i++)
            {
                LogDataInSilently(DataInCache[i]);
            }
            DataInCache.Clear();
            TextViewDataIn.LimitLines(maxLines);
            TextViewDataIn.ScrollToEnd();
        }

        public void LogEvent(string tag, string text, EventType eventType)
        {
            int maxLines = int.Parse(Resources.MainResources.MaxLogEventLines);
            string time = DateTime.Now.ToString("[HH:mm:ss.fff] ");

            TextViewEvents.LimitLines(maxLines);

            Color textColor = Color.White;
            switch (eventType)
            {
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

        internal void PrintLogo()
        {
            Bitmap logo = new Bitmap(Properties.Resources.msIcon);
            // Copy the bitmap to the clipboard.
            Clipboard.SetDataObject(logo);
            DataFormats.Format format = DataFormats.GetFormat(DataFormats.Bitmap);
            // After verifying that the data can be pasted, paste
            if (true || TextViewEvents.CanPaste(format))
            {
                TextViewEvents.AppendText("\n ");
                TextViewEvents.Paste(format);
                TextViewEvents.AppendText("\n\n");
            }
        }

        public void LogDataIn(string portName, byte[] data)
        {
            if (!CheckBoxEnableDataInLogging.Checked)
                return;
            DataInCache.Add(new DataSet(DateTime.Now, portName, data));
            TimerDataInUpdate.Start();
        }

        public void ClearDataIn()
        {
            TextViewDataIn.Clear();
        }

        public void ClearDataOut()
        {
            TextViewDataOut.Clear();
        }

        public void ClearEvents()
        {
            TextViewEvents.Clear();
        }

        private void LogDataInSilently(DataSet data)
        {
            string time = data.timestamp.ToString("[HH:mm:ss.fff] ");
            string dataString = "";
            for (int i = 0; i < data.data.Length; i++)
            {
                dataString += string.Format("{0:X2} ", data.data[i]);
            }
            TextViewDataIn.AppendTextWithHightlight(time, Color.Orange);
            TextViewDataIn.AppendTextWithHightlight($"[{data.portName}] ", Color.ForestGreen);
            TextViewDataIn.AppendTextWithHightlight($"{dataString}\n", Color.White);
        }

        public void LogDataOut(string portName, byte[] data)
        {
            int maxLines = int.Parse(Resources.MainResources.MaxLogDataLines);
            string time = DateTime.Now.ToString("[HH:mm:ss.fff] ");
            //TextViewDataOut.AppendTextWithHightlight(time, Color.Orange);
            //TextViewDataOut.AppendTextWithHightlight($"[{portName}] ", Color.ForestGreen);
            //TextViewDataOut.AppendTextWithHightlight($"{data}\n", Color.White);
            //TextViewDataOut.LimitLines(maxLines);
            //TextViewDataOut.ScrollToEnd();


            string dataString = "";
            for (int i = 0; i < data.Length; i++)
            {
                dataString += string.Format("{0:X2} ", data[i]);
            }
            TextViewDataOut.AppendTextWithHightlight(time, Color.Orange);
            TextViewDataOut.AppendTextWithHightlight($"[{portName}] ", Color.ForestGreen);
            TextViewDataOut.AppendTextWithHightlight($"{dataString}\n", Color.White);
            TextViewDataOut.LimitLines(maxLines);
            TextViewDataOut.ScrollToEnd();
        }
    }
}
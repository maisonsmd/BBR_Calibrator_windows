using System.Drawing;
using System.Windows.Forms;

namespace ExtensionMethods {

    public static class MyExtensions {

        public static double Map ( this double x, double in_min, double in_max, double out_min, double out_max ) {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        public static double Constrain ( this double x, double min, double max ) {
            if (x < min)
                x = min;
            if (x > max)
                x = max;
            return x;
        }

        public static int Constrain ( this int x, int min, int max ) {
            if (x < min)
                x = min;
            if (x > max)
                x = max;
            return x;
        }

        public static bool IsInside ( this Point p, Rectangle rect ) {
            return ((p.X >= rect.X && p.X <= rect.X + rect.Width)
                && (p.Y >= rect.Y && p.Y <= rect.Y + rect.Height));
        }

        //lowercase method name to avoid confusing with existing string.Substring(startIndex, length) method
        public static string substring ( this string s, int startIndex, int endIndex ) {
            if (startIndex > endIndex)
                return string.Empty;

            if (endIndex > s.Length)
                return string.Empty;

            int length = endIndex - startIndex;
            return s.Substring(startIndex, length);
        }

        public static void AppendTextWithHightlight ( this RichTextBox richTextBox, string text, Color color ) {
            int selectionStartIndex = richTextBox.Text.Length;
            richTextBox.AppendText(text);
            int selectionEndIndex = richTextBox.Text.Length;
            richTextBox.Select(selectionStartIndex, selectionEndIndex - selectionStartIndex + 1);
            richTextBox.SelectionColor = color;
        }
        /// <summary>
        /// Remove upper lines if number of lines reached maximum
        /// </summary>
        /// <param name="richTextBox"></param>
        /// <param name="maxLines">max number of line</param>
        /// <returns>number of lines deleted</returns>
        public static int LimitLines(this RichTextBox richTextBox, int maxLines ) {
            if (richTextBox.Lines.Length < maxLines)
                return 0;
            int removedLines = 0;
            if (maxLines > 0 && richTextBox.Lines.Length > maxLines) {
                removedLines = richTextBox.Lines.Length - maxLines;
                richTextBox.Select(0, richTextBox.GetFirstCharIndexFromLine(removedLines));
                richTextBox.SelectedText = string.Empty;
            }
            return removedLines;
        }

        public static void ScrollToEnd(this RichTextBox richTextBox) {
            richTextBox.SelectionStart = richTextBox.Text.Length;
            richTextBox.ScrollToCaret();
        }
    }
}
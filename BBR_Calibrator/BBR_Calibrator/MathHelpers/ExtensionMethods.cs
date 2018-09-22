using System.Drawing;

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
    }
}
using System;

namespace BBR_Calibrator.MathHelpers {

    public static class TimeCounter {
        private static DateTime startTime = DateTime.Now;
        public static ulong Millis ( ) {
            return (ulong)Math.Max(0L, DateTime.Now.Subtract(startTime).TotalMilliseconds);
        }
    }
}
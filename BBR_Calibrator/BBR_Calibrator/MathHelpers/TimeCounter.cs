﻿using System;

namespace BBR_Calibrator.MathHelpers {

    public class TimeCounter {
        private static TimeCounter instance;
        private static DateTime startTime;
        public static TimeCounter Instance {
            get {
                if (instance == null) {
                    instance = new TimeCounter();
                    startTime = DateTime.Now;
                }
                return instance;
            }
        }
        
        public long Millis ( ) {
            return (long)Math.Max(0L, DateTime.Now.Subtract(startTime).TotalMilliseconds);
        }
    }
}
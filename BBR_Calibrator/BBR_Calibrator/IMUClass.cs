using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BBR_Calibrator.GraphicHelpers;

namespace BBR_Calibrator {

    /// <summary>
    /// this class is used to 'pack' handler purpose only
    /// </summary>
    public class IMUClass {

        public delegate void OnHeadingChanged ( double angle );
        public event OnHeadingChanged HeadingChanged;
        struct Values {
            public Int16 raw;
            public float scale;
            public Int16 offset;
            public Int16 min;
            public Int16 max;
        }
        Graph2D GraphXY;
        Graph2D GraphXZ;
        Graph2D GraphYZ;

        int MaxValueX;
        int MaxValueY;
        int MaxValueZ;

        bool IsScaled = false;

        Values X, Y, Z;

        public IMUClass ( FrmMain parent ) {
            GraphXY = parent.GraphXY;
            GraphXZ = parent.GraphXZ;
            GraphYZ = parent.GraphYZ;
        }

        public void Clear ( ) {
            GraphXY.Clear();
            GraphXZ.Clear();
            GraphYZ.Clear();

            int MaxValueX = 0;
            int MaxValueY = 0;
            int MaxValueZ = 0;

            GraphXY.AbsoluteMaxValue = Math.Max(MaxValueX, MaxValueY);
            GraphXZ.AbsoluteMaxValue = Math.Max(MaxValueX, MaxValueZ);
            GraphYZ.AbsoluteMaxValue = Math.Max(MaxValueY, MaxValueZ);
        }

        public void Interpret ( byte [] data ) {
            int currentIndex = 0;
            X.raw = BitConverter.ToInt16(data, currentIndex);
            currentIndex += sizeof(Int16);
            Y.raw = BitConverter.ToInt16(data, currentIndex);
            currentIndex += sizeof(Int16);
            Z.raw = BitConverter.ToInt16(data, currentIndex);
            currentIndex += sizeof(Int16);

            X.max = Math.Max(X.max, X.raw);
            Y.max = Math.Max(Y.max, Y.raw);
            Z.max = Math.Max(Z.max, Z.raw);

            X.min = Math.Min(X.min, X.raw);
            Y.min = Math.Min(Y.min, Y.raw);
            Z.min = Math.Min(Z.min, Z.raw);

            //offset XY
            Int16 centerX = (Int16)((X.max + X.min) / 2);
            Int16 centerY = (Int16)((Y.max + Y.min) / 2);
            Int16 centerZ = (Int16)((Z.max + Z.min) / 2);

            if (Math.Abs(X.raw) > MaxValueX)
                MaxValueX = Math.Abs(X.raw);
            if (Math.Abs(Y.raw) > MaxValueY)
                MaxValueY = Math.Abs(Y.raw);
            if (Math.Abs(Z.raw) > MaxValueZ)
                MaxValueZ = Math.Abs(Z.raw);

            GraphXY.AbsoluteMaxValue = Math.Max(MaxValueX, MaxValueY);
            GraphXZ.AbsoluteMaxValue = Math.Max(MaxValueX, MaxValueZ);
            GraphYZ.AbsoluteMaxValue = Math.Max(MaxValueY, MaxValueZ);

            X.raw = (Int16)( X.raw - centerX);
            Y.raw = (Int16)(Y.raw - centerY);
            if (IsScaled) {
                Console.WriteLine($"{centerX} {centerY}");
                GraphXY.AddPoint(X.raw, Y.raw);
                GraphXZ.AddPoint(X.raw, Z.raw);
                GraphYZ.AddPoint(Y.raw, Z.raw);
            }

            else {
                GraphXY.AddPoint(X.raw, Y.raw);
                GraphXZ.AddPoint(X.raw, Z.raw);
                GraphYZ.AddPoint(Y.raw, Z.raw);
            }

            double heading = Math.Atan2(Y.raw, X.raw) * 180.0 / Math.PI + 180.0;
            HeadingChanged?.Invoke(heading);
        }

        public void DisplayScaled ( bool isChecked ) {
            IsScaled = isChecked;
        }

        internal void ClearScale ( ) {
            X.min = 0;
            X.max = 0;
            X.scale = 1;
            X.offset = 0;

            Y.min = 0;
            Y.max = 0;
            Y.scale = 1;
            Y.offset = 0;

            Z.min = 0;
            Z.max = 0;
            Z.scale = 1;
            Z.offset = 0;
        }
    }
}

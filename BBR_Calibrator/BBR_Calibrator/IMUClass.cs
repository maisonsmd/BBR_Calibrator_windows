using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBR_Calibrator.GraphicHelpers;

namespace BBR_Calibrator {
    
    /// <summary>
    /// this class is used to 'pack' handler purpose only
    /// </summary>
    public class IMUClass {

        Graph2D GraphXY;
        Graph2D GraphXZ;
        Graph2D GraphYZ;
        public IMUClass ( FrmMain parent ) {
            GraphXY = parent.GraphXY;
            GraphXZ = parent.GraphXZ;
            GraphYZ = parent.GraphYZ;
        }

        public void Clear ( ) {
            GraphXY.Clear();
            GraphXZ.Clear();
            GraphYZ.Clear();
        }

        internal void Randomize ( ) {
            Random random = new Random();
            for (int i = 0; i < 10; i++) {
                GraphXY.AddPoint(random.Next(-100, 100), random.Next(-100, 100));
                GraphYZ.AddPoint(random.Next(-100, 100), random.Next(-100, 100));
                GraphXZ.AddPoint(random.Next(-100, 100), random.Next(-100, 100));
            }
        }
    }
}

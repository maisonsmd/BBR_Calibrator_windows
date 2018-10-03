using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

//using System.Linq;

using ExtensionMethods;

namespace BBR_Calibrator.GraphicHelpers
{

    internal struct PointValue
    {
        public double X;
        public double Y;
        public Rectangle Boundary;
    }

    public partial class Graph2D : UserControl
    {
        private String xAxisLabel;
        private String yAxisLabel;
        private Color pointColor;
        private Color gridColor;

        private List<PointValue> values;
        private Pen linePen;
        private Pen pointPen;
        private Brush pointBrush;
        private Brush textBrush;
        private double absoluteMaxValue;
        private int pointSize;

        public Graph2D()
        {
            InitializeComponent();

            values = new List<PointValue>();
            xAxisLabel = "X";
            yAxisLabel = "Y";
            pointColor = Color.Red;
            gridColor = Color.Gray;

            pointSize = 5;
            absoluteMaxValue = 1;

            linePen = new Pen(gridColor, 1);
            pointPen = new Pen(pointColor, 1);
            pointBrush = new SolidBrush(pointColor);
            textBrush = new SolidBrush(gridColor);
        }

        public void AddPoint(double xValue, double yValue)
        {
            int h = Size.Height;
            int w = Size.Width;
            PointValue newValue = new PointValue();
            newValue.X = xValue;
            newValue.Y = yValue;
            newValue.Boundary = new Rectangle((int)newValue.X.Map(-absoluteMaxValue * 1.2, absoluteMaxValue * 1.2, 0, w),
                                    (int)newValue.Y.Map(-absoluteMaxValue * 1.2, absoluteMaxValue * 1.2, h, 0), pointSize, pointSize);
            values.Add(newValue);
            Rectangle rectangle = newValue.Boundary;
            rectangle.Size = new Size(rectangle.Size.Width + 1, rectangle.Size.Height + 1);
            Invalidate(rectangle);
        }

        public void Clear()
        {
            values.Clear();
            Invalidate();
        }

        public double AbsoluteMaxValue {
            get {
                return absoluteMaxValue;
            }
            set {
                if (value != absoluteMaxValue)
                {
                    int h = Size.Height;
                    int w = Size.Width;
                    absoluteMaxValue = Math.Abs(value);

                    for (int i = 0; i < values.Count; i++)
                    {
                        PointValue pointValue = values[i];
                        pointValue.Boundary = new Rectangle((int)pointValue.X.Map(-absoluteMaxValue * 1.2, absoluteMaxValue * 1.2, 0, w),
                                    (int)pointValue.Y.Map(-absoluteMaxValue * 1.2, absoluteMaxValue * 1.2, h, 0), pointSize, pointSize);
                        values[i] = pointValue;
                    }
                    Invalidate();
                }
            }
        }

        public string XAxisLabel {
            get { return xAxisLabel; }
            set { xAxisLabel = value; Invalidate(); }
        }

        public string YAxisLabel {
            get { return yAxisLabel; }
            set { yAxisLabel = value; }
        }

        public Color PointColor {
            get { return pointColor; }
            set {
                pointColor = value;
                pointPen = new Pen(pointColor, 1);
                pointBrush = new SolidBrush(pointColor);
                Invalidate();
            }
        }

        public Color GridColor {
            get { return gridColor; }
            set {
                gridColor = value;
                linePen = new Pen(gridColor, 1);
                textBrush = new SolidBrush(gridColor);
                Invalidate();
            }
        }

        public int PointSize {
            get { return pointSize; }
            set {
                pointSize = value;
                if (pointSize < 3)
                    pointSize = 3;
                Invalidate();
            }
        }

        private void Graph2D_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int h = Size.Height;
            int w = Size.Width;

            #region draw axes' lines and labels

            //X axis
            g.DrawLine(linePen, new Point(w, h / 2), new Point(0, h / 2));
            g.DrawLine(linePen, new Point(w, h / 2), new Point(w - 5, h / 2 + 5));
            g.DrawLine(linePen, new Point(w, h / 2), new Point(w - 5, h / 2 - 5));
            g.DrawString(xAxisLabel, new Font(FontFamily.GenericSansSerif, 8), textBrush, w - 10, h / 2 + 10);

            //Y axis
            g.DrawLine(linePen, new Point(w / 2, 0), new Point(w / 2, h));
            g.DrawLine(linePen, new Point(w / 2, 0), new Point(w / 2 - 5, 5));
            g.DrawLine(linePen, new Point(w / 2, 0), new Point(w / 2 + 5, 5));
            g.DrawString(yAxisLabel, new Font(FontFamily.GenericSansSerif, 8), textBrush, w / 2 + 10, 0);

            #endregion draw axes' lines and labels

            #region draw points
            foreach (PointValue value in values)
            {
                try
                {
                    //g.DrawEllipse(pointPen, value.Boundary);
                    g.FillEllipse(pointBrush, value.Boundary);
                }
                catch
                {
                    Console.WriteLine(value.Boundary);
                }
            }

            #endregion draw points
        }

        private void Graph2D_SizeChanged(object sender, EventArgs e)
        {
            //if (Size.Width != Size.Height)
            //    Size = new Size((Size.Height + Size.Width) / 2, (Size.Height + Size.Width) / 2);
            Invalidate();
        }
    }
}
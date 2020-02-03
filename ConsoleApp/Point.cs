using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(string pointString)
        {
            this.X = Convert.ToDouble(pointString.Split(Constants.PointSeparator)[0]);
            this.Y = Convert.ToDouble(pointString.Split(Constants.PointSeparator)[1]);
        }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point(double x, double y)
        {
            this.X = Convert.ToInt32(x);
            this.Y = Convert.ToInt32(y);
        }
    }
}

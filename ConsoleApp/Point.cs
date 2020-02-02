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
    }
}

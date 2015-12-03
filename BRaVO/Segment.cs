using System;
using System.Collections.Generic;
using System.Drawing;

namespace BRaVO
{
    public class Segment
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public List<Point> Points { get; }

        public Segment(Point a, Point b)
        {
            A = a;
            B = b;
            Points = new List<Point> { a, b};
        }

        public Point GetTheOtherPoint(Point x)
        {
            return x.Equals(A) ? B : A;
        }

        public bool Egale(Segment x)
        {
            if((A.Equals(x.A) && B.Equals(x.B)) || (B.Equals(x.A) && A.Equals(x.B)))
                return true;
            return false;
        }

        public Point GetTheMiddlePoint()
        {
            return new Point((A.X + B.X) / 2, (A.Y + B.Y) / 2);
        }

        public double GetLength()
        {
            return Math.Sqrt(Math.Pow((B.X - A.X), 2) + Math.Pow((B.Y - A.Y), 2));
        }
    }
}

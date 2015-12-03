using System.Collections.Generic;
using System.Drawing;

namespace BRaVO
{
    public class Triangle
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public Segment S1 { get; set; }
        public Segment S2 { get; set; }
        public Segment S3 { get; set; }
        public List<Point> Points { get; } 

        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
            S1 = new Segment(a, b);
            S2 = new Segment(b, c);
            S3 = new Segment(a, c);
            Points = new List<Point> {a, b, c};
        }

        public Point GetGravityCenter()
        {
            return new Point((A.X + B.X + C.X) / 3, (A.Y + B.Y + C.Y) / 3);
        }
    }
}

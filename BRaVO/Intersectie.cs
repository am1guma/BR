using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRaVO
{
    public class Intersectie
    {
        private Point a, b, c, d;
        private double m1, m2;
        private double a1, a2, b1, b2, c1, c2;
        public Intersectie(Point a, Point b, Point c, Point d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            m1 = CalculateSlope(a, b);
            m2 = CalculateSlope(c, d);
            a1 = b.Y - a.Y;
            a2 = d.Y - c.Y;
            b1 = a.X - b.X;
            b2 = c.X - d.X;
            c1 = -1 * a.X * b.Y + a.X * a.Y + a.Y * b.X - a.Y * a.X;
            c2 = -1 * c.X * d.Y + c.X * c.Y + c.Y * d.X - c.Y * c.X;
        }
        public Intersectie()
        { }
        private double CalculateSlope(Point a, Point b)
        {
            double var1 = b.Y - a.Y;
            double var2 = b.X - a.X;
            return (var1 / var2);
        }
        public bool Intersectation()
        {
            if (m1 == m2)
                return false;
            if ((a2 != 0) && (b2 != 0) && (c2 != 0) && (a1 / a2 == b1 / b2) && (a1 / a2 == c1 / c2) && (b1 / b2 == c1 / c2))
                return true;
            double x = (c2 * b1 - c1 * b2) / (a1 * b2 - a2 * b1);
            double y = (-1 * c1 - a1 * x) / b1;
            if ((x == b.X && y == b.Y) || (x == a.X && y == a.Y))
                return false;
            if ((x == d.X && y == d.Y) || (x == c.X && y == c.Y))
                return false;
            if (((x > a.X && x > b.X) || (x < a.X && x < b.X)) || ((y > a.Y && y > b.Y) || (y < a.Y && y < b.Y)))
                return false;
            if (((x > c.X && x > d.X) || (x < c.X && x < d.X)) || ((y > c.Y && y > d.Y) || (y < c.Y && y < d.Y)))
                return false;
            return true;
        }
    }
}

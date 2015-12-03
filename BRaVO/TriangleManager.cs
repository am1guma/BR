using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BRaVO
{
    public class TriangleManager
    {
        public static List<Triangle> Triangles;
         
        public static bool CheckIfPointIsInsideTriangle(Triangle t)
        {
            foreach (var p in PolygonManager.GetAllPoints())
            {
                if (p != t.A && p != t.B && p != t.C)
                {
                    var a = CalculateArea(t.A, t.B, t.C);
                    var a1 = CalculateArea(p, t.A, t.B);
                    var a2 = CalculateArea(p, t.B, t.C);
                    var a3 = CalculateArea(p, t.A, t.C);
                    if (Math.Abs(a - (a1 + a2 + a3)) < 0.001)
                        return true;
                }
            }
            return false;
        }

        private static double CalculateArea(Point a, Point b, Point c)
        {
            return Math.Abs((a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y)) / 2.0);
        }

        public static List<Triangle> GetAllTrianglesNextToMainTriangle(Triangle mainT)
        {
            return Triangles.Where(t => !t.Equals(mainT)).Where(t => (t.S1.Egale(mainT.S1)) || (t.S1.Egale(mainT.S2)) || (t.S1.Egale(mainT.S3)) || (t.S2.Egale(mainT.S1)) || (t.S2.Egale(mainT.S2)) || (t.S2.Egale(mainT.S3)) || (t.S3.Egale(mainT.S1)) || (t.S3.Egale(mainT.S2)) || (t.S3.Egale(mainT.S3))).ToList();
        }

        public static bool CheckIfTriangleAlreadyExists(Triangle t)
        {
            return Triangles.Any(tr => (t.A.Equals(tr.A) || t.A.Equals(tr.B) || t.A.Equals(tr.C)) && (t.B.Equals(tr.A) || t.B.Equals(tr.B) || t.B.Equals(tr.C)) && (t.C.Equals(tr.A) || t.C.Equals(tr.B) || t.C.Equals(tr.C)));
        }

        public static Segment GetCommonSegmentFromTwoTriangles(Triangle a, Triangle b)
        {
            if (a.S1.Egale(b.S1) || a.S1.Egale(b.S2) || a.S1.Egale(b.S3))
                return a.S1;
            if (a.S2.Egale(b.S1) || a.S2.Egale(b.S2) || a.S2.Egale(b.S3))
                return a.S2;
            if (a.S3.Egale(b.S1) || a.S3.Egale(b.S2) || a.S3.Egale(b.S3))
                return a.S3;
            return new Segment(new Point(0,0), new Point(0, 0));
        }

        public static Triangle ReturnTriangleWithAPointInside(Point p)
        {
            foreach (var t in Triangles)
            {
                if (p != t.A && p != t.B && p != t.C)
                {
                    var a = CalculateArea(t.A, t.B, t.C);
                    var a1 = CalculateArea(p, t.A, t.B);
                    var a2 = CalculateArea(p, t.B, t.C);
                    var a3 = CalculateArea(p, t.A, t.C);
                    if (Math.Abs(a - (a1 + a2 + a3)) < 0.001)
                        return t;
                }
            }
            return new Triangle(p, p, p);
        }

        public static bool CheckIfAPointIsInsideATriangle(Point p,Triangle t)
        {
                if (p != t.A && p != t.B && p != t.C)
                {
                    var a = CalculateArea(t.A, t.B, t.C);
                    var a1 = CalculateArea(p, t.A, t.B);
                    var a2 = CalculateArea(p, t.B, t.C);
                    var a3 = CalculateArea(p, t.A, t.C);
                    if (Math.Abs(a - (a1 + a2 + a3)) < 0.001)
                        return true;
                }
            return false;
        }
    }
}

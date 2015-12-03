using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRaVO
{
    public class IntersectieManager
    {
        public static Intersectie VerificaIntersectia;
        public static bool CheckIfASegmentIntersectsAnotherSegment(Segment s)
        {
            var ls = SegmentsManager.Segments;
            foreach (var seg in ls.Where(seg => !seg.Egale(s)))
            {
                VerificaIntersectia = new Intersectie(seg.A, seg.B, s.A, s.B);
                if (VerificaIntersectia.Intersectation())
                    return false;
            }
            return true;
        }

        public static bool CheckIfTwoPointsIntersectOnlyASpecificSegment(Point a, Point b, Segment s)
        {
            Segment s1 = new Segment(a,b);
            var ls = SegmentsManager.Segments;
            foreach (var seg in ls.Where(seg => !seg.Egale(s1)))
            {
                if (!seg.Egale(s))
                {
                    VerificaIntersectia = new Intersectie(seg.A, seg.B, s1.A, s1.B);
                    if (VerificaIntersectia.Intersectation())
                        return false;
                }
            }
            return true;
        }

        public static bool CheckIfTwoPointsIntersectAShape(Point a, Point b)
        {
            for (var i = 1; i < PolygonManager.ListOfPolygons.Count; i++)
            {
                var ls = PolygonManager.ListOfPolygons[i].Segmente;
                foreach (var s in ls)
                {
                    if (CheckIfTwoPointsIntersectOnlyASpecificSegment(a, b, s))
                        return true;
                }
            }
            return true;
        }

        private static List<Segment> GetAllSegmentesThatAreIntersectedByASegment(Segment s)
        {
            var ls = new List<Segment>();
            foreach (var seg in SegmentsManager.Segments)
            {
                var intersectie = new Intersectie(seg.A, seg.B, s.A, s.B);
                if (intersectie.Intersectation())
                    ls.Add(seg);
            }
            foreach (var seg in PolygonManager.Contur.Segmente)
            {
                var intersectie = new Intersectie(seg.A, seg.B, s.A, s.B);
                if (intersectie.Intersectation())
                    ls.Add(seg);
            }
            return ls;
        }

        public static Point GetFirstIntersectionPoint(Segment s)
        {
            var ls = GetAllSegmentesThatAreIntersectedByASegment(s);
            var lp = new List<Point>();
            foreach (var seg in ls)
            {
                var intersectie = new Intersectie(seg.A, seg.B, s.A, s.B);
                if (intersectie.Intersectation())
                {
                    intersectie.SetIntersectionPoint();
                    if(!double.IsNaN(intersectie.x) && !double.IsNaN(intersectie.y))
                        lp.Add(new Point(Convert.ToInt32(intersectie.x), Convert.ToInt32(intersectie.y)));
                }
            }
            lp = lp.OrderBy(p => p.Y).ToList();
            return lp.First();
        }

        public static Point GetLastIntersectionPoint(Segment s)
        {
            var ls = GetAllSegmentesThatAreIntersectedByASegment(s);
            var lp = new List<Point>();
            foreach (var seg in ls)
            {
                var intersectie = new Intersectie(seg.A, seg.B, s.A, s.B);
                if (intersectie.Intersectation())
                {
                    intersectie.SetIntersectionPoint();
                    if (!double.IsNaN(intersectie.x) && !double.IsNaN(intersectie.y))
                        lp.Add(new Point(Convert.ToInt32(intersectie.x), Convert.ToInt32(intersectie.y)));
                }
            }
            lp = lp.OrderBy(p => p.Y).ToList();
            return lp.Last();
        }

        public static bool CanDraw(Point p, Point x)
        {
            var ls = SegmentsManager.GetSegmentsThatContainsASpecificPoint(p);
            var p1 = ls[0].GetTheOtherPoint(p);
            var p2 = ls[1].GetTheOtherPoint(p);
            var tr = new Triangle(p, p1, p2);
            if (TriangleManager.CheckIfAPointIsInsideATriangle(x, tr))
                return false;
            return true;
        }

        public static bool CheckIfSegmentIntersectInteriorSegment(Segment s)
        {
            foreach (var seg in SegmentsManager.InteriorSegments)
            {
                VerificaIntersectia = new Intersectie(seg.A, seg.B, s.A, s.B);
                if (VerificaIntersectia.Intersectation())
                {
                    var pt = new Point(Convert.ToInt32(VerificaIntersectia.x), Convert.ToInt32(VerificaIntersectia.y));
                    if (!(pt.Equals(s.A) || pt.Equals(s.B)))
                        return true;
                }
                    
            }
            return false;
        }
    }
}

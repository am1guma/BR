using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace BRaVO
{
    public class PolygonManager
    {
        public static Polygon Contur;

        public static List<Point> ListOfMiddlePoints;

        public static List<Polygon> ListOfPolygons;

        public static List<Segment> GetAllPolygonsSegments()
        {
            return ListOfPolygons.SelectMany(p => p.Segmente).ToList();
        }

        public static List<Point> GetAllPolygonPoints(Polygon p)
        {
            var lp = new List<Point>();
            foreach (var s in p.Segmente)
            {
                if (!lp.Contains(s.A))
                    lp.Add(s.A);
                if (!lp.Contains(s.B))
                    lp.Add(s.B);
            }
            return lp;
        } 

        public static List<Point> GetAllPoints()
        {
            var ls = GetAllPolygonsSegments();
            var lp = new List<Point>();
            foreach (var p in ls)
            {
                if(!lp.Contains(p.A))
                    lp.Add(p.A);
                if (!lp.Contains(p.B))
                    lp.Add(p.B);
            }
            return lp;
        }

        public static bool CheckIfSegmentIntersectTwoPointsFromAnInternalShape(Segment s)
        {
            for (var i = 1; i < ListOfPolygons.Count; i++)
            {
                var lp = GetAllPolygonPoints(ListOfPolygons[i]);
                if (lp.Contains(s.A) && lp.Contains(s.B))
                {
                    if (!SegmentsManager.CheckIfSegmentAlreadyExists(s))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool CheckIfTriangleIsAShape(Triangle t)
        {
            return ListOfPolygons.Select(p => p.Segmente).Where(ls => ls.Count == 3).Any(ls => (ls[0].Egale(t.S1) || ls[0].Egale(t.S2) || ls[0].Egale(t.S3)) && (ls[1].Egale(t.S1) || ls[1].Egale(t.S2) || ls[1].Egale(t.S3)) && (ls[2].Egale(t.S1) || ls[2].Egale(t.S2) || ls[2].Egale(t.S3)));
        }

    }
}

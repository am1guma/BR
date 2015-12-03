using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BRaVO
{
    public class SegmentsManager
    {
        public static List<Segment> Segments;

        public static List<Segment> InteriorSegments;

        public static List<Segment> GetSegmentsThatContainsASpecificPoint(Point a)
        {
            return Segments.FindAll(p => p.A.Equals(a) || p.B.Equals(a));
        }

        public static Segment FindSegment(Point a,Point b)
        {
            return Segments.Find(p => (p.A.Equals(a) && p.B.Equals(b)) || (p.A.Equals(b) && p.B.Equals(a)));
        }

        public static bool CheckIfSegmentAlreadyExists(Segment s)
        {
            return Segments.Any(seg => seg.Egale(s));
        }
    }
}

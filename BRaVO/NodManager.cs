using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BRaVO
{
    public class NodManager
    {
        public static List<Nod> Noduri;

        public static Nod GetNod(Point p)
        {
            foreach (var n in Noduri.Where(n => n.P.Equals(p)))
            {
                return n;
            }
            return new Nod('a', new Point(0, 0));
        }

        public static bool CheckIfNodExists(Nod d)
        {
            return Noduri.Any(n => n.P.Equals(d.P));
        }

        public static Nod GetNodWithId(int id)
        {
            return Noduri.First(n => n.Id == id);
        }

        public static List<Nod> CheckWehereANodCanGo(Nod n)
        {
            var returnList = new List<Nod>();
            foreach (var nod in Noduri)
            {
                if (!n.P.Equals(nod.P) && DrumManager.CheckIfDrumExists(new Drum(n, nod, new Segment(n.P, nod.P).GetLength())))
                {
                    returnList.Add(nod);
                }
            }
            return returnList;
        }
    }
}

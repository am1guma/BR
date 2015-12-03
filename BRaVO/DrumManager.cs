using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace BRaVO
{
    public class DrumManager
    {
        public static List<Drum> Drumuri;

        public static bool CheckIfDrumExists(Drum d)
        {
            foreach (var dr in Drumuri)
            {
                if (((d.Nod1.P.Equals(dr.Nod1.P)) || (d.Nod1.P.Equals(dr.Nod2.P))) &&
                    ((d.Nod2.P.Equals(dr.Nod1.P)) || (d.Nod2.P.Equals(dr.Nod2.P))))
                    return true;
            }
            return false;
        }
    }
}

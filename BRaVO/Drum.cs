using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRaVO
{
    public class Drum
    {
        public Nod Nod1 { get; } 
        public Nod Nod2 { get; }
        public double Distanta { get; }
        public double Cost { get; } 

        public Drum(Nod nod1, Nod nod2, double distanta)
        {
            Nod1 = nod1;
            Nod2 = nod2;
            Distanta = distanta;
        }
    }
}

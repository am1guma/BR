using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRaVO
{
    public class Nod
    {
        public char Id { get; }
        public Point P { get; }
        public Nod(char id, Point p)
        {
            Id = id;
            P = p;
        }
    }
}

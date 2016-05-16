using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Figurer
{
    class Triangel : Figur
    {
        public int b;
        public int h;
        public int sh;
        public int sv;
        
        public Triangel(int bas, int höjd, int sidah, int sidav)
        {
            this.h = höjd;
            this.b = bas;
            this.sh = sidah;
            this.sv = sidav;
        }
        public override double Area()
        {
            return b * h / 2;
        }
        public override double omkrets()
        {
            return b + sv + sh;
        }
    }
}

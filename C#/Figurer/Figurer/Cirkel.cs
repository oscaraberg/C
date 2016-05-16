using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Figurer
{
    class Cirkel : Figur
    {
        public int r;
        
        public Cirkel(int radie)
        {
            this.r = radie;

        }

        public override double Area()
        {
           return r * r * Math.PI;
        }

        public override double omkrets()
        {
            return r + r * Math.PI;  
            
        }

    }
}

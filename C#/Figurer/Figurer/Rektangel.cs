using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Figurer
{
    class Rektangel : Figur
    {
        public int b;
        public int h;
        public Rektangel(int bas, int höjd)
        {
            this.h = höjd;
            this.b = bas;
        }


        public override double Area()
        {
            return h * b;
        }

        public override double omkrets()
        {
            return h + h + b + b;
        }
    }
}

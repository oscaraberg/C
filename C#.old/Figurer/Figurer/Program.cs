using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Figurer
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Figur> figurer = new List<Figur>();
            figurer.Add(new Cirkel(4));
            figurer.Add(new Rektangel(4, 44));
            figurer.Add(new Triangel(34, 34, 44, 54));
            foreach (Figur f in figurer)
            {
                Console.WriteLine(f.Area().ToString, f.omkrets().ToString);
            }

            Console.ReadLine();
        }
    }
}

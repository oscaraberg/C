using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gissaigen
{
    class Program
    {
        static void Main(string[] args)
        {
            int antal = gissaigenFkt(1000);
            Console.WriteLine("antal försök " + antal);
            Console.Read();

        }
        static int gissaigenFkt(int taket)
        {
            int antalförsök = 0;
            Console.WriteLine("gissa på ett tal mela 1 och " + taket);
            Random rand = new Random();
            int slumptal = rand.Next(1, taket + 1);
            while (true)
            {
                string gissatalstr = Console.ReadLine();
                int gissatal = int.Parse(gissatalstr);
                //int.TryParse(gissatalstr, out gissatal);
                antalförsök++;
                if (slumptal == gissatal)
                {
                    Console.WriteLine("rätt");
                    return antalförsök;
                }
                else if (slumptal > gissatal)
                {
                    Console.WriteLine("fel! gissa högre");
                }
                else
                {
                    Console.WriteLine("fel! gissa lägre");
                }

            }
        }
    }
}

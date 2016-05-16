using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace skrivfält
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] f = { 2, 4, 1, 8, 6};
            int[] a = new int[5];
            SorteraTal(f);
            skrivut(f);
            Console.Read();

        }

        static void SorteraTal(int[] g)
        {
            for (int i = 0; i < g.Length; i++)
            {

            }
            
        }
        static void skrivut(int[] r)
        {
            for (int i = 0; i < r.Length; i++)
            {
                int e = r[i];
                Console.WriteLine(e);
            }
        }
    }
}

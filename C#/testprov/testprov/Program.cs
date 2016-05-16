using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testprov
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] fält = new int[10];
            slumptal(fält);
            Console.WriteLine(fält);
            Console.ReadLine();

        }

        static void slumptal(int [] f ){
            Random r = new Random();
            for (int i = 0; i < f.Length; i++)
            {
                f[i] = r.Next(20, 70);
            }


        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pytagoras_sats
{
    class Program
    {
        static void Main(string[] args)
        {
            double svar = pytagoras(5,13);
            Console.WriteLine("hypotinusa är " + svar);
            Console.Read();

        }
        static double pytagoras(int a, int b)
        {
            int A = a * a;
            int B = b * b;
            int c = A + B;
            double C = Math.Sqrt(c);
            return C;
        } 
    }
}

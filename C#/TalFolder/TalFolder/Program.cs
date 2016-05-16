using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {

        
        static void Main(string[] args)
        {
            
             TalF(20);
             Console.ReadLine();
           
        }

        static void TalF(int e )
        {
            for (int j = 0; j < e; j++)
            {
                Double[] tal = new Double[e];
                tal[0] = 1;
                tal[1] = 1;
                for (int i = 2; i < e; i++)
                {
                    tal[i] = tal[i - 1] + tal[i - 2];
                }
                Console.WriteLine((j+1) + " " + tal[j]);
            }
        }
       
    }
}

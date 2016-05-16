using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace polimorfism
{
    class Program
    {
        static void Main(string[] args)
        {
            player p = new player();
            Warrior w = new Warrior();
            p.Attack();
            w.Attack();
            p = w;
            p.Attack();
            Console.ReadLine();

        }
    }
}

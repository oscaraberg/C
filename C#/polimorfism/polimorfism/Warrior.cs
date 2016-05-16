using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace polimorfism
{
    class Warrior : player 
    {
        public override void Attack()
        {
            Console.WriteLine("a warrior attack whid a sword!");
        }
    }
}

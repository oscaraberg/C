using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Person
    {

        public string namn{get;set;}
        public int ålder { get; set;}
        public static int antal = 0;

        public Person(string namn, int ålder)
        {
            this.namn = namn;
            this.ålder = ålder;
            antal++;
        }
        public string ToString()
        {
            return namn + " " + ålder;
        }
    }
}

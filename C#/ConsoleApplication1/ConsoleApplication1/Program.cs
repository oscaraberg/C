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
           
            Person person1 = new Person("Viktor", 17);
            Person person2 = new Person("Shemi", 18); 
            Console.WriteLine(person1.ToString());
            Console.WriteLine(person2.ToString());
            Console.WriteLine(Person.antal);
            Console.ReadLine();

        }
    }
}

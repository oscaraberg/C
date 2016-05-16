using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace gissaigenmed
{
    class Program
    {
        static void Main(string[] args)
        {
            int antal = GissaIgen(10);
            UppDateraLista(antal);
            Console.WriteLine("antal försök " + antal);
            visalista();
            Console.Read();

        }

        static int GissaIgen(int tal)
        {
            Random rand = new Random();
            int slumptal = rand.Next(1, tal + 1);
            while (true)
            {
                int antalförsök = 0;
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
    




        static void visalista()
        {

            StreamReader infil = new StreamReader(@"E:\C#\gissaigenmed\bastalista.txt", Encoding.Default);
            while (true)
            {
                string rad = infil.ReadLine();
                if (rad == null)
                {
                    break;
                }
                Console.WriteLine(rad);
            }


        }


        static void UppDateraLista(int nyapoäng)
        {

            int[] poängA = new int[5];
            string[] namnA = new string[5];
            StreamReader infil = new StreamReader(@"E:\C#\gissaigenmed\bastalista.txt", Encoding.Default);
            int i = 0;
            while (true)
            {

                string namn = infil.ReadLine();
                if (namn == null)
                {
                    break;
                }
                namnA[i] = namn;
                int poäng = int.Parse(infil.ReadLine());
                poängA[i] = poäng;
                i++;

            }
            infil.Close();
            if (nyapoäng < poängA[4])
            { 
                Console.Write("ange ditt namn: ");
                string nyttNamn = Console.ReadLine();
                for (int j = 0 ;j < 5; j++)
                {
                
                    if (nyapoäng < poängA[j])
                    {
                        string tmpNamn = namnA[j];
                        int temPoäng = poängA[j];
                        namnA[j] = nyttNamn;
                        poängA[j] = nyapoäng;
                        nyapoäng = temPoäng;
                        nyttNamn =tmpNamn;
                    }
                }

                StreamWriter utfil = new StreamWriter(@"E:\C#\gissaigenmed\bastalista.txt", false, Encoding.Default);
                for (int j = 0; j < 5; j++)
                {
                    utfil.WriteLine(namnA[j]);
                    utfil.WriteLine(poängA[j]);

                }
                utfil.Close();
            }
        }
    }
}

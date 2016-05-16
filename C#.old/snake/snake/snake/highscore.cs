using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace snake
{
    class highscore
    {
        //public int nyapoäng;
        //public highscore(int nyapoäng)
        //{
        //    this.nyapoäng = nyapoäng;
        //}

        public int test;

        public string visalista()
        {
            string lista = "";
            StreamReader infil = new StreamReader(@"..\..\..\..\..\bastalista.txt", Encoding.Default);
            StreamReader infil2 = new StreamReader(@"..\..\..\..\..\bastalista2.txt", Encoding.Default);
            string lagst = infil2.ReadLine();
            test = int.Parse(lagst);
            while (true)
            {
                string rad = infil.ReadLine();
                if (rad == null)
                {
                    break;
                }
                lista = lista + "\n" + rad;
                
            }
            infil.Close();
            infil2.Close();
            return lista;
           
 
        }

        public void UppDateraLista(int nyapoäng, string n)
        {

            int[] poängA = new int[5];
            string[] namnA = new string[5];
            StreamReader infil = new StreamReader(@"..\..\..\..\..\bastalista.txt", Encoding.Default);
            StreamReader infil2 = new StreamReader(@"..\..\..\..\..\bastalista2.txt", Encoding.Default);
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
            infil2.Close();
            if (nyapoäng > poängA[4])
            {            
                string nyttNamn = n;
                for (int j = 0; j < 5; j++)
                {

                    if (nyapoäng > poängA[j])
                    {
                        string tmpNamn = namnA[j];
                        int temPoäng = poängA[j];
                        namnA[j] = nyttNamn;
                        poängA[j] = nyapoäng;
                        nyapoäng = temPoäng;
                        nyttNamn = tmpNamn;
                    }
                }

                StreamWriter utfil = new StreamWriter(@"..\..\..\..\..\bastalista.txt", false, Encoding.Default);
                for (int j = 0; j < 5; j++)
                {
                    utfil.WriteLine(namnA[j]);
                    utfil.WriteLine(poängA[j]);

                }
                utfil.Close();
               
                StreamWriter utfil2 = new StreamWriter(@"..\..\..\..\..\bastalista2.txt", false, Encoding.Default);
                utfil2.WriteLine(poängA[4]);
                utfil2.Close();
                
            }
        }
    }
}

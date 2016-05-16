using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace GissaIgenWinForms
{
    public partial class Form1 : Form
    {

        int slumptal;
        int antal = 0;
        public Form1()
        {
            InitializeComponent();
            Random r = new Random();
            slumptal = r.Next(1, 11);
            

        }

        private void GissaIgenWinForms(object sender, EventArgs e)
        {
           
            Kollagisning(); //anropat fungtionen som kollar om ens tal är sama som slump talet


        }
       

        void Kollagisning()
        {

           
            string s = maskedTextBox1.Text;
            int gissatTal = int.Parse(s);
            antal++;
            if (slumptal == gissatTal)//av gör vad som skr om man har rätt
            {
                label2.Text = "rätt. antal gisningar " + antal;
                string nytnamn = InputBox.Show("ditt Namn");//sertil att man kan skriva in sit namn
                UppDateraLista(antal, nytnamn);
                label3.Text = visalista();
                maskedTextBox1.Text ="";
                
  
            }
            else if (slumptal < gissatTal)
            {
                label2.Text = "gissa lägre";
                maskedTextBox1.Text ="";
            

            }

            else
            {
                label2.Text = "gissa högre";
                maskedTextBox1.Text ="";
            
            }
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void kol(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // tilåter en att tryka på enter
            {
                Kollagisning(); 
            }

        }
        // markering
        static string visalista()
        {
            string text = "";
            StreamReader infil = new StreamReader(@"E:\C#\GissaIgenWinForms\bastalista.txt", Encoding.Default);// var listan hemtas ifrån
            while (true)
            {
                string rad = infil.ReadLine();
                if (rad == null)
                {
                    break;
                }
                Console.WriteLine(rad);
                text += '\n' + rad; // leger in värdena i variaben tal. 
            }

            return text;
        }


        static void UppDateraLista(int nyapoäng, string nyttNamn)
        {

            int[] poängA = new int[5]; // hur månda värden som fins i variabeln.
            string[] namnA = new string[5];
            StreamReader infil = new StreamReader(@"E:\C#\GissaIgenWinForms\bastalista.txt", Encoding.Default);// val listan fins
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
            if (nyapoäng < poängA[4])// kolar om det nya talet är mindere en tal 5 i listan
            {
             
               
                
                for (int j = 0; j < 5; j++)
                {

                    if (nyapoäng < poängA[j])// byter ut namn och påeng i listan
                    {
                        string tmpNamn = namnA[j];
                        int temPoäng = poängA[j];
                        namnA[j] = nyttNamn;
                        poängA[j] = nyapoäng;
                        nyapoäng = temPoäng;
                        nyttNamn = tmpNamn;
                    }
                }

                StreamWriter utfil = new StreamWriter(@"E:\C#\GissaIgenWinForms\bastalista.txt", false, Encoding.Default);
                for (int j = 0; j < 5; j++)
                {
                    utfil.WriteLine(namnA[j]);
                    utfil.WriteLine(poängA[j]);

                }
                utfil.Close();
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            

        }


    }

}

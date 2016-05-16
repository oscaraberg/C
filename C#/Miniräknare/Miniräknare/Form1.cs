using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Miniräknare
{
    public partial class Form1 : Form
    {
        double tal1;
        double tal2;
        string op;
        Boolean forsta = true;
        Boolean ny = true;

        public Form1()
        {
            InitializeComponent();
           
           

        }

        private void symboler(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            
            
            if (forsta == true)
            {
                
                tal1 = double.Parse(textBox1.Text); //gör om det som står i textbox till en dubel och leger in den i tal1 variaben
                forsta = false;
                op = button.Text;//setter op till den symbålen som ska anvendas
                textBox1.Text = "";
                
            }
            else
            {


                tal2 = double.Parse(textBox1.Text);  //gör om det som står i textbox till en dubel och leger in den i tal2 variaben
                beräkning(); // startar fungtionen berekning.
                ny = true; // åter steler booliena så att man kan fårseta att räkma vidare
                forsta = true;
               
            }
            


            
        }

        private void nummerKlick(object sender, EventArgs e)// gör så att det som ståt på knapen skrivs utt i tekst feltet.
        {
            Button button = (Button)sender;  
            if (ny == true)
            {
                textBox1.Text = button.Text;
                ny = false;
            }
            else
            {
                textBox1.Text += button.Text;
                
            }
            
        }


        private void beräkning()//kolar om variaben op har en vis symbol och om den har det starta en fungtion och skikamed värdena tal1 och tal2
        {

            if (op == "+")
            {
                adision(tal1, tal2);
            }
            else if (op == "-")
            {
                suptrakrion(tal1, tal2);
            }
            else if (op == "*")
            {
                multiplikation(tal1, tal2);
            }
            else if (op == "/")
            {
                divition(tal1, tal2);
            }
            
        }



        private void adision(double numer1, double numer2)
        {
            
            
                double svar = numer1 + numer2; // räkanr ut svaren 
                tal1 = svar; // seter tal1 ett till svar 
                tal2 = 0; // seter tal2 till 0 
                textBox1.Text = tal1.ToString(); // skriver ut svaret

        }

        private void suptrakrion(double numer1, double numer2)
        {

                double svar = numer1 - numer2; // räkanr ut svaren 
                tal1 = svar; // seter tal1 ett till svar 
                tal2 = 0; // seter tal2 till 0 
                textBox1.Text = tal1.ToString(); // skriver ut sva
           
        }

        private void multiplikation(double numer1, double numer2)
        {

            double svar = numer1 * numer2; // räkanr ut svaren 
            tal1 = svar; // seter tal1 ett till svar 
            tal2 = 0; // seter tal2 till 0 
            textBox1.Text = tal1.ToString(); // skriver ut sva
           
        }

        private void divition(double numer1, double numer2)
        {

            double svar = numer1 / numer2; // räkanr ut svaren 
            tal1 = svar; // seter tal1 ett till svar 
            tal2 = 0; // seter tal2 till 0 
            textBox1.Text = tal1.ToString(); // skriver ut sva
           

        }
     

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void rensa(object sender, EventArgs e) // nolsteler allt nar man trycer på c
        {
            tal1 = 0;
            tal2 = 0;
            textBox1.Text = "";
            ny = true;
            forsta = true;
        }
    }
}

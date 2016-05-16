using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _21
{
    static class Program
    {
        public static void Main()
        {

            Kortbunt kortlek = new Kortbunt();  // Skapa en instans av klassen Kortbunt, kalla den t.ex. "kortlek"

            int anatall = int.Parse(InputBox.Show("en eller två spelare"));

            if (anatall == 1)
            {
                Människa spelare = new Människa(kortlek); // Skapa en instans av klassen Människa, kalla den t.ex. "spelare"

                Dator dator = new Dator(kortlek, spelare);// Skapa en instans av klassen Dator, kalla den t.ex. "dator"

                int box = int.Parse(InputBox.Show("hur myket vil du satsa. du har " + spelare.pengar));

                while (true)   // Starta en while(true)-loop
                {

                    kortlek.NyKortlek();  // Anropa en metod så att en ny kortlek skapas

                    kortlek.Blanda();// Blanda kortleken



                    if (box <= spelare.pengar && box > 0)
                    {
                        spelare.Spela();// Låt spelaren spela

                        if (spelare.Poäng > 21)// > 21, skriv i så fall "Du förlorade"
                        {
                            MessageBox.Show("Du förlorade: Du har " + spelare.Poäng);
                            spelare.pengar -= box;
                            box = 0;
                        }
                        else if (spelare.Poäng == 21)// == 21, skriv i så fall "Du vann"
                        {
                            MessageBox.Show("Du vann. Duhar 21");
                            spelare.pengar += box;
                            box = 0;
                        }
                        else
                        {
                            dator.Spela(); // Annars är det datorns tur att spela
                            if (dator.Poäng > 21) // Kolla om datorn vann eller förlorade, ge meddelande
                            {
                                MessageBox.Show("Du vann. dator kom över 21");
                                spelare.pengar += box;
                                box = 0;
                            }
                            else
                            {

                                if (spelare.Poäng > dator.Poäng)
                                {
                                    MessageBox.Show("Du vann: Du har " + spelare.Poäng + " och datorn fick " + dator.Poäng);
                                    spelare.pengar += box;                                    
                                    box = 0;
                                }
                                if (dator.Poäng > spelare.Poäng)
                                {
                                    MessageBox.Show("Du förlorade: Du har " + spelare.Poäng + " och datorn fick " + dator.Poäng);
                                    spelare.pengar -= box;
                                    box = 0;
                                }
                            }
                        }
                        // Fråga om det ska vara ett ny parti, t.ex. kan du använda:
                        if (spelare.pengar <= 0)
                        {
                            break;
                        }
                        DialogResult svar = MessageBox.Show("Nytt parti?", "Fråga", MessageBoxButtons.YesNo);

                        if (svar != DialogResult.Yes)
                        {
                            break;
                        }
                    }
                    else
                    {
                        box = int.Parse(InputBox.Show("Du kan inte satsa mer än vad du har " + spelare.pengar));
                    }


                }
            }

            else if (anatall == 2)
            {
                Människa spelare = new Människa(kortlek); // Skapa en instans av klassen Människa, kalla den t.ex. "spelare"

                Människa spelare2 = new Människa(kortlek);

                

                while (true)   // Starta en while(true)-loop
                {

                    kortlek.NyKortlek();  // Anropa en metod så att en ny kortlek skapas

                    kortlek.Blanda();// Blanda kortleken

                    int box = int.Parse(InputBox.Show("hur myket vill spelare 1 satsa. du har " + spelare.pengar));

                    int box2 = int.Parse(InputBox.Show("hur myket vill spelare 2 satsa. du har " + spelare2.pengar));


                    if (box == box2 && box > 0 && box <= spelare.pengar && box2 <= spelare2.pengar)
                    {
                        spelare.Spela();// Låt spelaren spela

                        if (spelare.Poäng > 21)// > 21, skriv i så fall "Du förlorade"
                        {
                            MessageBox.Show("spelare 2 vann: spelare 1 kom över 21 " + spelare.Poäng);
                            spelare.pengar -= box;
                            spelare2.pengar += box2;
                            box = 0;
                            box2 = 0;
                        }
                        else if (spelare.Poäng == 21)// == 21, skriv i så fall "Du vann"
                        {
                            MessageBox.Show("spelare 1 vann. han har 21");
                            spelare.pengar += box;
                            spelare2.pengar -= box2;
                            box = 0;
                            box2 = 0;
                        }
                        else
                        {
                            spelare2.Spela(); // Annars är det datorns tur att spela
                            if (spelare2.Poäng > 21) // Kolla om datorn vann eller förlorade, ge meddelande
                            {
                                MessageBox.Show("spelare 1 vann. spelare 2 kom över 21");
                                spelare.pengar += box;
                                spelare2.pengar -= box2;
                                box = 0;
                                box2 = 0;
                            }
                            else if (spelare2.Poäng == 21)
                            {
                                MessageBox.Show("spelare 2 vann. han har 21");
                                spelare.pengar -= box;
                                spelare2.pengar += box2;
                                box = 0;
                                box2 = 0;
                            }
                            else if (spelare.pengar == spelare2.pengar)
                            {
                                MessageBox.Show("Det är oavgjort");
                                box = 0;
                                box2 = 0;
                            }

                            else
                            {

                                if (spelare.Poäng > spelare2.Poäng)
                                {
                                    MessageBox.Show("spelare 1 vann: spelare 1 fick " + spelare.Poäng + " och spelare 2 fick " + spelare2.Poäng);
                                    spelare.pengar += box;
                                    spelare2.pengar -= box2;
                                    box = 0;
                                    box2 = 0;

                                }
                                if (spelare2.Poäng > spelare.Poäng)
                                {
                                    MessageBox.Show("spelare 2 vann: spelare 1 fick " + spelare.Poäng + " och spelare 2 fick " + spelare2.Poäng);
                                    spelare.pengar -= box;
                                    spelare2.pengar += box2;
                                    box = 0;
                                    box2 = 0;
                                }
                            }
                        }
                        // Fråga om det ska vara ett ny parti, t.ex. kan du använda:
                        if (spelare.pengar <= 0 || spelare2.pengar <= 0)
                        {
                            break;
                        }
                        DialogResult svar = MessageBox.Show("Nytt parti?", "Fråga", MessageBoxButtons.YesNo);

                        if (svar != DialogResult.Yes)
                        {
                            break;
                        }
                    }
                    else
                    {
                        box = int.Parse(InputBox.Show("Ogiltig valör, försök igen. spelare 1"));
                        box2 = int.Parse(InputBox.Show("Ogiltig valör, försök igen spelare 2"));
                    }


                }
            }

            else
            {
                anatall = int.Parse(InputBox.Show("en eler två spelare"));
                anatall = 0; 
            }


            
        }

    }
}

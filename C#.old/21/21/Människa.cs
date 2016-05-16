using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


class Människa : Spelare
{
    public Människa(Kortbunt k) : base(k) { }
    public int pengar = 100;

    public override void Spela()
    {
        NyttSpel();
        while (Poäng < 21)
        {
            NyttKort();
            if (Poäng < 21)
            {

                DialogResult r = MessageBox.Show("Du har korten: " + ToString() + " och har " + Poäng + " poäng." + "\nVill du ha ett kort till?", "Fråga", MessageBoxButtons.YesNo);// Visar vilaka kort du har och hur myket poeng du får mindre än 21

                if (r == DialogResult.No)      // nej
                    break;
                else if (r == DialogResult.Cancel) // avbryt
                    Environment.Exit(0);
            }
            else
                MessageBox.Show("Du har korten: " + ToString() + " och har " + Poäng + " poäng."); // Visar vilaka kort du har och hur myket poeng du får om du paserar 20
        }
    }
}



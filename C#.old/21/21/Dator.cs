using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

    class Dator : Spelare
    {
        Spelare motspelare;
        public Dator(Kortbunt k, Spelare mot)
            : base(k)
        {
            motspelare = mot;
        }
        public override void Spela()
        {
            NyttSpel();
            while (Poäng < 21 && Poäng < motspelare.Poäng)
                NyttKort();
            MessageBox.Show("Datorn fick korten: " + ToString() +
                            " och har " + Poäng + " poäng");
        }
    }




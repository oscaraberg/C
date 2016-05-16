using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    abstract class Spelare
    {
        Kortbunt leken;
        Kortbunt hand = new Kortbunt();
        int poäng;      // aktuell poäng

        public Spelare(Kortbunt k)
        {
            leken = k;
        }

        public abstract void Spela();   // deklareras i subklasserna

        public void NyttSpel()
        {
            hand.SlängKorten();
            poäng = 0;
        }

        public Kort NyttKort()
        {
            Kort k = leken.TaBortÖversta();
            hand.LäggÖverst(k);
            // Beräkna ny poäng
            int antalEss = 0;
            poäng = 0;
            for (int i = 0; i < hand.AntalKort; i++)
            {
                KortValör v = hand[i].Valör;
                poäng += hand[i].Värde;
                if (v == KortValör.ESS)
                    antalEss++;
            }
            for (int j = 1; j <= antalEss && poäng > 21; j++)
                poäng -= 13;  // räkna ett ess som 1
            return k;       // returnera det nya kortet
        }

        public int Poäng
        {
            get { return poäng; }
        }

        public override string ToString()
        {
            string s = "";
            if (hand.AntalKort > 0)
                s += hand[0];            // ToString anropas automatiskt
            for (int i = 1; i < hand.AntalKort; i++)
                s += ", " + hand[i];     // ToString anropas automatiskt
            return s;
        }
    }



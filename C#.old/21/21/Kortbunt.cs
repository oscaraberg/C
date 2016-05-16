using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    class Kortbunt
    {
        List<Kort> bunten = new List<Kort>();
        static Random rand = new Random();
        public void LäggÖverst(Kort k)
        {
            bunten.Insert(0, k);
        }

        public Kort TaBortÖversta()
        {
            Kort k = bunten[0];
            bunten.RemoveAt(0);
            return k;
        }

        public int AntalKort
        {
            get { return bunten.Count; }
        }

        public void SlängKorten()
        {
            bunten.Clear();
        }

        public Kort this[int nr]
        {     // indexerare
            get { return bunten[nr]; }
        }

        public Kort TaBort(int nr)
        {
            Kort k = bunten[nr];
            bunten.RemoveAt(nr);
            return k;
        }

        public int Sök(KortFärg f, KortValör v)
        {
            int i = 0;
            for (i = 0; i < bunten.Count; i++)
                if (bunten[i].Färg == f && bunten[i].Valör == v)
                    return i;
            return -1;
        }

        public void NyKortlek()
        {
            bunten.Clear();
            for (KortFärg f = KortFärg.KLÖVER; f <= KortFärg.SPADER; f++)
                for (KortValör v = KortValör.TVÅ; v <= KortValör.ESS; v++)
                    bunten.Add(new Kort(f, v));
        }

        public void Blanda()
        {
            for (int i = 0; i < 100; i++)
            {
                // Låt två slumpmässiga kort byta plats
                int a = rand.Next(bunten.Count);
                int b = rand.Next(bunten.Count);
                Kort k = bunten[a];
                bunten[a] = bunten[b];
                bunten[b] = k;
            }
        }
    }





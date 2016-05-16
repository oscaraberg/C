enum KortFärg { KLÖVER, RUTER, HJÄRTER, SPADER };
enum KortValör
{
    TVÅ = 2, TRE, FYRA, FEM, SEX, SJU, ÅTTA,
    NIO, TIO, KNEKT, DAM, KUNG, ESS
};

class Kort
{
    KortFärg f;
    KortValör v;
    static string[] färgTab = { "Kl", "Ru", "Hj", "Sp" };
    static string[] valörTab = {"2", "3", "4", "5", "6", "7", "8","9", "10", "Kn", "D", "K", "E"};//håler dom olika värdena

    public Kort(KortFärg fä, KortValör va)
    {
        f = fä;
        v = va;
    }

    public KortFärg Färg
    {
        get { return f; }
    }

    public KortValör Valör
    {
        get { return v; }
    }

    public int Värde
    {
        get { return (int)v; }
    }

    public override string ToString()
    {
        return färgTab[(int)f] + " " + valörTab[Värde - 2];
    }
}




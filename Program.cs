// See https://aka.ms/new-console-template for more information

public class Program
{
    public enum NamaBuah
    {
        Apel,
        Aprikot,
        Alpukat,
        Pisang,
        Paprika,
        Blackberry,
        Ceri,
        Kelapa,
        Jagung,
        Kurma,
        Durian,
        Anggur,
        Melon,
        Semangka
    }

    public static string getKodeBuah(NamaBuah buah)
    {
        string[] kodeBuah = {"A00", "B00", "C00", "D00", "E00", "F00", "G00", "H00", "I00", "J00", "K00", "L00", "M00", "N00", "O00"};
        return kodeBuah[(int)buah];
    }

    public static void Main(string[] args)
    {
        NamaBuah namaBuah = NamaBuah.Apel;
        string kodebuah = getKodeBuah(namaBuah);
        Console.WriteLine("Kode buah " + namaBuah + " adalah " + kodebuah);
    }
}

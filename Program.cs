// See https://aka.ms/new-console-template for more information

public class Program
{
   /* public enum NamaBuah
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
    //untuk mengurutkan nama nama buah

    public static string getKodeBuah(NamaBuah buah)
    {
        string[] kodeBuah = { "A00", "B00", "C00", "D00", "E00", "F00", "G00", "H00", "I00", "J00", "K00", "L00", "M00", "N00", "O00" };
        //isi kode dari nama buah secara berurutan
        return kodeBuah[(int)buah];
        //mengembalikan indeks dari kode buah
    }

    public static void Main(string[] args)
    {
        NamaBuah namaBuah = NamaBuah.Apel;
        //mendeklarasikan nama buah 
        string kodebuah = getKodeBuah(namaBuah);
        //untuk mendapatkan kode buah sesuah dengan namanya
        Console.WriteLine("Kode buah " + namaBuah + " adalah " + kodebuah);
        //mengeluarkan output nama buah dan kodenya
    }*/

    class PosisiKarakterGame
    {
        public enum posisiState
        {
            Jongkok,
            Berdiri,
            Tengkurap,
            Terbang
        }
        //untuk mengurutkan isi dari posisi
        public enum Trigger
        {
            TombolW,
            TombolS,
            TombolX
        }
        //untuk mengurutkan trigger
        public class Transition
        {
            public posisiState StateAwal;
            public posisiState StateAkhir;
            public Trigger trigger;
            //pendeklarasian untuk state awal, akhir, dan trigger

            public Transition(posisiState stateAwal, posisiState stateAkhir, Trigger trigger)
            {
                this.StateAwal = stateAwal;
                this.StateAkhir = stateAkhir;
                this.trigger = trigger;
            }
            //untuk mengganti isi dari state awal, akhir, dan trigger
        }

        Transition[] transisi =
        {
        new Transition(posisiState.Jongkok, posisiState.Tengkurap, Trigger.TombolS),
        new Transition(posisiState.Tengkurap, posisiState.Jongkok, Trigger.TombolW),
        new Transition(posisiState.Jongkok, posisiState.Berdiri, Trigger.TombolW),
        new Transition(posisiState.Berdiri, posisiState.Jongkok, Trigger.TombolS),
        new Transition(posisiState.Berdiri, posisiState.Terbang, Trigger.TombolW),
        new Transition(posisiState.Terbang, posisiState.Berdiri, Trigger.TombolS),
        new Transition(posisiState.Terbang, posisiState.Jongkok, Trigger.TombolX)
        };
        //penbuatan skenario kondisi

        public posisiState currenState = posisiState.Terbang;
        //pendeklarasian state awal

        public posisiState getNextState(posisiState StateAwal, Trigger trigger)
        {
            posisiState stateAkhir = StateAwal;
            for (int i = 0; i < transisi.Length; i++)
            {
                Transition perubahan = transisi[i];
                if (StateAwal == perubahan.StateAwal && trigger == perubahan.trigger)
                {
                    stateAkhir = perubahan.StateAkhir;
                }
            }
            return stateAkhir;
        }
        //fungsi untuk melooping dari kondisi state
        public void ActiveTrigger(Trigger trigger)
        {
            currenState = getNextState(currenState, trigger);
            Console.WriteLine("Posisi Awal " + currenState);
            if (currenState == posisiState.Terbang)
            {
                Console.WriteLine("posisi landing");
            }
            else if (currenState == posisiState.Berdiri)
            {
                Console.WriteLine("posisi take off");
            }
        }
        //memberikan output jika terjadi trigger sesuai dengan skenario

        public static void Main(string[] args)
        {
            PosisiKarakterGame Posisi = new PosisiKarakterGame();

            
            Console.WriteLine(Posisi.getNextState(posisiState.Terbang, Trigger.TombolX));
         /*   Posisi.ActiveTrigger(Trigger.TombolW);*/
        }
    }
}

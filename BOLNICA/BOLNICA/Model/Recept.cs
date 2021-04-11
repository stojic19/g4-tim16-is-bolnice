using System;

namespace Model
{
    public class Recept
    {
        public String IDRecepta { get; set; }
        public String IDLekara { get; set; }

        public String IDPacijenta { get; set; }
        public String KrajTerapije { get; set; }
        public String PocetakTerapije { get; set; }
        public int Satnica { get; set; }

        public int Kolicina { get; set; }

        public Lek Lek { get; set; }

        public Recept() { }

        public Recept(string iDRecepta, string iDLekara, String idPacijenta, String krajTerapije, String pocetakTerapije, int satnica, int kolicina, Lek lek)
        {
            IDRecepta = iDRecepta;
            IDLekara = iDLekara;
            IDPacijenta = idPacijenta;
            KrajTerapije = krajTerapije;
            PocetakTerapije = pocetakTerapije;
            Satnica = satnica;
            Kolicina = kolicina;
            Lek = lek;
        }
    }
}
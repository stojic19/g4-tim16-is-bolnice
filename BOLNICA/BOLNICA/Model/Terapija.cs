using System;

namespace Model
{
    public class Terapija
    {

        public String IDTerapije { get; set; }
        public String IDAnamneze { get; set; }
        public DateTime PocetakTerapije { get; set; }
        public DateTime KrajTerapije { get; set; }
        public String Kolicina { get; set; }
        public String Satnica { get; set; }

        
        public Lek PreporucenLek { get; set; }

        public Terapija() { }

        public Terapija(string iDTerapije, DateTime pocetakTerapije, DateTime krajTerapije, string kolicina, string satnica, Lek preporucenLek)
        {
            IDTerapije = iDTerapije;
            PocetakTerapije = pocetakTerapije;
            KrajTerapije = krajTerapije;
            Kolicina = kolicina;
            Satnica = satnica;
            PreporucenLek = preporucenLek;
        }

        public Terapija(string iDTerapije, string iDAnamneze, DateTime pocetakTerapije, DateTime krajTerapije, string kolicina, string satnica, Lek preporucenLek)
        {
            IDTerapije = iDTerapije;
            IDAnamneze = iDAnamneze;
            PocetakTerapije = pocetakTerapije;
            KrajTerapije = krajTerapije;
            Kolicina = kolicina;
            Satnica = satnica;
            PreporucenLek = preporucenLek;
        }
    }
}
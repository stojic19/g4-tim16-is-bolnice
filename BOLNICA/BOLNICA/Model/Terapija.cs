using System;

namespace Model
{
    public class Terapija
    {

        public String IDTerapije { get; set; }
        public String IDAnamneze { get; set; }
        public String PocetakTerapije { get; set; }
        public String KrajTerapije { get; set; }
        public String Kolicina { get; set; }
        public String Satnica { get; set; }

        
        public Lek PreporucenLek { get; set; }

        public Terapija() { }

        public Terapija(string iDTerapije, string pocetakTerapije, string krajTerapije, string kolicina, string satnica, Lek preporucenLek)
        {
            IDTerapije = iDTerapije;
            PocetakTerapije = pocetakTerapije;
            KrajTerapije = krajTerapije;
            Kolicina = kolicina;
            Satnica = satnica;
            PreporucenLek = preporucenLek;
        }

        public Terapija(string iDTerapije, string iDAnamneze, string pocetakTerapije, string krajTerapije, string kolicina, string satnica, Lek preporucenLek)
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
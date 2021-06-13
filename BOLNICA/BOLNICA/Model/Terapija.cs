using System;

namespace Model
{
    public class Terapija
    {

        private String iDTerapije;
        private String iDAnamneze;
        private DateTime pocetakTerapije;
        private DateTime krajTerapije;
        private String kolicina;
        private String satnica;
        private String uputsvoKonzumiranja;
        private Lek preporucenLek;
        public Terapija() { }

        public Terapija(string iDTerapije, string iDAnamneze, DateTime pocetakTerapije, DateTime krajTerapije, string kolicina, string satnica, string uputsvoKonzumiranja, Lek preporucenLek)
        {
            IDTerapije = iDTerapije;
            IDAnamneze = iDAnamneze;
            PocetakTerapije = pocetakTerapije;
            KrajTerapije = krajTerapije;
            Kolicina = kolicina;
            Satnica = satnica;
            UputsvoKonzumiranja = uputsvoKonzumiranja;
            PreporucenLek = preporucenLek;
        }

        public string IDTerapije { get => iDTerapije; set => iDTerapije = value; }
        public string IDAnamneze { get => iDAnamneze; set => iDAnamneze = value; }
        public DateTime PocetakTerapije { get => pocetakTerapije; set => pocetakTerapije = value; }
        public DateTime KrajTerapije { get => krajTerapije; set => krajTerapije = value; }
        public string Kolicina { get => kolicina; set => kolicina = value; }
        public string Satnica { get => satnica; set => satnica = value; }
        public string UputsvoKonzumiranja { get => uputsvoKonzumiranja; set => uputsvoKonzumiranja = value; }
        public Lek PreporucenLek { get => preporucenLek; set => preporucenLek = value; }
    }
}
using System;
using System.ComponentModel;

namespace Model
{
    public class Lek
    {
        public String IDLeka { get; set; }
        public String NazivLeka { get; set; }
        public String Jacina { get; set; }
        public int Kolicina { get; set; }
        public String Proizvodjac { get; set; }
        public String Sastojci { get; set; }
        public bool JeVerifikovan { get; set; }

        public Lek()
        {
        }

        public Lek(string iDLeka, string nazivLeka, string jacina)
        {
            IDLeka = iDLeka;
            NazivLeka = nazivLeka;
            Jacina = jacina;
        }

        public Lek(string iDLeka, string nazivLeka, string jacina, int kolicina, String proizvodjac, String sastojci, bool verifikovan)
        {
            IDLeka = iDLeka;
            NazivLeka = nazivLeka;
            Jacina = jacina;
            Kolicina = kolicina;
            Proizvodjac = proizvodjac;
            Sastojci = sastojci;
            JeVerifikovan = verifikovan;
        }


    }
}
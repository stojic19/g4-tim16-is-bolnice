using Bolnica.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Model
{
    public class Lek
    {
        private double v;

        public String IDLeka { get; set; }
        public String NazivLeka { get; set; }
        public String Jacina { get; set; }
        public int Kolicina { get; set; }
        public String Proizvodjac { get; set; }
        public List<Sastojak> Sastojci { get; set; } = new List<Sastojak>();
        public bool Verifikacija { get; set; }
        public List<Lek> Zamene { get; set; } = new List<Lek>();

        public Lek(){}

        public Lek(string iDLeka, string nazivLeka, string jacina)
        {
            IDLeka = iDLeka;
            NazivLeka = nazivLeka;
            Jacina = jacina;
        }


        public Lek(string iDLeka, string nazivLeka, string jacina, int kolicina, string proizvodjac, List<Sastojak> sastojci, bool verifikacija)
        {
            IDLeka = iDLeka;
            NazivLeka = nazivLeka;
            Jacina = jacina;
            Kolicina = kolicina;
            Proizvodjac = proizvodjac;
            Sastojci = sastojci;
            Verifikacija = verifikacija;
        }

        public Lek(string iDLeka, string nazivLeka, string jacina, int kolicina)
        {
            IDLeka = iDLeka;
            NazivLeka = nazivLeka;
            Jacina = jacina;
            Kolicina = kolicina;
        }
    }
}
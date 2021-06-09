using Bolnica.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Model
{
    public class Lek
    {
        private String iDLeka;
        private String nazivLeka;
        private String jacina;
        private int kolicina;
        private String proizvodjac;
        private List<Sastojak> sastojci = new List<Sastojak>();
        private List<Lek> zamene = new List<Lek>();
        private bool verifikacija;

        public string IDLeka { get => iDLeka; set => iDLeka = value; }
        public string NazivLeka { get => nazivLeka; set => nazivLeka = value; }
        public string Jacina { get => jacina; set => jacina = value; }
        public int Kolicina { get => kolicina; set => kolicina = value; }
        public string Proizvodjac { get => proizvodjac; set => proizvodjac = value; }
        public List<Sastojak> Sastojci { get => sastojci; set => sastojci = value; }
        public List<Lek> Zamene { get => zamene; set => zamene = value; }
        public bool Verifikacija { get => verifikacija; set => verifikacija = value; }

        public Lek() { }
        public Lek(string iDLeka, string nazivLeka, string jacina)
        {
            IDLeka = iDLeka;
            NazivLeka = nazivLeka;
            Jacina = jacina;
        }

        public Lek(string iDLeka, string nazivLeka, string jacina, int kolicina)
        {
            IDLeka = iDLeka;
            NazivLeka = nazivLeka;
            Jacina = jacina;
            Kolicina = kolicina;
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
        public Lek(string iDLeka, string nazivLeka, string jacina, int kolicina, List<Sastojak> sastojci, string proizvodjac)
        {
            IDLeka = iDLeka;
            NazivLeka = nazivLeka;
            Jacina = jacina;
            Kolicina = kolicina;
            Sastojci = sastojci;
            Proizvodjac = proizvodjac;

        }
    }
}
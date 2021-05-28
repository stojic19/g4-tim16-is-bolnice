
using Bolnica;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Model
{
    public class Pacijent : Osoba
    {
        private VrsteNaloga vrstaNaloga;
        private ZdravstveniKarton zdravstveniKarton;
        private int zloupotrebioSistem;
        private bool blokiran;

        public VrsteNaloga VrstaNaloga { get => vrstaNaloga; set => vrstaNaloga = value; }
        public ZdravstveniKarton ZdravstveniKarton { get => zdravstveniKarton; set => zdravstveniKarton = value; }
        public int ZloupotrebioSistem { get => zloupotrebioSistem; set => zloupotrebioSistem = value; }
        public bool Blokiran { get => blokiran; set => blokiran = value; }

        public Pacijent() { }

        public String imePrezime()
        {
            return (this.Ime + " " + this.Prezime);
        }
        public Pacijent(string ime, string prezime, string jmbg, Pol pol)
        {
            string korisnickoIme = generisiID();
            this.KorisnickoIme = korisnickoIme;
            this.Ime = ime;
            this.Prezime = prezime;
            this.DatumRodjenja = DateTime.Now;
            this.Pol = pol;
            this.AdresaStanovanja = "";
            this.Jmbg = jmbg;
            this.KontaktTelefon = "";
            this.Email = "";
            this.VrstaNaloga = VrsteNaloga.gost;
            this.Lozinka = "";
            this.ZdravstveniKarton = new ZdravstveniKarton(korisnickoIme);
            ZloupotrebioSistem = 0;
            Blokiran = false;
        }

        public Pacijent(string korisnickoIme, string ime, string prezime, DateTime datum, Pol pol, string jmbg, string adresa, string telefon, string email, VrsteNaloga vrstaNaloga, string lozinka)
        {
            if (korisnickoIme.Length == 0)
                this.KorisnickoIme = generisiID();
            else
                this.KorisnickoIme = korisnickoIme;
            this.Ime = ime;
            this.Prezime = prezime;
            this.DatumRodjenja = datum;
            this.Pol = pol;
            this.AdresaStanovanja = adresa;
            this.Jmbg = jmbg;
            this.KontaktTelefon = telefon;
            this.Email = email;
            this.VrstaNaloga = vrstaNaloga;
            this.Lozinka = lozinka;
            this.ZdravstveniKarton = new ZdravstveniKarton(korisnickoIme);
            ZloupotrebioSistem = 0;
            Blokiran = false;
        }
        public Pacijent(string korisnickoIme, string ime, string prezime, DateTime datum, Pol pol, string jmbg, string adresa, string telefon, string email, VrsteNaloga vrstaNaloga)
        {
            if (korisnickoIme.Length == 0)
                this.KorisnickoIme = generisiID();
            else
                this.KorisnickoIme = korisnickoIme;
            this.Ime = ime;
            this.Prezime = prezime;
            this.DatumRodjenja = datum;
            this.Pol = pol;
            this.AdresaStanovanja = adresa;
            this.Jmbg = jmbg;
            this.KontaktTelefon = telefon;
            this.Email = email;
            this.VrstaNaloga = vrstaNaloga;
            this.Lozinka = "";
            this.ZdravstveniKarton = new ZdravstveniKarton(korisnickoIme);
            ZloupotrebioSistem = 0;
            Blokiran = false;
        }
        public String DobaviPolTekst()
        {

            if (Pol == Pol.zenski)
            {
                return "�";
            }
            return "M";

        }

        public String DobaviVrstuNalogaTekst()
        {

            if (VrstaNaloga == VrsteNaloga.gost)
            {
                return "Gost";
            }
            return "Regularan";
        }
        public static string generisiID()
        {
            return Guid.NewGuid().ToString();
        }

        public List<Alergeni> DobaviAlergene()
        {
            return ZdravstveniKarton.DobaviAlergene();
        }

        public void DodajAlergen(Alergeni alergenZaDodavanje)
        {
            ZdravstveniKarton.DodajAlergen(alergenZaDodavanje);
        }

        public void IzmeniAlergen(Alergeni alergenZaIzmenu)
        {
            ZdravstveniKarton.IzmeniAlergen(alergenZaIzmenu);
        }

        public void UkloniAlergen(Alergeni alergenZaUklanjanje)
        {
            ZdravstveniKarton.UkloniAlergen(alergenZaUklanjanje);
        }

    }
}
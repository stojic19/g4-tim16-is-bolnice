
using Bolnica;
using System;
using System.ComponentModel;

namespace Model
{
    public class Pacijent : Osoba
    {

        public VrsteNaloga VrstaNaloga { get; set; }

        public ZdravstveniKarton ZdravstveniKarton { get; set; }

        public int ZloupotrebioSistem { get; set; }
        public bool Blokiran { get; set; }


        public Pacijent() { }



        public Pacijent(string korisnickoIme)
        {
            this.KorisnickoIme = korisnickoIme;
        }

        public String imePrezime()
        {
            return (this.Ime + " " + this.Prezime);
        }
        public Pacijent(string ime,string prezime,string jmbg,Pol pol)
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

        public String DobaviPolTekst()
        {

            if (Pol == Pol.zenski)
            {
                return "Ž";
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
    }
}
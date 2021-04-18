
using Bolnica;
using System;
using System.ComponentModel;

namespace Model
{
    public class Pacijent : Osoba


    {
      
        public VrsteNaloga VrstaNaloga { get; set; }

        public ZdravstveniKarton ZdravstveniKarton { get; set; }
        

        public Pacijent() { }

    

    public Pacijent(string korisnickoIme)
        {
            this.KorisnickoIme = korisnickoIme;
        }
       
        public String imePrezime()
        {
            return (this.Ime + this.Prezime);
        }


        public Pacijent(string korisnickoIme, string ime, string prezime, DateTime datum,Pol pol, string jmbg, string adresa, string telefon, string email, VrsteNaloga vrstaNaloga, string lozinka)
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
        }

    }
}
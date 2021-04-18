
using System;
using System.ComponentModel;

namespace Model
{
   public class Osoba: INotifyPropertyChanged
   {
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public String Jmbg { get; set; }
        public String AdresaStanovanja { get; set; }
        public String KontaktTelefon { get; set; }
        public String Email { get; set; }

        public String KorisnickoIme { get; set; }
        public String Lozinka { get; set; }

        public Pol Pol { get; set; }

        public Osoba(string korisnickoIme, string ime, string prezime, DateTime datum, Pol pol, string jmbg, string adresa, string telefon, string email, string lozinka)
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
            this.Lozinka = lozinka;
        }

        public Osoba() { }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
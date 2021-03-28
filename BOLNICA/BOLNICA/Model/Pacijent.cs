
using System;
using System.ComponentModel;

namespace Model
{
   public class Pacijent : Osoba, INotifyPropertyChanged
    {
      public String KorisnickoIme { get; set; }

        public Pacijent() { }
        public Pacijent(string korisnickoIme)
        {
            this.KorisnickoIme = korisnickoIme;
        }

        public String imePrezime()
        {
            return (this.Ime + this.Prezime);
        }
        public Pacijent(string korisnickoIme, string ime, string prezime, DateTime datum, string jmbg, string adresa, string telefon, string email)
        {
            this.KorisnickoIme = korisnickoIme;
            this.Ime = ime;
            this.Prezime = prezime;
            this.DatumRodjenja = datum;
            this.AdresaStanovanja = adresa;
            this.Jmbg = jmbg;
            this.KontaktTelefon = telefon;
            this.Email = email;
            this.Uloga = Uloge.pacijent;
        }
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
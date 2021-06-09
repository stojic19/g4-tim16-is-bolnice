using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bolnica.ViewModel.SekretarViewModel
{
    public class DodavanjeNalogaViewModel : SekretarViewModel
    {
        private NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        private String poruka;
        private PacijentDTO podaci;

        public DodavanjeNalogaViewModel()
        {
            Podaci = new PacijentDTO();
            potvrdiKomanda = new RelayCommand(Potvrdi);
            odustaniKomanda = new RelayCommand(Odustani);
        }

        public PacijentDTO Podaci
        {
            get { return podaci; }
            set
            {
                podaci = value;
                OnPropertyChanged();
            }
        }
        public string Poruka
        {
            get { return poruka; }
            set { poruka = value; OnPropertyChanged("Poruka"); }
        }

        private RelayCommand potvrdiKomanda;

        public RelayCommand PotvrdiKomanda
        {
            get { return potvrdiKomanda; }
        }
        public void Potvrdi()
        {
            if (IspravniUnetiPodaci())
            {
                naloziPacijenataKontroler.DodajNalog(podaci);

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new PrikazNalogaSekretar();
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
        }
        private bool IspravniUnetiPodaci()
        {
            if (Podaci.Ime.Equals(""))
            {
                Poruka = "Morate uneti ime pacijenta!";
                return false;
            }
            if (Podaci.Prezime.Equals(""))
            {
                Poruka = "Morate uneti prezime pacijenta!";
                return false;
            }
            if (Podaci.Jmbg.Equals(""))
            {
                Poruka = "Morate uneti jmbg pacijenta!";
                return false;
            }

            if (Podaci.VrstaNalogaInt == 0)
            {
                Podaci.VrstaNaloga = VrsteNaloga.regularan;
                if (Podaci.KorisnickoIme.Equals(""))
                {
                    Poruka = "Morate uneti korisničko ime pacijenta!";
                    return false;
                }
                if (Podaci.AdresaStanovanja.Equals(""))
                {
                    Poruka = "Morate uneti adresu pacijenta!";
                    return false;
                }
                if (Podaci.KontaktTelefon.Equals(""))
                {
                    Poruka = "Morate uneti kontakt telefon pacijenta!";
                    return false;
                }
                if (Podaci.Email.Equals(""))
                {
                    Poruka = "Morate uneti email pacijenta!";
                    return false;
                }
                if (Podaci.Lozinka.Equals(""))
                {
                    Poruka = "Morate uneti lozinku pacijenta!";
                    return false;
                }
                if (Podaci.Lozinka.Length < 8)
                {
                    Poruka = "Lozinka se mora sastojati od minimum 8 znakova!";
                    return false;
                }
                if (!naloziPacijenataKontroler.DaLiJeKorisnickoImeJedinstveno(Podaci.KorisnickoIme))
                {
                    Poruka = "Već postoji uneto korisničko ime!";
                    return false;
                }
            }
            else
            {
                Podaci.VrstaNaloga = VrsteNaloga.gost;
            }
            if(Podaci.PolInt == 0)
            {
                Podaci.Pol = Pol.zenski;
            }
            else
            {
                Podaci.Pol = Pol.muski;
            }
            if (!naloziPacijenataKontroler.DaLiJeJmbgJedinstven(Podaci.Jmbg))
            {
                Poruka = "Već postoji uneti jmbg!";
                return false;
            }
            return true;
        }
        private RelayCommand odustaniKomanda;

        public RelayCommand OdustaniKomanda
        {
            get { return odustaniKomanda; }
        }
        public void Odustani()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new PrikazNalogaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}

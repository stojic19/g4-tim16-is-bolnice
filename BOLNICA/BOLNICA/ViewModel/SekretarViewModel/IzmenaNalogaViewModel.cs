using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.ViewModel.SekretarViewModel.AbstractKlase;
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
    public class IzmenaNalogaViewModel : PotvrdiOdustaniViewModel
    {
        private NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        KorisnikKontroler korisnikKontroler = new KorisnikKontroler();
        private PacijentDTO podaci;
        private int tipNaloga;
        private string korisnickoIme;
        private string jmbg;

        public IzmenaNalogaViewModel(String idPacijenta)
        {
            Podaci = naloziPacijenataKontroler.PretraziPoId(idPacijenta);
            tipNaloga = Podaci.VrstaNalogaInt;
            korisnickoIme = idPacijenta;
            jmbg = Podaci.Jmbg;
            PotvrdiKomanda = new RelayCommand(Potvrdi);
            OdustaniKomanda = new RelayCommand(Odustani);
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

        public override void Potvrdi()
        {
            if (IspravniUnetiPodaci())
            {
                naloziPacijenataKontroler.IzmeniNalog(Podaci);
                korisnikKontroler.IzmeniPacijenta(Podaci);

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new PrikazNalogaSekretar();
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
        }
        private bool IspravniUnetiPodaci()
        {
            if (Podaci.VrstaNalogaInt == 1 && tipNaloga == 0)
            {
                Poruka = "Regularan nalog se ne može promeniti u gostujući!";
                Podaci.VrstaNalogaInt = 0;
                return false;
            }
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
                if (!Podaci.KorisnickoIme.Equals(korisnickoIme))
                {
                    if (!naloziPacijenataKontroler.DaLiJeKorisnickoImeJedinstveno(Podaci.KorisnickoIme))
                    {
                        Poruka = "Već postoji uneto korisničko ime!";
                        return false;
                    }
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
            if (!Podaci.Jmbg.Equals(jmbg))
            {
                if (!naloziPacijenataKontroler.DaLiJeJmbgJedinstven(Podaci.Jmbg))
                {
                    Poruka = "Već postoji uneti jmbg!";
                    return false;
                }
            }
            return true;
        }

        public override void Odustani()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new PrikazNalogaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}

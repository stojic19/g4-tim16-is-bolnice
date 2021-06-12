using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.ViewModel.SekretarViewModel.AbstractKlase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bolnica.ViewModel.SekretarViewModel
{
    public class IzmenaAlergenaViewModel : PotvrdiOdustaniViewModel
    {
        private String korisnickoIme;
        private AlergeniKontroler alergeniKontroler;
        private AlergenDTO podaci;

        public IzmenaAlergenaViewModel(String korisnickoImePacijenta, string idAlergena)
        {
            alergeniKontroler = new AlergeniKontroler(korisnickoImePacijenta);
            Podaci = alergeniKontroler.DobaviAlergenPacijentaPoId(idAlergena);
            this.korisnickoIme = korisnickoImePacijenta;
            PotvrdiKomanda = new RelayCommand(Potvrdi);
            OdustaniKomanda = new RelayCommand(Odustani);
        }

        public AlergenDTO Podaci
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
                alergeniKontroler.IzmeniAlergen(Podaci);

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new AlergeniSekretar(korisnickoIme);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
        }
        private bool IspravniUnetiPodaci()
        {
            if (Podaci.OpisReakcije.Equals(""))
            {
                Poruka = "Morate uneti opis reaksije!";
                return false;
            }
            if (Podaci.VremeZaPojavu.Equals(""))
            {
                Poruka = "Morate uneti vreme potrebno za pojavu reakcije!";
                return false;
            }
            return true;
        }

        public override void Odustani()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new AlergeniSekretar(korisnickoIme);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}

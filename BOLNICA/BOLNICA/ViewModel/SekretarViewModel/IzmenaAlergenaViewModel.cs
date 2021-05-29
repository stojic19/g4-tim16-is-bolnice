using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bolnica.ViewModel.PacijentViewModel
{
    public class IzmenaAlergenaViewModel : ViewModel
    {
        private String korisnickoIme;
        private AlergeniKontroler alergeniKontroler = new AlergeniKontroler();
        private String poruka;
        private AlergenDTO podaci;

        public IzmenaAlergenaViewModel(String korisnickoImePacijenta, string idAlergena)
        {
            Podaci = alergeniKontroler.DobaviAlergenPacijentaPoId(korisnickoImePacijenta, idAlergena);
            this.korisnickoIme = korisnickoImePacijenta;
            potvrdiKomanda = new RelayCommand(Potvrdi);
            odustaniKomanda = new RelayCommand(Odustani);
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
                alergeniKontroler.IzmeniAlergen(korisnickoIme, Podaci);

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
        private RelayCommand odustaniKomanda;

        public RelayCommand OdustaniKomanda
        {
            get { return odustaniKomanda; }
        }
        public void Odustani()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new AlergeniSekretar(korisnickoIme);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}

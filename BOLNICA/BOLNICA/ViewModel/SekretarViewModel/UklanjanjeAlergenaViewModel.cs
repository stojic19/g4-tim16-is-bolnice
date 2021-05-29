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
    public class UklanjanjeAlergenaViewModel : ViewModel
    {
        private String korisnickoIme;
        private AlergeniKontroler alergeniKontroler = new AlergeniKontroler();
        private String idAlergena;

        public UklanjanjeAlergenaViewModel(String korisnickoImePacijenta, string idAlergena)
        {
            this.korisnickoIme = korisnickoImePacijenta;
            this.idAlergena = idAlergena;
            potvrdiKomanda = new RelayCommand(Potvrdi);
            odustaniKomanda = new RelayCommand(Odustani);
        }

        private RelayCommand potvrdiKomanda;

        public RelayCommand PotvrdiKomanda
        {
            get { return potvrdiKomanda; }
        }
        public void Potvrdi()
        {
            alergeniKontroler.UkloniAlergen(korisnickoIme, idAlergena);

            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new AlergeniSekretar(korisnickoIme);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
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

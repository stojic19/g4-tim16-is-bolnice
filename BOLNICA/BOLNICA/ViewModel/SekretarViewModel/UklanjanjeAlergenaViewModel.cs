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

namespace Bolnica.ViewModel.SekretarViewModel
{
    public class UklanjanjeAlergenaViewModel : SekretarViewModel
    {
        private String korisnickoIme;
        private AlergeniKontroler alergeniKontroler;
        private String idAlergena;

        public UklanjanjeAlergenaViewModel(String korisnickoImePacijenta, string idAlergena)
        {
            alergeniKontroler = new AlergeniKontroler(korisnickoImePacijenta);
            this.KorisnickoIme = korisnickoImePacijenta;
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
            alergeniKontroler.UkloniAlergen(idAlergena);

            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new AlergeniSekretar(KorisnickoIme);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        
        private RelayCommand odustaniKomanda;

        public RelayCommand OdustaniKomanda
        {
            get { return odustaniKomanda; }
        }

        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }

        public void Odustani()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new AlergeniSekretar(KorisnickoIme);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}

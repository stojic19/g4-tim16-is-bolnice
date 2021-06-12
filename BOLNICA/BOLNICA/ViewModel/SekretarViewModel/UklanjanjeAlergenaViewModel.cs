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
    public class UklanjanjeAlergenaViewModel : PotvrdiOdustaniViewModel
    {
        private String korisnickoIme;
        private AlergeniKontroler alergeniKontroler;
        private String idAlergena;

        public UklanjanjeAlergenaViewModel(String korisnickoImePacijenta, string idAlergena)
        {
            alergeniKontroler = new AlergeniKontroler(korisnickoImePacijenta);
            this.KorisnickoIme = korisnickoImePacijenta;
            this.idAlergena = idAlergena;
            PotvrdiKomanda = new RelayCommand(Potvrdi);
            OdustaniKomanda = new RelayCommand(Odustani);
        }

        public override void Potvrdi()
        {
            alergeniKontroler.UkloniAlergen(idAlergena);

            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new AlergeniSekretar(KorisnickoIme);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }

        public override void Odustani()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new AlergeniSekretar(KorisnickoIme);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}

using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.SekretarFolder;
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
    public class NaplataIzabraniPacijentViewModel : PotvrdiOdustaniViewModel
    {
        private String korisnickoIme;
        private ObservableCollection<PregledDTO> pregledi;
        public NaplataIzabraniPacijentViewModel(String korisnickoIme)
        {
            Pregledi = new ObservableCollection<PregledDTO>();
            this.korisnickoIme = korisnickoIme;
            OdustaniKomanda = new RelayCommand(Odustani);
            PotvrdiKomanda = new RelayCommand(Potvrdi);
        }
        public ObservableCollection<PregledDTO> Pregledi
        {
            get { return pregledi; }
            set
            {
                pregledi = value;
                OnPropertyChanged();
            }
        }
        public override void Odustani()
        {
           UserControl usc = null;
           GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

           usc = new NaplataUslugeSekretar();
           GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        public override void Potvrdi()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new NaplataUslugeSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}

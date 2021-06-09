using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.SekretarFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bolnica.ViewModel.SekretarViewModel
{
    public class NaplataIzabraniPacijentViewModel : SekretarViewModel
    {
        private String poruka;
        private String korisnickoIme;
        private ObservableCollection<PregledDTO> pregledi;
        public NaplataIzabraniPacijentViewModel(String korisnickoIme)
        {
            Pregledi = new ObservableCollection<PregledDTO>();
            this.korisnickoIme = korisnickoIme;
            odustaniKomanda = new RelayCommand(Odustani);
            potvrdiKomanda = new RelayCommand(Potvrdi);
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
        public string Poruka
        {
            get { return poruka; }
            set { poruka = value; OnPropertyChanged("Poruka"); }
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

           usc = new NaplataUslugeSekretar();
           GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private RelayCommand potvrdiKomanda;

        public RelayCommand PotvrdiKomanda
        {
            get { return potvrdiKomanda; }
        }
        public void Potvrdi()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new NaplataUslugeSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}

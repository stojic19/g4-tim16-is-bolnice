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
    public class AlergeniViewModel : ViewModel
    {
        private String korisnickoIme;
        private ObservableCollection<AlergeniPrikazDTO> alergeniPacijenta;
        private AlergeniKontroler alergeniKontroler = new AlergeniKontroler();
        private AlergeniPrikazDTO selektovaniAlergen;
        private String poruka;
  
        public AlergeniViewModel(String korisnickoImePacijenta)
        {
            this.korisnickoIme = korisnickoImePacijenta;
            UcitajUKolekciju();
            dodajAlergenKomanda = new RelayCommand(DodajAlergen);
            izmeniAlergenKomanda = new RelayCommand(IzmeniAlergen);
            ukloniAlergenKomanda = new RelayCommand(UkloniAlergen);
            nazadKomanda = new RelayCommand(Nazad);
        }

        public void UcitajUKolekciju()
        {
            AlergeniPacijenta = new ObservableCollection<AlergeniPrikazDTO>();
            foreach (AlergeniPrikazDTO alergeniPrikazDTO in alergeniKontroler.DobaviAlergenePoIdPacijenta(korisnickoIme))
            {
                AlergeniPacijenta.Add(alergeniPrikazDTO);
            }
        }
        public ObservableCollection<AlergeniPrikazDTO> AlergeniPacijenta
        {
            get { return alergeniPacijenta; }
            set
            {
                alergeniPacijenta = value;
                OnPropertyChanged();
            }
        }
        public AlergeniPrikazDTO SelektovaniAlergen
        {
            get { return selektovaniAlergen; }
            set
            {
                selektovaniAlergen = value;
                OnPropertyChanged();
            }
        }

        public string Poruka
        {
            get { return poruka; }
            set { poruka = value; OnPropertyChanged("Poruka"); }
        }

        private RelayCommand ukloniAlergenKomanda;

        public RelayCommand UkloniAlergenKomanda
        {
            get { return ukloniAlergenKomanda; }
        }
        public void UkloniAlergen()
        {
            if (selektovaniAlergen != null)
            {
                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new UklanjanjeAlergena(korisnickoIme, selektovaniAlergen.IdAlergena);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                Poruka = "*Morate izabrati alergen za uklanjanje!";
            }

        }

        private RelayCommand izmeniAlergenKomanda;

        public RelayCommand IzmeniAlergenKomanda
        {
            get { return izmeniAlergenKomanda; }
        }
        public void IzmeniAlergen()
        {
            if (selektovaniAlergen != null)
            {
                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new IzmenaAlergena(korisnickoIme, selektovaniAlergen.IdAlergena);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                Poruka = "*Morate izabrati alergen za izmenu!";
            }
        }


        private RelayCommand dodajAlergenKomanda;

        public RelayCommand DodajAlergenKomanda
        {
            get { return dodajAlergenKomanda; }
        }
        public void DodajAlergen()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new DodavanjeAlergena(korisnickoIme);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private RelayCommand nazadKomanda;

        public RelayCommand NazadKomanda
        {
            get { return nazadKomanda; }
        }
        public void Nazad()
        {
            // povratak na prikaz pacijenata
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new PrikazNalogaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}

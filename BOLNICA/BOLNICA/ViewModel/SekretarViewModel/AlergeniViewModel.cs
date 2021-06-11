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
    public class AlergeniViewModel : CRUDViewModel
    {
        private String korisnickoIme;
        private ObservableCollection<AlergeniPrikazDTO> alergeniPacijenta;
        private AlergeniKontroler alergeniKontroler;
        private AlergeniPrikazDTO selektovaniAlergen;
  
        public AlergeniViewModel(String korisnickoImePacijenta)
        {
            this.korisnickoIme = korisnickoImePacijenta;
            alergeniKontroler = new AlergeniKontroler(korisnickoImePacijenta);
            UcitajUKolekciju();
            DodajKomanda = new RelayCommand(Dodaj);
            IzmeniKomanda = new RelayCommand(Izmeni);
            UkloniKomanda = new RelayCommand(Ukloni);
            nazadKomanda = new RelayCommand(Nazad);
        }

        public void UcitajUKolekciju()
        {
            AlergeniPacijenta = new ObservableCollection<AlergeniPrikazDTO>();
            foreach (AlergeniPrikazDTO alergeniPrikazDTO in alergeniKontroler.DobaviAlergene())
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

        public override void Ukloni()
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
        
        public override void Izmeni()
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

        public override void Dodaj()
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

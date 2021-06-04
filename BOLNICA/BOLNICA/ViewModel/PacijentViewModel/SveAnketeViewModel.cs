using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.PacijentFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.ViewModel.PacijentViewModel
{
    public class SveAnketeViewModel: ViewModel
    {
        private String poruka;
        private ObservableCollection<PregledDTO> obavljeniPregledi;
        private PregledDTO selektovaniTermin;
        private PreglediKontroler preglediKontroler = new PreglediKontroler();
        private String korisnickoIme;


        public SveAnketeViewModel(String korisnickoIme)
        {
            this.korisnickoIme = korisnickoIme;
            UcitajUKolekciju();
            popuniAnketu = new RelayCommand(Popuni);
            oceniBolnicu = new RelayCommand(Oceni);
        }
        public void UcitajUKolekciju()
        {
            ObavljeniPregledi = new ObservableCollection<PregledDTO>();
            foreach (PregledDTO pregled in preglediKontroler.DobaviSveNeocenjenePregledePacijenta(KorisnickoIme))
                ObavljeniPregledi.Add(pregled);

        }
        public ObservableCollection<PregledDTO> ObavljeniPregledi
        {
            get { return obavljeniPregledi; }
            set { obavljeniPregledi = value; }
        }
        public String KorisnickoIme
        {
            get { return korisnickoIme; }
            set { korisnickoIme = value; }
        }

        public PregledDTO SelektovaniTermin
        {
            get { return selektovaniTermin; }
            set { selektovaniTermin = value; }
        }
        public String Poruka
        {
            get { return poruka; }
            set
            {
                poruka = value;
                OnPropertyChanged();
            }

        }


        private RelayCommand popuniAnketu;
        public RelayCommand PopuniAnketu
        {
            get { return popuniAnketu; }
        }
        public void Popuni()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PopuniAnketu(SelektovaniTermin));
        }

        private RelayCommand oceniBolnicu;
        public RelayCommand OceniBolnicu
        {
            get { return oceniBolnicu; }
        }
        public void Oceni()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new OcenjivanjeBolnice(KorisnickoIme));
        }
    }
}

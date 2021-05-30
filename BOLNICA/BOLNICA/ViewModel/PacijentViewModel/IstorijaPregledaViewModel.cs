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
    public class IstorijaPregledaViewModel: ViewModel
    {
        private String poruka;
        private ObservableCollection<PregledDTO> obavljeniPregledi;
        private PregledDTO selektovaniTermin;
        private PreglediKontroler preglediKontroler = new PreglediKontroler();
        private String korisnickoIme;
        public IstorijaPregledaViewModel(String korisnickoIme)
        {
            this.korisnickoIme = korisnickoIme;
            UcitajUKolekciju();
            izvestajPregleda = new RelayCommand(PrikaziIzvestaj);
            vratiSe = new RelayCommand(VratiSeNaIstoriju);
        }
        public void UcitajUKolekciju()
        {
            ObavljeniPregledi = new ObservableCollection<PregledDTO>();
            foreach (PregledDTO pregled in preglediKontroler.DobaviSveObavljenePregledePacijenta(KorisnickoIme))
            {
                if (pregled.Anamneza.IdAnamneze != null)
                    obavljeniPregledi.Add(pregled);
            }
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


        private RelayCommand izvestajPregleda;
        public RelayCommand IzvestajPregleda
        {
            get { return izvestajPregleda; }
        }
        public void PrikaziIzvestaj()
        {
            if (SelektovaniTermin != null)
            {
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new IzvestajSaPregleda(SelektovaniTermin));
            }
            else
            {
                Poruka = "*Izaberite pregled!";
            }
        }

        private RelayCommand vratiSe;
        public RelayCommand VratiSe
        {
            get { return vratiSe; }
        }
        public void VratiSeNaIstoriju()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazKartona(korisnickoIme));
        }
    }
}

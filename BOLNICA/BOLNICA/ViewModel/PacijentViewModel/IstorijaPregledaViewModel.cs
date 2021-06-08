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
            poljePretrage = DateTime.Now.Date;
            this.korisnickoIme = korisnickoIme;
            UcitajUKolekciju();
            izvestajPregleda = new RelayCommand(PrikaziIzvestaj);
            vratiSe = new RelayCommand(VratiSeNaIstoriju);
            pretraga = new RelayCommand(Pretrazi);
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

        private DateTime poljePretrage;
        public DateTime PoljePretrage
        {
            get { return poljePretrage; }
            set
            {
                poljePretrage = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand pretraga;

        public RelayCommand Pretraga
        {
            get { return pretraga; }
        }

        public void Pretrazi()
        {
            Poruka = "";
            List<PregledDTO> pretraga = PretragaTermina();
            if (pretraga.Count != 0)
            {
                ObavljeniPregledi.Clear();
                foreach (PregledDTO pregled in pretraga)
                {
                        ObavljeniPregledi.Add(pregled);
                }
                return;
            }
            Poruka = "Ne postoje obavljeni termini za uneti datum!";

        }

        private List<PregledDTO> PretragaTermina()
        {
            List<PregledDTO> rezultatiPretrage = new List<PregledDTO>();
            foreach (PregledDTO pregled in (preglediKontroler.DobaviSveObavljenePregledePacijenta(korisnickoIme)).OrderBy(user => user.Datum).ToList())
            {
                if (DateTime.Compare(pregled.Termin.Datum.Date, PoljePretrage.Date) == 0)
                    rezultatiPretrage.Add(pregled);
            }
            return rezultatiPretrage;
        }
    }
}

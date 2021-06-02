using Bolnica.Izvestaj.Pacijent;
using Bolnica.Komande;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.ViewModel.PacijentViewModel
{
    public class IzvestajViewModel:ViewModel
    {
        private DateTime datumOd;
        private DateTime datumDo;
        private List<DateTime> interval;
        private String korisnickoIme;
        private String poruka;
        private String porukaNeuspeh;
        private RasporedTerapijeIzvestaj nedeljniIzvestajTerapije = new RasporedTerapijeIzvestaj();
        public IzvestajViewModel(String korisnickoIme)
        {
            this.korisnickoIme = korisnickoIme;
            datumOd = DateTime.Now.Date;
            datumDo = DateTime.Now.AddDays(6).Date;
            vratiSe = new RelayCommand(VratiSeNaTerapiju);
            kreiraj = new RelayCommand(KreirajIzvestaj);
        }

        public List<DateTime> Interval
        {
            get { return interval; }
            set
            {
                interval = value;
                OnPropertyChanged();
            }
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
        public String PorukaNeuspeh
        {
            get { return porukaNeuspeh; }
            set
            {
                porukaNeuspeh = value;
                OnPropertyChanged();
            }
        }
        public DateTime DatumOd
        {
            get { return datumOd; }
            set
            {
                datumOd = value;
                OnPropertyChanged();
            }
        }
        public DateTime DatumDo
        {
            get { return datumDo; }
            set
            {
                datumDo = value;
                OnPropertyChanged();
            }
        }
        public String KorisnickoIme
        {
            get { return korisnickoIme; }
            set
            {
                korisnickoIme = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand vratiSe;
        public RelayCommand VratiSe
        {
            get { return vratiSe; }
        }
        public void VratiSeNaTerapiju()
        {

            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazTerapijePacijent(KorisnickoIme));
        }

        private RelayCommand kreiraj;
        public RelayCommand Kreiraj
        {
            get { return kreiraj; }
        }
        public void KreirajIzvestaj()
        {
            DateTime? pocetak = DatumOd;
            DateTime? kraj = DatumDo;

            if (Validacija())
            {
                interval = new List<DateTime>();
                interval.Add(DatumOd);
                interval.Add(DatumDo);
                nedeljniIzvestajTerapije.StampajIzvestaj(interval, KorisnickoIme);
                PorukaNeuspeh = "";
                Poruka = "Vaš izveštaj se nalazi u folderu IzveštajiPacijenta!";

            }
            else
            {
                PorukaNeuspeh = "Popunite sva polja!";
            }
        }

        private bool Validacija()
        {

            DateTime? pocetak = DatumOd;
            DateTime? kraj = DatumDo;
            if (!pocetak.HasValue || !kraj.HasValue)
            {

                return false;
            }

            return true;
        }
    }
}

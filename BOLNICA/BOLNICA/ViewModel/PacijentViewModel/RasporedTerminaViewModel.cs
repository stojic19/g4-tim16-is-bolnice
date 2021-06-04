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

namespace Bolnica.ViewModel
{
    public class RasporedTerminaViewModel:ViewModel
    {
        private String korisnickoIme;
        private ObservableCollection<TerminDTO> zakazaniTerminiPacijenta;
        private TerminKontroler terminKontroler = new TerminKontroler();
        private NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        private TerminDTO selektovaniTermin;
        private String poruka;

        public ObservableCollection<TerminDTO> ZakazaniTerminiPacijenta
        {
            get { return zakazaniTerminiPacijenta; }
            set
            {
                zakazaniTerminiPacijenta = value;
                OnPropertyChanged();
            }
        }
        public RasporedTerminaViewModel(String korisnickoImePacijenta)
        {
            this.korisnickoIme = korisnickoImePacijenta;
            UcitajUKolekciju();
            otkaziPregledKomanda = new RelayCommand(OtkaziPregled);
            detaljiPregledaKomanda = new RelayCommand(PrikazDetalja);
            pomeriPregledKomanda = new RelayCommand(PomeriPregled);
        }

        public RasporedTerminaViewModel(TerminDTO izabraniTermin)
        {
            selektovaniTermin = izabraniTermin;
            this.potvrdiOtkazivanjeKomanda = new RelayCommand(Potvrdi);
            UcitajUKolekciju();
        }

        public void UcitajUKolekciju()
        {
            ZakazaniTerminiPacijenta = new ObservableCollection<TerminDTO>();
            foreach (TerminDTO termin in terminKontroler.DobaviSveZakazaneTerminePacijenta(korisnickoIme))
            {
                ZakazaniTerminiPacijenta.Add(termin);
            }
        }

        public TerminDTO SelektovaniTermin
        {
            get { return selektovaniTermin; }
            set
            {
                selektovaniTermin = value;
                OnPropertyChanged();
            }
        }

        public string Poruka
        {
            get { return poruka; }
            set { poruka = value; OnPropertyChanged("Poruka"); }
        }

        private RelayCommand otkaziPregledKomanda;

        public RelayCommand OtkaziPregledKomanda
        {
            get { return otkaziPregledKomanda; }
        }
        public void OtkaziPregled()
        {
            if (SelektovaniTermin != null)
            {
                if (Validacija())
                {
                    if (!naloziPacijenataKontroler.NalogJeBlokiran(korisnickoIme))
                    {

                        OtkazivanjeTerminaPacijent otkazivanje = new OtkazivanjeTerminaPacijent(SelektovaniTermin);
                        otkazivanje.Show();
                    }
                    else
                    {
                        Poruka = "Vas nalog je blokiran";
                    }
                }
                else
                {
                    Poruka = "Ne mozete otkazati termin koji je za manje od 24h!";
                }

            }
            else
            {
                Poruka = "*Morate izabrati termin da biste otkazali!";
            }

        }



        private bool Validacija()
        {
            if (DateTime.Compare(SelektovaniTermin.Datum.Date, DateTime.Now.Date) < 0)
            {
                return false;
            }
            else if (DateTime.Compare(SelektovaniTermin.Datum.Date, DateTime.Now.AddDays(1).Date) == 0)
            {
                if (!terminKontroler.ProveriMogucnostPomeranjaVreme(SelektovaniTermin.Vreme))
                {
                    return false;
                }
            }
            return true;
        }

        private RelayCommand potvrdiOtkazivanjeKomanda;

        public RelayCommand PotvrdiOtkazivanjeKomanda
        {
            get { return potvrdiOtkazivanjeKomanda; }
        }
        public void Potvrdi()
        {

            terminKontroler.OtkaziPregledPacijent(SelektovaniTermin);
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazRasporedaPacijent(korisnickoIme));

        }

        private RelayCommand pomeriPregledKomanda;

        public RelayCommand PomeriPregledKomanda
        {
            get { return pomeriPregledKomanda; }
        }
        public void PomeriPregled()
        {
            if (selektovaniTermin != null)
            {
                if (Validacija())
                {
                    if (!naloziPacijenataKontroler.NalogJeBlokiran(korisnickoIme))
                    {
                        PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
                        PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomeranjeSaPrioritetom(SelektovaniTermin));
                    }
                    else
                    {
                        Poruka = "Vas nalog je blokiran";
                    }
                }
                else
                {
                    Poruka = "Ne mozete pomeriti termin koji je za manje od 24h!";

                }

            }
            else
            {
                Poruka = "*Morate izabrati termin da biste pomerili pregled!";
            }
        }

        private RelayCommand detaljiPregledaKomanda;

        public RelayCommand DetaljiPregledaKomanda
        {
            get { return detaljiPregledaKomanda; }
        }
        public void PrikazDetalja()
        {
            if (selektovaniTermin != null)
            {
                DetaljiTermina detaljiTermina = new DetaljiTermina(SelektovaniTermin);
                detaljiTermina.Show();
            }
            else
            {
                Poruka = "*Morate izabrati termin da biste videli detalje!";
            }
        }


    

}
}

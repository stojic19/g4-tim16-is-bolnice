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
        private ZakazaniTerminiKontroler terminKontroler = new ZakazaniTerminiKontroler();
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
            PoljePretrage = DateTime.Now;
            otkaziPregledKomanda = new RelayCommand(OtkaziPregled);
            detaljiPregledaKomanda = new RelayCommand(PrikazDetalja);
            pomeriPregledKomanda = new RelayCommand(PomeriPregled);
            pretraga = new RelayCommand(Pretrazi);
        }

        public RasporedTerminaViewModel(TerminDTO izabraniTermin)
        {
            selektovaniTermin = izabraniTermin;
            UcitajUKolekciju();
           
        }

        public void UcitajUKolekciju()
        {
            ZakazaniTerminiPacijenta = new ObservableCollection<TerminDTO>();
            foreach (TerminDTO termin in terminKontroler.DobaviSveZakazaneTerminePacijenta(korisnickoIme).OrderByDescending(user => user.Datum).ToList())
            {
                ZakazaniTerminiPacijenta.Add(termin);
            }
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
            set { poruka = value; OnPropertyChanged(); }
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
                    if (!SelektovaniTermin.Lekar.Specijalizacija.ToString().Equals("nema"))
                    {
                        Poruka = "Možete otkazivati termine samo kod opšte prakse";
                        return;
                    }
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
            if (terminKontroler.ProveriMogucnostPomeranjaTermina(SelektovaniTermin))
            {
                return true;
            }
            return false;
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
                    if (!SelektovaniTermin.Lekar.Specijalizacija.ToString().Equals("nema"))
                    {
                        Poruka = "Možete pomerati termine samo kod opšte prakse";
                        return;
                    }
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

        
        private RelayCommand pretraga;

        public RelayCommand Pretraga
        {
            get { return pretraga; }
        }
        public void Pretrazi()
        {
            List<TerminDTO> pretraga = PretragaTermina();
            if (pretraga.Count != 0) {
                ZakazaniTerminiPacijenta.Clear();
                foreach (TerminDTO termin in pretraga)
                {
                        ZakazaniTerminiPacijenta.Add(termin);
                }
                return;
            }
            Poruka = "Ne postoje zakazani termini za uneti datum!";

        }

        private List<TerminDTO>  PretragaTermina()
        {
            List<TerminDTO> rezultatiPretrage = new List<TerminDTO>();
            foreach (TerminDTO termin in terminKontroler.DobaviSveZakazaneTerminePacijenta(korisnickoIme).OrderBy(user => user.Datum).ToList())
            {
                if (DateTime.Compare(termin.Datum.Date, PoljePretrage.Date) == 0)
                    rezultatiPretrage.Add(termin);
            }
            return rezultatiPretrage;
        }
    }
}

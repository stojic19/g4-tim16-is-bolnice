using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.ViewModel.PacijentViewModel
{
    public class VremenaPomeranjaViewModel: ViewModel
    {
        private ObservableCollection<TerminDTO> slobodniTermini;
        private TerminKontroler terminKontroler = new TerminKontroler();
        private ZakazivanjePregledaDTO podaci = new ZakazivanjePregledaDTO();
        private String poruka;

        TerminDTO stariTermin;
        TerminDTO noviTermin;
        TerminDTO selektovaniTermin;
        List<TerminDTO> terminiZaIzmenu = new List<TerminDTO>();
        public VremenaPomeranjaViewModel(List<TerminDTO> terminiZaIzmenu, ZakazivanjePregledaDTO podaci)
        {
            this.terminiZaIzmenu = terminiZaIzmenu;
            this.podaci = podaci;
            this.stariTermin = terminiZaIzmenu[0];
            this.noviTermin = terminiZaIzmenu[1];
            UcitajUKolekciju(noviTermin);
            potvrdiZakazivanjeKomanda = new RelayCommand(Potvrdi);
            vratiSeKomanda = new RelayCommand(VratiSe);
        }
        private void UcitajUKolekciju(TerminDTO izabraniTermin)
        {
            SlobodniTermini = new ObservableCollection<TerminDTO>();
            foreach (TerminDTO termin in terminKontroler.NadjiVremeTermina(izabraniTermin))
                SlobodniTermini.Add(termin);
        }
        public ObservableCollection<TerminDTO> SlobodniTermini
        {
            get { return slobodniTermini; }
            set
            {
                slobodniTermini = value;
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
        public ZakazivanjePregledaDTO Podaci
        {
            get { return podaci; }
            set
            {
                podaci = value;
                OnPropertyChanged();
            }
        }
        public TerminDTO StariTermin
        {
            get { return stariTermin; }
            set
            {
                stariTermin = value;
                OnPropertyChanged();
            }
        }

        public TerminDTO NoviTermin
        {
            get { return noviTermin; }
            set
            {
                noviTermin = value;
                OnPropertyChanged();
            }
        }
        public List<TerminDTO> TerminiZaIzmenu
        {
            get { return terminiZaIzmenu; }
            set
            {
                TerminiZaIzmenu = value;
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


        private RelayCommand vratiSeKomanda;

        public RelayCommand VratiSeKomanda
        {
            get { return vratiSeKomanda; }
        }

        private void VratiSe()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazDatumaZaPomeranjePrioritet(StariTermin, Podaci));
        }

        private RelayCommand potvrdiZakazivanjeKomanda;

        public RelayCommand PotvrdiPomeranjeKomanda
        {
            get { return potvrdiZakazivanjeKomanda; }
        }

        private void Potvrdi()
        {
            if (SelektovaniTermin != null)
            {

                TerminiZaIzmenu.Add(SelektovaniTermin);
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PotvrdiPomeranjePacijent(terminiZaIzmenu, Podaci));

            }
            else
            {
                Poruka = "*Morate izabrati vreme!";
            }
        }
    }

}

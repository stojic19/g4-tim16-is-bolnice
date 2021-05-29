using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.ViewModel.PacijentViewModel
{
    public class PomeranjePregledaViewModel: ViewModel
    {
        private ZakazivanjePregledaDTO podaciIzmene;
        private LekariKontroler lekarKontroler = new LekariKontroler();
        private List<LekarDTO> sviLekari;
        private TerminDTO izabraniTermin;
        private String poruka;
        
        public PomeranjePregledaViewModel(TerminDTO selektovaniTermin)
        {
            UcitajUKolekciju();
            PodaciIzmene = new ZakazivanjePregledaDTO();
            IzabraniTermin = selektovaniTermin;
            vratiSeKomanda = new RelayCommand(VratiSe);
            prikaziDatumeKomanda = new RelayCommand(PrikaziDatume);

        }

        public ZakazivanjePregledaDTO PodaciIzmene
        {
            get { return podaciIzmene; }
            set
            {
                podaciIzmene = value;
                OnPropertyChanged();
            }
        }
        public TerminDTO IzabraniTermin
        {
            get { return izabraniTermin; }
            set
            {
                izabraniTermin = value;
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
        public List<LekarDTO> SviLekari
        {
            get { return sviLekari; }
            set
            {
                sviLekari = value;
                OnPropertyChanged();
            }
        }

        private void UcitajUKolekciju()
        {
            SviLekari = new List<LekarDTO>();
            foreach (LekarDTO lekar in lekarKontroler.DobaviLekareOpstePrakse())
                SviLekari.Add(lekar);
        }

        private RelayCommand vratiSeKomanda;

        public RelayCommand VratiSeKomanda
        {
            get { return vratiSeKomanda; }
        }
        public void VratiSe()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazRasporedaPacijent(IzabraniTermin.IdPacijenta));
        }

        private RelayCommand prikaziDatumeKomanda;
        public RelayCommand PrikaziDatumeKomanda
        {
            get { return prikaziDatumeKomanda; }
        }
        public void PrikaziDatume()
        {
            if (IzabraniTermin != null)
            {
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazDatumaZaPomeranjePrioritet(IzabraniTermin, PodaciIzmene));
            }
            else
            {
                Poruka = "Izaberite termin za pomeranje!";
            }
        }
    }
}

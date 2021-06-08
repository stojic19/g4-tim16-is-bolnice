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
    public class DatumiZaPomeranjeViewModel : ViewModel
    {
        private ObservableCollection<TerminDTO> slobodniDatumi;
        private TerminDTO selektovaniTermin;
        private TerminDTO stariTermin = new TerminDTO();
        private String poruka;
        private TerminKontroler terminKontroler = new TerminKontroler();
        private ZakazivanjePregledaDTO podaciIzmene;
        public DatumiZaPomeranjeViewModel(TerminDTO izabraniTermin, ZakazivanjePregledaDTO podaci)
        {
            PodaciIzmene = podaci;
            StariTermin = izabraniTermin;
            ProveriPrioritet();
            vratiSeKomanda = new RelayCommand(VratiSe);
            prikaziTermineKomanda = new RelayCommand(Prikazi);

        }
        public ObservableCollection<TerminDTO> SlobodniDatumi
        {
            get { return slobodniDatumi; }
            set
            {
                slobodniDatumi = value;
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
        public ZakazivanjePregledaDTO PodaciIzmene
        {
            get { return podaciIzmene; }
            set
            {
                podaciIzmene = value;
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
        public TerminDTO StariTermin
        {
            get { return stariTermin; }
            set
            {
                stariTermin = value;
            }
        }
       
        private void ProveriPrioritet()
        {
            if (PodaciIzmene.IzabraniLekar == null) return;

            String idLekara = PodaciIzmene.IzabraniLekar.KorisnickoIme;
            List<TerminDTO> datumiZaZakazivanje = terminKontroler.DobaviSveSlobodneDatumeZaPomeranje(StariTermin, idLekara);
            if (datumiZaZakazivanje.Count != 0)
            {
                UcitajUKolekciju(datumiZaZakazivanje);
            }
            else
            {

                if (podaciIzmene.Prioritet == 1)
                {
                    datumiZaZakazivanje = UcitajDatumePrioritetVreme();
                }


                if (datumiZaZakazivanje.Count == 0)
                {
                    Poruka = "*Nema slobodnih datuma! Vratite se na početnu.";
                    return;
                }
                UcitajUKolekciju(datumiZaZakazivanje);
            }

        }

        private void UcitajUKolekciju(List<TerminDTO> termini)
        {
            SlobodniDatumi = new ObservableCollection<TerminDTO>();
            foreach (TerminDTO termin in termini)
                SlobodniDatumi.Add(termin);
        }


        private List<TerminDTO> UcitajDatumePrioritetVreme()
        {
         
            DateTime pocetakIntervala = StariTermin.Datum.AddDays(-2);
            DateTime krajIntervala = StariTermin.Datum.AddDays(2);
            return terminKontroler.NadjiTermineUIntervalu(pocetakIntervala, krajIntervala);
        }
        private RelayCommand prikaziTermineKomanda;

        public RelayCommand PrikaziTermineKomanda
        {
            get { return prikaziTermineKomanda; }
        }
        public void Prikazi()
        {
            if (SelektovaniTermin != null)
            { 
                List<TerminDTO> terminiZaIzmenu = new List<TerminDTO>();
                terminiZaIzmenu.Add(StariTermin);
                terminiZaIzmenu.Add(SelektovaniTermin);
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazVremenaZaPomeranjePacijent(terminiZaIzmenu, PodaciIzmene));
            }
            else
            {
                Poruka = "*Morate izabrati datum!";
            }
        }

        private RelayCommand vratiSeKomanda;

        public RelayCommand VratiSeKomanda
        {
            get { return vratiSeKomanda; }
        }

        public void VratiSe()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomeranjeSaPrioritetom(StariTermin));
        }
    }
}

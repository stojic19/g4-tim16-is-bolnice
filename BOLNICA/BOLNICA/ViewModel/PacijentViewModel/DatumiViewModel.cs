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
    public class DatumiViewModel: ViewModel
    {
        private ObservableCollection<TerminDTO> slobodniDatumi;
        private ZakazaniTerminiKontroler terminKontroler = new ZakazaniTerminiKontroler();
        private SlobodniTerminiKontroler slobodniTerminiKontroler = new SlobodniTerminiKontroler();
        private List<DateTime> datumiUIntervalu = new List<DateTime>();
        private ZakazivanjePregledaDTO podaciZakazivanja;
        private TerminDTO selektovaniTermin;
        private String poruka;
       
        public DatumiViewModel(ZakazivanjePregledaDTO podaci)
        {
            podaciZakazivanja = podaci;
            datumiUIntervalu.Add(podaci.DatumOd);
            datumiUIntervalu.Add(podaci.DatumDo);
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
   
        public String Poruka
        {
            get { return poruka; }
            set
            {
                poruka = value;
                OnPropertyChanged();
            }
        }
        private void ProveriPrioritet()
        {
            List<TerminDTO> datumiZaZakazivanje = slobodniTerminiKontroler.DobaviSlobodneTermineZaZakazivanje(datumiUIntervalu, podaciZakazivanja.IzabraniLekar.KorisnickoIme);
            if (datumiZaZakazivanje.Count != 0)
            {
                UcitajUKolekciju(datumiZaZakazivanje);
            }
            else
            {
             
                if (podaciZakazivanja.Prioritet == 0)
                {

                    datumiZaZakazivanje = UcitajDatumePrioritetLekar();
                }else if(podaciZakazivanja.Prioritet == 1)
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

        private List<TerminDTO> UcitajDatumePrioritetLekar()
        {
            DateTime datumOd = datumiUIntervalu[0].AddDays(-7);
            DateTime datumDo = datumiUIntervalu[1].AddDays(7);
            List<DateTime> intervalDatuma = new List<DateTime>();
            intervalDatuma.Add(datumOd);
            intervalDatuma.Add(datumDo);
            return slobodniTerminiKontroler.DobaviSlobodneTermineZaZakazivanje(intervalDatuma, podaciZakazivanja.IzabraniLekar.KorisnickoIme);
        }

        private List<TerminDTO> UcitajDatumePrioritetVreme()
        {
            return slobodniTerminiKontroler.NadjiTermineUIntervalu(datumiUIntervalu);
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
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazVremenaTerminaPacijent(SelektovaniTermin, podaciZakazivanja));
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
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new ZakazivanjeSaPrioritetomPacijent(podaciZakazivanja.KorisnickoImePacijenta));
        }
    }
}

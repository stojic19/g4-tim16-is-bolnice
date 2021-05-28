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
    public class VremenaViewModel:ViewModel
    {
        private ObservableCollection<TerminDTO> slobodniTermini;
        private TerminKontroler terminKontroler = new TerminKontroler();
        private TerminDTO selektovaniTermin;
        private String poruka;
        private ZakazivanjePregledaDTO podaciZakazivanja;

        public VremenaViewModel(TerminDTO izabraniTermin,ZakazivanjePregledaDTO podaciZakazivanja)
        {
            this.podaciZakazivanja = podaciZakazivanja;
            UcitajUKolekciju(izabraniTermin);
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
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazSlobodnihDatumaPacijent(podaciZakazivanja));
        }

        private RelayCommand potvrdiZakazivanjeKomanda;

        public RelayCommand PotvrdiZakazivanjeKomanda
        {
            get { return potvrdiZakazivanjeKomanda; }
        }

        private void Potvrdi()
        {
            if (SelektovaniTermin != null)
            {
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PotvrdiZakazivanjePacijent(SelektovaniTermin, podaciZakazivanja));

            }
            else
            {
                Poruka = "*Morate izabrati vreme!";
            }
        }

    }
}

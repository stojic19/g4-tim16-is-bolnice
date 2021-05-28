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
    public class PotvrdiZakazivanjeViewModel:ViewModel
    {
        private TerminDTO izabraniTermin;
        private ZakazivanjePregledaDTO podaciZaPrikaz;
        private TerminKontroler terminKontroler = new TerminKontroler();
        public PotvrdiZakazivanjeViewModel(TerminDTO izabraniTermin, ZakazivanjePregledaDTO podaciZaPrikaz)
        {
            this.IzabraniTermin = izabraniTermin;
            this.podaciZaPrikaz = podaciZaPrikaz;
            vratiSeKomanda = new RelayCommand(VratiSe);
            potvrdiKomanda = new RelayCommand(Potvrdi);
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


        private RelayCommand vratiSeKomanda;

        public RelayCommand VratiSeKomanda
        {
            get { return vratiSeKomanda; }
        }
        private void VratiSe()
        {

            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazVremenaTerminaPacijent(IzabraniTermin, podaciZaPrikaz));
        }

        private RelayCommand potvrdiKomanda;

        public RelayCommand PotvrdiKomanda
        {
            get { return potvrdiKomanda; }
        }
        private void Potvrdi()
        {
            terminKontroler.ZakaziPregled(IzabraniTermin, podaciZaPrikaz.KorisnickoImePacijenta);
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazRasporedaPacijent(podaciZaPrikaz.KorisnickoImePacijenta));
        }

    }
}

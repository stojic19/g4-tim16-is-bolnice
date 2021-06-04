using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.View.PacijentFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.ViewModel.PacijentViewModel
{
    public class KreirajPodsetnikViewModel:ViewModel
    {
        private PregledDTO pregled;
        private PodsetnikDTO podsetnik = new PodsetnikDTO();
        private String poruka;
        private ObavestenjaKontroler obavestenjaKontroler = new ObavestenjaKontroler();

        public KreirajPodsetnikViewModel(String tekstObavestenja, PregledDTO pregled)
        {
            podsetnik.Tekst = tekstObavestenja;
            podsetnik.Naslov = "";
            podsetnik.DatumOd = DateTime.Now.Date;
            podsetnik.DatumDo = DateTime.Now.AddDays(3).Date;
            podsetnik.Vreme = DateTime.Now;
            this.pregled = pregled;
            vratiSeKomanda = new RelayCommand(VratiSe);
            sacuvajPodsetnikKomanda = new RelayCommand(Sacuvaj);

        }
        public PregledDTO Pregled
        {
            get { return pregled; }
            set
            {
                pregled = value;
                OnPropertyChanged();
            }
        }

        public PodsetnikDTO Podsetnik
        {
            get { return podsetnik; }
            set
            {
                podsetnik = value;
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
        private RelayCommand vratiSeKomanda;

        public RelayCommand VratiSeKomanda
        {
            get { return vratiSeKomanda; }
        }
        private void VratiSe()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new KreirajBelesku(Pregled));
        }

        private RelayCommand sacuvajPodsetnikKomanda;

        public RelayCommand SacuvajPodsetnikKomanda
        {
            get { return sacuvajPodsetnikKomanda; }
        }
        private void Sacuvaj()
        {
            DateTime? pocetak = Podsetnik.DatumOd;
            DateTime? kraj = Podsetnik.DatumDo;
            DateTime? vreme = Podsetnik.Vreme;
            if (Podsetnik.Naslov.Equals("") || Podsetnik.Tekst.Equals("") || !pocetak.HasValue || !kraj.HasValue || !vreme.HasValue)
            {
                Poruka = "*Popunite sva polja!";
                return;
            }


            obavestenjaKontroler.DodajPodsetnikOAnamnezi(Podsetnik, Pregled.Termin.IdPacijenta);
            Poruka = "*Podsetnik uspešno sačuvan!";


        }
    }
}

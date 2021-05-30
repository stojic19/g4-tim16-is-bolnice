using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.PacijentFolder;
using Bolnica.View.PacijentFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.ViewModel.PacijentViewModel
{
    public class BeleskaViewModel : ViewModel
    {
        private BeleskaDTO beleska;
        private PregledDTO pregled;
        private String tekst;
        private String poruka;
        BeleskaKontroler beleskaKontroler = new BeleskaKontroler();

        public BeleskaViewModel(PregledDTO pregled)
        {
            this.pregled = pregled;
            PostaviTekstBeleske(pregled.Anamneza.IdAnamneze);
            vratiSeKomanda = new RelayCommand(VratiSe);
            kreirajPodsetnikKomanda = new RelayCommand(Kreiraj);
            sacuvajBeleskuKomanda = new RelayCommand(Sacuvaj);
        }

        private void PostaviTekstBeleske(String idAnamneze)
        {
            if (beleskaKontroler.PretraziBeleskePoIdAnamneze(pregled.Anamneza.IdAnamneze) != null)
                Tekst = beleskaKontroler.PretraziBeleskePoIdAnamneze(pregled.Anamneza.IdAnamneze).Tekst;
            else
                Tekst = "";
        }

        public BeleskaDTO Beleska
        {
            get { return beleska; }
            set
            {
                beleska = value;
                OnPropertyChanged();
            }
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
        public String Poruka
        {
            get { return poruka; }
            set
            {
                poruka = value;
                OnPropertyChanged();
            }
        }

        public String Tekst
        {
            get { return tekst; }
            set
            {
                tekst = value;
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
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new IzvestajSaPregleda(pregled));
        }

        private RelayCommand sacuvajBeleskuKomanda;

        public RelayCommand SacuvajBeleskuKomanda
        {
            get { return sacuvajBeleskuKomanda; }
        }
        private void Sacuvaj()
        {
            BeleskaDTO beelska = beleskaKontroler.PretraziBeleskePoIdAnamneze(pregled.Anamneza.IdAnamneze);
            if (beelska != null)
            {
                beelska.Tekst = Tekst;
                beleskaKontroler.IzmeniBelesku(beelska);
                Poruka = "*Beleska uspešno izmenjena!";
            }
            else
            {
                BeleskaDTO novaBeleska = new BeleskaDTO(DateTime.Now, Tekst, Guid.NewGuid().ToString(), pregled.Anamneza);
                beleskaKontroler.SacuvajBelesku(novaBeleska);
                Poruka = "*Beleska uspešno sačuvana!";
            }

        }

        private RelayCommand kreirajPodsetnikKomanda;

        public RelayCommand KreirajPodsetnikKomanda
        {
            get { return kreirajPodsetnikKomanda; }
        }
        private void Kreiraj()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new KreirajPodsetnik(Tekst, Pregled));
        }
    }
}

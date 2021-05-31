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

namespace Bolnica.ViewModel.PacijentViewModel
{
    public class PopuniAnketuViewModel: ViewModel
    {
        private ObservableCollection<PitanjeDTO> pitanjaAnkete;
        private String korisnickoIme;
        private PitanjaKontroler pitanjaKontroler = new PitanjaKontroler();
        private PreglediKontroler pregledKontroler = new PreglediKontroler();
        private NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        private AnketaKontroler anketaKontroler = new AnketaKontroler();
        private PregledDTO pregled;
        private String dodatniKomentar;
        public PopuniAnketuViewModel(PregledDTO pregled)
        {
            this.pregled = pregled;
            this.korisnickoIme = pregled.Termin.IdPacijenta;
            UcitajKolekciju();
            vratiSeKomanda = new RelayCommand(VratiSe);
            posaljiAnketu = new RelayCommand(Posalji);
        }
        private void UcitajKolekciju()
        {
            PitanjaAnkete = new ObservableCollection<PitanjeDTO>();
            foreach (PitanjeDTO pitanje in pitanjaKontroler.DobaviPitanjaOPregledu())
                PitanjaAnkete.Add(pitanje);


        }
        private String poruka;
        public String Poruka
        {
            get { return poruka; }
            set
            {
                poruka = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<PitanjeDTO> PitanjaAnkete
        {
            get { return pitanjaAnkete; }
            set
            {
                pitanjaAnkete = value;
                OnPropertyChanged();
            }
        }
        public String DodatniKomentar
        {
            get { return dodatniKomentar; }
            set
            {
                dodatniKomentar = value;
                OnPropertyChanged();
            }
        }

        public String KorisnickoIme
        {
            get { return korisnickoIme; }
            set
            {
                korisnickoIme = value;
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

        private RelayCommand vratiSeKomanda;

        public RelayCommand VratiSeKomanda
        {
            get { return vratiSeKomanda; }
        }
        public void VratiSe()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazAnketa(KorisnickoIme));
        }

        private RelayCommand posaljiAnketu;
        public RelayCommand PosaljiAnketu
        {
            get { return posaljiAnketu; }
        }
        public void Posalji()
        {
            for (int i = 0; i < pitanjaAnkete.Count; i++)
            {

                int indexCombo = pitanjaAnkete[i].Ocena + 1;
                pitanjaAnkete[i].Ocena = indexCombo;

            }
            List<PitanjeDTO> svaPitanja = new List<PitanjeDTO>();
            foreach (PitanjeDTO pitanje in PitanjaAnkete)
            {
                svaPitanja.Add(pitanje);
            }
            pregledKontroler.PostaviOcenuPregledu(Pregled);
            AnketaDTO novaAnketa = new AnketaDTO(svaPitanja, DodatniKomentar);
            anketaKontroler.DodajAnketu(novaAnketa, Pregled.IdPregleda);

        }
    }
}

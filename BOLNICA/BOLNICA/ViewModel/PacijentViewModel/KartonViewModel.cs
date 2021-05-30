using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.PacijentFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.ViewModel.PacijentViewModel
{
    public class KartonViewModel:ViewModel
    {
        private PacijentDTO pacijentDTO = new PacijentDTO();
        private NaloziPacijenataKontroler naloziPacijentaKontroler = new NaloziPacijenataKontroler();
        public KartonViewModel(String korisnickoIme)
        {
            PacijentDTO = naloziPacijentaKontroler.PretraziPoKorisnickomImenu(korisnickoIme);
            alergeniKomanda = new RelayCommand(PrikaziAlergene);
            istorijaPregleda = new RelayCommand(PrikaziIstoriju);
        }


        public PacijentDTO PacijentDTO
        {
            get { return pacijentDTO; }
            set { pacijentDTO = value; }
        }


        private RelayCommand alergeniKomanda;
        public RelayCommand AlergeniKomanda
        {
            get { return alergeniKomanda; }
        }
        public void PrikaziAlergene()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazAlergenaPacijenta(PacijentDTO));
        }


        private RelayCommand istorijaPregleda;
        public RelayCommand IstorijaPregleda
        {
            get { return istorijaPregleda; }
        }
        public void PrikaziIstoriju()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new IstorijaPregleda(PacijentDTO.KorisnickoIme));
        }

    }
}

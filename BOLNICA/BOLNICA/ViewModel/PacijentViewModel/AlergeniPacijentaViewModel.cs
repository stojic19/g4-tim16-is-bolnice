using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.PacijentFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.ViewModel.PacijentViewModel
{
    public class AlergeniPacijentaViewModel: ViewModel
    {
        PacijentDTO pacijent = new PacijentDTO();
        ObservableCollection<AlergenDTO> alergeni;
        public AlergeniPacijentaViewModel(PacijentDTO pacijent)
        {
            this.pacijent = pacijent;
            UcitajUKolekciju();
            vratiSeKomanda = new RelayCommand(VratiSe);
        }
        private void UcitajUKolekciju()
        {
            Alergeni = new ObservableCollection<AlergenDTO>();
            foreach (AlergenDTO alergen in pacijent.Karton.Alergeni)
                Alergeni.Add(alergen);
        }

        public ObservableCollection<AlergenDTO> Alergeni
        {
            get { return alergeni; }
            set { alergeni = value; }
        }
        public PacijentDTO Pacijent
        {
            get { return pacijent; }
            set { pacijent = value; }
        }

        private RelayCommand vratiSeKomanda;
        public RelayCommand VratiSeKomanda
        {
            get { return vratiSeKomanda; }
        }
        public void VratiSe()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazKartona(Pacijent.KorisnickoIme));
        }
    }
}

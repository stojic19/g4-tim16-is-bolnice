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
    public class PotvrdiOtkazivanjeViewModel: ViewModel
    {
        private TerminKontroler terminKontroler = new TerminKontroler();
        private TerminDTO selektovaniTermin;
        private String korisnickoIme;
        public PotvrdiOtkazivanjeViewModel(TerminDTO izabranZaOtkazivanje)
        {
            selektovaniTermin = izabranZaOtkazivanje;
            korisnickoIme = izabranZaOtkazivanje.Pacijent.KorisnickoIme;
            potvrdi = new RelayCommand(PotvrdiOtkazivanje);
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
        private RelayCommand potvrdi;
        public RelayCommand Potvrdi
        {
            get { return potvrdi; }
        }
        public void PotvrdiOtkazivanje()
        {

            terminKontroler.OtkaziPregledPacijent(SelektovaniTermin);
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazRasporedaPacijent(korisnickoIme));
        }
    }
}

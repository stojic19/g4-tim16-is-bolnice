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
    public class PotvrdiPomeranjeViewModel: ViewModel
    {
        private TerminDTO stariTermin = new TerminDTO();
        private ZakazivanjePregledaDTO podaci = new ZakazivanjePregledaDTO();
        private TerminDTO noviTermin;
        private TerminKontroler terminKontroler = new TerminKontroler();

        public PotvrdiPomeranjeViewModel(List<TerminDTO> terminiZaIzmenu, ZakazivanjePregledaDTO podaci)
        {
            this.stariTermin = terminiZaIzmenu[0];
            this.noviTermin = terminiZaIzmenu[2];
            pomeriTerminKomanda = new RelayCommand(PomeriPregled);
            vratiSe = new RelayCommand(VratiSeNazad);
        }

        private RelayCommand pomeriTerminKomanda;

        public RelayCommand PomeriTerminKomanda
        {
            get { return pomeriTerminKomanda; }
        }

        private RelayCommand vratiSe;

        public RelayCommand VratiSe
        {
            get { return vratiSe; }
        }
        public void VratiSeNazad()
        {
            List<TerminDTO> terminiZaizmenu = new List<TerminDTO>();
            terminiZaizmenu.Add(StariTermin);
            terminiZaizmenu.Add(NoviTermin);
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazVremenaZaPomeranjePacijent(terminiZaizmenu, Podaci));
        }

        public TerminDTO NoviTermin
        {
            get { return noviTermin; }
        }

        public TerminDTO StariTermin
        {
            get { return stariTermin; }
            set { stariTermin = value; }
        }

        public ZakazivanjePregledaDTO Podaci
        {
            get { return podaci; }
            set { podaci = value; }
        }

        public void PomeriPregled()
        {
            String korisnickoIme = stariTermin.IdPacijenta;
            terminKontroler.PomeriPregledPacijent(stariTermin, noviTermin);
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazRasporedaPacijent(korisnickoIme));
        }
    }
}

using Bolnica.Komande;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.ViewModel.PacijentViewModel
{
    public class OcenaAplikacijeViewModel: ViewModel
    {
       // private OcenaAplikacijeDTO ocenaAplikacije = new OcenaAplikacijeDTO();
        private String korisnickoIme;
        private String poruka;
       // private OcenaAplikacijeKontroler ocenaAplikacijeKontroler = new OcenaAplikacijeKontroler();

        public OcenaAplikacijeViewModel(String korisnickoIme)
        {
            this.korisnickoIme = korisnickoIme;
            sacuvajOcenu = new RelayCommand(Sacuvaj);
        }
        private int ocenaCombo;
        public int OcenaCombo
        {
            get { return ocenaCombo; }
            set
            {
                ocenaCombo = value;
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
      /*  public OcenaAplikacijeDTO OcenaAplikacije
        {
            get { return ocenaAplikacije; }
            set
            {
                ocenaAplikacije = value;
                OnPropertyChanged();
            }
        }*/
        public String KorisnickoIme
        {
            get { return korisnickoIme; }

        }
        private RelayCommand sacuvajOcenu;
        public RelayCommand SacuvajOcenu
        {
            get { return sacuvajOcenu; }
        }
        public void Sacuvaj()
        {
            int ocena = OcenaCombo + 1;
            if (ocena != 0)
            {
               /* ocenaAplikacije.KorisnickoIme = KorisnickoIme;
                ocenaAplikacije.Datum = DateTime.Now;
                ocenaAplikacije.Ocena = ocena;
                ocenaAplikacijeKontroler.SacuvajOcenuAplikacije(ocenaAplikacije);*/
                Poruka = "Ocena sačuvana!";
            }
        }
    }
}

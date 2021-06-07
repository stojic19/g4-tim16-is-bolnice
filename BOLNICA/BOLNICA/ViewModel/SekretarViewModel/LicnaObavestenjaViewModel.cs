using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.SekretarFolder;
using Bolnica.View.SekretarFolder.LicnaObavestenja;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bolnica.ViewModel.SekretarViewModel
{
    public class LicnaObavestenjaViewModel : ViewModel
    {
        private String korisnickoIme;
        private ObservableCollection<ObavestenjeDTO> obavestenja;
        private ObavestenjaKontroler obavestenjaKontroler= new ObavestenjaKontroler();
        private ObavestenjeDTO selektovanoObavestenje;
        private String poruka;
  
        public LicnaObavestenjaViewModel(String korisnickoIme)
        {
            this.korisnickoIme = korisnickoIme;
            UcitajUKolekciju();
            pregledajKomanda = new RelayCommand(Pregledaj);
            nazadKomanda = new RelayCommand(Nazad);
        }

        public void UcitajUKolekciju()
        {
            obavestenja = new ObservableCollection<ObavestenjeDTO>();
            foreach (ObavestenjeDTO obavestenje in obavestenjaKontroler.DobaviSvaObavestenja())
            {
                if(obavestenje.DaLiJePrimalac(korisnickoIme)|| obavestenje.DaLiJePrimalac("svi")||obavestenje.DaLiJePrimalac("sekretari"))
                {
                    obavestenja.Add(obavestenje);
                }
            }
        }
        public ObservableCollection<ObavestenjeDTO> Obavestenja
        {
            get { return obavestenja; }
            set
            {
                obavestenja = value;
                OnPropertyChanged();
            }
        }
        public ObavestenjeDTO SelektovanoObavestenje
        {
            get { return selektovanoObavestenje; }
            set
            {
                selektovanoObavestenje = value;
                OnPropertyChanged();
            }
        }

        public string Poruka
        {
            get { return poruka; }
            set { poruka = value; OnPropertyChanged("Poruka"); }
        }

        private RelayCommand pregledajKomanda;

        public RelayCommand PregledajKomanda
        {
            get { return pregledajKomanda; }
        }
        public void Pregledaj()
        {
            if (selektovanoObavestenje != null)
            {
                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new LicnaObavestenjaPregledSekretar(selektovanoObavestenje.IdObavestenja);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                Poruka = "*Morate izabrati obavestenje za pregled!";
            }
        }

        private RelayCommand nazadKomanda;

        public RelayCommand NazadKomanda
        {
            get { return nazadKomanda; }
        }
        public void Nazad()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new GlavniProzorSadrzaj();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}

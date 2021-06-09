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
    public class LicnaObavestenjaPregledViewModel : SekretarViewModel
    {
        private ObavestenjaKontroler obavestenjaKontroler= new ObavestenjaKontroler();
        private ObavestenjeDTO podaci;
        public LicnaObavestenjaPregledViewModel(String idObavestenja)
        {
            Podaci = obavestenjaKontroler.PretraziPoId(idObavestenja);
            povratakKomanda = new RelayCommand(Povratak);
        }
        public ObavestenjeDTO Podaci
        {
            get { return podaci; }
            set
            {
                podaci = value;
                OnPropertyChanged();
            }
        }
        private RelayCommand povratakKomanda;

        public RelayCommand PovratakKomanda
        {
            get { return povratakKomanda; }
        }
        public void Povratak()
        {
                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new LicnaObavestenjaSekretar(GlavniProzorSekretar.getInstance().getSekretar().KorisnickoIme);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}

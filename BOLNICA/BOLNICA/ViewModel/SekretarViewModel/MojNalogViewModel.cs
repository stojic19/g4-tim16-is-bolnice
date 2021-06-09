using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.SekretarFolder;
using Bolnica.View.SekretarFolder.LicnaObavestenja;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bolnica.ViewModel.SekretarViewModel
{
    public class MojNalogViewModel : SekretarViewModel
    {
        private Osoba podaci;
        public MojNalogViewModel()
        {
            Podaci = GlavniProzorSekretar.getInstance().getSekretar();
            povratakKomanda = new RelayCommand(Povratak);
        }
        public Osoba Podaci
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

                usc = new GlavniProzorSadrzaj();
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}

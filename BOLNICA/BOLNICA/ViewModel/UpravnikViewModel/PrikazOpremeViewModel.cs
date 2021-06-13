using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.UpravnikFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Bolnica.ViewModel.UpravnikViewModel
{
    public class PrikazOpremeViewModel : ViewModel
    {
        OpremaKontroler opremaKontroler = new OpremaKontroler();
        private ObservableCollection<OpremaDTO> oprema;
        private OpremaDTO izabranaOprema;
        public PrikazOpremeViewModel()
        {
            InicijalizacijaTabele();
            dodajOpremuKomanda = new RelayCommand(DodajOpremu);
            izmijeniOpremuKomanda = new RelayCommand(IzmijeniOpremu);
            ukloniOpremuKomanda = new RelayCommand(UkloniOpremu);
            premjestiStatickuOpremuKomanda = new RelayCommand(PremjestiStatickuOpremu);
        }

        public ObservableCollection<OpremaDTO> Oprema
        {
            get { return oprema; }
            set
            {
                oprema = value;
                OnPropertyChanged();
            }
        }

        private void InicijalizacijaTabele()
        {
            Oprema = new ObservableCollection<OpremaDTO>();
            foreach (OpremaDTO o in opremaKontroler.SvaOprema())
            {
                Oprema.Add(o);
            }
        }

        private RelayCommand dodajOpremuKomanda;

        public RelayCommand DodajOpremuKomanda
        {
            get { return dodajOpremuKomanda; }
        }
        public void DodajOpremu()
        {
            DodavanjeOpreme dodavanje = new DodavanjeOpreme();
            dodavanje.Show();
        }

        public OpremaDTO IzabranaOprema
        {
            get { return izabranaOprema; }
            set
            {
                izabranaOprema = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand izmijeniOpremuKomanda;

        public RelayCommand IzmijeniOpremuKomanda
        {
            get { return izmijeniOpremuKomanda; }
        }
        public void IzmijeniOpremu()
        {
            if (izabranaOprema != null)
            {

                IzmenaOpreme izmena = new IzmenaOpreme(izabranaOprema.IdOpreme);
                izmena.Show();
            }
            else
            {
                MessageBox.Show("Izaberite opremu koju želite da izmenite!");
            }
        }

        private RelayCommand ukloniOpremuKomanda;

        public RelayCommand UkloniOpremuKomanda
        {
            get { return ukloniOpremuKomanda; }
        }

        public void UkloniOpremu()
        {
            if (izabranaOprema != null)
            {

                UklanjanjeOpreme uklanjanje = new UklanjanjeOpreme(izabranaOprema.IdOpreme);
                uklanjanje.Show();
            }
            else
            {
                MessageBox.Show("Izaberite opremu koju želite da uklonite!");
            }
        }

        private RelayCommand premjestiStatickuOpremuKomanda;

        public RelayCommand PremjestiStatickuOpremuKomanda
        {
            get { return premjestiStatickuOpremuKomanda; }
        }

        public void PremjestiStatickuOpremu()
        {
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
            System.Windows.Controls.UserControl usc = null;
            usc = new PremjestanjeStatickeOpreme();
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);
        }

        private RelayCommand pretraziKomanda;

        public RelayCommand PretraziKomanda
        {
            get { return pretraziKomanda; }
        }

        /* public void Pretrazi()
         {
             ObservableCollection<OpremaDTO> filtriranje = new ObservableCollection<OpremaDTO>();

             foreach (OpremaDTO o in Oprema)
             {
                 if (o.IdOpreme.StartsWith(SearchBox.Text, StringComparison.InvariantCultureIgnoreCase) ||
                     o.NazivOpreme.StartsWith(SearchBox.Text, StringComparison.InvariantCultureIgnoreCase) ||
                     o.VrstaOpreme.ToString().StartsWith(SearchBox.Text, StringComparison.InvariantCultureIgnoreCase))
                 {
                     filtriranje.Add(o);
                 }
             }

             dataGridOprema.ItemsSource = filtriranje;
         }*/
    }
}

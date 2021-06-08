using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace Bolnica.ViewModel.LekarViewModel
{

    public class LekarRasporedViewModel : ViewModel
    {
        TerminKontroler terminKontroler = new TerminKontroler();
        private PreglediKontroler preglediKontroler = new PreglediKontroler();
        private DispatcherTimer dispatcherTimer;
        private ObservableCollection<TerminDTO> termini;

        public ObservableCollection<TerminDTO> Termini
        {
            get { return termini; }
            set
            {
                termini = value;
                OnPropertyChanged();
            }

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

        private TerminDTO izabranTermin;

        public TerminDTO IzabranTermin
        {
            get { return izabranTermin; }
            set
            {
                izabranTermin = value;
                OnPropertyChanged();
            }
        }

        public LekarRasporedViewModel()
        {
            InicijalizacijaTabele();
            PodesavanjeTajmera();
            InicijalizacijaPretrage();
            otkaziTerminKomanda = new RelayCommand(OtkaziTermin);
            zakaziTerminKomanda = new RelayCommand(ZakaziTermin);
            izmeniTerminKomanda = new RelayCommand(IzmeniTermin);
            prikazKartonaKomanda = new RelayCommand(PrikazKartona);
        }

        public void InicijalizacijaTabele()
        {
            Termini = new ObservableCollection<TerminDTO>();
            foreach (TerminDTO t in terminKontroler.PretraziPoLekaru(LekarGlavniProzor.DobaviKorisnickoIme()))
            {
                if (t.Datum.AddDays(5).Date.CompareTo(DateTime.Now) >= 0)
                {
                    Termini.Add(t);
                }
            }
        }

        private void PodesavanjeTajmera()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
        }

        public void podesiObavestenje(String poruka)
        {
            Poruka = "Termin uspešno otkazan!";
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Poruka = String.Empty;
            dispatcherTimer.IsEnabled = false;
        }

        private RelayCommand prikazKartonaKomanda;

        public RelayCommand PrikazKartonaKomanda
        {
            get { return prikazKartonaKomanda; }
        }
        public void PrikazKartona()
        {
            if (IzabranTermin != null)
            {
                String IdNovogPregleda = preglediKontroler.PristupPregledu(IzabranTermin.IdTermina);

                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(IdNovogPregleda, 0));
            }
        }

        private RelayCommand zakaziTerminKomanda;

        public RelayCommand ZakaziTerminKomanda
        {
            get { return zakaziTerminKomanda; }
        }
        public void ZakaziTermin()
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new ZakazivanjeTerminaLekar());
        }

        private RelayCommand izmeniTerminKomanda;

        public RelayCommand IzmenaTerminKomanda
        {
            get { return izmeniTerminKomanda; }
        }
        public void IzmeniTermin()
        {
            if (IzabranTermin != null)
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new IzmenaTerminaLekar(IzabranTermin.IdTermina));

            }
        }

        private RelayCommand otkaziTerminKomanda;

        public RelayCommand OtkaziTerminKomanda
        {
            get { return otkaziTerminKomanda; }
        }
        public void OtkaziTermin()
        {
            if (IzabranTermin != null)
            {
                if (System.Windows.MessageBox.Show("Da li ste sigurni da želite da otkažete termin?", "Otkazivanje termina", MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    return;
                }

                preglediKontroler.UklanjanjePregleda(IzabranTermin.IdTermina);
                if (terminKontroler.OtkaziTerminLekar(IzabranTermin.IdTermina))
                {
                    Termini.Remove(IzabranTermin);
                    podesiObavestenje("Termin uspešno otkazan!");
                }
            }
            else
            {
                MessageBox.Show("Izaberite termin koji želite da otkažete!");
            }
        }

        private String poljePretraga;

        public String PoljePretraga
        {
            get { return poljePretraga; }
            set
            {
                poljePretraga = value;
                OnPropertyChanged("PoljePretraga");
                CollectionViewSource.GetDefaultView(Termini).Refresh();

            }
        }

        private void InicijalizacijaPretrage()
        {
            CollectionView view2 = (CollectionView)CollectionViewSource.GetDefaultView(Termini);
            view2.Filter = FiltriranjeTermina;
        }

        private bool FiltriranjeTermina(object item)
        {
            if (String.IsNullOrEmpty(PoljePretraga))
                return true;
            else
                return ((item as TerminDTO).Datum.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).IndexOf(PoljePretraga, StringComparison.OrdinalIgnoreCase) >= 0);

        }




    }
}

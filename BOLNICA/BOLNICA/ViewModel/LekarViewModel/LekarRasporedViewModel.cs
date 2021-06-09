using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;

namespace Bolnica.ViewModel.LekarViewModel
{

    public class LekarRasporedViewModel : ViewModel
    {
        TerminKontroler terminKontroler = new TerminKontroler();
        private PreglediKontroler preglediKontroler = new PreglediKontroler();
        private DispatcherTimer dispatcherTimer;
        private ObservableCollection<TerminDTO> termini;

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
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
        }

        public void podesiObavestenje(String poruka)
        {
            Poruka = poruka;
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
            else
            {
                podesiObavestenje("Izaberite termin!");
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

        public RelayCommand IzmeniTerminKomanda
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
            else
            {
                podesiObavestenje("Izaberite datum za pomeranje!");
            }
        }

        private RelayCommand otkaziTerminKomanda;

        public RelayCommand OtkaziTerminKomanda
        {
            get { return otkaziTerminKomanda; }
        }
        public void OtkaziTermin()
        {
            if (IzabranTermin != null && terminKontroler.ProveriZaOtkazivanje(izabranTermin.IdTermina))
            {
                if (System.Windows.MessageBox.Show("Da li ste sigurni da želite da otkažete termin?", Properties.Resources.OtkaziTermin, MessageBoxButton.YesNo) == MessageBoxResult.No)
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
            else if(IzabranTermin == null)
            {
                podesiObavestenje("Izaberite datum za otkazivanje!");
            }else if (!terminKontroler.ProveriZaOtkazivanje(izabranTermin.IdTermina))
            {
                podesiObavestenje("Termin je prošao!");
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

using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Bolnica.LekarFolder.LekoviLekar
{
    public partial class IzmenaLeka : System.Windows.Controls.UserControl
    {
        LekDTO izabranLek = null;
        List<SastojakDTO> izmenjeniSastojci = new List<SastojakDTO>();
        String KorisnickoIme = null;
        private LekoviKontroler lekoviKontroler = new LekoviKontroler();
        private DispatcherTimer dispatcherTimer;
        public static ObservableCollection<SastojakDTO> Sastojci { get; set; } = new ObservableCollection<SastojakDTO>();

        public IzmenaLeka(String idIzabranogLeka)
        {
            InitializeComponent();
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            izabranLek = lekoviKontroler.PretraziPoID(idIzabranogLeka);
            KorisnickoIme = LekarGlavniProzor.DobaviKorisnickoIme();
            PodesavanjeTajmera();
            this.DataContext = this;
            inicijalizacijaPolja();

        }

        private void inicijalizacijaPolja()
        {
            this.nazivLeka.Text = izabranLek.NazivLeka;
            this.jacinaLeka.Text = izabranLek.Jacina;

            Sastojci.Clear();
            foreach (SastojakDTO s in lekoviKontroler.DobaviSastojkeLeka(izabranLek.IdLeka))
            {
                Sastojci.Add(s);
                izmenjeniSastojci.Add(s);
            }
        }

        private void BrisanjeSastojka(object sender, RoutedEventArgs e)
        {
            SastojakDTO izabranSastojak = (SastojakDTO)dataGridSastojci.SelectedItem;

            if (izabranSastojak != null)
            {
                foreach (SastojakDTO s in izmenjeniSastojci)
                {
                    if (s.Naziv.Equals(izabranSastojak.Naziv))
                    {
                        izmenjeniSastojci.Remove(s);
                        Sastojci.Remove(s);
                        break;
                    }
                }
            }
        }

        private void DodavanjeSastojka(object sender, RoutedEventArgs e)
        {
            if (!ValidacijaNovogSastojka()) return;

            SastojakDTO noviSastojak = new SastojakDTO(nazivSastojka.Text, Double.Parse(kolicinaSastojka.Text));

            izmenjeniSastojci.Add(noviSastojak);
            Sastojci.Add(noviSastojak);
            nazivSastojka.Text = String.Empty;
            kolicinaSastojka.Text = String.Empty;

        }

        private Boolean ValidacijaNovogSastojka()
        {
            if (nazivSastojka.Text.Equals("") || kolicinaSastojka.Text.Equals(""))
            {
                validacijaPolja.Visibility = Visibility.Visible;
                dispatcherTimer.Start();
                return false;

            }

            if (!Double.TryParse(kolicinaSastojka.Text, out Double broj))
            {
                kolicinaSastojka.Text = String.Empty;
                validacijaPolja.Visibility = Visibility.Visible;
                dispatcherTimer.Start();

                return false;
            }

            return true;
        }

        private void Odustajanje(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new BazaLekova());
        }

        private void CuvanjeIzmena(object sender, RoutedEventArgs e)
        {
            if (!ValidacijaUnosa()) return;

            izabranLek.NazivLeka = nazivLeka.Text;
            izabranLek.Jacina = jacinaLeka.Text;

            lekoviKontroler.IzmenaLeka(izabranLek, izmenjeniSastojci);

            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new BazaLekova());


        }

        private Boolean ValidacijaUnosa()
        {
            if (nazivLeka.Text.Equals("") || jacinaLeka.Text.Equals(""))
            {
                validacijaPolja.Visibility = Visibility.Visible;
                dispatcherTimer.Start();
                return false;

            }

            return true;
        }


        private void PodesavanjeTajmera()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            validacijaPolja.Visibility = Visibility.Hidden;
            dispatcherTimer.IsEnabled = false;
        }

        private void nazivLeka_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (nazivLeka.Text.Equals(String.Empty))
            {
                nazivLeka.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                nazivLeka.BorderBrush = System.Windows.Media.Brushes.Black;
            }
        }

        private void jacinaLeka_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (jacinaLeka.Text.Equals(""))
            {
                jacinaLeka.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                jacinaLeka.BorderBrush = System.Windows.Media.Brushes.Black;
            }
        }

        private void nazivSastojka_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (nazivSastojka.Text.Equals(String.Empty) && !kolicinaSastojka.Text.Equals(String.Empty))
            {
                nazivSastojka.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                nazivSastojka.BorderBrush = System.Windows.Media.Brushes.Black;
            }

        }

        private void kolicinaSastojka_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((kolicinaSastojka.Text.Equals(String.Empty) && !nazivSastojka.Text.Equals(String.Empty)) || !Double.TryParse(kolicinaSastojka.Text, out Double broj))
            {
                kolicinaSastojka.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                kolicinaSastojka.BorderBrush = System.Windows.Media.Brushes.Black;
            }

        }

        private void Label_ToolTipOpening(object sender, ToolTipEventArgs e)
        {

        }
    }
}

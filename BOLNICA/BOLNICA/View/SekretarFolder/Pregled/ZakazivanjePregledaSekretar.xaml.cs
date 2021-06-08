using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.SekretarFolder;
using Bolnica.SekretarFolder.Operacija;
using Bolnica.View.SekretarFolder.LicnaObavestenja;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace Bolnica.Sekretar.Pregled
{
    /// <summary>
    /// Interaction logic for ZakazivanjePregledaSekretar.xaml
    /// </summary>
    public partial class ZakazivanjePregledaSekretar : System.Windows.Controls.UserControl
    {
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        LekariKontroler lekariKontroler = new LekariKontroler();

        TerminKontroler terminKontroler = new TerminKontroler();
        public static ObservableCollection<PacijentDTO> SviPacijenti { get; set; }
        public static ObservableCollection<LekarDTO> SviLekari { get; set; }
        CancellationTokenSource cts;
        public ZakazivanjePregledaSekretar()
        {
            InitializeComponent();
            ObicanMod();
            this.DataContext = this;
            SviPacijenti = new ObservableCollection<PacijentDTO>();
            SviLekari = new ObservableCollection<LekarDTO>();

            foreach (PacijentDTO p in naloziPacijenataKontroler.DobaviSveNaloge())
            {
                SviPacijenti.Add(p);
            }
            this.dataGridPacijenti.ItemsSource = SviPacijenti;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dataGridPacijenti.ItemsSource);
            view.Filter = FiltriranjePacijenata;
            foreach (LekarDTO l in lekariKontroler.DobaviSveLekare())
            {
                SviLekari.Add(l);
            }
            this.dataGridLekari.ItemsSource = SviLekari;
            view = (CollectionView)CollectionViewSource.GetDefaultView(dataGridLekari.ItemsSource);
            view.Filter = FiltriranjeLekara;
        }
        private bool FiltriranjeLekara(object item)
        {
            if (String.IsNullOrEmpty(poljeZaPreragu.Text))
                return true;
            else
                return ((item as LekarDTO).Prezime.IndexOf(poljeZaPreragu.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void poljeZaPreraguLekara_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dataGridLekari.ItemsSource).Refresh();
        }
        private bool FiltriranjePacijenata(object item)
        {
            if (String.IsNullOrEmpty(poljeZaPretragu.Text))
                return true;
            else
                return ((item as PacijentDTO).Prezime.IndexOf(poljeZaPretragu.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void poljeZaPreraguPacijenata_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dataGridPacijenti.ItemsSource).Refresh();
        }
        private void ObicanMod()
        {
            btnDemo.Visibility = Visibility.Visible;
            btnStop.Visibility = Visibility.Hidden;
            lblDemo.Visibility = Visibility.Hidden;
            lblPacijent.Visibility = Visibility.Hidden;
            cursor1.Visibility = Visibility.Hidden;
            lblDatum.Visibility = Visibility.Hidden;
            cursor2.Visibility = Visibility.Hidden;
            cursor3.Visibility = Visibility.Hidden;
            lblLekar.Visibility = Visibility.Hidden;
            cursor4.Visibility = Visibility.Hidden;
            lblPrioritet.Visibility = Visibility.Hidden;
            cursor5.Visibility = Visibility.Hidden;
            lblPotvrdi.Visibility = Visibility.Hidden;
            cursor6.Visibility = Visibility.Hidden;

            dataGridPacijenti.SelectedIndex = -1;
            datumPocetak.SelectedDate = null;
            datumKraj.SelectedDate = null;
            dataGridLekari.SelectedIndex = -1;
            prioritet.SelectedIndex = -1;
        }
        private async void ScreenTap(object sender, System.Windows.Input.InputGesture e)
        {
            if (cts == null)
            {
                cts = new CancellationTokenSource();
                try
                {
                    await DemoAsync(cts.Token);
                }
                catch (OperationCanceledException)
                {
                }
                finally
                {
                    cts = null;
                }
            }
            else
            {
                cts.Cancel();
                cts = null;
            }
        }

        private async Task DemoAsync(CancellationToken token)
        {
            for (int i = 0; ; i++)
            {
                token.ThrowIfCancellationRequested();
                await Demo();
            }
        }
        private async void Demo_Click(object sender, RoutedEventArgs e)
        {
            if(btnStop.Visibility == Visibility.Visible)
            {
                btnStop.Visibility = Visibility.Hidden;
            }
            else
            {
                btnStop.Visibility = Visibility.Visible;
            }
            if (cts == null)
            {
                cts = new CancellationTokenSource();
                try
                {
                    await DemoAsync(cts.Token);
                }
                catch (OperationCanceledException)
                {
                }
                finally
                {
                    cts = null;
                }
            }
            else
            {
                cts.Cancel();
                cts = null;
            }
        }
        private async Task Demo()
        {
            btnDemo.Visibility = Visibility.Hidden;
            btnStop.Visibility = Visibility.Visible;
            lblDemo.Visibility = Visibility.Visible;

            if(Provera())
            {
                return;
            }
            await Task.Delay(1500);
            if (Provera())
            {
                return;
            }
            lblPacijent.Visibility = Visibility.Visible;
            cursor1.Visibility = Visibility.Visible;
            if (Provera())
            {
                return;
            }
            await Task.Delay(1000);
            if (Provera())
            {
                return;
            }
            dataGridPacijenti.SelectedIndex = 1;
            if (Provera())
            {
                return;
            }
            await Task.Delay(2000);
            if (Provera())
            {
                return;
            }
            lblPacijent.Visibility = Visibility.Hidden;
            cursor1.Visibility = Visibility.Hidden;
            
            lblDatum.Visibility = Visibility.Visible;
            cursor2.Visibility = Visibility.Visible;
            if (Provera())
            {
                return;
            }
            await Task.Delay(1000);
            if (Provera())
            {
                return;
            }
            datumPocetak.SelectedDate = DateTime.Now;
            if (Provera())
            {
                return;
            }
            await Task.Delay(1000);
            if (Provera())
            {
                return;
            }
            cursor2.Visibility = Visibility.Hidden;
            
            cursor3.Visibility = Visibility.Visible;
            if (Provera())
            {
                return;
            }
            await Task.Delay(1000);
            if (Provera())
            {
                return;
            }
            datumKraj.SelectedDate = DateTime.Now.AddDays(10);
            if (Provera())
            {
                return;
            }
            await Task.Delay(1000);
            if (Provera())
            {
                return;
            }
            lblDatum.Visibility = Visibility.Hidden;
            cursor3.Visibility = Visibility.Hidden;

            lblLekar.Visibility = Visibility.Visible;
            cursor4.Visibility = Visibility.Visible;
            if (Provera())
            {
                return;
            }
            await Task.Delay(1000);
            if (Provera())
            {
                return;
            }
            dataGridLekari.SelectedIndex = 1;
            await Task.Delay(2000);
            if (Provera())
            {
                return;
            }
            lblLekar.Visibility = Visibility.Hidden;
            cursor4.Visibility = Visibility.Hidden;

            lblPrioritet.Visibility = Visibility.Visible;
            cursor5.Visibility = Visibility.Visible;
            if (Provera())
            {
                return;
            }
            await Task.Delay(1000);
            if (Provera())
            {
                return;
            }
            prioritet.SelectedIndex = 1;
            if (Provera())
            {
                return;
            }
            await Task.Delay(2000);
            if (Provera())
            {
                return;
            }
            lblPrioritet.Visibility = Visibility.Hidden;
            cursor5.Visibility = Visibility.Hidden;

            lblPotvrdi.Visibility = Visibility.Visible;
            cursor6.Visibility = Visibility.Visible;
            if (Provera())
            {
                return;
            }
            await Task.Delay(2000);
            if (Provera())
            {
                return;
            }
            lblPotvrdi.Visibility = Visibility.Hidden;
            cursor6.Visibility = Visibility.Hidden;
            if (Provera())
            {
                return;
            }
            await Task.Delay(1000);

            dataGridPacijenti.SelectedIndex = -1;
            datumPocetak.SelectedDate = null;
            datumKraj.SelectedDate = null;
            dataGridLekari.SelectedIndex = -1;
            prioritet.SelectedIndex = -1;

            lblDemo.Visibility = Visibility.Hidden;
        }
        private bool Provera()
        {
            if(cts==null)
            {
                ObicanMod();
                return true;
            }
            return false;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        { 
            if (!PodaciPravilnoUneti())
            {
                return;
            }
            String idPacijenta = (((PacijentDTO)dataGridPacijenti.SelectedItem).KorisnickoIme);
            String idLekara = (((LekarDTO)dataGridLekari.SelectedItem).KorisnickoIme);

            List<TerminDTO> datumi = new List<TerminDTO>();

                DateTime? datum = this.datumPocetak.SelectedDate;
                DateTime? datum1 = this.datumKraj.SelectedDate;
                DateTime pom = (DateTime)datum;
                DateTime pom1 = (DateTime)datum1;

                List<TerminDTO> pomocna = new List<TerminDTO>();

                bool nasao = false;

                datumi.Clear();

                pomocna = terminKontroler.PretraziPoLekaruUIntervalu(NadjiDatumUIntervalu((DateTime)datumPocetak.SelectedDate, (DateTime)datumKraj.SelectedDate), idLekara);
            foreach (TerminDTO t in pomocna)
                {
                    nasao = false;
                    foreach (TerminDTO t1 in datumi)
                    {
                        if (t1.Datum.Equals(t.Datum))
                        {
                            nasao = true;
                            break;
                        }
                    }
                    if (!nasao)
                    {
                        datumi.Add(t);
                    }

                }
            if (datumi.Count == 0)  //Prioritet lekar
            {
                if (prioritet.SelectedIndex == 0)
                {
                    DateTime tr1 = pom.AddDays(-7);
                    DateTime tr2 = pom.AddDays(7);

                    pomocna = terminKontroler.PretraziPoLekaruUIntervalu(NadjiDatumUIntervalu((DateTime)datumPocetak.SelectedDate, (DateTime)datumKraj.SelectedDate), idLekara);

                    foreach (TerminDTO t in pomocna)
                    {
                        nasao = false;
                        foreach (TerminDTO t1 in datumi)
                        {
                            if (t1.Datum.Equals(t.Datum))
                            {
                                nasao = true;
                                break;
                            }
                        }
                        if (!nasao)
                        {
                            datumi.Add(t);
                        }

                    }
                    if(datumi.Count==0)
                    {
                        System.Windows.Forms.MessageBox.Show("Nema slobodnih termina za unete podatke!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else 
                    {
                        UserControl usc = null;
                        GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                        usc = new ZakazivanjePregledaTerminiSekretar(idPacijenta, datumi);
                        GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
                    }
                }
                else if (prioritet.SelectedIndex == 1)//Prioritet datum
                {
                    pomocna = terminKontroler.NadjiTermineUIntervalu(pom, pom1);
                    foreach (TerminDTO t in pomocna)
                    {
                        nasao = false;
                        foreach (TerminDTO t1 in datumi)
                        {
                            if (t1.Datum.Equals(t.Datum) && t1.Lekar.KorisnickoIme.Equals(t.Lekar.KorisnickoIme))
                            {
                                nasao = true;
                                break;
                            }
                        }
                        if (!nasao)
                        {
                            datumi.Add(t);
                        }
                    }
                    if (datumi.Count == 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Nema slobodnih termina za unete podatke!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        UserControl usc = null;
                        GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                        usc = new ZakazivanjePregledaTerminiSekretar(idPacijenta, datumi);
                        GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
                    }
                }
            }
            else
            {
                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new ZakazivanjePregledaTerminiSekretar(idPacijenta, datumi);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
        }

        private bool PodaciPravilnoUneti()
        {
            if (dataGridPacijenti.SelectedIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Izaberite pacijenta!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dataGridLekari.SelectedIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Izaberite lekara!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!datumPocetak.SelectedDate.HasValue)
            {
                System.Windows.Forms.MessageBox.Show("Izaberite početni datum!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!datumKraj.SelectedDate.HasValue)
            {
                System.Windows.Forms.MessageBox.Show("Izaberite krajnji datum!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public List<Termin> NadjiDatumUIntervalu(DateTime datumOd, DateTime datumDo)
        {
            return terminKontroler.NadjiTermineUIntervaluSekretar(datumOd, datumDo);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new TerminiPregledaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Pocetna_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new GlavniProzorSadrzaj();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Nalozi_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new PrikazNalogaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Odjava_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();

            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
        private void Operacija_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new HitnaOperacijePregled();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Obavestenja_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new ObavestenjaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Stacionarno_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new StacionarnoLecenjeSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new TransferPacijenataSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Naplata_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new NaplataUslugeSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void LicnaObavestenja_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new LicnaObavestenjaSekretar(GlavniProzorSekretar.getInstance().getSekretar().KorisnickoIme);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void MojNalog_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new MojNalogSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}

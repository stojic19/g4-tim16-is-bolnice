using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.SekretarFolder;
using Bolnica.SekretarFolder.Operacija;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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

        public ZakazivanjePregledaSekretar()
        {
            InitializeComponent();

            this.DataContext = this;
            SviPacijenti = new ObservableCollection<PacijentDTO>();
            SviLekari = new ObservableCollection<LekarDTO>();

            foreach (PacijentDTO p in naloziPacijenataKontroler.DobaviSveNaloge())
            {
                SviPacijenti.Add(p);
            }
            foreach (LekarDTO l in lekariKontroler.DobaviSveLekare())
            {
                SviLekari.Add(l);
            }
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
    }
}

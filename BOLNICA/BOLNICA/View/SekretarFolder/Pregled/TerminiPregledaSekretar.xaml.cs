using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.Repozitorijum;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bolnica.Sekretar.Pregled
{
    /// <summary>
    /// Interaction logic for TerminiPregledaSekretar.xaml
    /// </summary>
    public partial class TerminiPregledaSekretar : UserControl
    {
        TerminKontroler terminKontroler = new TerminKontroler();
        public static ObservableCollection<TerminDTO> TerminiPregleda { get; set; }
        public TerminiPregledaSekretar()
        {
            InitializeComponent();

            this.DataContext = this;
            TerminiPregleda = new ObservableCollection<TerminDTO>();

            foreach (TerminDTO t in terminKontroler.DobaviSveZakazaneTermine())
            {
                    TerminiPregleda.Add(t);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Zakazivanje
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new ZakazivanjePregledaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Pomeranje
            if (dataGridTerminiPregleda.SelectedIndex != -1)
            {
                TerminDTO t = (((TerminDTO)dataGridTerminiPregleda.SelectedItem));

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new PomeranjePregledaSekretar(t);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                MessageBox.Show("Izaberite termin za pomeranje!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Otkazivanje
            if (dataGridTerminiPregleda.SelectedIndex != -1)
            {
                String id = (((TerminDTO)dataGridTerminiPregleda.SelectedItem).IdTermina);

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new OtkazivanjePregledaSekretar(id);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
                MessageBox.Show("Izaberite termin za otkazivanje!");
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

using Bolnica.Izvestaj.Upravnik;
using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
using Bolnica.UpravnikFolder;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for UpravnikGlavniProzor.xaml
    /// </summary>
    public partial class UpravnikGlavniProzor : Window
    {
        private static UpravnikGlavniProzor instance = null;
        ProstoriKontroler prostoriKontroler = new ProstoriKontroler();
        ZahtjeviKontroler zahtjeviKontroler = new ZahtjeviKontroler();
        LijekIzvjestaj lijekIzvjestaj = new LijekIzvjestaj();
        public static UpravnikGlavniProzor getInstance()
        {
            if (instance == null)
                instance = new UpravnikGlavniProzor();
            return instance;
        }
        public UpravnikGlavniProzor()
        {
            InitializeComponent();
            prostoriKontroler.ProvjeriDaLiJeProstorRenoviran();
        }

        private void strelica_Click(object sender, RoutedEventArgs e)
        {
            Login mw = new Login();
            mw.Show();
            this.Close();
        }

        private void Prostorije_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            MainPanel.Children.Clear();

            usc = new PrikazProstora();
            MainPanel.Children.Add(usc);

        }

        private void Oprema_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            MainPanel.Children.Clear();

            usc = new PrikazOpreme();
            MainPanel.Children.Add(usc);
        }

        private void Lijekovi_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            MainPanel.Children.Clear();

            usc = new PrikazLijekova();
            MainPanel.Children.Add(usc);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void krevet_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            MainPanel.Children.Clear();

            usc = new PremjestanjeStatickeOpreme();
            MainPanel.Children.Add(usc);
        }

        private void Renoviranje_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            MainPanel.Children.Clear();

            usc = new PrikazRenoviranja();
            MainPanel.Children.Add(usc);
        }

        private void Zahtjevi_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            MainPanel.Children.Clear();

            usc = new PrikazZahtjeva();
            MainPanel.Children.Add(usc);
        }

        private void renoviranje_Click_1(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            MainPanel.Children.Clear();

            usc = new RenoviranjeProstorije();
            MainPanel.Children.Add(usc);
        }

        private void Pdf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable dtbl = lijekIzvjestaj.MakeDataTable();
                String naslov = "Izvestaj lijekova";
                String datum = DateTime.Now.ToString("dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                String putanja = @"IzvjestajiUpravnik\IzvjestajLijek_" + datum + ".pdf";
                lijekIzvjestaj.ExportDataTableToPdf(dtbl, putanja, naslov);

                if (System.Windows.MessageBox.Show("Izvjestaj izgenerisan! Pogledati ga?", "Izvestaj lijekova", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start(putanja);
                }

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Error Message");
            }

        }

        private void Feedback_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            MainPanel.Children.Clear();

            usc = new DodavanjeFeedbacka();
            MainPanel.Children.Add(usc);
        }
    }
}
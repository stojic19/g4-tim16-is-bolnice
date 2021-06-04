using Bolnica.Kontroler;
using Bolnica.PacijentFolder;
using Bolnica.Repozitorijum;
using Bolnica.View.PacijentFolder;
using Model;
using System;
using System.Collections.Generic;
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
    public partial class PacijentGlavniProzor : Window
    {
        private static Grid GlavniSadrzaj;
        private String korisnickoIme;
        public PacijentGlavniProzor(String korisnickoIme)
        {
            InitializeComponent();
            this.korisnickoIme = korisnickoIme;
            GlavniSadrzaj = this.MainPanel;
            MainPanel.Children.Clear();
            MainPanel.Children.Add(new PrikazObavestenjaPacijent(korisnickoIme));
        }
        
        public static Grid GetGlavniSadrzaj()
        {
            return GlavniSadrzaj;
        }

        private void strelica_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        public void PromeniPrikaz(UserControl userControl)
        {
            MainPanel.Children.Clear();
            MainPanel.Children.Add(userControl);
        }

        private void obavestenja_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new PrikazObavestenjaPacijent(korisnickoIme));
            naslovStrane.Content = "          Obaveštenja";
        }

        private void Zakazi_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new ZakazivanjeSaPrioritetomPacijent(korisnickoIme));
            naslovStrane.Content = "    Zakaži pregled";
        }

        private void Raspored_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new PrikazRasporedaPacijent(korisnickoIme));
            naslovStrane.Content = "          Raspored";
        }

        private void Terapija_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new PrikazTerapijePacijent(korisnickoIme));
            naslovStrane.Content = "          Terapija";
        }

        private void Karton_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new PrikazKartona(korisnickoIme));
            naslovStrane.Content = "Zdravstveni karton";
        }

        private void Ankete_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new PrikazAnketa(korisnickoIme));
            naslovStrane.Content = "          Ankete";
        }

        private void Pomoc_Click(object sender, RoutedEventArgs e)
        {
           naslovStrane.Content = "     Pomoć";
            PromeniPrikaz(new Pomoc());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void mojNalog_Click(object sender, RoutedEventArgs e)
        {
            naslovStrane.Content = "     Lični profil";
            PromeniPrikaz(new LicniProfil(korisnickoIme));
        }

        private void odjaviSe_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void oceni_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

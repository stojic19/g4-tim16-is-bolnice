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
            PromeniPrikaz(new PrikazObavestenjaPacijent(korisnickoIme));
            SetNaslov("Obaveštenja");
        }
        
        public static Grid GetGlavniSadrzaj()
        {
            return GlavniSadrzaj;
        }

        public void PromeniPrikaz(UserControl userControl)
        {
            MainPanel.Children.Clear();
            MainPanel.Children.Add(userControl);
        }
        public void SetNaslov(String naslov)
        {
            naslovStrane.Content = "ZdravoKlinika -  " + naslov;
        }

        private void Obavestenja_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new PrikazObavestenjaPacijent(korisnickoIme));
            SetNaslov("Obaveštenja");
        }

        private void Zakazi_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new ZakazivanjeSaPrioritetomPacijent(korisnickoIme));
            SetNaslov("Zakaži pregled");
        }

        private void Raspored_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new PrikazRasporedaPacijent(korisnickoIme));
            SetNaslov("Raspored");
        }

        private void Terapija_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new PrikazTerapijePacijent(korisnickoIme));
            SetNaslov("Terapija");
        }

        private void Karton_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new PrikazKartona(korisnickoIme));
            SetNaslov("Zdravstvenii karton");
        }

        private void Ankete_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new PrikazAnketa(korisnickoIme));
            SetNaslov("Ankete");
        }

        private void Pomoc_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new Pomoc());
            SetNaslov("Pomoć");
        }

        private void MojNalog_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new LicniProfil(korisnickoIme));
            SetNaslov("Moj nalog");
        }

        private void OdjaviSe_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Oceni_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new OceniAplikaciju(korisnickoIme));
            SetNaslov("Prijavi problem");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}

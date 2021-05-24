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
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();

        private static Grid GlavniSadrzaj;
        public static Pacijent ulogovani = null;
   
        public PacijentGlavniProzor(String id)
        {
            InitializeComponent();
            
            ulogovani = naloziPacijenataKontroler.PretraziPoId(id);
            GlavniSadrzaj = this.MainPanel;
            MainPanel.Children.Clear();
            MainPanel.Children.Add(new PrikazObavestenjaPacijent());

            MessageBox.Show("ksavndksjvnksjvnskjnv" + TerminRepozitorijum.nadjiSlobodanTerminPoId("T12").IdTermina);
        }
        
        public static Grid GetGlavniSadrzaj()
        {
            return GlavniSadrzaj;
        }

        private void strelica_Click(object sender, RoutedEventArgs e)
        {
            TerminRepozitorijum.SerijalizacijaTermina();
            TerminRepozitorijum.SerijalizacijaSlobodnihTermina();
            // NaloziPacijenataServis.Sacuvaj();
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
            PromeniPrikaz(new PrikazObavestenjaPacijent());
            naslovStrane.Content = "          Obaveštenja";
        }

        private void Zakazi_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new ZakazivanjeSaPrioritetomPacijent());
            naslovStrane.Content = "    Zakaži pregled";
        }

        private void Raspored_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new PrikazRasporedaPacijent());
            naslovStrane.Content = "          Raspored";
        }

        private void Terapija_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new PrikazTerapijePacijent());
            naslovStrane.Content = "          Terapija";
        }

        private void Karton_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new PrikazKartona());
            naslovStrane.Content = "Zdravstveni karton";
        }

        private void Ankete_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new PrikazAnketa());
            naslovStrane.Content = "          Ankete";
        }

        private void Pomoc_Click(object sender, RoutedEventArgs e)
        {
           naslovStrane.Content = "     Pomoć";
            PromeniPrikaz(new PomocZakazivanje());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TerminRepozitorijum.SerijalizacijaTermina();
            TerminRepozitorijum.SerijalizacijaSlobodnihTermina();
            // NaloziPacijenataServis.Sacuvaj();
        }
      

    }
}

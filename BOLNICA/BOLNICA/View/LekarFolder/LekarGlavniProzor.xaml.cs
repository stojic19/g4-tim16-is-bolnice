using Bolnica.Model.Rukovanja;
using Bolnica.Repozitorijum;
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

namespace Bolnica.LekarFolder
{
    public partial class LekarGlavniProzor : Window
    {
        private static Grid PocetniPogled;
        String KoriscnickoImeLekara = null;
        public LekarGlavniProzor(String korisnickoIme)
        {
            InitializeComponent();
            PocetniPogled = this.GlavniProzor;
            this.KoriscnickoImeLekara = korisnickoIme;
            PromenaPogleda(new PocetnaStranicaLekar(KoriscnickoImeLekara));
        }

        private void Povratak(object sender, RoutedEventArgs e)
        {
            Serijalizacije();
            Login prozorLogovanje = new Login();
            prozorLogovanje.Show();
            this.Close();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Serijalizacije();

        }

        private void Serijalizacije()
        {
            TerminRepozitorijum.SerijalizacijaTermina();
            TerminRepozitorijum.SerijalizacijaSlobodnihTermina();
        }

        public void PromenaPogleda(UserControl userControl)
        {
            GlavniProzor.Children.Clear();
            GlavniProzor.Children.Add(userControl);
        }

        public static Grid DobaviProzorZaIzmenu()
        {
            return PocetniPogled;
        }

        private void PocetnaStrana(object sender, RoutedEventArgs e)
        {
            Serijalizacije();
            this.menu.Visibility = Visibility.Hidden;
            PromenaPogleda(new PocetnaStranicaLekar(KoriscnickoImeLekara));
        }

        private void PrikazRasporeda(object sender, RoutedEventArgs e)
        {
            Serijalizacije();
            this.menu.Visibility = Visibility.Hidden;
            PromenaPogleda(new PrikazTerminaLekara(KoriscnickoImeLekara));
        }

        private void ZakazivanjeTermina(object sender, RoutedEventArgs e)
        {
            Serijalizacije();
            this.menu.Visibility = Visibility.Hidden;
            PromenaPogleda(new ZakazivanjeTerminaLekar(KoriscnickoImeLekara));
        }

        private void UtrosenMaterijal(object sender, RoutedEventArgs e)
        {

        }

        private void PrikazBaze(object sender, RoutedEventArgs e)
        {
            Serijalizacije();
            this.menu.Visibility = Visibility.Hidden;
            PromenaPogleda(new BazaLekova(KoriscnickoImeLekara));
        }

        private void VerifikacijaLekova(object sender, RoutedEventArgs e)
        {
            Serijalizacije();
            this.menu.Visibility = Visibility.Hidden;
            PromenaPogleda(new VerifikacijaLekova(KoriscnickoImeLekara));
        }

        private void PrikazZahtevaOdsustva(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {

        }

        private void OtvaranjeMenija(object sender, RoutedEventArgs e)
        {
            if (this.menu.Visibility == Visibility.Visible)
            {
                this.menu.Visibility = Visibility.Hidden;
            }
            else { this.menu.Visibility = Visibility.Visible; }

        }
    }
}

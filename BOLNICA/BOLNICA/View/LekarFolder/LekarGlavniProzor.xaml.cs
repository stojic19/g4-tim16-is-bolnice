﻿using Bolnica.Model.Rukovanja;
using Bolnica.Repozitorijum;
using Bolnica.View.LekarFolder.NalogLekara;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Bolnica.LekarFolder
{
    public partial class LekarGlavniProzor : Window
    {
        private static Grid PocetniPogled;
        private static UserControl PrethodnaStanica;
        private static UserControl TrenutnaStranica;
        private static String korisnickoImeLekara = null;
        public LekarGlavniProzor(String korisnickoIme)
        {
            InitializeComponent();
            PostaviKorisnickoIme(korisnickoIme);
            var app = (App)Application.Current;
            app.PromenaJezika("sr-LATN");
            PocetniPogled = this.GlavniProzor;
            PromenaPogleda(new PocetnaStranicaLekar());
            postaviPrethodnu();
        }

        private void Povratak(object sender, RoutedEventArgs e)
        {
            PromenaPogleda(PrethodnaStanica);
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

        public static void postaviPrethodnu()
        {
            PrethodnaStanica = TrenutnaStranica;
        }

        public static void postaviTrenutnu(UserControl trenutna)
        {
            TrenutnaStranica = trenutna;
        }

        public static void PostaviKorisnickoIme(String idLekara)
        {
            korisnickoImeLekara = null;
            korisnickoImeLekara = idLekara;
        }

        public static String DobaviKorisnickoIme()
        {
            return korisnickoImeLekara;
        }

        private void PocetnaStrana(object sender, RoutedEventArgs e)
        {
            this.menu.Visibility = Visibility.Hidden;
            PromenaPogleda(new PocetnaStranicaLekar());
        }

        private void PrikazRasporeda(object sender, RoutedEventArgs e)
        {
            this.menu.Visibility = Visibility.Hidden;
            PromenaPogleda(new PrikazTerminaLekara());
        }

        private void ZakazivanjeTermina(object sender, RoutedEventArgs e)
        {
            this.menu.Visibility = Visibility.Hidden;
            PromenaPogleda(new ZakazivanjeTerminaLekar());
        }

        private void UtrosenMaterijal(object sender, RoutedEventArgs e)
        {

        }

        private void PrikazBaze(object sender, RoutedEventArgs e)
        {
            this.menu.Visibility = Visibility.Hidden;
            PromenaPogleda(new BazaLekova());
        }

        private void VerifikacijaLekova(object sender, RoutedEventArgs e)
        {
            this.menu.Visibility = Visibility.Hidden;
            PromenaPogleda(new VerifikacijaLekova());

        }

        private void PrikazZahtevaOdsustva(object sender, RoutedEventArgs e)
        {

        }

        private void KreiranjeOdsustva(object sender, RoutedEventArgs e)
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

        private void menu_MouseLeave(object sender, MouseEventArgs e)
        {
            this.menu.Visibility = Visibility.Hidden;
            this.mojProfil.Visibility = Visibility.Hidden;
            this.tema.Visibility = Visibility.Hidden;
            this.jezik.Visibility = Visibility.Hidden;
        }

        private void PrikazProfila(object sender, RoutedEventArgs e)
        {
            PromenaPogleda(new NalogLekara());
        }

        private void PrikazObavestenja(object sender, RoutedEventArgs e)
        {

        }

        private void IzmenaNaloga(object sender, RoutedEventArgs e)
        {
            PromenaPogleda(new IzmenaNaloga());
        }

        private void Odjava(object sender, RoutedEventArgs e)
        {
            Login prozorLogovanje = new Login();
            prozorLogovanje.Show();
            this.Close();
        }

        private void PromenaLozinke(object sender, RoutedEventArgs e)
        {
            PromenaPogleda(new PromenaLozinke());
        }

        private void OtvaranjeMojProfil(object sender, RoutedEventArgs e)
        {
            if (this.mojProfil.Visibility == Visibility.Visible)
            {
                this.mojProfil.Visibility = Visibility.Hidden;
            }
            else { this.mojProfil.Visibility = Visibility.Visible; }
        }

        private void PrikazTema(object sender, RoutedEventArgs e)
        {
            if (this.tema.Visibility == Visibility.Visible)
            {
                this.tema.Visibility = Visibility.Hidden;
            }
            else { this.tema.Visibility = Visibility.Visible; }
        }

        private void SvetlaTema(object sender, RoutedEventArgs e)
        {
            var app = (App)Application.Current;
            app.PromenaTeme(new Uri("Teme/SvetlaTema.xaml", UriKind.Relative));
            ikonicaTeme.Source = new BitmapImage(new Uri(@"/Slike/LekarSlike/sun.png", UriKind.Relative));

        }

        private void TamnaTema(object sender, RoutedEventArgs e)
        {
            var app = (App)Application.Current;
            app.PromenaTeme(new Uri("Teme/TamnaTema.xaml", UriKind.Relative));
            ikonicaTeme.Source = new BitmapImage(new Uri(@"/Slike/LekarSlike/night.png", UriKind.Relative));

        }

        private void PromenaSrpski(object sender, RoutedEventArgs e)
        {
            var app = (App)Application.Current;
            app.PromenaJezika("sr-LATN");
            izabranJezik.Content = "SR";
        }

        private void PromenaEngleski(object sender, RoutedEventArgs e)
        {
            var app = (App)Application.Current;
            app.PromenaJezika("en-US");
            izabranJezik.Content = "EN";
        }

        private void PrikazJezika(object sender, RoutedEventArgs e)
        {
            if (this.jezik.Visibility == Visibility.Visible)
            {
                this.jezik.Visibility = Visibility.Hidden;
            }
            else { this.jezik.Visibility = Visibility.Visible; }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.M && Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                menu.Visibility = Visibility.Visible;
            }
            else if (e.Key == Key.X && Keyboard.IsKeyDown(Key.LeftCtrl)) {
                Odjava(sender, e);
            }
            else if (e.Key == Key.L && Keyboard.IsKeyDown(Key.LeftCtrl)){
                SvetlaTema(sender, e);
            }
            else if (e.Key == Key.D && Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                TamnaTema(sender, e);
            }
            else if (e.Key == Key.S && Keyboard.IsKeyDown(Key.LeftCtrl)){
                PromenaSrpski(sender, e);
            }
            else if (e.Key == Key.E && Keyboard.IsKeyDown(Key.LeftCtrl)){
                PromenaEngleski(sender, e);
            }

            if (menu.Visibility == Visibility.Visible)
            {
                if (e.Key == Key.D1 && Keyboard.IsKeyDown(Key.LeftCtrl))
                {
                    PrikazRasporeda(sender, e);
                }
                else if (e.Key == Key.D2 && Keyboard.IsKeyDown(Key.LeftCtrl))
                {
                    ZakazivanjeTermina(sender, e);
                }
                else if (e.Key == Key.D4 && Keyboard.IsKeyDown(Key.LeftCtrl))
                {
                    PrikazBaze(sender, e);
                }
                else if (e.Key == Key.D5 && Keyboard.IsKeyDown(Key.LeftCtrl))
                {
                    VerifikacijaLekova(sender, e);
                }
            }
        }
    }
}

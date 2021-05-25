﻿using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.Sekretar.Pregled;
using Bolnica.SekretarFolder.Operacija;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.SekretarFolder
{
    /// <summary>
    /// Interaction logic for PrikazPregledaSekretar.xaml
    /// </summary>
    public partial class PromenaSmeneSekretar : UserControl
    {
        RasporedLekaraKontroler rasporedLekaraKontroler = new RasporedLekaraKontroler();

        private String IdIzabranogLekara;
        private RadniDan radniDanZaPromenuSmene;
        public PromenaSmeneSekretar(String idIzabranogLekara, RadniDan radniDan)
        {
            InitializeComponent();
            IdIzabranogLekara = idIzabranogLekara;
            radniDanZaPromenuSmene = radniDan;

            dpPocetniDatum.SelectedDate = radniDan.PocetakSmene;
            dpKrajnjiDatum.SelectedDate = radniDan.KrajSmene;
        }

        private void Pocetna_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new GlavniProzorSadrzaj();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Termini_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new TerminiPregledaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private void Nalozi_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new PrikazNalogaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Obavestenja_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new ObavestenjaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Operacije_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new HitnaOperacijePregled();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new PrikazRasporedaLekaraSekretar(IdIzabranogLekara);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            rasporedLekaraKontroler.PromeniSmenu(IdIzabranogLekara, radniDanZaPromenuSmene, cbSmena.Text);

            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new PrikazRasporedaLekaraSekretar(IdIzabranogLekara);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}

﻿using Bolnica.Sekretar.Pregled;
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

namespace Bolnica
{

    public partial class PrikazNalogaSekretar : UserControl
    {
        public static ObservableCollection<Pacijent> NaloziPacijenata { get; set; }

        public PrikazNalogaSekretar()
        {
            InitializeComponent();

            this.DataContext = this;

            NaloziPacijenata = new ObservableCollection<Pacijent>();

            foreach (Pacijent p in NaloziPacijenataServis.SviNalozi())
            {
                NaloziPacijenata.Add(p);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new DodavanjeNalogaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (dataGridNaloziPacijenata.SelectedIndex != -1)
            {
                String id = (((Pacijent)dataGridNaloziPacijenata.SelectedItem).KorisnickoIme);
                Pacijent pacijent = NaloziPacijenataServis.PretraziPoId(id);

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new IzmenaNalogaSekretar(pacijent.KorisnickoIme);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                MessageBox.Show("Izaberite nalog za izmenu!");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (dataGridNaloziPacijenata.SelectedIndex != -1)
            {
                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new UklanjanjeNalogaSekretar(((Pacijent)dataGridNaloziPacijenata.SelectedItem).KorisnickoIme);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
                MessageBox.Show("Izaberite nalog za uklanjanje!");

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (dataGridNaloziPacijenata.SelectedIndex != -1)
            {
                String id = (((Pacijent)dataGridNaloziPacijenata.SelectedItem).KorisnickoIme);
                Pacijent pacijent = NaloziPacijenataServis.PretraziPoId(id);

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new AlergeniSekretar(id);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                MessageBox.Show("Izaberite nalog za ažuriranje alergena!");
            }
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (dataGridNaloziPacijenata.SelectedIndex != -1)
            {
                if (((Pacijent)dataGridNaloziPacijenata.SelectedItem).Blokiran == false)
                {
                    MessageBox.Show("Nalog nije blokiran!");
                    return;
                }
                Pacijent p = NaloziPacijenataServis.PretraziPoId(((Pacijent)dataGridNaloziPacijenata.SelectedItem).KorisnickoIme);
                p.Blokiran = false;
                p.ZloupotrebioSistem = 0;
                // NaloziPacijenataServis.Sacuvaj();
            }
            else
            {
                MessageBox.Show("Izaberite nalog koji želite da odblokirate!");
            }
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

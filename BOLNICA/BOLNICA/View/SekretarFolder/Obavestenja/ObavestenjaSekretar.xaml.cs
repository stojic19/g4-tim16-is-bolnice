﻿using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.Sekretar.Pregled;
using Bolnica.SekretarFolder;
using Bolnica.SekretarFolder.Operacija;
using Bolnica.View.SekretarFolder.LicnaObavestenja;
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
    /// <summary>
    /// Interaction logic for ObavestenjaSekretar.xaml
    /// </summary>
    public partial class ObavestenjaSekretar : UserControl
    {
        ObavestenjaKontroler obavestenjaKontroler = new ObavestenjaKontroler();

        public static ObservableCollection<ObavestenjeDTO> SvaObavestenja { get; set; }
        public ObavestenjaSekretar()
        {
            InitializeComponent();

            // this.DataContext = this;
            PopuniTabeluObavestenja();
        }

        private void PopuniTabeluObavestenja()
        {
            SvaObavestenja = new ObservableCollection<ObavestenjeDTO>();
            foreach (ObavestenjeDTO o in obavestenjaKontroler.DobaviSvaObavestenja())
            {
                if (!o.Naslov.Equals("Terapija"))
                {
                    SvaObavestenja.Add(o);
                }
            }
            this.dataGridObavestenjaSekretar.ItemsSource = SvaObavestenja;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dataGridObavestenjaSekretar.ItemsSource);
            view.Filter = FiltriranjeObavestenja;
        }
        private bool FiltriranjeObavestenja(object item)
        {
            if (String.IsNullOrEmpty(poljeZaPreragu.Text))
                return true;
            else
                return ((item as ObavestenjeDTO).Naslov.IndexOf(poljeZaPreragu.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void poljeZaPreragu_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dataGridObavestenjaSekretar.ItemsSource).Refresh();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {    
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new DodavanjeObavestenja();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (dataGridObavestenjaSekretar.SelectedIndex != -1)
            {
                String id = (((ObavestenjeDTO)dataGridObavestenjaSekretar.SelectedItem).IdObavestenja);
                ObavestenjeDTO obavestenje = obavestenjaKontroler.PretraziPoId(id);

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new IzmenaObavestenja(obavestenje.IdObavestenja);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                MessageBox.Show("Izaberite obavestenje za izmenu!");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {          
            if (dataGridObavestenjaSekretar.SelectedIndex != -1)
            {
                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new UklanjanjeObavestenja(((ObavestenjeDTO)dataGridObavestenjaSekretar.SelectedItem).IdObavestenja);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
                MessageBox.Show("Izaberite obavestenje za uklanjanje!");
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new GlavniProzorSadrzaj();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
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
        private void Stacionarno_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new StacionarnoLecenjeSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new TransferPacijenataSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Naplata_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new NaplataUslugeSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void LicnaObavestenja_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new LicnaObavestenjaSekretar(GlavniProzorSekretar.getInstance().getSekretar().KorisnickoIme);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void MojNalog_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new MojNalogSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}

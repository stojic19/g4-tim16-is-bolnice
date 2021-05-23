using Bolnica.Sekretar.Pregled;
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
    /// <summary>
    /// Interaction logic for ObavestenjaSekretar.xaml
    /// </summary>
    public partial class ObavestenjaSekretar : UserControl
    {
        public static ObservableCollection<Obavestenje> SvaObavestenja { get; set; }
        public ObavestenjaSekretar()
        {
            InitializeComponent();

            this.DataContext = this;
            PopuniTabeluObavestenja();
        }

        private static void PopuniTabeluObavestenja()
        {
            SvaObavestenja = new ObservableCollection<Obavestenje>();
            foreach (Obavestenje o in ObavestenjaServis.SvaObavestenja())
            {
                if (!o.Naslov.Equals("Terapija"))
                {
                    SvaObavestenja.Add(o);
                }
            }
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
                String id = (((Obavestenje)dataGridObavestenjaSekretar.SelectedItem).IdObavestenja);
                Obavestenje obavestenje = ObavestenjaServis.PretraziPoId(id);

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

                usc = new UklanjanjeObavestenja(((Obavestenje)dataGridObavestenjaSekretar.SelectedItem).IdObavestenja);
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
    }
}

using Bolnica.Sekretar.Pregled;
using Bolnica.SekretarFolder;
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
    /// Interaction logic for AlergeniSekretar.xaml
    /// </summary>
    public partial class AlergeniSekretar : UserControl
    {
        String izabran = null;
        public static ObservableCollection<Alergeni> AlergeniPacijenta { get; set; }
        public AlergeniSekretar(String idPacijenta)
        {
            InitializeComponent();

            this.DataContext = this;
            izabran = idPacijenta;
            AlergeniPacijenta = new ObservableCollection<Alergeni>();

            foreach (Alergeni a in RukovanjeNalozimaPacijenata.DobaviAlergenePoIdPacijenta(idPacijenta))
            {
                AlergeniPacijenta.Add(a);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Dodavanje alergena
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new DodavanjeAlergena(izabran);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Izmena alergena
            if (dataGridAlergeniPacijenta.SelectedIndex != -1)
            {
                String id = (((Alergeni)dataGridAlergeniPacijenta.SelectedItem).IdAlergena);

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new IzmenaAlergena(izabran, id);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                MessageBox.Show("Izaberite alergene za izmenu!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Uklanjanje Alergena
            if (dataGridAlergeniPacijenta.SelectedIndex != -1)
            {
                String id = (((Alergeni)dataGridAlergeniPacijenta.SelectedItem).IdAlergena);

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new UklanjanjeAlergena(izabran, id);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
                MessageBox.Show("Izaberite alergene za uklanjanje!");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new PrikazNalogaSekretar();
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
    }
}

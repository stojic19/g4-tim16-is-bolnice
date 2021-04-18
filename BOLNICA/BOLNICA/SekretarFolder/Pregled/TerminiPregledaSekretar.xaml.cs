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

namespace Bolnica.Sekretar.Pregled
{
    /// <summary>
    /// Interaction logic for TerminiPregledaSekretar.xaml
    /// </summary>
    public partial class TerminiPregledaSekretar : Window
    {
        public static ObservableCollection<Termin> TerminiPregleda { get; set; }
        public TerminiPregledaSekretar()
        {
            InitializeComponent();

            this.DataContext = this;
            TerminiPregleda = new ObservableCollection<Termin>();

            foreach (Termin t in RukovanjeTerminima.DobaviSveTermine())
            {
                if(t.VrstaTermina == VrsteTermina.pregled)
                {
                    TerminiPregleda.Add(t);
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Zakazivanje
            ZakazivanjePregledaSekretar dodavanje = new ZakazivanjePregledaSekretar();
            dodavanje.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Pomeranje
            if (dataGridTerminiPregleda.SelectedIndex != -1)
            {
                Termin t = (((Termin)dataGridTerminiPregleda.SelectedItem));
                PomeranjePregledaSekretar pps = new PomeranjePregledaSekretar(t);
                pps.Show();
            }
            else
            {
                MessageBox.Show("Izaberite termin za pomeranje!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Otkazivanje
            if (dataGridTerminiPregleda.SelectedIndex != -1)
            {
                String id = (((Termin)dataGridTerminiPregleda.SelectedItem).IdTermina);
                OtkazivanjePregledaSekretar otkazivanje = new OtkazivanjePregledaSekretar(id);
                otkazivanje.Show();
            }
            else
                MessageBox.Show("Izaberite termin za otkazivanje!");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            GlavniProzorSekretar gps = new GlavniProzorSekretar();
            this.Close();
            gps.Show();
        }
    }
}

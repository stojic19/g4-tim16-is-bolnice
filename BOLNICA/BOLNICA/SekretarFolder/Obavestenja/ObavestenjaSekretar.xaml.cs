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
    public partial class ObavestenjaSekretar : Window
    {
        public static ObservableCollection<Obavestenje> SvaObavestenja { get; set; }
        public ObavestenjaSekretar()
        {
            InitializeComponent();

            this.DataContext = this;

            SvaObavestenja = new ObservableCollection<Obavestenje>();
            RukovanjeNalozimaPacijenata.Ucitaj();
            foreach (Obavestenje o in RukovanjeObavestenjimaSekratar.svaObavestenja)//Izmeniti kada je u pitanju personalizacija obavestenja
            {
                if (o.IdPrimaoca == "svi")
                {
                    SvaObavestenja.Add(o);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {    
            DodavanjeObavestenja dodavanje = new DodavanjeObavestenja();
            dodavanje.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (dataGridObavestenjaSekretar.SelectedIndex != -1)
            {
                String id = (((Obavestenje)dataGridObavestenjaSekretar.SelectedItem).IdObavestenja);
                Obavestenje obavestenje = RukovanjeObavestenjimaSekratar.PretraziPoId(id);
                IzmenaObavestenja izmena = new IzmenaObavestenja(obavestenje.IdObavestenja);
                izmena.Show();
            }
            else
            {
                MessageBox.Show("Izaberite obavestenje za izmenu!");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //TO DO: brisanje obaveštenja
            
            if (dataGridObavestenjaSekretar.SelectedIndex != -1)
            {
                UklanjanjeObavestenja uklanjanje = new UklanjanjeObavestenja(((Obavestenje)dataGridObavestenjaSekretar.SelectedItem).IdObavestenja);
                uklanjanje.Show();
            }
            else
                MessageBox.Show("Izaberite obavestenje za uklanjanje!");
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //TO DO: Povratak na glavni prozor sekretara
            GlavniProzorSekretar gps = new GlavniProzorSekretar();
            this.Close();
            gps.Show();
        }
    }
}

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
    public partial class AlergeniSekretar : Window
    {
        String izabran = null;
        public static ObservableCollection<Alergeni> AlergeniPacijenta { get; set; }
        public AlergeniSekretar(String id)
        {
            InitializeComponent();

            this.DataContext = this;
            izabran = id;
            AlergeniPacijenta = new ObservableCollection<Alergeni>();

            foreach (Alergeni a in RukovanjeNalozimaPacijenata.PretraziPoId(id).ZdravstveniKarton.Alergeni)
            {
                AlergeniPacijenta.Add(a);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Dodavanje alergena
            DodavanjeAlergena dodavanje = new DodavanjeAlergena(izabran);
            dodavanje.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Izmena alergena
            if (dataGridAlergeniPacijenta.SelectedIndex != -1)
            {
                String id = (((Alergeni)dataGridAlergeniPacijenta.SelectedItem).IdAlergena);
                IzmenaAlergena izmena = new IzmenaAlergena(izabran,id);
                izmena.Show();
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
                UklanjanjeAlergena uklanjanje = new UklanjanjeAlergena(izabran,id);
                uklanjanje.Show();
            }
            else
                MessageBox.Show("Izaberite alergene za uklanjanje!");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PrikazNalogaSekretar pns = new PrikazNalogaSekretar();
            this.Close();
            pns.Show();
        }
    }
}

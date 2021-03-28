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

    public partial class PrikazNalogaSekretar : Window
    {
        public static ObservableCollection<Pacijent> NaloziPacijenata { get; set; }

        public PrikazNalogaSekretar()
        {
            InitializeComponent();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //ZakazivanjeTerminaPacijent zakazivanje = new ZakazivanjeTerminaPacijent();
            //zakazivanje.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (dataGridNaloziPacijenata.SelectedIndex != -1)
            {
                String id = (((Pacijent)dataGridNaloziPacijenata.SelectedItem).korisnickoIme);
                Pacijent pacijent = RukovanjeNalozimaPacijenata.PretraziPoId(id);
                //IzmenaTerminaPacijent izmena = new IzmenaTerminaPacijent(termin);
                //izmena.Show();
            }
            else
            {
                MessageBox.Show("Izaberite nalog za izmenu!");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (dataGridNaloziPacijenata.SelectedIndex != -1)
                RukovanjeNalozimaPacijenata.UkolniNalog(((Pacijent)dataGridNaloziPacijenata.SelectedItem).korisnickoIme);
            else
                MessageBox.Show("Izaberite nalog za uklanjanje!");

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
        }
    }
}

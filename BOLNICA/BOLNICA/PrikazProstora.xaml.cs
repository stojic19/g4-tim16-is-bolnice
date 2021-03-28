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

    public partial class PrikazProstora : Window
    {

        public static ObservableCollection<Prostor> Prostori { get; set; }

        public PrikazProstora()
        {
            InitializeComponent();

            this.DataContext = this;

            Prostori = new ObservableCollection<Prostor>();

            foreach (Prostor p in RukovanjeProstorom.SviProstori())
            {
                Prostori.Add(p);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            DodavanjeProstora dodavanje = new DodavanjeProstora();
            dodavanje.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {





            IzmenaProstora izmena = new IzmenaProstora();
            izmena.Show();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {






            UklanjanjeProstora uklanjanje = new UklanjanjeProstora();
            uklanjanje.Show();


        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow glavniProzor = new MainWindow();
            glavniProzor.Show();
            this.Close();
        }

    }
}

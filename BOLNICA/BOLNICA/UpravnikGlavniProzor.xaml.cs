using Model;
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
using System.Windows.Shapes;

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for UpravnikGlavniProzor.xaml
    /// </summary>
    public partial class UpravnikGlavniProzor : Window
    {
        private static UpravnikGlavniProzor instance = null;

        public static UpravnikGlavniProzor getInstance()
        {
            if (instance == null)
                instance = new UpravnikGlavniProzor();
            return instance;
        }
        private UpravnikGlavniProzor()
        {
            InitializeComponent();
        }

        private void strelica_Click(object sender, RoutedEventArgs e)
        {
            RukovanjeProstorom.SerijalizacijaProstora();
            Login l = new Login();
            l.Show();
            this.Close();
            
        }

        private void Prostorije_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            MainPanel.Children.Clear();

            usc = new PrikazProstora();
            MainPanel.Children.Add(usc);

        }

        private void Oprema_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            MainPanel.Children.Clear();

            usc = new PrikazOpreme();
            MainPanel.Children.Add(usc);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /* RukovanjeTerminima.SerijalizacijaTermina();
             RukovanjeTerminima.SerijalizacijaSlobodnihTermina();*/
        }
    }
}
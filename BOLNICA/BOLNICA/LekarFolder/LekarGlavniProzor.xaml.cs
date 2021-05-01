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

namespace Bolnica.LekarFolder
{
    public partial class LekarGlavniProzor : Window
    {
        public LekarGlavniProzor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Nazad
        {
            Login prozorLogovanje = new Login();
            prozorLogovanje.Show();
            this.Close();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RukovanjeTerminima.SerijalizacijaTermina();
            RukovanjeNalozimaPacijenata.Sacuvaj();
            
        }
    }
}

using Bolnica.Model.Rukovanja;
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
        private static Grid PocetniPogled;
        String KoriscnickoImeLekara = null;
        public LekarGlavniProzor(String korisnickoIme)
        {
            InitializeComponent();
            PocetniPogled = this.GlavniProzor;
            this.KoriscnickoImeLekara = korisnickoIme;
            PromenaPogleda(new PocetnaStranicaLekar(KoriscnickoImeLekara));
        }

        private void Povratak(object sender, RoutedEventArgs e) 
        {
            RukovanjeTerminima.SerijalizacijaTermina();
            RukovanjeTerminima.SerijalizacijaSlobodnihTermina();
            RukovanjePregledima.SerijalizacijaPregleda();
            RukovanjeNalozimaPacijenata.Sacuvaj();
            RukovanjeOdobrenimLekovima.SerijalizacijaLekova();

            Login prozorLogovanje = new Login();
            prozorLogovanje.Show();
            this.Close();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RukovanjeTerminima.SerijalizacijaTermina();
            RukovanjeTerminima.SerijalizacijaSlobodnihTermina();
            RukovanjePregledima.SerijalizacijaPregleda();
            RukovanjeNalozimaPacijenata.Sacuvaj();
            RukovanjeOdobrenimLekovima.SerijalizacijaLekova();

        }

        public void PromenaPogleda(UserControl userControl)
        {
            GlavniProzor.Children.Clear();
            GlavniProzor.Children.Add(userControl);
        }

        public static Grid DobaviProzorZaIzmenu()
        {
            return PocetniPogled;
        }

        
        
    }
}

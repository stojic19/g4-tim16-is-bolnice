using Bolnica.Model;
using Bolnica.Model.Rukovanja;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.PacijentFolder
{
    public partial class IstorijaPregleda : UserControl
    {
        public static ObservableCollection<Pregled> ObavljeniPregledi { get; set; }
        public IstorijaPregleda()
        {
            InitializeComponent();
            ObavljeniPregledi = new ObservableCollection<Pregled>();
            foreach (Pregled pregled in RukovanjePregledima.sviPregledi)
            {
                if (pregled.Termin.Pacijent.KorisnickoIme.Equals(PacijentGlavniProzor.ulogovani.KorisnickoIme) && pregled.Odrzan)
                    ObavljeniPregledi.Add(pregled);
            }
            TerminiUProslosti.ItemsSource = ObavljeniPregledi;
        }

        private void IzvestajSaTermina_Click(object sender, RoutedEventArgs e)
        {
            if (TerminiUProslosti.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite termin!");
                    return;
            }
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new IzvestajSaPregleda((Pregled)TerminiUProslosti.SelectedItem));
        }
    }
}

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
    /// <summary>
    /// Interaction logic for IzvestajSaPregleda.xaml
    /// </summary>
    public partial class IzvestajSaPregleda : UserControl
    {
        public static ObservableCollection<Terapija> TerapijaPregleda { get; set; }
        public IzvestajSaPregleda(Pregled izabraniPregled)
        {
            InitializeComponent();
            DataContext = izabraniPregled;
            TerapijaPregleda = new ObservableCollection<Terapija>();

            foreach (Terapija terapija in izabraniPregled.Anamneza.Terapije)
            {
                TerapijaPregleda.Add(terapija);
            }

            Lekovi.ItemsSource = TerapijaPregleda;
        }
       
    }
}

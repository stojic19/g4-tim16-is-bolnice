using Bolnica.DTO;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
using Bolnica.ViewModel.PacijentViewModel;
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
    public partial class IzvestajSaPregleda : UserControl
    {
        IzvestajSaPregledaViewModel izvestajPregledaViewModel;
        public IzvestajSaPregleda(PregledDTO izabraniPregled)
        {
            InitializeComponent();
            izvestajPregledaViewModel = new IzvestajSaPregledaViewModel(izabraniPregled);
            Lekovi.ItemsSource = izvestajPregledaViewModel.Terapije;
            Recepti.ItemsSource = izvestajPregledaViewModel.Recepti;
            this.DataContext = izvestajPregledaViewModel;
        }

    }
}

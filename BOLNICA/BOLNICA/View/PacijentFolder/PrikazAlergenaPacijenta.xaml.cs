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
    /// Interaction logic for PrikazAlergenaPacijenta.xaml
    /// </summary>
    public partial class PrikazAlergenaPacijenta : UserControl
    {
        public static ObservableCollection<Alergeni> sviAlergeniPacijenta { get; set; }
        public PrikazAlergenaPacijenta()
        {
            InitializeComponent();
            sviAlergeniPacijenta = new ObservableCollection<Alergeni>();
            foreach (Alergeni a in PacijentGlavniProzor.ulogovani.ZdravstveniKarton.Alergeni)
            {
                    sviAlergeniPacijenta.Add(a);
            }
            alergeniPacijenta.ItemsSource = sviAlergeniPacijenta;
        }
    }
}

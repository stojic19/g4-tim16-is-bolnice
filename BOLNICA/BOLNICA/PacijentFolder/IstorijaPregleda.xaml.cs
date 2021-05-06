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
        public static ObservableCollection<Termin> ObavljeniTermini { get; set; }
        public IstorijaPregleda()
        {
            InitializeComponent();
            ObavljeniTermini = new ObservableCollection<Termin>();
            foreach (Termin t in RukovanjeTerminima.DobaviSveTermine())
            {
                if (t.Pacijent.KorisnickoIme.Equals(PacijentGlavniProzor.ulogovani.KorisnickoIme) && DateTime.Compare(t.Datum.Date,DateTime.Now.Date)<0)
                    ObavljeniTermini.Add(t);
            }
            TerminiUProslosti.ItemsSource = ObavljeniTermini;
        }
    }
}

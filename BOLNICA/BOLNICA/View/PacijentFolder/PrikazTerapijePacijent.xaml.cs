using Bolnica.Model;
using Bolnica.PacijentFolder;
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

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for PrikazTerapijePacijent.xaml
    /// </summary>
    public partial class PrikazTerapijePacijent : UserControl
    {
        //Dodato dok ne dodas kontroler za to
        ZdravstveniKartoniServis zdravstveniKartoniServis = new ZdravstveniKartoniServis();

        public static ObservableCollection<Terapija> sveTerapijePacijenta { get; set; }
        public PrikazTerapijePacijent()
        {
            InitializeComponent();
            sveTerapijePacijenta = new ObservableCollection<Terapija>();

            foreach (Terapija t in zdravstveniKartoniServis.dobaviSveTerapijePacijenta(PacijentGlavniProzor.ulogovani.KorisnickoIme))
            {
                if(DateTime.Compare(DateTime.Now.Date,t.KrajTerapije)<=0)
                sveTerapijePacijenta.Add(t);
            }

            LekoviLista.ItemsSource = sveTerapijePacijenta;
        }

    

        private void izvestaj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void informacije_Click(object sender, RoutedEventArgs e)
        {
            DetaljiTerapije prikazDetalja = new DetaljiTerapije((Terapija)LekoviLista.SelectedItem);
            prikazDetalja.Show();
        }
    }
}

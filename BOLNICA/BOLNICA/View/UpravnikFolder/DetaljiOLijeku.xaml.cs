using Bolnica.DTO;
using Bolnica.Kontroler;
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
using System.Windows.Shapes;

namespace Bolnica
{
    public partial class DetaljiOLijeku : UserControl
    {
        public static ObservableCollection<SastojakDTO> Sastojci { get; set; } 
        String IDLeka = null;
        ZahtjeviKontroler zahtjeviKontroler = new ZahtjeviKontroler();
        LekoviKontroler lekKontroler = new LekoviKontroler();
        public DetaljiOLijeku(String id)
        {
            InitializeComponent();

            IDLeka = id;
            LekDTO izabran = zahtjeviKontroler.pretraziLekPoId(id);
            textBoxNaziv.Text = izabran.NazivLeka;
            textBoxProizvodjac.Text = izabran.Proizvodjac;
            checkBox.IsChecked = izabran.Verifikacija;

            this.DataContext = this;
            Sastojci = new ObservableCollection<SastojakDTO>();

            foreach (SastojakDTO s in lekKontroler.DobaviSastojkeLeka(IDLeka))
            {
                Sastojci.Add(s);
            }

        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(new PrikazLijekova());
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)

        {
            if (zahtjeviKontroler.PretraziPoIdLijeka(IDLeka).Odgovor == Model.Enumi.VrsteOdgovora.Čekanje){
                DodavanjeSastojka dodavanje = new DodavanjeSastojka(IDLeka);
                dodavanje.Show();
            }

        }

        private void dataGridSastojci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}

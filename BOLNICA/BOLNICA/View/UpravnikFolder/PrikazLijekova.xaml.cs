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
    public partial class PrikazLijekova : UserControl
    {
        public static ObservableCollection<ZahtjevDTO> Zahtjevi { get; set; }
        ZahtjeviKontroler zahtjeviKontroler = new ZahtjeviKontroler();
        public PrikazLijekova()
        {
            InitializeComponent();

            this.DataContext = this;

            Zahtjevi = new ObservableCollection<ZahtjevDTO>();

            foreach (ZahtjevDTO z in zahtjeviKontroler.SviZahtjevi())
            {
                Zahtjevi.Add(z);

            }

        }

        private void Dodavanje_Click(object sender, RoutedEventArgs e)
        {

            DodavanjeLijeka dodavanje = new DodavanjeLijeka();
            dodavanje.Show();

        }

        private void Izmjena_Click(object sender, RoutedEventArgs e)
        {

            ZahtjevDTO izabranZaMenjanje = (ZahtjevDTO)dataGridLijekovi.SelectedItem;

            if (izabranZaMenjanje != null)
            {

                IzmjenaLijeka izmjena = new IzmjenaLijeka(izabranZaMenjanje.Lek.IdLeka);
                izmjena.Show();
            }
            else
            {
                MessageBox.Show("Izaberite lijek koji želite da izmenite!");
            }
        }

        private void Uklanjanje_Click(object sender, RoutedEventArgs e)
        {
            ZahtjevDTO izabranZaBrisanje = (ZahtjevDTO)dataGridLijekovi.SelectedItem;

            if (izabranZaBrisanje != null)
            {

                UklanjanjeLijeka uklanjanje = new UklanjanjeLijeka(izabranZaBrisanje.Lek.IdLeka);
                uklanjanje.Show();
            }
            else
            {
                MessageBox.Show("Izaberite lijek koji želite da uklonite!");
            }
        }

        private void dataGridLijekovi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Detalji_Click(object sender, RoutedEventArgs e)
        {
            ZahtjevDTO izabran = (ZahtjevDTO)dataGridLijekovi.SelectedItem;

            if (izabran != null)
            {

                UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
                UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(new DetaljiOLijeku(izabran.Lek.IdLeka));
            }
            else
            {
                MessageBox.Show("Izaberite lijek cije detalje zelite da vidite!");
            }
        }
    }
}

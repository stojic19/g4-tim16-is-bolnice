using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.UpravnikFolder;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

    public partial class PrikazZahtjeva : UserControl
    {
        ZahtjeviKontroler zahtjeviKontroler = new ZahtjeviKontroler();
        public static ObservableCollection<ZahtjevDTO> Zahtjevi { get; set; }

        public PrikazZahtjeva()
        {
            InitializeComponent();

            this.DataContext = this;

            Zahtjevi = new ObservableCollection<ZahtjevDTO>();

            foreach (ZahtjevDTO z in zahtjeviKontroler.SviZahtjevi())
            {
                Zahtjevi.Add(z);
            }
        }

        private void DodajZahtjev_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeZahtjeva dodavanje = new DodavanjeZahtjeva();
            dodavanje.Show();
        }

        private void IzmijeniZahtjev_Click(object sender, RoutedEventArgs e)
        {
            ZahtjevDTO izabranZaMenjanje = (ZahtjevDTO)dataGridZahtjevi.SelectedItem;

            if (izabranZaMenjanje != null)
            {

                IzmjenaZahtjeva izmjena = new IzmjenaZahtjeva(izabranZaMenjanje.IDZahtjeva);
                izmjena.Show();
            }
            else
            {
                MessageBox.Show("Izaberite lijek koji želite da izmenite!");
            }
        }

        private void UkloniZahtjev_Click(object sender, RoutedEventArgs e)
        {
            ZahtjevDTO izabranZaBrisanje = (ZahtjevDTO)dataGridZahtjevi.SelectedItem;

            if (izabranZaBrisanje != null)
            {

                UklanjanjeZahtjeva uklanjanje = new UklanjanjeZahtjeva(izabranZaBrisanje.IDZahtjeva);
                uklanjanje.Show();
            }
            else
            {
                MessageBox.Show("Izaberite lijek koji želite da uklonite!");
            }
        }
    }
}

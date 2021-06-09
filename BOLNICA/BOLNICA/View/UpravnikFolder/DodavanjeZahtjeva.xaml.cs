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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for DodavanjeLijeka.xaml
    /// </summary>
    public partial class DodavanjeZahtjeva : Window
    {
        ZahtjeviKontroler zahtjeviKontroler = new ZahtjeviKontroler();
        public static List<SastojakDTO> Sastojci { get; set; }
        public static ObservableCollection<ZahtjevDTO> Zahtjevi { get; set; }

        public ZahtjevDTO pomocniZahtjev;

        public DodavanjeZahtjeva()
        {
            InitializeComponent();
            Sastojci = new List<SastojakDTO>();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (zahtjeviKontroler.ProvjeriValidnostNaziva(this.nazivLijeka.Text))
            {
                LekDTO lijek = new LekDTO(Guid.NewGuid().ToString(), this.nazivLijeka.Text, this.jacina.Text, 0, Sastojci, this.proizvodjac.Text);
                ZahtjevDTO zahtjev = new ZahtjevDTO(Guid.NewGuid().ToString(), lijek, DateTime.Now);
                zahtjeviKontroler.DodajZahtjev(zahtjev);

                this.Close();
            }
        }

        private void DodajSastojak_Click(object sender, RoutedEventArgs e)
        {
            if (this.nazivSastojka.Text != String.Empty && this.kolicinaSastojka.Text != String.Empty)
            {
                SastojakDTO sastojak = new SastojakDTO(this.nazivSastojka.Text, double.Parse(this.kolicinaSastojka.Text));
                Sastojci.Add(sastojak);
                this.dataGridSastojci.DataContext = Sastojci;
                this.nazivSastojka.Text = String.Empty;
                this.kolicinaSastojka.Text = String.Empty;
            }
            else
            {
                System.Windows.MessageBox.Show("Morate unijeti i naziv i kolicinu da bi dodali sastojak!");
            }
        }

        private void UkloniSastojak_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridSastojci.SelectedItems.Count == 1)
            {
                SastojakDTO sastojak = (SastojakDTO)dataGridSastojci.SelectedItem;
                dataGridSastojci.Items.RemoveAt(dataGridSastojci.SelectedIndex);
            }
            else
            {
                System.Windows.MessageBox.Show("Morate izabrati sastojak da biste ga uklonili!");
            }
        }
    }
}

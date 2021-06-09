using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
using Model;
using System;
using System.Collections.Generic;
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
    public partial class IzmjenaZahtjeva : Window
    {
        String stari = null;
        ZahtjeviKontroler zahtjeviKontroler = new ZahtjeviKontroler();
        public IzmjenaZahtjeva(String id)
        {
            InitializeComponent();

            ZahtjevDTO zahtjev = zahtjeviKontroler.PretraziPoId(id);
            stari = id;
            LekDTO lijek = zahtjev.Lek;

            NazivLijeka.Text = lijek.NazivLeka;
            Jacina.Text = lijek.Jacina;
            Proizvodjac.Text = lijek.Proizvodjac;
            dataGridSastojci.DataContext = lijek.Sastojci;
        }
        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (zahtjeviKontroler.ProvjeriValidnostNaziva(this.NazivLijeka.Text))
            {
                LekDTO lijek = new LekDTO(stari, NazivLijeka.Text, Jacina.Text, 0, new List<SastojakDTO>(), Proizvodjac.Text);
                zahtjeviKontroler.IzmeniZahtjev(lijek);

                this.Close();
            }
        }

        private void DodajSastojak_Click(object sender, RoutedEventArgs e)
        {
           /* if (this.nazivSastojka != null && this.kolicinaSastojka != null)
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
            }*/
        }

        private void UkloniSastojak_Click(object sender, RoutedEventArgs e)
        {
            /*if (dataGridSastojci.SelectedItems.Count == 1)
            {
                SastojakDTO sastojka = (SastojakDTO)dataGridSastojci.SelectedItem;
                dataGridSastojci.Items.RemoveAt(dataGridSastojci.SelectedIndex);
            }
            else
            {
                System.Windows.MessageBox.Show("Morate izabrati sastojak da biste ga uklonili!");
            }*/
        }
    }
}

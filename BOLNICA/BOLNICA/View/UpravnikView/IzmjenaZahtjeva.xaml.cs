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
        public List<SastojakDTO> SastojciLista;
        public IzmjenaZahtjeva(String id)
        {
            InitializeComponent();

            ZahtjevDTO zahtjev = zahtjeviKontroler.PretraziPoId(id);
            stari = id;
   
            NazivLijeka.Text = zahtjev.Lek.NazivLeka;
            Jacina.Text = zahtjev.Lek.Jacina;
            Proizvodjac.Text = zahtjev.Lek.Proizvodjac;
            this.dataGridSastojci.ItemsSource = zahtjev.Lek.Sastojci;
            SastojciLista = new List<SastojakDTO>();
            SastojciLista = zahtjev.Lek.Sastojci;
        }
        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
           // if (zahtjeviKontroler.ProvjeriValidnostNaziva(this.NazivLijeka.Text))
           // {
                LekDTO lijek = new LekDTO(stari, NazivLijeka.Text, Jacina.Text, 0, new List<SastojakDTO>(), Proizvodjac.Text);
                zahtjeviKontroler.IzmeniZahtjev(lijek);

                this.Close();
            //}
        }

        private void DodajSastojak_Click(object sender, RoutedEventArgs e)
        {
            if (this.NazivSastojka.Text != String.Empty && this.KolicinaSastojka.Text != String.Empty)
            {
                SastojakDTO sastojak = new SastojakDTO(this.NazivSastojka.Text, double.Parse(this.KolicinaSastojka.Text));
                SastojciLista.Add(sastojak);
                this.dataGridSastojci.ItemsSource = SastojciLista;
                this.NazivSastojka.Text = String.Empty;
                this.KolicinaSastojka.Text = String.Empty;
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
                SastojciLista.Remove(sastojak);
                this.dataGridSastojci.ItemsSource = SastojciLista;
            }
            else
            {
                System.Windows.MessageBox.Show("Morate izabrati sastojak da biste ga uklonili!");
            }
        }
    }
}

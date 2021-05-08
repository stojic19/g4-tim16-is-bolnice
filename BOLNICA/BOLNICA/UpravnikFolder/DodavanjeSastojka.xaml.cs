using Bolnica.Model;
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
    /// <summary>
    /// Interaction logic for DodavanjeSastojka.xaml
    /// </summary>
    public partial class DodavanjeSastojka : Window
    {
        public DodavanjeSastojka()
        {
            InitializeComponent();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            String nazivSastojka = this.nazivSastojka.Text;
            foreach (Sastojak sastojak in RukovanjeLijekovima.SviSastojci())
            {
                if (sastojak.Naziv.Equals(this.nazivSastojka.Text))
                {
                    System.Windows.Forms.MessageBox.Show("Već postoji uneti naziv sastojka!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            int kolicina = int.Parse(this.kolicina.Text);


            Sastojak s = new Sastojak(nazivSastojka, kolicina);

            RukovanjeLijekovima.DodajSastojak(s);

            this.Close();

        }
    }
}

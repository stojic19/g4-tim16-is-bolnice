using Bolnica.Model;
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
    /// <summary>
    /// Interaction logic for IzmjenaLijeka.xaml
    /// </summary>
    public partial class IzmjenaLijeka : Window
    {
        String stari = null;
        public IzmjenaLijeka(String id)
        {
            InitializeComponent();

            stari = id;
            Lek lijek = RukovanjeLijekovima.pretraziPoId(stari);

            IdLijeka.Text = id;
            NazivLijeka.Text = lijek.NazivLeka;
            Jacina.Text = lijek.Jacina;
            Kolicina.Text = lijek.Kolicina.ToString();


        }
        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            foreach (Lek l in RukovanjeLijekovima.SviLijekovi())
            {
                if (l.IDLeka.Equals(this.IdLijeka.Text))
                {
                    System.Windows.Forms.MessageBox.Show("Već postoji evidentiran ID lijeka!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Lek lijek = new Lek(IdLijeka.Text, NazivLijeka.Text, Jacina.Text, int.Parse(Kolicina.Text), Proizvodjac.Text, Sastojci.Text, false);
            RukovanjeLijekovima.IzmjeniLijek(lijek);

            this.Close();
        }
    }
}

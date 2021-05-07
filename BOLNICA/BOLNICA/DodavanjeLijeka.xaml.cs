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
    /// Interaction logic for DodavanjeLijeka.xaml
    /// </summary>
    public partial class DodavanjeLijeka : Window
    {
        public DodavanjeLijeka()
        {
            InitializeComponent();
            
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            String idLijeka = Guid.NewGuid().ToString();
            foreach (Lek lek in RukovanjeLijekovima.SviLijekovi())
            {
                if (lek.IDLeka.Equals(this.idLijeka.Text))
                {
                    System.Windows.Forms.MessageBox.Show("Već postoji uneti Id lijeka!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            String nazivLeka = this.nazivLijeka.Text;
            String jacina = this.jacina.Text;
            int kolicina = int.Parse(this.kolicinaLijeka.Text);

            Lek lijek = new Lek(idLijeka, nazivLeka, jacina, kolicina);
            RukovanjeLijekovima.DodajLijek(lijek);
            RukovanjeLijekovima.SerijalizacijaLijekova();

            this.Close();

        }
    }
}

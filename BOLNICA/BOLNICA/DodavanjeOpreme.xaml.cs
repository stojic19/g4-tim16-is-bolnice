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

    public partial class DodavanjeOpreme : Window
    {

        public DodavanjeOpreme()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String idOpreme = this.idOpreme.Text;
            foreach (Oprema o1 in RukovanjeOpremom.SvaOprema())
            {
                if (o1.IdOpreme.Equals(this.idOpreme.Text))
                {
                    System.Windows.Forms.MessageBox.Show("Već postoji uneto Id opreme!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            VrsteOpreme vrstaOpreme;

            if (this.vrstaOpreme.Text.Equals("staticka"))
            {
                vrstaOpreme = VrsteOpreme.staticka;
            }
            else
            {
                vrstaOpreme = VrsteOpreme.dinamicka;
            }

            String nazivOpreme = this.nazivOpreme.Text;
            int kolicina = int.Parse(this.kolicina.Text);

            Oprema o = new Oprema(idOpreme, nazivOpreme, vrstaOpreme, kolicina);
            RukovanjeOpremom.DodajOpremu(o);

            this.Close();

        }

    }
}

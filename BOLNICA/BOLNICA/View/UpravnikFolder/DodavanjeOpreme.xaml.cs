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
        OpremaServis opremaServis = new OpremaServis();
        public DodavanjeOpreme()
        {
            InitializeComponent();
        }


        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            Oprema o = new Oprema(Guid.NewGuid().ToString(), this.nazivOpreme.Text, ProvjeriVrstuOpreme(), int.Parse(this.kolicina.Text));
            opremaServis.DodajOpremu(o);

            this.Close();
        }

        private VrsteOpreme ProvjeriVrstuOpreme()
        {
            VrsteOpreme vrstaOpreme;

            if (this.vrstaOpreme.Text.Equals("staticka"))
            {
                vrstaOpreme = VrsteOpreme.staticka;
            }
            else
            {
                vrstaOpreme = VrsteOpreme.dinamicka;
            }
            return vrstaOpreme;
        }

    }
}

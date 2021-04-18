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

    public partial class IzmenaOpreme : Window
    {
        String stari = null;


        public IzmenaOpreme(String id)//korisnik unosi informacije
        {
            InitializeComponent();

            stari = id;
            Oprema o = RukovanjeOpremom.PretraziPoId(id);

            IdOpreme.Text = id;
            NazivOpreme.Text = o.NazivOpreme;


            if (o.VrstaOpreme == VrsteOpreme.staticka)
            {
                VrstaOpreme.Text = "staticka";
            }
            else
            {
                VrstaOpreme.Text = "dinamicka";
            }

            Kolicina.Text = o.Kolicina.ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!stari.Equals(IdOpreme.Text))
            {
                foreach (Oprema o1 in RukovanjeOpremom.SvaOprema())
                {
                    if (o1.IdOpreme.Equals(IdOpreme.Text))
                    {
                        System.Windows.Forms.MessageBox.Show("Već postoji unet Id opreme!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            RukovanjeOpremom.IzmeniOpremu(stari, IdOpreme.Text, NazivOpreme.Text, VrstaOpreme.SelectedIndex, Kolicina.Text);

            this.Close();
        }
    }
}
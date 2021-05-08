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

    public partial class DodavanjeProstora : Window
    {

        public DodavanjeProstora()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String idProstora = this.idProstora.Text;
            foreach (Prostor p1 in RukovanjeProstorom.SviProstori())
            {
                if (p1.IdProstora.Equals(this.idProstora.Text))
                {
                    System.Windows.Forms.MessageBox.Show("Već postoji uneto Id prostora!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            VrsteProstora vrstaProstora;

            if (this.vrstaProstora.Text.Equals("Ordinacija"))
            {
                vrstaProstora = VrsteProstora.ordinacija;
            }
            else if (this.vrstaProstora.Text.Equals("sala"))
            {
                vrstaProstora = VrsteProstora.sala;
            }
            else
            {
                vrstaProstora = VrsteProstora.soba;
            }

            int sprat = int.Parse(this.sprat.Text);
            float kvadratura = float.Parse(this.kvadratura.Text);
            int brojKreveta = int.Parse(this.brojKreveta.Text);


            Prostor p = new Prostor(idProstora, vrstaProstora, sprat, kvadratura, brojKreveta, false, new Renoviranje());
            RukovanjeProstorom.DodajProstor(p);

            this.Close();

        }

    }
}
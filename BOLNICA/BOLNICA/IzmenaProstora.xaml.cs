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

    public partial class IzmenaProstora : Window
    {
        String stari = null;
       

        public IzmenaProstora(String id)//korisnik unosi informacije
        {
            InitializeComponent();

            stari = id;
            Prostor p = RukovanjeProstorom.PretraziPoId(id);

            IdProstora.Text = id;


            if (p.VrstaProstora == VrsteProstora.ordinacija)
            {
                VrstaProstora.Text = "Ordinacija";
            }
            else if (p.VrstaProstora == VrsteProstora.sala)
            {
                VrstaProstora.Text = "Sala";
            }
            else
            {
                VrstaProstora.Text = "Soba";
            }

            Sprat.Text = p.Sprat.ToString();
            Kvadratura.Text = p.Sprat.ToString();
            BrojKreveta.Text = p.BrojKreveta.ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!stari.Equals(IdProstora.Text))
            {
                foreach (Prostor p1 in RukovanjeProstorom.SviProstori())
                {
                    if (p1.IdProstora.Equals(IdProstora.Text))
                    {
                        System.Windows.Forms.MessageBox.Show("Već postoji unet Id prostora!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            RukovanjeProstorom.IzmeniProstor(stari, IdProstora.Text, VrstaProstora.SelectedIndex, Sprat.Text, Kvadratura.Text, BrojKreveta.Text);

            this.Close();
        }
    }
}
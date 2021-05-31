using Bolnica.DTO;
using Bolnica.Kontroler;
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
        ProstoriKontroler prostoriKontroler = new ProstoriKontroler();
        public DodavanjeProstora()
        {
            InitializeComponent();
        }


        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {

            ProstorDTO p = new ProstorDTO(Guid.NewGuid().ToString(), this.NazivProstora.Text, ProvjeriVrstuProstora(), int.Parse(this.sprat.Text), float.Parse(this.kvadratura.Text), false);
            prostoriKontroler.DodajProstor(p);

            this.Close();

        }

        private VrsteProstora ProvjeriVrstuProstora()
        {
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

            return vrstaProstora;
        }

    }
}
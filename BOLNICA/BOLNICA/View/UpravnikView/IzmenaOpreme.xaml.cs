using Bolnica.DTO;
using Bolnica.Kontroler;
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
        OpremaKontroler opremaKontroler = new OpremaKontroler();

        public IzmenaOpreme(String id)//korisnik unosi informacije
        {
            InitializeComponent();

            stari = id;
            OpremaDTO o = opremaKontroler.PretraziPoId(id);

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

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            //if (opremaKontroler.ProvjeriValidnostNaziva(NazivOpreme.Text))
            //{
                OpremaDTO o = new OpremaDTO(stari, NazivOpreme.Text, ProvjeriVrstuOpreme(), int.Parse(Kolicina.Text));
                opremaKontroler.IzmeniOpremu(o);
                this.Close();
            //}
        }

        private VrsteOpreme ProvjeriVrstuOpreme()
        {
            VrsteOpreme vrstaOpreme;

            if (this.VrstaOpreme.Text.Equals("staticka"))
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
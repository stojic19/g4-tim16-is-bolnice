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

    public partial class DodajOpremuProstoru : Window
    {
        private List<Oprema> oprema;
       // private RasporedOpreme raspored;
        private string IdProstora;
        public DodajOpremuProstoru( string idProstora)
        {
            InitializeComponent();
            oprema = RukovanjeOpremom.SvaOprema();
          //  this.raspored = raspored;
            this.DataContext = this;
            IdProstora = idProstora;
        }

        public List<Oprema> Oprema { get => oprema; set => oprema = value; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Oprema opr = (Oprema)dataGridOprema.SelectedItem;
            int Kolicina = Int32.Parse(kolicina.Text);
            if(opr.Kolicina < Kolicina)
            {
                System.Windows.Forms.MessageBox.Show("Neispravna kolicina !", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 

            foreach(Oprema o in RukovanjeOpremom.SvaOprema())
            {
                if (o.IdOpreme.Equals(opr.IdOpreme))
                {
                    o.Kolicina -= Kolicina;
                }
            }

            Prostor p = RukovanjeProstorom.PretraziPoId(IdProstora);

            bool postoji = false;
            foreach (Oprema o in p.Oprema)
            {
                if (o.IdOpreme.Equals(opr.IdOpreme))
                {
                    o.Kolicina += Kolicina;
                    postoji = true;
                }
            }
            if (!postoji)
            {
                RukovanjeProstorom.PretraziPoId(IdProstora).Oprema.Add(new Oprema(opr.IdOpreme,opr.NazivOpreme,opr.VrstaOpreme, Kolicina));
            }
            // RasporedOpreme.oprema.Add(opr
            RukovanjeOpremom.SerijalizacijaOpreme();
            RukovanjeProstorom.SerijalizacijaProstora();
            this.Close();
        }

        private void dataGridOprema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
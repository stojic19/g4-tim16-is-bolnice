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
    /// Interaction logic for DodavanjeObavestenja.xaml
    /// </summary>
    public partial class DodavanjeObavestenja : Window
    {

        public DodavanjeObavestenja()
        {
            InitializeComponent();

            idObavestenja.Text = generisiIdObavestenja();
            datum.SelectedDate = DateTime.Now;
        }
        private String generisiIdObavestenja()
        {
            int brojac = RukovanjeObavestenjimaSekratar.SvaObavestenja().Count;
            bool postoji;
            do
            {
                postoji = false;
                foreach (Obavestenje o in RukovanjeObavestenjimaSekratar.SvaObavestenja())
                {
                    if (o.IdObavestenja.Equals("O" + brojac.ToString()))
                    {
                        postoji = true;
                        brojac++;
                        break;
                    }
                }
            } while (postoji);

            return "O" + brojac.ToString();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (naslov.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti naslov obaveštenja!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tekst.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti tekst obaveštenja!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            Obavestenje o = new Obavestenje(idObavestenja.Text, naslov.Text, tekst.Text, DateTime.Now, "svi") ;
            RukovanjeObavestenjimaSekratar.DodajObavestenje(o);
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

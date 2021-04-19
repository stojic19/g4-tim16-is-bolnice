using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PremjestanjeOpreme.xaml
    /// </summary>
    public partial class PremjestanjeOpreme : Window
    {
        String idOpreme = null;
        String idProstoraIzKojegPrebacujem = null;
        public static ObservableCollection<Prostor> Prostori { get; set; }

        public PremjestanjeOpreme(string idOpreme, String idProstoraIzKojegPrebacujem)//korisnik unosi informacije
        {
            InitializeComponent();
            this.idOpreme = idOpreme;
            this.idProstoraIzKojegPrebacujem = idProstoraIzKojegPrebacujem;


            this.DataContext = this;

            Prostori = new ObservableCollection<Prostor>();

            foreach (Prostor p in RukovanjeProstorom.SviProstori())
            {
                if (!p.IdProstora.Equals(idProstoraIzKojegPrebacujem))
                {
                    Prostori.Add(p);
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Prostor izabranZaMenjanje = (Prostor)dataGridProstori.SelectedItem;
            int kolicina = Int32.Parse(Kolicina.Text);

            if (izabranZaMenjanje != null)
            {
                if (this.Kolicina.Text.Equals(""))
                {
                    System.Windows.MessageBox.Show("Unesite kolicinu!");
                    return;
                }
                List<Oprema> pomocna = new List<Oprema>();
              
                foreach(Oprema o in RukovanjeProstorom.PretraziPoId(idProstoraIzKojegPrebacujem).Oprema)
                {
                    if (o.IdOpreme.Equals(idOpreme))
                    {
                        if (o.Kolicina < kolicina)
                        {
                            System.Windows.Forms.MessageBox.Show("Neispravna kolicina !", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        o.Kolicina -= kolicina;
                    }

                    pomocna.Add(o);
                }
                RukovanjeProstorom.PretraziPoId(idProstoraIzKojegPrebacujem).Oprema = pomocna;
                Prostor p = RukovanjeProstorom.PretraziPoId(izabranZaMenjanje.IdProstora);

                bool postoji = false;
                pomocna = new List<Oprema>();
                foreach (Oprema o in p.Oprema)
                {
                    if (o.IdOpreme.Equals(idOpreme))
                    {
                        o.Kolicina += kolicina;
                        postoji = true;
                    }
                    pomocna.Add(o);
                }
                if (!postoji)
                {
                    Oprema o = RukovanjeOpremom.PretraziPoId(idOpreme);
                    RukovanjeProstorom.PretraziPoId(izabranZaMenjanje.IdProstora).Oprema.Add(new Oprema(idOpreme, o.NazivOpreme, o.VrstaOpreme, kolicina));
                }
                else
                {
                    RukovanjeProstorom.PretraziPoId(izabranZaMenjanje.IdProstora).Oprema = pomocna;
                }
                RukovanjeProstorom.SerijalizacijaProstora();
                this.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Izaberite prostriju u koju želite da prebacite!");
            }



        }
    }
}
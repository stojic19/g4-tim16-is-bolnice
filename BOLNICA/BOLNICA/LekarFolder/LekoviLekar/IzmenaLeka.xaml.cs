using Bolnica.Model;
using Bolnica.Model.Rukovanja;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.LekarFolder.LekoviLekar
{
    public partial class IzmenaLeka : System.Windows.Controls.UserControl
    {
        Lek izabranLek = null;
        List<Sastojak> izmenjeniSastojci = new List<Sastojak>();
        String KorisnickoIme = null;
        public static ObservableCollection<Sastojak> Sastojci { get; set; } = new ObservableCollection<Sastojak>();

        public IzmenaLeka(String idIzabranogLeka, String korisnickoImeLekara)
        {
            InitializeComponent();
            izabranLek = RukovanjeOdobrenimLekovima.PretraziPoID(idIzabranogLeka);
            KorisnickoIme = korisnickoImeLekara;

            this.DataContext = this;
            inicijalizacijaPolja();

        }

        private void inicijalizacijaPolja()
        {
            this.nazivLeka.Text = izabranLek.NazivLeka;
            this.jacinaLeka.Text = izabranLek.Jacina;
            Sastojci.Clear();
            foreach (Sastojak s in izabranLek.Sastojci)
            {
                Sastojci.Add(s);
                izmenjeniSastojci.Add(s);
            }
        }

        private void BrisanjeSastojka(object sender, RoutedEventArgs e)
        {
            Sastojak izabranSastojak = (Sastojak)dataGridSastojci.SelectedItem;

            if (izabranSastojak != null)
            {
                foreach (Sastojak s in izmenjeniSastojci)
                {
                    if (s.Naziv.Equals(izabranSastojak.Naziv))
                    {
                        izmenjeniSastojci.Remove(s);
                        Sastojci.Remove(s);
                        break;
                    }
                }
            }
        }

        private void DodavanjeSastojka(object sender, RoutedEventArgs e)
        {
            if (!ValidacijaNovogSastojka()) return;

            Sastojak noviSastojak = new Sastojak(nazivSastojka.Text, Double.Parse(kolicinaSastojka.Text));

            izmenjeniSastojci.Add(noviSastojak);
            Sastojci.Add(noviSastojak);
            nazivSastojka.Text = String.Empty;
            kolicinaSastojka.Text = String.Empty;

        }

        private Boolean ValidacijaNovogSastojka()
        {
            if (nazivSastojka.Text.Equals("") || kolicinaSastojka.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Niste popunili sva polja!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            return true;
        }

        private void Odustajanje(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new BazaLekova(KorisnickoIme));
        }

        private void CuvanjeIzmena(object sender, RoutedEventArgs e)
        {
            if (!ValidacijaUnosa()) return;

            RukovanjeOdobrenimLekovima.IzmenaLeka(new Lek(izabranLek.IDLeka, nazivLeka.Text, jacinaLeka.Text, izmenjeniSastojci));
            RukovanjeOdobrenimLekovima.SerijalizacijaLekova();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new BazaLekova(KorisnickoIme));


        }

        private Boolean ValidacijaUnosa()
        {
            if (nazivLeka.Text.Equals("") || jacinaLeka.Text.Equals("") )
            {
                System.Windows.Forms.MessageBox.Show("Niste popunili sva polja!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            return true;
        }


    }
}

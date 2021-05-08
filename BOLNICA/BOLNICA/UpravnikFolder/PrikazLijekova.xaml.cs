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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bolnica
{
    public partial class PrikazLijekova : UserControl
    {
        public static ObservableCollection<Lek> Lijekovi { get; set; }
        //   public static ObservableCollection<Zahtjev> Zahtjevi { get; set; }
        public PrikazLijekova()
        {
            InitializeComponent();

            this.DataContext = this;

            Lijekovi = new ObservableCollection<Lek>();
            // Zahtjevi = new ObservableCollection<Zahtjev>();

            foreach (Zahtjev z in RukovanjeZahtjevima.SviZahtevi)
            {
                Lijekovi.Add(z.Lijek);

            }

        }

        private void Dodavanje_Click(object sender, RoutedEventArgs e)
        {

            DodavanjeLijeka dodavanje = new DodavanjeLijeka();
            dodavanje.Show();

        }

        private void Izmjena_Click(object sender, RoutedEventArgs e)
        {

            Lek izabranZaMenjanje = (Lek)dataGridLijekovi.SelectedItem;

            if (izabranZaMenjanje != null)
            {

                IzmjenaLijeka izmjena = new IzmjenaLijeka(izabranZaMenjanje.IDLeka);
                izmjena.Show();
            }
            else
            {
                MessageBox.Show("Izaberite lijek koji želite da izmenite!");
            }
        }

        private void Uklanjanje_Click(object sender, RoutedEventArgs e)
        {
            Lek izabranZaBrisanje = (Lek)dataGridLijekovi.SelectedItem;

            if (izabranZaBrisanje != null)
            {

                UklanjanjeLijeka uklanjanje = new UklanjanjeLijeka(izabranZaBrisanje.IDLeka);
                uklanjanje.Show();
            }
            else
            {
                MessageBox.Show("Izaberite lijek koji želite da uklonite!");
            }
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RukovanjeNeodobrenimLijekovima.SerijalizacijaLijekova();
            RukovanjeZahtjevima.SerijalizacijaZahtjeva();
        }

        private void dataGridLijekovi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Detalji_Click(object sender, RoutedEventArgs e)
        {
            Lek izabran = (Lek)dataGridLijekovi.SelectedItem;

            if (izabran != null)
            {

                UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
                UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(new DetaljiOLijeku(izabran.IDLeka));
            }
            else
            {
                MessageBox.Show("Izaberite lijek cije detalje zelite da vidite!");
            }
        }
    }
}

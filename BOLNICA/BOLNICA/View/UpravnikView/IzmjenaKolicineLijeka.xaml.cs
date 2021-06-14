using Bolnica.DTO;
using Bolnica.Kontroler;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for IzmjenaKolicineLijeka.xaml
    /// </summary>
    public partial class IzmjenaKolicineLijeka : Window
    {
        public LekDTO lijekZaIzmjenu;
        LekoviKontroler lekoviKontroler = new LekoviKontroler();
        public IzmjenaKolicineLijeka(LekDTO lijek)
        {
            InitializeComponent();
            lijekZaIzmjenu = lijek;
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (this.Kolicina.Text != "")
            {
                LekDTO l = new LekDTO(lijekZaIzmjenu.IdLeka, lijekZaIzmjenu.NazivLeka,lijekZaIzmjenu.Jacina, int.Parse(this.Kolicina.Text),lijekZaIzmjenu.Sastojci,lijekZaIzmjenu.Proizvodjac);
                lekoviKontroler.IzmjenaLijeka(l);
                this.Close();
            }else
            {
                System.Windows.MessageBox.Show("Morate unijeti kolicinu lijeka");
            }
        }
    }
}

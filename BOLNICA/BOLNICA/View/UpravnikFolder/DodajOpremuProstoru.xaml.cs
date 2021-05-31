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

    public partial class DodajOpremuProstoru : Window
    {
        private List<OpremaDTO> oprema;
        private string IdProstora;
        ProstoriKontroler prostoriKontroler = new ProstoriKontroler();
        OpremaKontroler opremaKontroler = new OpremaKontroler();

        public DodajOpremuProstoru(string idProstora)
        {
            InitializeComponent();
            oprema = opremaKontroler.SvaOprema();
            this.DataContext = this;
            IdProstora = idProstora;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpremaDTO oprema = (OpremaDTO)dataGridOprema.SelectedItem;
            int Kolicina = Int32.Parse(kolicina.Text);
            if (this.kolicina.Text.Equals(""))
            {
                System.Windows.MessageBox.Show("Unesite kolicinu!");
                return;
            }
            ProstorDTO p = prostoriKontroler.PretraziProstorPoId(IdProstora);
            opremaKontroler.PremjestiKolicinuOpreme(p, oprema, Kolicina);
     
            this.Close();
        }
    }
}
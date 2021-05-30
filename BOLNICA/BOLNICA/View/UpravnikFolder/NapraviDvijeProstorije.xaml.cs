using Bolnica.Model;
using Bolnica.Servis;
using Bolnica.UpravnikFolder;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

    public partial class NapraviDvijeProstorije : UserControl
    {
        private Prostor izabranaProstorija;
        ProstoriServis prostoriServis = new ProstoriServis();
        public NapraviDvijeProstorije(Prostor izabran)
        {
            InitializeComponent();
            izabranaProstorija = izabran;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Prostor prostor1 = new Prostor(Guid.NewGuid().ToString(), this.NazivProstora1.Text, ProvjeriVrstuProstora1(), int.Parse(this.Sprat1.Text), float.Parse(this.Kvadratura1.Text), false);
            Prostor prostor2 = new Prostor(Guid.NewGuid().ToString(), this.NazivProstora2.Text, ProvjeriVrstuProstora2(), int.Parse(this.Sprat2.Text), float.Parse(this.Kvadratura2.Text), false);

            if (!prostoriServis.ProvjeriZakazaneTermine((DateTime)PickStartDate.SelectedDate, (DateTime)PickEndtDate.SelectedDate))
            {
                RenovirajProstor(izabranaProstorija);

                UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
                UserControl usc = null;
                usc = new PrikazProstora();
                UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);
            }

            if (DateTime.Compare(DateTime.Now.Date, (DateTime)PickEndtDate.SelectedDate) >= 0)
            {
                ProstoriServis.UkloniProstor(izabranaProstorija.IdProstora);
                ProstoriServis.DodajProstor(prostor1);
                ProstoriServis.DodajProstor(prostor2);
            }

        }


        private void RenovirajProstor(Prostor prostor)
        {
            Prostor izabranZaRenoviranje = prostor;
            Renoviranje renoviranje = new Renoviranje(Guid.NewGuid().ToString(), izabranZaRenoviranje, DateTime.Parse(PickStartDate.Text), DateTime.Parse(PickEndtDate.Text));
            RenoviranjeServis.DodajZaRenoviranje(renoviranje);
            RenoviranjeServis.ProveriRenoviranje();
            RenoviranjeServis.SerijalizacijaProstoraZaRenoviranje();
            ProstoriServis.SerijalizacijaProstora();
        }

        private VrsteProstora ProvjeriVrstuProstora1()
        {
            VrsteProstora vrstaProstora;

            if (this.VrstaProstora1.Text.Equals("Ordinacija"))
            {
                vrstaProstora = VrsteProstora.ordinacija;
            }
            else if (this.VrstaProstora1.Text.Equals("sala"))
            {
                vrstaProstora = VrsteProstora.sala;
            }
            else
            {
                vrstaProstora = VrsteProstora.soba;
            }

            return vrstaProstora;
        }

        private VrsteProstora ProvjeriVrstuProstora2()
        {
            VrsteProstora vrstaProstora;

            if (this.VrstaProstora2.Text.Equals("Ordinacija"))
            {
                vrstaProstora = VrsteProstora.ordinacija;
            }
            else if (this.VrstaProstora2.Text.Equals("sala"))
            {
                vrstaProstora = VrsteProstora.sala;
            }
            else
            {
                vrstaProstora = VrsteProstora.soba;
            }

            return vrstaProstora;
        }

        private void odustani_Click(object sender, RoutedEventArgs e)
        {
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
            UserControl usc = null;
            usc = new PrikazProstora();
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);
        }
    }
}

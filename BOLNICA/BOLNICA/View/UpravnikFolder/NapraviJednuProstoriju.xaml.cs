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

    public partial class NapraviJednuProstoriju : UserControl
    {
        private Prostor izabraniProstor1;
        private Prostor izabraniProstor2;
        ProstoriServis prostoriServis = new ProstoriServis();

        public NapraviJednuProstoriju(Prostor prostor1, Prostor prostor2)
        {
            InitializeComponent();
            izabraniProstor1 = prostor1;
            izabraniProstor2 = prostor2;

        }

        private void odustani_Click(object sender, RoutedEventArgs e)
        {
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
            UserControl usc = null;
            usc = new PrikazProstora();
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);
        }

        private void potvrdi_Click(object sender, RoutedEventArgs e)
        {
            Prostor prostor = new Prostor(Guid.NewGuid().ToString(), this.NazivProstora.Text, ProvjeriVrstuProstora(), int.Parse(this.Sprat.Text), float.Parse(this.Kvadratura.Text), false);


            if (!prostoriServis.ProvjeriZakazaneTermine((DateTime)PickStartDate.SelectedDate, (DateTime)PickEndDate.SelectedDate))
            {
                RenovirajProstor(izabraniProstor1);
                RenovirajProstor(izabraniProstor2);


                UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
                UserControl usc = null;
                usc = new PrikazProstora();
                UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);
            }

            if (DateTime.Compare(DateTime.Now.Date, (DateTime)PickEndDate.SelectedDate) >= 0)
            {
                ProstoriServis.UkloniProstor(izabraniProstor1.IdProstora);
                ProstoriServis.UkloniProstor(izabraniProstor2.IdProstora);
                ProstoriServis.DodajProstor(prostor);

            }
        }

        private void RenovirajProstor(Prostor prostor)
        {
            Prostor izabranZaRenoviranje = prostor;
            Renoviranje renoviranje = new Renoviranje(Guid.NewGuid().ToString(), izabranZaRenoviranje, DateTime.Parse(PickStartDate.Text), DateTime.Parse(PickEndDate.Text));
            RenoviranjeServis.DodajZaRenoviranje(renoviranje);
            RenoviranjeServis.ProveriRenoviranje();
            RenoviranjeServis.SerijalizacijaProstoraZaRenoviranje();
            ProstoriServis.SerijalizacijaProstora();
        }

        private VrsteProstora ProvjeriVrstuProstora()
        {
            VrsteProstora vrstaProstora;

            if (this.VrstaProstora.Text.Equals("Ordinacija"))
            {
                vrstaProstora = VrsteProstora.ordinacija;
            }
            else if (this.VrstaProstora.Text.Equals("sala"))
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

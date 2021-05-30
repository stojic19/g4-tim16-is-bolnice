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
        private List<Prostor> ProstoriKojiSeBrisu = new List<Prostor>();
        ProstoriServis prostoriServis = new ProstoriServis();
        RenoviranjeServis renoviranjeServis = new RenoviranjeServis();

        public NapraviJednuProstoriju(List<Prostor> prostoriZaRenoviranje)
        {
            InitializeComponent();
            ProstoriKojiSeBrisu = prostoriZaRenoviranje;

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
                RenovirajProstor(prostor,ProstoriKojiSeBrisu);

                UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
                UserControl usc = null;
                usc = new PrikazProstora();
                UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);
            }

        }

        private void RenovirajProstor(Prostor prostorKojiSePravi, List<Prostor> prostoriKojiSeBrisu)
        {
            Prostor izabranZaRenoviranje = prostorKojiSePravi;
            Renoviranje renoviranje = new Renoviranje(Guid.NewGuid().ToString(), izabranZaRenoviranje, DateTime.Parse(PickStartDate.Text), DateTime.Parse(PickEndDate.Text));
            renoviranje.ProstoriKojiSeBrisu.Add(prostoriKojiSeBrisu[0]);
            renoviranje.ProstoriKojiSeBrisu.Add(prostoriKojiSeBrisu[1]);
            renoviranje.ProstoriKojiSeDodaju.Add(prostorKojiSePravi);     
            renoviranjeServis.DodajZaRenoviranje(renoviranje);
            renoviranjeServis.ProveriRenoviranje();   
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

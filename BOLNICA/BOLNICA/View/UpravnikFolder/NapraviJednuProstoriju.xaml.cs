using Bolnica.DTO;
using Bolnica.Kontroler;
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
        private List<ProstorDTO> ProstoriKojiSeBrisu;
        ProstoriKontroler prostoriKontroler = new ProstoriKontroler();
        RenoviranjeKontroler renoviranjeKontroler = new RenoviranjeKontroler();

        public NapraviJednuProstoriju(List<ProstorDTO> prostoriZaRenoviranje)
        {
            InitializeComponent();
            ProstoriKojiSeBrisu = new List<ProstorDTO>();
            ProstoriKojiSeBrisu= prostoriZaRenoviranje;

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
            ProstorDTO prostor = new ProstorDTO(Guid.NewGuid().ToString(), this.NazivProstora.Text, ProvjeriVrstuProstora(), int.Parse(this.Sprat.Text), float.Parse(this.Kvadratura.Text), new List<OpremaDTO>(), false);


            if (!prostoriKontroler.ProvjeriZakazaneTermine((DateTime)PickStartDate.SelectedDate, (DateTime)PickEndDate.SelectedDate))
            {
                RenovirajProstor(prostor,ProstoriKojiSeBrisu);

                UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
                UserControl usc = null;
                usc = new PrikazProstora();
                UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);
            }

        }

        private void RenovirajProstor(ProstorDTO prostorKojiSePravi, List<ProstorDTO> prostoriKojiSeBrisu)
        {
            ProstorDTO izabranZaRenoviranje = prostorKojiSePravi;
            RenoviranjeDTO renoviranje = new RenoviranjeDTO(Guid.NewGuid().ToString(), izabranZaRenoviranje, DateTime.Parse(PickStartDate.Text), DateTime.Parse(PickEndDate.Text));
            renoviranje.ProstoriKojiSeBrisu.Add(prostoriKojiSeBrisu[0]);
            renoviranje.ProstoriKojiSeBrisu.Add(prostoriKojiSeBrisu[1]);
            renoviranje.ProstoriKojiSeDodaju.Add(prostorKojiSePravi);     
            renoviranjeKontroler.DodajZaRenoviranje(renoviranje);
            renoviranjeKontroler.ProveriRenoviranje();   
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

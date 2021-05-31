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

    public partial class NapraviDvijeProstorije : UserControl
    {
        private ProstorDTO izabranaProstorija;
        ProstoriKontroler prostoriKontroler = new ProstoriKontroler();
        RenoviranjeKontroler renoviranjeKontroler = new RenoviranjeKontroler();
        public NapraviDvijeProstorije(ProstorDTO izabran)
        {
            InitializeComponent();
            izabranaProstorija = izabran;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ProstorDTO prostor1 = new ProstorDTO(Guid.NewGuid().ToString(), this.NazivProstora1.Text, ProvjeriVrstuProstora1(), int.Parse(this.Sprat1.Text), float.Parse(this.Kvadratura1.Text), false);
            ProstorDTO prostor2 = new ProstorDTO(Guid.NewGuid().ToString(), this.NazivProstora2.Text, ProvjeriVrstuProstora2(), int.Parse(this.Sprat2.Text), float.Parse(this.Kvadratura2.Text), false);


            if (!prostoriKontroler.ProvjeriZakazaneTermine((DateTime)PickStartDate.SelectedDate, (DateTime)PickEndtDate.SelectedDate))
            {
                NapraviDvaProstoraOdJednog(izabranaProstorija,prostor1,prostor2);

                UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
                UserControl usc = null;
                usc = new PrikazProstora();
                UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);
            }     
        }


        private void NapraviDvaProstoraOdJednog(ProstorDTO prostor,ProstorDTO prostorKojiSeDodaje1,ProstorDTO prostorKojiSeDodaje2)
        {
            ProstorDTO izabranZaRenoviranje = prostor;
            RenoviranjeDTO renoviranje = new RenoviranjeDTO(Guid.NewGuid().ToString(), izabranZaRenoviranje, DateTime.Parse(PickStartDate.Text), DateTime.Parse(PickEndtDate.Text));
            renoviranje.ProstoriKojiSeBrisu.Add(izabranaProstorija);
            renoviranje.ProstoriKojiSeDodaju.Add(prostorKojiSeDodaje1);
            renoviranje.ProstoriKojiSeDodaju.Add(prostorKojiSeDodaje2);
            renoviranjeKontroler.DodajZaRenoviranje(renoviranje);
            renoviranjeKontroler.ProveriRenoviranje();         
       
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

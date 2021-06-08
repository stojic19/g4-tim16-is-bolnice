using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.View.LekarFolder.NalogLekara
{
    public partial class NalogLekara : UserControl
    {
        String idLekara = null;
        LekariKontroler lekariKontroler = new LekariKontroler();
        public NalogLekara(String idLekara)
        {
            InitializeComponent();
            this.idLekara = idLekara;
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            inicijalizacijaPolja();
        }

        private void inicijalizacijaPolja()
        {
            LekarDTO l = lekariKontroler.PretraziPoId(idLekara);

            this.ime.Text = l.Ime;
            this.prezime.Text = l.Prezime;
            this.korIme.Text = l.KorisnickoIme;
            this.email.Text = "email@ftn.com";
            this.adresa.Text = "Zagrebačka 9";
            this.telefon.Text = "042151252";
            this.datumRodjenja.Text = "21.9.1999.";
            this.lozinka.Password = "flasaflasica";
            this.specijalizacija.Text = "Kardiohirurg";
        }

        private void izmeni_Click(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new IzmenaNaloga(idLekara));
        }
    }
}

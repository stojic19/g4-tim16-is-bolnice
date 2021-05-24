using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.LekarFolder.ZdravstveniKartonLekar
{
    public partial class InformacijeSpecijalisticki : UserControl
    {
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();

        Pregled izabranPregled = null;
        Uput izabranUput = null;
        public InformacijeSpecijalisticki(Uput informacijeUput, String IDIzabranogPregleda)
        {

            InitializeComponent();
            izabranUput = informacijeUput;
            izabranPregled = PreglediServis.PretraziPoId(IDIzabranogPregleda);

            inicijalizacijaPolja();
        }

        private void inicijalizacijaPolja()
        {

            Pacijent p = naloziPacijenataKontroler.PretraziPoId(izabranPregled.Termin.Pacijent.KorisnickoIme);
            Lekar specijalista = TerminiServis.pretraziLekare(izabranUput.IDLekaraSpecijaliste);

            imePacijenta.Text = p.Ime;
            prezimePacijenta.Text = p.Prezime;
            jmbgPacijenta.Text = p.Jmbg;
            imeLekaraSpecijaliste.Text = specijalista.Ime;
            prezimeLekaraSpecijaliste.Text = specijalista.Prezime;
            datumIzdavanjaUputa.Text = izabranUput.DatumIzdavanja.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            nalazMisljenje.Text = izabranUput.NalazMisljenje;


        }

    }
}

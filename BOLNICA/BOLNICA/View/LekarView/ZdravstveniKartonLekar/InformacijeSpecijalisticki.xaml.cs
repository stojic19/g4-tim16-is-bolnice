using Bolnica.DTO;
using Bolnica.Kontroler;
using System;
using System.Windows.Controls;

namespace Bolnica.LekarFolder.ZdravstveniKartonLekar
{
    public partial class InformacijeSpecijalisticki : UserControl
    {
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        LekariKontroler lekariKontroler = new LekariKontroler();
        PreglediKontroler preglediKontroler = new PreglediKontroler();
        PregledDTO izabranPregled = null;
        UputDTO izabranUput = null;

        public InformacijeSpecijalisticki(UputDTO informacijeUput, String IDIzabranogPregleda)
        {

            InitializeComponent();
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            izabranUput = informacijeUput;
            izabranPregled = preglediKontroler.DobaviPregled(IDIzabranogPregleda);

            inicijalizacijaPolja();
        }

        private void inicijalizacijaPolja()
        {
            PacijentDTO p = naloziPacijenataKontroler.PretraziPoId(izabranPregled.Termin.Pacijent.KorisnickoIme);
            LekarDTO specijalista = lekariKontroler.PretraziPoId(izabranUput.IdLekaraSpecijaliste);

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

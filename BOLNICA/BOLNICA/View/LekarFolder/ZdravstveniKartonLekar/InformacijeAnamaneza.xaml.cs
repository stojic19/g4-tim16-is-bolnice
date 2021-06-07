using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Bolnica
{

    public partial class InformacijeAnamaneza : UserControl
    {
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        LekariKontroler lekariKontroler = new LekariKontroler();
        private PreglediKontroler preglediKontroler = new PreglediKontroler();
        ZdravstvenKartoniKontroler zdravstvenKartoniKontroler = new ZdravstvenKartoniKontroler();
        PregledDTO izabranPregled = null;
        AnamnezaDTO izabranaAnamneza = null;
        public static ObservableCollection<TerapijaDTO> Terapije { get; set; }

        public InformacijeAnamaneza(AnamnezaDTO odabranaAnamneza, String IDIzabranog)
        {

            InitializeComponent();
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            this.izabranPregled = preglediKontroler.DobaviPregled(IDIzabranog);
            this.izabranaAnamneza = odabranaAnamneza;

            inicijalizacijaPolja();

            this.DataContext = this;

            Terapije = new ObservableCollection<TerapijaDTO>();

            foreach (TerapijaDTO t in izabranaAnamneza.SveTerapije)
            {
                Terapije.Add(t);
            }
        }

        private void inicijalizacijaPolja()
        {

            PacijentDTO p = naloziPacijenataKontroler.PretraziPoId(izabranaAnamneza.IdPacijenta);
            LekarDTO l = lekariKontroler.PretraziPoId(izabranaAnamneza.IdLekara);

            ime.Text = p.Ime;
            prezime.Text = p.Prezime;
            jmbg.Text = p.Jmbg;
            imeLekara.Text = l.Ime;
            prezimeLekara.Text = l.Prezime;
            datumPregleda.Text = izabranaAnamneza.Datum.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            tekst.Text = izabranaAnamneza.Dijagnoza;

        }

    }
}
using Bolnica.Model;
using Bolnica.Model.Enumi;
using Bolnica.Model.Rukovanja;
using Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;

namespace Bolnica.LekarFolder
{
    public partial class IzdavanjeUputa : UserControl
    {
        Pregled izabranPregled = null;
        String idLekaraSpecijaliste = null;
        Uput noviUput = null;
        public IzdavanjeUputa(string idPregleda)
        {
            InitializeComponent();
            izabranPregled = RukovanjePregledima.PretraziPoId(idPregleda);

            inicijalizacijaPolja();

            this.TabelaLekara.ItemsSource = RukovanjeTerminima.DobaviSpecijaliste();
            CollectionView view2 = (CollectionView)CollectionViewSource.GetDefaultView(TabelaLekara.ItemsSource);
            view2.Filter = UserFilterLekar;

            this.DataContext = this;
        }

        private void inicijalizacijaPolja()
        {
            Pacijent p = izabranPregled.Termin.Pacijent;
            Lekar l = izabranPregled.Termin.Lekar;

            imePacijenta.Text = p.Ime;
            prezimePacijenta.Text = p.Prezime;
            jmbgPacijenta.Text = p.Jmbg;
            imeLekara.Text = l.Ime;
            prezimeLekara.Text = l.Prezime;
            datumIzdavanjaUputa.Text = (DateTime.Now.ToString("dd/MM/yyyy"));

        }

        private void CuvanjeSpecijalistickog(object sender, RoutedEventArgs e)
        {

            DodavanjeNovogSpecijalistickog();
            if (noviUput != null)
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 4));
            }

        }

        private void DodavanjeNovogSpecijalistickog()
        {
            String imeiprezime = RukovanjeTerminima.ImeiPrezime(izabranPregled.Termin.Lekar.KorisnickoIme);

            if (this.nalazMisljenje.Text.Equals("") || this.imeLekaraSpecijaliste.Text.Equals("") || this.prezimeLekaraSpecijaliste.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Niste popunili sva polja!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            noviUput = new Uput(Guid.NewGuid().ToString(), TipoviUputa.SPECIJALISTA, DateTime.Now, izabranPregled.Termin.Lekar.KorisnickoIme, imeiprezime,
                idLekaraSpecijaliste, izabranPregled.Termin.Pacijent.KorisnickoIme, nalazMisljenje.Text);

            RukovanjeZdravstvenimKartonima.DodajUput(noviUput);
            RukovanjePregledima.DodajUput(izabranPregled, noviUput);
            RukovanjePregledima.SerijalizacijaPregleda();
            RukovanjeNalozimaPacijenata.Sacuvaj();
        }


        private void CuvanjeIZakazivanjeSpecijalistickog(object sender, RoutedEventArgs e)
        {

            DodavanjeNovogSpecijalistickog();
            if (noviUput != null)
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new ZakazivanjeIzUputa(noviUput, izabranPregled.IdPregleda));
            }
        }

        private void Otkazivanje(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 4));
        }

        private void Povratak(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 4));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RukovanjeNalozimaPacijenata.Sacuvaj();
            RukovanjePregledima.SerijalizacijaPregleda();
        }

        private void pretragaLekara_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(TabelaLekara.ItemsSource).Refresh();
        }

        private bool UserFilterLekar(object item)
        {
            if (String.IsNullOrEmpty(pretragaLekara.Text))
                return true;
            else
                return ((item as Lekar).Prezime.IndexOf(pretragaLekara.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void TabelaLekara_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabelaLekara.SelectedItems.Count > 0)
            {
                Lekar item = (Lekar)TabelaLekara.SelectedItems[0];
                imeLekaraSpecijaliste.Text = item.Ime;
                prezimeLekaraSpecijaliste.Text = item.Prezime;
                pretragaLekara.Text = String.Empty;
                idLekaraSpecijaliste = item.KorisnickoIme;

            }
        }


    }
}

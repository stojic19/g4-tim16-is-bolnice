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
using System.Windows.Shapes;

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for PomeranjeSaPrioritetom.xaml
    /// </summary>
    public partial class PomeranjeSaPrioritetom : Window
    {
        public static List<Termin> datumiZaIzmenu = new List<Termin>();
        public String idTermina = null;
        public PomeranjeSaPrioritetom(Termin termin)
        {
            InitializeComponent();
            lekar.Text = termin.Lekar.KorisnickoIme;
            datum.Text = termin.Datum.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            vreme.Text = termin.PocetnoVreme;
            idTermina = termin.IdTermina;
        }


        private void nastavi_Click(object sender, RoutedEventArgs e)
        {
            if (prioritet.SelectedIndex == -1)
            {
                MessageBox.Show("Popunite sva polja!");
                return;
            }

            string datum1 = datum.Text;
            bool dostupanDatum = RukovanjeTerminima.ProveriMogucnostPomeranjaDatum(datum1);


            ///////////////////////
         

            DateTime pregled = DateTime.ParseExact(datum1, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);



            String[] split = DateTime.Now.ToString().Split(' ');




            String[] delovi = split[0].Split('/');



            DateTime konacni = new DateTime(Int32.Parse(delovi[2]), Int32.Parse(delovi[0]), Int32.Parse(delovi[1]), 0, 0, 0);


            if (DateTime.Compare(konacni, pregled) == 0)
            {
                MessageBox.Show("Termin je za manje od 24h ne mozete ga pomeriti!");
                return;
            }



            //////////////////////

            if (dostupanDatum)
            {
                bool dostupnoVreme = RukovanjeTerminima.ProveriMogucnostPomeranjaVreme(RukovanjeTerminima.PretraziPoId(idTermina).PocetnoVreme);
                // Console.WriteLine("BOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOL" + dostupnoVreme);
                if (!dostupnoVreme)
                {
                    MessageBox.Show("Datum pregleda je za manje od 24h! Ne mozete pomeriti!", "Datum pregleda!");
                    return;
                }
            }


            Termin t = RukovanjeTerminima.PretraziPoId(idTermina);
            DateTime datumPregleda = DateTime.ParseExact(datum.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime pocetni = datumPregleda.AddDays(-2);
            DateTime krajnji = datumPregleda.AddDays(2);


            List<Termin> pomocna = new List<Termin>();

            bool nasao = false;

            datumiZaIzmenu.Clear();


            pomocna = RukovanjeTerminima.PretraziPoLekaruIIntervalu(pocetni, krajnji, t.Lekar.KorisnickoIme);
            foreach (Termin ter in pomocna)
            {
                nasao = false;
                foreach (Termin t1 in datumiZaIzmenu)
                {
                    if (t1.Datum.Equals(ter.Datum))
                    {
                        nasao = true;
                        break;
                    }
                }
                if (!nasao)
                {
                    datumiZaIzmenu.Add(ter);
                }

            }



            //**************************************************

            if (datumiZaIzmenu.Count == 0)
            {
                if (prioritet.SelectedIndex == 0)
                {


                    pomocna = RukovanjeTerminima.PretraziPoLekaruIIntervalu(pocetni, krajnji, t.Lekar.KorisnickoIme);

                    foreach (Termin ter in pomocna)
                    {
                        nasao = false;
                        foreach (Termin t1 in datumiZaIzmenu)
                        {
                            if (t1.Datum.Equals(ter.Datum))
                            {
                                nasao = true;
                                break;
                            }
                        }
                        if (!nasao)
                        {
                            datumiZaIzmenu.Add(ter);
                        }

                    }
                    PrikazDatumaZaPomeranjeLekar pd = new PrikazDatumaZaPomeranjeLekar();
                    pd.Show();
                    this.Close();

                }
                else if (prioritet.SelectedIndex == 1)
                {
                    pomocna = RukovanjeTerminima.ProveriDatum(pocetni, krajnji);
                    foreach (Termin ter in pomocna)
                    {
                        nasao = false;
                        foreach (Termin t1 in datumiZaIzmenu)
                        {
                            if (t1.Datum.Equals(ter.Datum) && t1.Lekar.KorisnickoIme.Equals(ter.Lekar.KorisnickoIme))
                            {
                                nasao = true;
                                break;
                            }
                        }
                        if (!nasao)
                        {
                            datumiZaIzmenu.Add(ter);
                        }

                    }

                    PrikazDatumaZaPomeranjePrioritet pd = new PrikazDatumaZaPomeranjePrioritet();
                    pd.Show();
                    this.Close();



                }

            }
            else
            {


                PrikazDatumaZaPomeranjeLekar pd = new PrikazDatumaZaPomeranjeLekar();
                pd.Show();
                this.Close();

            }
            //***************************************

            /*DatumiZaPomeranjePacijent d = new DatumiZaPomeranjePacijent();
            d.Show();
            this.Close();*/

            
        }

        private void odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

using Bolnica.SekretarFolder;
using Bolnica.SekretarFolder.Operacija;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace Bolnica.Sekretar.Pregled
{
    /// <summary>
    /// Interaction logic for ZakazivanjePregledaTerminiSekretar.xaml
    /// </summary>
    public partial class ZakazivanjePregledaTerminiSekretar : System.Windows.Controls.UserControl
    {
        private static String IdPacijenta;
        public static ObservableCollection<Termin> SlobodniDatumi { get; set; }

        public ZakazivanjePregledaTerminiSekretar(String idPacijenta, List<Termin> datumi)
        {
            InitializeComponent();

            SlobodniDatumi = new ObservableCollection<Termin>();
            IdPacijenta = idPacijenta;

            foreach (Termin t in datumi)
            {
                SlobodniDatumi.Add(t);
            }

            slobodniTerminiLista.ItemsSource = SlobodniDatumi;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new GlavniProzorSadrzaj();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Termin termin = TerminIdaljeSlobodan();
            if(termin == null)
            {
                return;
            }    
            termin.Pacijent = RukovanjeNalozimaPacijenata.PretraziPoId(IdPacijenta);
            RukovanjeTerminima.ZakaziPregledSekretar(termin);

            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new GlavniProzorSadrzaj();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private Termin TerminIdaljeSlobodan()
        {
            bool postoji = false;
            Termin termin = new Termin();
            foreach (Termin t in RukovanjeTerminima.slobodniTermini)
            {
                if (t.IdTermina.Equals(((Termin)slobodniTerminiLista.SelectedItem).IdTermina))
                {
                    termin = t;
                    postoji = true;
                    break;
                }
            }
            if (!postoji)
            {
                System.Windows.Forms.MessageBox.Show("Odabrani termin je u međuvremenu zauzet!", "Odaberite drugi datum", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return termin;
        }

        private void Pocetna_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new GlavniProzorSadrzaj();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Nalozi_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new PrikazNalogaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Odjava_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();

            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
        private void Operacija_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new HitnaOperacijePregled();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Obavestenja_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new ObavestenjaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}

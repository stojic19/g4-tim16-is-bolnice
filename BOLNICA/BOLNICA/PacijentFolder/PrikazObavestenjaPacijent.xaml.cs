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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for PrikazObavestenjaPacijent.xaml
    /// </summary>
    public partial class PrikazObavestenjaPacijent : UserControl
    {
        public static ObservableCollection<Obavestenje> obavestenjaPacijenta { get; set; }
        public PrikazObavestenjaPacijent()
        {
            InitializeComponent();
            obavestenjaPacijenta = new ObservableCollection<Obavestenje>();

            List<Obavestenje> datumi = ObavestenjaServis.svaObavestenja.OrderByDescending(user => user.Datum).ToList();

            foreach (Obavestenje o in datumi)//Izmeniti kada je u pitanju personalizacija obavestenja
            {
                if (o.IdPrimaoca.Equals(PacijentGlavniProzor.ulogovani.KorisnickoIme))
                {

                    // String[] sadasnji = o.Datum.Split(' ');

                  /*  Console.WriteLine("PRAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAVI" + o.Datum);

                    String KONACNI = "";

                    String[] brojevi = o.Datum.Split('/');

                    if (brojevi[1].Length == 1)
                        KONACNI += "0" + brojevi[1] + "/";
                    else
                        KONACNI += brojevi[1] + "/";



                    if (brojevi[0].Length == 1)
                        KONACNI += "0" + brojevi[0] + "/";
                    else
                        KONACNI += brojevi[0] + "/";

                    KONACNI += brojevi[2];

                    String[] r = KONACNI.Split(' ');
                    Console.WriteLine(r[0]);
                    String[] delovi = r[0].Split('/');

                    DateTime konacni = new DateTime(Int32.Parse(delovi[2]), Int32.Parse(delovi[1]), Int32.Parse(delovi[0]), 0, 0, 0);*/
                    if (DateTime.Compare(o.Datum.Date, DateTime.Now) <= 0)
                    {
                        obavestenjaPacijenta.Add(o);
                    }

                }
                else if (o.IdPrimaoca.Equals("svi"))
                {
                    obavestenjaPacijenta.Add(o);
                }

            }

            obavestenjaPacijentaLista.ItemsSource = obavestenjaPacijenta;
        }

    }
}

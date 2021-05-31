using Bolnica.DTO;
using Bolnica.Kontroler;
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
    public partial class PrikazObavestenjaPacijent : UserControl
    {
        ObavestenjaKontroler obavestenjaKontroler = new ObavestenjaKontroler();

        public static ObservableCollection<ObavestenjeDTO> obavestenjaPacijenta { get; set; }
        public PrikazObavestenjaPacijent(String korisnickoIme)
        {
            InitializeComponent();
            obavestenjaPacijenta = new ObservableCollection<ObavestenjeDTO>();

            List<ObavestenjeDTO> datumi = obavestenjaKontroler.DobaviSvaObavestenja().OrderByDescending(user => user.Datum).ToList();

            foreach (ObavestenjeDTO o in datumi)
            {
                if (o.IdPrimaoca.Equals(korisnickoIme))
                {

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

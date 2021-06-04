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
        private ObavestenjaKontroler obavestenjaKontroler = new ObavestenjaKontroler();
        public ObservableCollection<ObavestenjeDTO> obavestenjaPacijenta { get; set; }
        public PrikazObavestenjaPacijent(String korisnickoIme)
        {
            InitializeComponent();
            obavestenjaPacijenta = new ObservableCollection<ObavestenjeDTO>();

            foreach (ObavestenjeDTO obavestenje in obavestenjaKontroler.DobaviSvaObavestenjaPacijenta(korisnickoIme).OrderByDescending(user => user.Datum).ToList())
            {
                obavestenjaPacijenta.Add(obavestenje);
            }

            obavestenjaPacijentaLista.ItemsSource = obavestenjaPacijenta;
        }

    }
}

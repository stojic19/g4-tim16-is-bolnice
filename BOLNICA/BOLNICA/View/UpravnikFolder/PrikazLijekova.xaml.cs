using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
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
using System.Windows.Shapes;

namespace Bolnica
{
    public partial class PrikazLijekova : UserControl
    {
        public static ObservableCollection<LekDTO> Lijekovi { get; set; }
        LekoviKontroler lijekoviKontroler = new LekoviKontroler();
        public PrikazLijekova()
        {
            InitializeComponent();

            this.DataContext = this;

            Lijekovi = new ObservableCollection<LekDTO>();

            foreach (LekDTO l in lijekoviKontroler.DobaviSveLekove())
            {
                Lijekovi.Add(l);

            }

        }

    }
}

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
    /// Interaction logic for UklanjanjeAlergena.xaml
    /// </summary>
    public partial class UklanjanjeAlergena : Window
    {
        private static String izabranPacijent = null;
        private static String izabranAlergen = null;
        public UklanjanjeAlergena(String idPacijenta,String idAlergena)
        {
            InitializeComponent();
            izabranAlergen = idAlergena;
            izabranPacijent = idPacijenta;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach(Alergeni a in RukovanjeNalozimaPacijenata.PretraziPoId(izabranPacijent).ZdravstveniKarton.Alergeni)
            {
                if(a.IdAlergena.Equals(izabranAlergen))
                {
                    RukovanjeNalozimaPacijenata.PretraziPoId(izabranPacijent).ZdravstveniKarton.Alergeni.Remove(a);
                    AlergeniSekretar.AlergeniPacijenta.Remove(a);

                    RukovanjeNalozimaPacijenata.Sacuvaj();
                    break;
                }
            }    
            this.Close();
        }
    }
}

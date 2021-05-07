using Bolnica.Model;
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
    /// Interaction logic for UklanjanjeLijeka.xaml
    /// </summary>
    public partial class UklanjanjeLijeka : Window
    {
        private  string izabran = null;
        public UklanjanjeLijeka(String idLijeka)
        {
            InitializeComponent();
            izabran = idLijeka;
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {

            RukovanjeLijekovima.UkloniLijek(izabran);
            this.Close();
        }
    }
}
/*< Grid >
        < Button Click = "Ok_Click" x: Name = "button" Content = "Ok" HorizontalAlignment = "Left" Margin = "283,310,0,0" VerticalAlignment = "Top" Width = "92" Height = "48" />
                
                        < Button Click = "Cancel_Click" x: Name = "button1" Content = "Cancel" HorizontalAlignment = "Left" Margin = "421,310,0,0" VerticalAlignment = "Top" Width = "102" RenderTransformOrigin = "3.545,9.063" Height = "48" />
                                  
                                          < DatePicker  Name = "PickStartDate" HorizontalAlignment = "Left" Margin = "332,118,0,0" VerticalAlignment = "Top" Width = "215" />
                                           
                                                   < DatePicker  Name = "PickEndtDate" HorizontalAlignment = "Left" Margin = "332,162,0,0" VerticalAlignment = "Top" Width = "215" />
                                                    
                                                            < Label x: Name = "label" Content = "Od" HorizontalAlignment = "Left" Margin = "245,118,0,0" VerticalAlignment = "Top" />
                                                              
                                                                      < Label x: Name = "label1" Content = "Do" HorizontalAlignment = "Left" Margin = "245,162,0,0" VerticalAlignment = "Top" />
                                                                        
                                                                                < Label x: Name = "label2" Content = "Izaberite datum od kad do kada ce biti renovirana" HorizontalAlignment = "Left" Margin = "249,40,0,0" VerticalAlignment = "Top" />
                                                                                  


                                                                                      </ Grid >*/
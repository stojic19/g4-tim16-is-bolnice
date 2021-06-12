using Bolnica.ViewModel.AdminViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.View.AdminView
{
    /// <summary>
    /// Interaction logic for UklanjanjeFeedbacka.xaml
    /// </summary>
    public partial class UklanjanjeFeedbacka : UserControl
    {
        UklanjanjeFeedbackaViewModel uklanjanjeFeedbackaViewModel;
        public UklanjanjeFeedbacka(string idFeedbacka)
        {
            InitializeComponent();
            uklanjanjeFeedbackaViewModel = new UklanjanjeFeedbackaViewModel(idFeedbacka);
            this.DataContext = uklanjanjeFeedbackaViewModel;
        }
    }
}

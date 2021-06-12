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
    /// Interaction logic for PregledFeedbacka.xaml
    /// </summary>
    public partial class PregledFeedbacka : UserControl
    {
        AdminFeedbackViewModel adminViewModel;
        public PregledFeedbacka()
        {
            InitializeComponent();
            adminViewModel = new AdminFeedbackViewModel();
            dataGridFeedback.ItemsSource = adminViewModel.Feedbacks;
            this.DataContext = adminViewModel;
        }
    }
}

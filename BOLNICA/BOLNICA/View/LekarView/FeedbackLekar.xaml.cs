using Bolnica.LekarFolder;
using Bolnica.ViewModel.LekarViewModel;
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

namespace Bolnica.View.LekarView
{
    public partial class FeedbackLekar : UserControl
    {
        private FeedbackLekarViewModel feedbackViewModel;
        public FeedbackLekar()
        {
            InitializeComponent();
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            feedbackViewModel = new FeedbackLekarViewModel();
            this.DataContext = feedbackViewModel;
        }
    }
}

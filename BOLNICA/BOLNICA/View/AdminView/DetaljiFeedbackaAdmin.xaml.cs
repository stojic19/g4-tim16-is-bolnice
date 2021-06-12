﻿using Bolnica.ViewModel.AdminViewModel;
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
    public partial class DetaljiFeedbackaAdmin : UserControl
    {
        DetaljiFeedbackaViewModel adminViewModel;
        public DetaljiFeedbackaAdmin(string idFeedbacka)
        {
            InitializeComponent();
            adminViewModel = new DetaljiFeedbackaViewModel(idFeedbacka);
            this.DataContext = adminViewModel;
        }
    }
}

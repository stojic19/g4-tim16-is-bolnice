﻿using Bolnica.DTO;
using Bolnica.ViewModel.PacijentViewModel;
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

namespace Bolnica.View.PacijentFolder
{
    public partial class KreirajPodsetnik : UserControl
    {
        KreirajPodsetnikViewModel kreirajPodsetnikViewModel;
        public KreirajPodsetnik(String tekstBeleske, PregledDTO pregled)
        {
            InitializeComponent();
            kreirajPodsetnikViewModel = new KreirajPodsetnikViewModel(tekstBeleske, pregled);
            this.DataContext = kreirajPodsetnikViewModel;
        }
    }
}

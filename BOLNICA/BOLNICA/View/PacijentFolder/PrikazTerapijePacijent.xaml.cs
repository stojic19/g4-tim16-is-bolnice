using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.PacijentFolder;
using Bolnica.ViewModel.PacijentViewModel;
using Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Bolnica
{
    public partial class PrikazTerapijePacijent : UserControl
    {
        TerapijaViewModel terapijaViewModel;
        public PrikazTerapijePacijent(String korisnickoIme)
        {
            InitializeComponent();
            terapijaViewModel = new TerapijaViewModel(korisnickoIme);
            Lekovi.ItemsSource = terapijaViewModel.TerapijePacijenta;
            this.DataContext = terapijaViewModel;
        }
    }
}

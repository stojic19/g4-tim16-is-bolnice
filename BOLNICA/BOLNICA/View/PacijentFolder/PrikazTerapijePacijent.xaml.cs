using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.PacijentFolder;
using Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Bolnica
{
    public partial class PrikazTerapijePacijent : UserControl
    {
        ZdravstvenKartoniKontroler zdravstvenKartoniKontroler = new ZdravstvenKartoniKontroler();
        public static ObservableCollection<Terapija> sveTerapijePacijenta { get; set; }
        public PrikazTerapijePacijent()
        {
            InitializeComponent();
            sveTerapijePacijenta = new ObservableCollection<Terapija>();

            foreach (Terapija t in zdravstvenKartoniKontroler.DobaviSveTerapijePacijenta(PacijentGlavniProzor.ulogovani.KorisnickoIme))
            {
                if(DateTime.Compare(DateTime.Now.Date,t.KrajTerapije)<=0)
                sveTerapijePacijenta.Add(t);
            }

            LekoviLista.ItemsSource = sveTerapijePacijenta;
        }

    

        private void izvestaj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void informacije_Click(object sender, RoutedEventArgs e)
        {
            DetaljiTerapije prikazDetalja = new DetaljiTerapije((Terapija)LekoviLista.SelectedItem);
            prikazDetalja.Show();
        }
    }
}

﻿using Model;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bolnica.Sekretar.Pregled
{
    /// <summary>
    /// Interaction logic for ZakazivanjePregledaTerminiSekretar.xaml
    /// </summary>
    public partial class ZakazivanjePregledaTerminiSekretar : Window
    {
        private static String IdPacijenta;
        public static ObservableCollection<Termin> SlobodniDatumi { get; set; }

        public ZakazivanjePregledaTerminiSekretar(String idPacijenta, List<Termin> datumi)
        {
            InitializeComponent();

            SlobodniDatumi = new ObservableCollection<Termin>();
            IdPacijenta = idPacijenta;

            foreach (Termin t in datumi)
            {
                SlobodniDatumi.Add(t);
            }

            slobodniTerminiLista.ItemsSource = SlobodniDatumi;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String IdTermina = ((Termin)slobodniTerminiLista.SelectedItem).IdTermina;
            Termin termin = new Termin();
            bool postoji = false;
            foreach(Termin t in RukovanjeTerminima.slobodniTermini)
            {
                if(t.IdTermina.Equals(IdTermina))
                {
                    termin = t;
                    postoji = true;
                    break;
                }
            }
            if(!postoji)
            {
                System.Windows.Forms.MessageBox.Show("Odabrani termin je u međuvremenu zauzet!", "Odaberite drugi datum", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            termin.Pacijent = RukovanjeNalozimaPacijenata.PretraziPoId(IdPacijenta);
            RukovanjeTerminima.ZakaziPregledSekretar(termin);
            this.Close();
        }
    }
}

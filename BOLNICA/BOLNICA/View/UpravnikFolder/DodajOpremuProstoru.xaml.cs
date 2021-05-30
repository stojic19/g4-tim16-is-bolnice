﻿using Model;
using System;
using System.Collections.Generic;
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

namespace Bolnica
{

    public partial class DodajOpremuProstoru : Window
    {
        private List<Oprema> oprema;
        private string IdProstora;
        ProstoriServis prostoriServis = new ProstoriServis();
        OpremaServis opremaServis = new OpremaServis();

        public DodajOpremuProstoru(string idProstora)
        {
            InitializeComponent();
            oprema = opremaServis.SvaOprema();
            this.DataContext = this;
            IdProstora = idProstora;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Oprema oprema = (Oprema)dataGridOprema.SelectedItem;
            int Kolicina = Int32.Parse(kolicina.Text);
            if (this.kolicina.Text.Equals(""))
            {
                System.Windows.MessageBox.Show("Unesite kolicinu!");
                return;
            }
            Prostor p = prostoriServis.PretraziPoId(IdProstora);
            opremaServis.PremjestiKolicinuOpreme(p, oprema, Kolicina);
     
            this.Close();
        }

        private void dataGridOprema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
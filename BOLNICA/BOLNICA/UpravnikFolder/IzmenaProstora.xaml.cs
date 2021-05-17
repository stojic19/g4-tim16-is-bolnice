﻿using Bolnica.Model;
using Model;
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

    public partial class IzmenaProstora : Window
    {
        String stari = null;
       

        public IzmenaProstora(String id)//korisnik unosi informacije
        {
            InitializeComponent();

            Prostor prostor = ProstoriServis.PretraziPoId(id);
            stari = id;
  
            if (prostor.VrstaProstora == VrsteProstora.ordinacija)
            {
                VrstaProstora.Text = "Ordinacija";
            }
            else if (prostor.VrstaProstora == VrsteProstora.sala)
            {
                VrstaProstora.Text = "Sala";
            }
            else
            {
                VrstaProstora.Text = "Soba";
            }

            Sprat.Text = prostor.Sprat.ToString();
            Kvadratura.Text = prostor.Kvadratura.ToString();

        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            Prostor p = new Prostor(stari ,ProvjeriVrstuProstora(), int.Parse(this.Sprat.Text), float.Parse(this.Kvadratura.Text), false);
            ProstoriServis.IzmeniProstor(p);

            this.Close();
        }

        private VrsteProstora ProvjeriVrstuProstora()
        {
            VrsteProstora vrstaProstora;

            if (this.VrstaProstora.Text.Equals("Ordinacija"))
            {
                vrstaProstora = VrsteProstora.ordinacija;
            }
            else if (this.VrstaProstora.Text.Equals("Sala"))
            {
                vrstaProstora = VrsteProstora.sala;
            }
            else
            {
                vrstaProstora = VrsteProstora.soba;
            }

            return vrstaProstora;
        }
    }
}
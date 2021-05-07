﻿using Bolnica.Model;
using Bolnica.Model.Enumi;
using Bolnica.Model.Rukovanja;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.PacijentFolder
{
    public partial class PopuniAnketu : UserControl
    {
        public static Pregled predmetAnkete;
        public PopuniAnketu(Pregled izabranZaAnketu)
        {
            InitializeComponent();
            predmetAnkete = izabranZaAnketu;
        }

        private void PosaljiAnketu_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < RukovanjeAnketama.pitanjaOPregledu.Count; i++)
            {

                int indexCombo = i + 1;
                postaviOcenuZaPitanje(((ComboBox)this.FindName("pitanje" + indexCombo)).SelectedIndex, i);

            }
            predmetAnkete.OcenjenPregled = true;
            RukovanjeAnketama.DodajAnketu(new Anketa(PacijentGlavniProzor.ulogovani,DateTime.Now, predmetAnkete, RukovanjeAnketama.pitanjaOPregledu, DodatniKomentar.Text));
            RukovanjeAnketama.UpisiAnkete();
       
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazAnketa());

        }

        private void postaviOcenuZaPitanje(int indexCombo, int indexPitanje)
        {
            switch (indexCombo)
            {

                case 0:
                    RukovanjeAnketama.pitanjaOPregledu[indexPitanje].Ocena = OcenaPitanja.jedan;
                    break;
                case 1:
                    RukovanjeAnketama.pitanjaOPregledu[indexPitanje].Ocena = OcenaPitanja.dva;
                    break;
                case 2:
                    RukovanjeAnketama.pitanjaOPregledu[indexPitanje].Ocena = OcenaPitanja.tri;
                    break;
                case 3:
                    RukovanjeAnketama.pitanjaOPregledu[indexPitanje].Ocena = OcenaPitanja.cetiri;
                    break;
                case 4:
                    RukovanjeAnketama.pitanjaOPregledu[indexPitanje].Ocena = OcenaPitanja.pet;
                    break;
            }
        }
    }
}

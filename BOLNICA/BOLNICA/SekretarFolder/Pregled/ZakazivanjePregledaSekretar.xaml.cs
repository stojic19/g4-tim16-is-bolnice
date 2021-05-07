﻿using Bolnica.SekretarFolder;
using Model;
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
using UserControl = System.Windows.Controls.UserControl;

namespace Bolnica.Sekretar.Pregled
{
    /// <summary>
    /// Interaction logic for ZakazivanjePregledaSekretar.xaml
    /// </summary>
    public partial class ZakazivanjePregledaSekretar : System.Windows.Controls.UserControl
    {
        public static ObservableCollection<Pacijent> SviPacijenti { get; set; }
        public static ObservableCollection<Lekar> SviLekari { get; set; }

        public ZakazivanjePregledaSekretar()
        {
            InitializeComponent();

            this.DataContext = this;
            SviPacijenti = new ObservableCollection<Pacijent>();
            SviLekari = new ObservableCollection<Lekar>();

            foreach (Pacijent p in RukovanjeNalozimaPacijenata.SviNalozi())
            {
                SviPacijenti.Add(p);
            }
            foreach (Lekar l in RukovanjeTerminima.sviLekari)
            {
                SviLekari.Add(l);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Verifikacije
            String idPacijenta = null;
            if (dataGridPacijenti.SelectedIndex != -1)
            {
                idPacijenta = (((Pacijent)dataGridPacijenti.SelectedItem).KorisnickoIme);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Izaberite pacijenta!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            String idLekara = null;
            if (dataGridLekari.SelectedIndex != -1)
            {
                idLekara = (((Lekar)dataGridLekari.SelectedItem).KorisnickoIme);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Izaberite lekara!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!datumPocetak.SelectedDate.HasValue)
            {
                System.Windows.Forms.MessageBox.Show("Izaberite početni datum!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!datumKraj.SelectedDate.HasValue)
            {
                System.Windows.Forms.MessageBox.Show("Izaberite krajnji datum!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Termin> datumi = new List<Termin>();

                DateTime? datum = this.datumPocetak.SelectedDate;
                DateTime? datum1 = this.datumKraj.SelectedDate;
                DateTime pom = (DateTime)datum;
                DateTime pom1 = (DateTime)datum1;

                List<Termin> pomocna = new List<Termin>();

                bool nasao = false;

                datumi.Clear();

                pomocna = RukovanjeTerminima.PretraziPoLekaruUIntervalu(NadjiDatumUIntervalu((DateTime)datumPocetak.SelectedDate, (DateTime)datumKraj.SelectedDate), idLekara);
            foreach (Termin t in pomocna)
                {
                    nasao = false;
                    foreach (Termin t1 in datumi)
                    {
                        if (t1.Datum.Equals(t.Datum))
                        {
                            nasao = true;
                            break;
                        }
                    }
                    if (!nasao)
                    {
                        datumi.Add(t);
                    }

                }
            if (datumi.Count == 0)  //Prioritet lekar
            {
                if (prioritet.SelectedIndex == 0)
                {
                    DateTime tr1 = pom.AddDays(-7);
                    DateTime tr2 = pom.AddDays(7);

                    pomocna = RukovanjeTerminima.PretraziPoLekaruUIntervalu(NadjiDatumUIntervalu((DateTime)datumPocetak.SelectedDate, (DateTime)datumKraj.SelectedDate), idLekara);

                    foreach (Termin t in pomocna)
                    {
                        nasao = false;
                        foreach (Termin t1 in datumi)
                        {
                            if (t1.Datum.Equals(t.Datum))
                            {
                                nasao = true;
                                break;
                            }
                        }
                        if (!nasao)
                        {
                            datumi.Add(t);
                        }

                    }
                    if(datumi.Count==0)
                    {
                        System.Windows.Forms.MessageBox.Show("Nema slobodnih termina za unete podatke!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else 
                    {
                        UserControl usc = null;
                        GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                        usc = new ZakazivanjePregledaTerminiSekretar(idPacijenta, datumi);
                        GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
                    }
                }
                else if (prioritet.SelectedIndex == 1)//Prioritet datum
                {
                    pomocna = RukovanjeTerminima.NadjiTermineUIntervalu(pom, pom1);
                    foreach (Termin t in pomocna)
                    {
                        nasao = false;
                        foreach (Termin t1 in datumi)
                        {
                            if (t1.Datum.Equals(t.Datum) && t1.Lekar.KorisnickoIme.Equals(t.Lekar.KorisnickoIme))
                            {
                                nasao = true;
                                break;
                            }
                        }
                        if (!nasao)
                        {
                            datumi.Add(t);
                        }
                    }
                    if (datumi.Count == 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Nema slobodnih termina za unete podatke!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        UserControl usc = null;
                        GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                        usc = new ZakazivanjePregledaTerminiSekretar(idPacijenta, datumi);
                        GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
                    }
                }
            }
            else
            {
                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new ZakazivanjePregledaTerminiSekretar(idPacijenta, datumi);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
        }
        public List<Termin> NadjiDatumUIntervalu(DateTime datumOd, DateTime datumDo)
        {
            return RukovanjeTerminima.NadjiTermineUIntervalu(datumOd, datumDo);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new TerminiPregledaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Pocetna_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new GlavniProzorSadrzaj();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Nalozi_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new PrikazNalogaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}

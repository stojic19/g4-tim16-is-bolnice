using Bolnica.DTO;
using Bolnica.Sekretar.Pregled;
using Bolnica.SekretarFolder;
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
using System.Windows.Shapes;

namespace Bolnica
{ 
    public partial class GlavniProzorSekretar : Window
    {
        private static GlavniProzorSekretar instance = null;
        private static SekretarDTO Sekretar;
        public SekretarDTO getSekretar()
        {
            return Sekretar;
        }
        public static GlavniProzorSekretar getInstance()
        {
            if (instance == null)
            {
                instance = new GlavniProzorSekretar();
            }
            return instance;
        }
        public static GlavniProzorSekretar getInstance(SekretarDTO sekretar)
        {
            if (instance == null)
            {
                instance = new GlavniProzorSekretar(sekretar);
            }
            return instance;
        }
        public GlavniProzorSekretar()
        {
            InitializeComponent();

            UserControl usc = null;
            MainPanel.Children.Clear();

            usc = new GlavniProzorSadrzaj();
            MainPanel.Children.Add(usc);
        }
        public GlavniProzorSekretar(SekretarDTO sekretar)
        {
            Sekretar = sekretar;
            InitializeComponent();

            UserControl usc = null;
            MainPanel.Children.Clear();

            usc = new GlavniProzorSadrzaj();
            MainPanel.Children.Add(usc);
        }
        public void Odjava()
        {
            Login login = new Login();
            login.Show();

            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            instance = null;
        }
    }
}

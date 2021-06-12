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

namespace Bolnica.View.AdminView
{ 
    public partial class GlavniProzorAdmin : Window
    {
        private static GlavniProzorAdmin instance = null;

        public static GlavniProzorAdmin getInstance()
        {
            if (instance == null)
            {
                instance = new GlavniProzorAdmin();
            }
            return instance;
        }

        public GlavniProzorAdmin()
        {
            InitializeComponent();

            UserControl usc = null;
            MainPanel.Children.Clear();

            usc = new PregledFeedbacka();
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

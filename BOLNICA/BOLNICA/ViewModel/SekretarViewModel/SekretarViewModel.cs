using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.Sekretar.Pregled;
using Bolnica.SekretarFolder;
using Bolnica.SekretarFolder.Operacija;
using Bolnica.View.SekretarFolder.LicnaObavestenja;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Bolnica.ViewModel.SekretarViewModel
{
    public abstract class SekretarViewModel : ViewModel
    {
        public SekretarViewModel()
        {
            pocetnaKomanda = new RelayCommand(Pocetna);
            preglediKomanda = new RelayCommand(Termini);
            operacijeKomanda = new RelayCommand(Operacija);
            naloziKomanda = new RelayCommand(Nalozi);
            obavestenjaKomanda = new RelayCommand(Obavestenja);
            naplataKomanda = new RelayCommand(Naplata);
            stacionarnoKomanda = new RelayCommand(Stacionarno);
            transferKomanda = new RelayCommand(Transfer);
            licnaObavestenjaKomanda = new RelayCommand(LicnaObavestenja);
            nalogKomanda = new RelayCommand(MojNalog);
            odjavaKomanda = new RelayCommand(Odjava);
        }
        private RelayCommand pocetnaKomanda;
        public RelayCommand PocetnaKomanda
        {
            get { return pocetnaKomanda; }
        }
        private RelayCommand preglediKomanda;

        public RelayCommand PreglediKomanda
        {
            get { return preglediKomanda; }
        }
        private RelayCommand operacijeKomanda;

        public RelayCommand OperacijeKomanda
        {
            get { return operacijeKomanda; }
        }
        private RelayCommand naloziKomanda;

        public RelayCommand NaloziKomanda
        {
            get { return naloziKomanda; }
        }

        private RelayCommand obavestenjaKomanda;

        public RelayCommand ObavestenjaKomanda
        {
            get { return obavestenjaKomanda; }
        }

        private RelayCommand naplataKomanda;

        public RelayCommand NaplataKomanda
        {
            get { return naplataKomanda; }
        }

        private RelayCommand stacionarnoKomanda;

        public RelayCommand StacionarnoKomanda
        {
            get { return stacionarnoKomanda; }
        }

        private RelayCommand transferKomanda;

        public RelayCommand TransferKomanda
        {
            get { return transferKomanda; }
        }

        private RelayCommand licnaObavestenjaKomanda;

        public RelayCommand LicnaObavestenjaKomanda
        {
            get { return licnaObavestenjaKomanda; }
        }

        private RelayCommand nalogKomanda;

        public RelayCommand NalogKomanda
        {
            get { return nalogKomanda; }
        }

        private RelayCommand odjavaKomanda;

        public RelayCommand OdjavaKomanda
        {
            get { return odjavaKomanda; }
        }
        private void Odjava()
        {
            GlavniProzorSekretar.getInstance().Odjava();
        }
        private void Pocetna()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new GlavniProzorSadrzaj();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Nalozi()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new PrikazNalogaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private void Obavestenja()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new ObavestenjaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Termini()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new TerminiPregledaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Operacija()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new HitnaOperacijePregled();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Stacionarno()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new StacionarnoLecenjeSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Transfer()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new TransferPacijenataSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Naplata()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new NaplataUslugeSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void RasporedLekara()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new PrikazLekaraSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void LicnaObavestenja()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new LicnaObavestenjaSekretar(GlavniProzorSekretar.getInstance().getSekretar().KorisnickoIme);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void MojNalog()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new MojNalogSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Pomoc()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new Pomoc();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}

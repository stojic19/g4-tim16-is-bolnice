using Bolnica.Komande;
using Bolnica.View.PacijentFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.ViewModel.PacijentViewModel
{
    public class PomocViewModel: ViewModel
    {
        public PomocViewModel()
        {
            pomocAnkete = new RelayCommand(PrikaziPomocAnkete);
            vratiSeNaPocetnu = new RelayCommand(VratiSe);
            glavniMeni = new RelayCommand(PrikaziGlavniMeni);
            vratiSeNaAnkete = new RelayCommand(VratiAnkete);
            pomocZakazivanje = new RelayCommand(PrikaziPomocZakazivanje);
            vratiSeNaGlavniMeni = new RelayCommand(VratiGlavniMeni);
            pomocIzmenaIOtkazivanje = new RelayCommand(PrikaziPomocIzmenaIOtkazivanje);
            vratiSeNaZakazivanje = new RelayCommand(VratiZakazivanje);
            pomocTerapija = new RelayCommand(PrikaziPomocTerapija);
            vratiSeNaIzmenu = new RelayCommand(VratiIzmenu);
            pomocZdravstveniKarton = new RelayCommand(PrikaziPomocZdravstveniKarton);
            vratiSeNaTerapiju = new RelayCommand(VratiTerapiju);
            
        }

      
        private RelayCommand vratiSeNaPocetnu;

        public RelayCommand VratiSeNaPocetnu
        {
            get { return vratiSeNaPocetnu; }
        }

        public void VratiSe()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new Pomoc());
        }

        private RelayCommand glavniMeni;

        public RelayCommand GlavniMeni
        {
            get { return glavniMeni; }
        }

        public void PrikaziGlavniMeni()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocGlavniMeni());
        }


        private RelayCommand pomocAnkete;

        public RelayCommand PomocAnkete
        {
            get { return pomocAnkete; }
        }

        public void PrikaziPomocAnkete()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocAnkete());
        }



        private RelayCommand vratiSeNaAnkete;

        public RelayCommand VratiSeNaAnkete
        {
            get { return vratiSeNaAnkete; }
        }

        public void VratiAnkete()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocAnkete());
        }

        private RelayCommand pomocZakazivanje;

        public RelayCommand PomocZakazivanje
        {
            get { return pomocZakazivanje; }
        }

        public void PrikaziPomocZakazivanje()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocZakazivanje());
        }

        private RelayCommand vratiSeNaGlavniMeni;

        public RelayCommand VratiSeNaGlavniMeni
        {
            get { return vratiSeNaGlavniMeni; }
        }

        public void VratiGlavniMeni()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocGlavniMeni());
        }
        
        private RelayCommand pomocIzmenaIOtkazivanje;

        public RelayCommand PomocIzmenaIOtkazivanje
        {
            get { return pomocIzmenaIOtkazivanje; }
        }

        public void PrikaziPomocIzmenaIOtkazivanje()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocIzmenaIOtkazivanje());
        }
        private RelayCommand vratiSeNaZakazivanje;

        public RelayCommand VratiSeNaZakazivanje
        {
            get { return vratiSeNaZakazivanje; }
        }

        public void VratiZakazivanje()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocZakazivanje());
        }

        
        private RelayCommand pomocTerapija;

        public RelayCommand PomocTerapija
        {
            get { return pomocTerapija; }
        }

        public void PrikaziPomocTerapija()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocTerapija());
        }


        private RelayCommand vratiSeNaIzmenu;

        public RelayCommand VratiSeNaIzmenu
        {
            get { return vratiSeNaIzmenu; }
        }

        public void VratiIzmenu()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocIzmenaIOtkazivanje());
        }
        
        private RelayCommand pomocZdravstveniKarton;

        public RelayCommand PomocZdravstveniKarton
        {
            get { return pomocZdravstveniKarton; }
        }

        public void PrikaziPomocZdravstveniKarton()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocZdravsteniKarton());
        }

        private RelayCommand vratiSeNaTerapiju;

        public RelayCommand VratiSeNaTerapiju
        {
            get { return vratiSeNaTerapiju; }
        }

        public void VratiTerapiju()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocTerapija());
        }

    }

}

using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.SekretarFolder;
using Bolnica.ViewModel.SekretarViewModel.AbstractKlase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bolnica.ViewModel.SekretarViewModel
{
    public class NaplataViewModel : PotvrdiOdustaniViewModel
    {
        private ObservableCollection<PacijentDTO> pacijenti;
        private NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        private PacijentDTO selektovaniPacijent;
  
        public NaplataViewModel()
        {
            UcitajUKolekciju();
            OdustaniKomanda = new RelayCommand(Odustani);
            PotvrdiKomanda = new RelayCommand(Potvrdi);
        }

        private void UcitajUKolekciju()
        {
            Pacijenti = new ObservableCollection<PacijentDTO>();
            foreach (PacijentDTO pacijentDTO in naloziPacijenataKontroler.DobaviSveNaloge())
            {
                Pacijenti.Add(pacijentDTO);
            }
        }
        public PacijentDTO SelektovaniPacijent
        {
            get { return selektovaniPacijent; }
            set
            {
                selektovaniPacijent = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<PacijentDTO> Pacijenti
        {
            get { return pacijenti; }
            set
            {
                pacijenti = value;
                OnPropertyChanged();
            }
        }

        public override void Odustani()
        {
           UserControl usc = null;
           GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

           usc = new GlavniProzorSadrzaj();
           GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        public override void Potvrdi()
        {
            if (selektovaniPacijent != null)
            {
                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new NaplataUslugeIzabraniPacijent(selektovaniPacijent.KorisnickoIme);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                Poruka = "*Morate izabrati pacijenta za pregled usluga!";
            }
        }
    }
}

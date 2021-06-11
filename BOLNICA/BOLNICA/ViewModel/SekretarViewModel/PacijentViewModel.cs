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
using System.Windows.Data;

namespace Bolnica.ViewModel.SekretarViewModel
{
    public class PacijentViewModel : CRUDViewModel
    {
        private ObservableCollection<PacijentDTO> pacijenti;
        private NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        private PacijentDTO selektovaniPacijent;
        private String tekstPretrage;
        public PacijentViewModel()
        {
            UcitajUKolekciju();
            TekstPretrage = "";
            DodajKomanda = new RelayCommand(Dodaj);
            IzmeniKomanda = new RelayCommand(Izmeni);
            UkloniKomanda = new RelayCommand(Ukloni);
            azurirajAlergeneKomanda = new RelayCommand(AzurirajAlergene);
            odblokirajNalogKomanda = new RelayCommand(OdblokirajNalog);
        }

        public void UcitajUKolekciju()
        {
            Pacijenti = new ObservableCollection<PacijentDTO>();
            foreach (PacijentDTO pacijentDTO in naloziPacijenataKontroler.DobaviSveNaloge())
            {
                Pacijenti.Add(pacijentDTO);
            }
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Pacijenti);
            view.Filter = FiltriranjePacijenata;
        }
        private bool FiltriranjePacijenata(object item)
        {
            if (String.IsNullOrEmpty(tekstPretrage))
                return true;
            else
                return ((item as PacijentDTO).Prezime.IndexOf(tekstPretrage, StringComparison.OrdinalIgnoreCase) >= 0);
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
        public String TekstPretrage
        {
            get { return tekstPretrage; }
            set
            {
                    tekstPretrage = value;
                    OnPropertyChanged(() => this.tekstPretrage);
            }
        }

        private void OnPropertyChanged(Func<object> p)
        {
            CollectionViewSource.GetDefaultView(Pacijenti).Refresh();
        }

        public override void Ukloni()
        {
            if (selektovaniPacijent != null)
            {
                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new UklanjanjeNalogaSekretar(selektovaniPacijent.KorisnickoIme);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                Poruka = "*Morate izabrati pacijenta za uklanjanje!";
            }

        }

        public override void Izmeni()
        {
            if (selektovaniPacijent != null)
            {
                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new IzmenaNalogaSekretar(selektovaniPacijent.KorisnickoIme);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                Poruka = "*Morate izabrati pacijenta za izmenu!";
            }
        }

        public override void Dodaj()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new DodavanjeNalogaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private RelayCommand azurirajAlergeneKomanda;

        public RelayCommand AzurirajAlergeneKomanda
        {
            get { return azurirajAlergeneKomanda; }
        }
        public void AzurirajAlergene()
        {
            if (selektovaniPacijent != null)
            {
                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new AlergeniSekretar(selektovaniPacijent.KorisnickoIme);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                Poruka = "*Morate izabrati pacijenta za azuriranje alergena!";
            }
        }

        private RelayCommand odblokirajNalogKomanda;
        public RelayCommand OdblokirajNalogKomanda
        {
            get { return odblokirajNalogKomanda; }
        }
        public void OdblokirajNalog()
        {
            if (selektovaniPacijent != null)
            {
                if(naloziPacijenataKontroler.NalogJeBlokiran(selektovaniPacijent.KorisnickoIme))
                {
                    naloziPacijenataKontroler.OdblokirajNalog(selektovaniPacijent.KorisnickoIme);
                }
                else
                {
                    Poruka = "*Izabrani nalog nije blokiran!";
                }
            }
            else
            {
                Poruka = "*Izaberite nalog za odblokiranje!";
            }
        }
    }
}

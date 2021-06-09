using Bolnica.DTO;
using Bolnica.Kontroler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.ViewModel.LekarViewModel
{
    public class InformacijeAnamnezaViewModel : ViewModel
    {
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        LekariKontroler lekariKontroler = new LekariKontroler();
        private PreglediKontroler preglediKontroler = new PreglediKontroler();
        ZdravstvenKartoniKontroler zdravstvenKartoniKontroler = new ZdravstvenKartoniKontroler();

        private ObservableCollection<TerapijaDTO> terapije;
        public ObservableCollection<TerapijaDTO> Terapije
        {
            get { return terapije; }
            set
            {
                terapije = value;
                OnPropertyChanged();
            }

        }

        private String imePacijenta;
        public String ImePacijenta
        {
            get { return imePacijenta; }
            set
            {
                imePacijenta = value;
                OnPropertyChanged();
            }

        }

        private String prezimePacijenta;
        public String PrezimePacijenta
        {
            get { return prezimePacijenta; }
            set
            {
                prezimePacijenta = value;
                OnPropertyChanged();
            }

        }

        private String jmbgPacijenta;
        public String JmbgPacijenta
        {
            get { return jmbgPacijenta; }
            set
            {
                jmbgPacijenta = value;
                OnPropertyChanged();
            }

        }

        private String imeLekara;
        public String ImeLekara
        {
            get { return imeLekara; }
            set
            {
                imeLekara = value;
                OnPropertyChanged();
            }

        }

        private String prezimeLekara;
        public String PrezimeLekara
        {
            get { return prezimeLekara; }
            set
            {
                prezimeLekara = value;
                OnPropertyChanged();
            }

        }

        private String datum;
        public String Datum
        {
            get { return datum; }
            set
            {
                datum = value;
                OnPropertyChanged();
            }

        }

        private String tekst;
        public String Tekst
        {
            get { return tekst; }
            set
            {
                tekst = value;
                OnPropertyChanged();
            }

        }

        public InformacijeAnamnezaViewModel(AnamnezaDTO odabranaAnamneza)
        {
            InicijalizacijaTabele(odabranaAnamneza);
            InicijalizacijaPolja(odabranaAnamneza);
        }

        private void InicijalizacijaTabele(AnamnezaDTO anamneza)
        {
            Terapije = new ObservableCollection<TerapijaDTO>();

            foreach (TerapijaDTO t in anamneza.SveTerapije)
            {
                Terapije.Add(t);
            }
        }

        private void InicijalizacijaPolja(AnamnezaDTO anamneza)
        {

            PacijentDTO p = naloziPacijenataKontroler.PretraziPoId(anamneza.IdPacijenta);
            LekarDTO l = lekariKontroler.PretraziPoId(anamneza.IdLekara);

            ImePacijenta = p.Ime;
            PrezimePacijenta = p.Prezime;
            JmbgPacijenta = p.Jmbg;
            ImeLekara = l.Ime;
            PrezimeLekara = l.Prezime;
            Datum = anamneza.Datum.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            Tekst = anamneza.Dijagnoza;

        }
    }
}

using System;
using System.ComponentModel;

namespace Model
{
    public class Termin : INotifyPropertyChanged
    {
        public String IdTermina { get; set; }
        
        public VrsteTermina VrstaTermina { get; set; }
        public String PocetnoVreme { get; set; }
        public Double Trajanje { get; set; }
        public String Datum { get; set;  }

        public Prostor Prostor { get; set; }
        public Pacijent Pacijent { get; set; }
        public Lekar Lekar { get; set; }

        public Termin(string idTermina, VrsteTermina vrstaTermina, string pocetnoVreme, double trajanje, string datum, Prostor prostor, Pacijent pacijent, Lekar lekar)
        {
            IdTermina = idTermina;
            VrstaTermina = vrstaTermina;
            PocetnoVreme = pocetnoVreme;
            Trajanje = trajanje;
            Datum = datum;
            Prostor = prostor;
            Pacijent = pacijent;
            Lekar = lekar;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
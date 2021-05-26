using System;
using System.ComponentModel;
using System.Xml;

namespace Model
{
    public class Termin : INotifyPropertyChanged
    {
        public String IdTermina { get; set; }
        
        public VrsteTermina VrstaTermina { get; set; }
        public String PocetnoVreme { get; set; }
        public Double Trajanje { get; set; }
        public DateTime Datum { get; set;  }

        public Prostor Prostor { get; set; }
        public Pacijent Pacijent { get; set; }
        public Lekar Lekar { get; set; }
        public Termin() { }
        public Termin(string idTermina, VrsteTermina vrstaTermina, string pocetnoVreme, double trajanje, DateTime datum, Prostor prostor, Pacijent pacijent, Lekar lekar)
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
        public Termin(VrsteTermina vrstaTermina, string pocetnoVreme, double trajanje, DateTime datum, Lekar lekar)
        {
            IdTermina = generisiID();
            VrstaTermina = vrstaTermina;
            PocetnoVreme = pocetnoVreme;
            Trajanje = trajanje;
            Datum = datum;
            Prostor = null;
            Pacijent = null;
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

        public override string ToString()
        {
            return base.ToString();
        }

        public String getVrstaTerminaString()
        {

            if (VrstaTermina == VrsteTermina.operacija)
            {
                return "Operacija";
            }
            else 
            {
                return "Pregled";
            }
        }
        public static string generisiID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
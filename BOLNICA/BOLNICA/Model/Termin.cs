using System;
using System.ComponentModel;
using System.Xml;

namespace Model
{
    public class Termin : INotifyPropertyChanged
    {
        private String idTermina;
        private VrsteTermina vrstaTermina;
        private String pocetnoVreme;
        private double trajanje;
        private DateTime datum;
        private Prostor prostor;
        private Pacijent pacijent;
        private Lekar lekar;

        public String IdTermina
        {
            get { return idTermina; }
            set { idTermina = value; }
        }
        public VrsteTermina VrstaTermina
        {
            get { return vrstaTermina; }
            set { vrstaTermina = value; }
        }
        public String PocetnoVreme
        {
            get { return pocetnoVreme; }
            set { pocetnoVreme = value; }
        }

        public double Trajanje
        {
            get { return trajanje; }
            set { trajanje = value; }
        }

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        public Prostor Prostor
        {
            get { return prostor; }
            set { prostor = value; }
        }

        public Pacijent Pacijent
        {
            get { return pacijent; }
            set { pacijent = value; }
        }

        public Lekar Lekar
        {
            get { return lekar; }
            set { lekar = value; }
        }

        public Termin() { }
        public Termin(string idTermina, VrsteTermina vrstaTermina, string pocetnoVreme, double trajanje, DateTime datum, Prostor prostor, Pacijent pacijent, Lekar lekar)
        {
            this.idTermina = idTermina;
            this.vrstaTermina = vrstaTermina;
            this.pocetnoVreme = pocetnoVreme;
            this.trajanje = trajanje;
            this.datum = datum;
            this.prostor = prostor;
            this.pacijent = pacijent;
            this.lekar = lekar;
        }
        public Termin(VrsteTermina vrstaTermina, string pocetnoVreme, double trajanje, DateTime datum, Lekar lekar)
        {
            this.idTermina = Guid.NewGuid().ToString();
            this.vrstaTermina = vrstaTermina;
            this.pocetnoVreme = pocetnoVreme;
            this.trajanje = trajanje;
            this.datum = datum;
            this.prostor = null;
            this.pacijent = null;
            this.lekar = lekar;
        }

        public Termin(VrsteTermina vrstaTermina, DateTime datum, Prostor prostor)
        {
            this.vrstaTermina = vrstaTermina;
            this.datum = datum;
            this.prostor = prostor;
        }

        public Termin(VrsteTermina vrstaTermina, DateTime datum, Prostor prostor, String pocetnoVreme)
        {
            this.vrstaTermina = vrstaTermina;
            this.datum = datum;
            this.prostor = prostor;
            this.pocetnoVreme = pocetnoVreme;
        }


        /*
public Termin(string idTermina, DateTime datum, string vreme, Lekar lekar, string trajanje1, string prostor1, string tipTermina, string idPacijenta, double v, Pacijent pacijent)
{
   this.idTermina = idTermina;
   this.datum = datum;
   this.vreme = vreme;
   this.lekar = lekar;
   this.trajanje1 = trajanje1;
   this.prostor1 = prostor1;
   this.tipTermina = tipTermina;
   this.idPacijenta = idPacijenta;
   this.v = v;
   this.pacijent = pacijent;
}
*/
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

    }
}
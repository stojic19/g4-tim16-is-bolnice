using Bolnica.Model;
using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace Model
{
    public class Termin
    {
        private String idTermina;
        private String pocetnoVreme;
        private double trajanje;
        private DateTime datum;
        private Prostor prostor;
        private Pacijent pacijent;
        private Lekar lekar;

        private object vrstaTerminaInterfejs;
        [XmlIgnore()]
        public object VrstaTerminaInterfejs
        {
            get { return vrstaTerminaInterfejs; }
            set { vrstaTerminaInterfejs = value; }
        }
        public String IdTermina
        {
            get { return idTermina; }
            set { idTermina = value; }
        }

        private VrsteTermina vrstaTermina;
        public VrsteTermina VrstaTermina
        {
            get { return vrstaTermina; }
            set
            {
                vrstaTermina = value;
                if (value == VrsteTermina.operacija)
                {
                    VrstaTerminaInterfejs = new ProstorOperacija();
                }
                else if (value == VrsteTermina.pregled)
                {
                    VrstaTerminaInterfejs = new ProstorPregled();
                }
                else
                {
                    vrstaTerminaInterfejs = null;
                }
            }
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

        public Termin(object vrstaTerminaInterfejs, string idTermina, VrsteTermina vrstaTermina, string pocetnoVreme, double trajanje, DateTime datum, Prostor prostor, Pacijent pacijent, Lekar lekar)
        {
            VrstaTerminaInterfejs = vrstaTerminaInterfejs;
            IdTermina = idTermina;
            VrstaTermina = vrstaTermina;
            PocetnoVreme = pocetnoVreme;
            Trajanje = trajanje;
            Datum = datum;
            Prostor = prostor;
            Pacijent = pacijent;
            Lekar = lekar;
        }
    }
}
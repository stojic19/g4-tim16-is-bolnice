using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Pregled
    {
        private String idPregleda;
        private Boolean odrzan = false;
        private Termin termin;
        private Anamneza anamneza = null;
        private List<Recept> recepti = new List<Recept>();
        private List<Uput> uputi = new List<Uput>();
        private List<Alergeni> alergeni = new List<Alergeni>();
        private bool ocenjenPregled;

        public string IdPregleda { get => idPregleda; set => idPregleda = value; }
        public bool Odrzan { get => odrzan; set => odrzan = value; }
        public Termin Termin { get => termin; set => termin = value; }
        public Anamneza Anamneza { get => anamneza; set => anamneza = value; }
        public List<Recept> Recepti { get => recepti; set => recepti = value; }
        public List<Uput> Uputi { get => uputi; set => uputi = value; }
        public List<Alergeni> Alergeni { get => alergeni; set => alergeni = value; }
        public bool OcenjenPregled { get => ocenjenPregled; set => ocenjenPregled = value; }

      

        public Pregled() { }

        public Pregled(string idPregleda, Termin termin)
        {
            this.IdPregleda = idPregleda;
            this.Termin = termin;
            OcenjenPregled = false;

        }

        public Pregled(string idPregleda, Termin termin, Anamneza anamneza, List<Recept> recepti, bool ocenjenPregled) : this(idPregleda, termin) { }
    }
}

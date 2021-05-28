using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Anketa
    {
        private Pacijent pacijent;
        private DateTime ocenioBolnicu;
        private Pregled pregled;
        private List<Pitanje> pitanjaAnkete;
        private String dodatniKomentar;

        public Pacijent Pacijent
        {
            get { return pacijent; }
            set { pacijent = value; }
        }

        public DateTime OcenioBolnicu
        {
            get { return ocenioBolnicu; }
            set { ocenioBolnicu = value; }
        }

        public Pregled Pregled
        {
            get { return pregled; }
            set { pregled = value; }
        }

        public List<Pitanje> PitanjaAnkete
        {
            get { return pitanjaAnkete; }
            set { pitanjaAnkete = value; }
        }

        public String DodatniKomentar
        {
            get { return dodatniKomentar; }
            set { dodatniKomentar = value; }
        }

        public Anketa() { }

        public Anketa(Pacijent pacijent, DateTime ocenioBolnicu, Pregled pregled, List<Pitanje> pitanjaAnkete, string dodatniKomentar)
        {
            this.pacijent = pacijent;
            this.ocenioBolnicu = ocenioBolnicu;
            this.pregled = pregled;
            this.pitanjaAnkete = pitanjaAnkete;
            this.dodatniKomentar = dodatniKomentar;
        }
    }
}

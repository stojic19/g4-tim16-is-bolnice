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
        public Pacijent Pacijent { get; set; }
        public DateTime OcenioBolnicu { get; set; }
        public Pregled Pregled { get; set; }
        public List<Pitanje> PitanjaAnkete { get; set; }
        public String DodatniKomentar { get; set; }


        public Anketa() { }

        public Anketa(Pacijent pacijent, DateTime ocenioBolnicu, Pregled pregled, List<Pitanje> pitanjaAnkete, string dodatniKomentar)
        {
            Pacijent = pacijent;
            OcenioBolnicu = ocenioBolnicu;
            Pregled = pregled;
            PitanjaAnkete = pitanjaAnkete;
            DodatniKomentar = dodatniKomentar;
        }
    }
}

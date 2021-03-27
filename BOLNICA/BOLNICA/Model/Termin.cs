using System;

namespace Model
{
    public class Termin
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
    }
}
using System;
using System.Collections.Generic;

namespace Model
{
    public class Anamneza
    {
        public String IdAnamneze { get; set; }
        public String IdLekara { get; set; }

        public String ImeIPrezimeLekara { get; set; }
        public String IdPacijenta { get; set; }
        public DateTime Datum { get; set; }

        public String Dijagnoza { get; set; }
        public List<Terapija> Terapije { get; set; } = new List<Terapija>();

        public Anamneza() { }

        public Anamneza(string idLekara, string imeIPrezimeLekara, string idPacijenta, DateTime datum, string dijagnoza, List<Terapija> terapije)
        {
            IdLekara = idLekara;
            ImeIPrezimeLekara = imeIPrezimeLekara;
            IdPacijenta = idPacijenta;
            Datum = datum;
            Dijagnoza = dijagnoza;
            Terapije = terapije;
        }

        public Anamneza(string idAnamneze, string idLekara, string imeIPrezimeLekara, string idPacijenta, DateTime datum, string dijagnoza, List<Terapija> terapije)
        {
            IdAnamneze = idAnamneze;
            IdLekara = idLekara;
            ImeIPrezimeLekara = imeIPrezimeLekara;
            IdPacijenta = idPacijenta;
            Datum = datum;
            Dijagnoza = dijagnoza;
            Terapije = terapije;
        }

        public Anamneza(string idAnamneze, string idPacijenta, string dijagnoza, List<Terapija> terapije)
        {
            IdAnamneze = idAnamneze;
            IdPacijenta = idPacijenta;
            Dijagnoza = dijagnoza;
            Terapije = terapije;
        }
    }
}
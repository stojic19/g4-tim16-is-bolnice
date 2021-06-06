using System;
using System.Collections.Generic;

namespace Model
{
    public class Anamneza
    {
        private String idAnamneze;
        private String idLekara;
        private String imeIPrezimeLekara;
        private String idPacijenta;
        private DateTime datum;
        private String dijagnoza;
        private List<Terapija> terapije = new List<Terapija>();

        public string IdAnamneze { get => idAnamneze; set => idAnamneze = value; }
        public string IdLekara { get => idLekara; set => idLekara = value; }
        public string ImeIPrezimeLekara { get => imeIPrezimeLekara; set => imeIPrezimeLekara = value; }
        public string IdPacijenta { get => idPacijenta; set => idPacijenta = value; }
        public DateTime Datum { get => datum; set => datum = value; }
        public string Dijagnoza { get => dijagnoza; set => dijagnoza = value; }
        public List<Terapija> Terapije { get => terapije; set => terapije = value; }

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
using System;

namespace Model
{
    public class Recept
    {
        public String IDRecepta { get; set; }
        public String IDLekara { get; set; }

        public String ImeiPrezimeLekara { get; set; }

        public String IDPacijenta { get; set; }

        public DateTime Datum { get; set; }
        public Lek Lek { get; set; }


        public Recept() { }

        public Recept(string iDRecepta, string iDLekara, string iDPacijenta, DateTime datum, Lek lek)
        {
            IDRecepta = iDRecepta;
            IDLekara = iDLekara;
            IDPacijenta = iDPacijenta;
            Datum = datum;
            Lek = lek;
            ImeiPrezimeLekara = RukovanjeTerminima.ImeiPrezime(iDLekara);
        }
    }
}
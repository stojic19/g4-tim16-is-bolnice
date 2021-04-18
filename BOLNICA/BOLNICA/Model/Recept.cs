using System;

namespace Model
{
    public class Recept
    {
        public String IDRecepta { get; set; }
        public String IDLekara { get; set; }

        public String ImeiPrezimeLekara { get; set; }

        public String IDPacijenta { get; set; }

        public String Datum { get; set; }
        public Lek Lek { get; set; }



        public Recept() { }

        public Recept(string iDRecepta, string iDLekara, string imeiPrezimeLekara, string iDPacijenta, String datum, Lek lek)
        {
            IDRecepta = iDRecepta;
            IDLekara = iDLekara;
            ImeiPrezimeLekara = imeiPrezimeLekara;
            IDPacijenta = iDPacijenta;
            Datum = datum;
            Lek = lek;
        }
    }
}
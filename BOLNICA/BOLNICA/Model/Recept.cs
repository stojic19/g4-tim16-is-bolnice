using System;

namespace Model
{
    public class Recept
    {
        public String IDRecepta { get; set; }
        public DateTime Datum { get; set; }
        public Lek Lek { get; set; }


        public Recept() { }

        public Recept(string iDRecepta, DateTime datum, Lek lek)
        {
            IDRecepta = iDRecepta;
            Datum = datum;
            Lek = lek;
        }
    }
}
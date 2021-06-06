using System;

namespace Model
{
    public class Recept
    {
        private String iDRecepta;
        private DateTime datum;
        private Lek lek;

        public string IDRecepta { get => iDRecepta; set => iDRecepta = value; }
        public DateTime Datum { get => datum; set => datum = value; }
        public Lek Lek { get => lek; set => lek = value; }

        public Recept() { }

        public Recept(string iDRecepta, DateTime datum, Lek lek)
        {
            IDRecepta = iDRecepta;
            Datum = datum;
            Lek = lek;
        }
    }
}
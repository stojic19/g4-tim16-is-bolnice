using System;

namespace Model
{
    public class Lek
    {
        public String IDLeka { get; set; }
        public String NazivLeka { get; set; }
        public String Jacina { get; set; }

        public Lek()
        {
        }

        public Lek(string iDLeka, string nazivLeka, string jacina)
        {
            IDLeka = iDLeka;
            NazivLeka = nazivLeka;
            Jacina = jacina;
        }

    }
}
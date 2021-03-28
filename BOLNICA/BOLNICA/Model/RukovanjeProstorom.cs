using Bolnica;
using System;
using System.Collections.Generic;

namespace Model
{
    public class RukovanjeProstorom
    {
        private String imeFajla;
        public static List<Prostor> prostori = new List<Prostor>();

        public static Prostor DodajProstor(Prostor p)
        {
            prostori.Add(p);
            PrikazProstora.Prostori.Add(p);

            if (prostori.Contains(p))
            {
                return p;
            }
            else
            {
                return null;
            }
        }
        public Boolean IzmeniProstor(String idProstora)
        {
            throw new NotImplementedException();
        }

        public Boolean UkloniProstor(String idProstora)
        {
            throw new NotImplementedException();
        }

        public Prostor PretraziPoId(String idProstora)
        {
            throw new NotImplementedException();
        }

        public static List<Prostor> SviProstori()
        {

            return prostori;
        }

    }
}
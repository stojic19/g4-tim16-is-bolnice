// File:    RukovanjeTerminima.cs
// Author:  Jelena
// Created: Friday, March 26, 2021 12:40:47 PM
// Purpose: Definition of Class RukovanjeTerminima

using Bolnica;
using System;
using System.Collections.Generic;

namespace Model
{
    public class RukovanjeTerminima
    {
        private String imeFajla;

        public static Termin ZakaziTermin(Termin t)
        {
            sviTermini.Add(t);
            PrikazTerminaLekara.Termini.Add(t);

            if (sviTermini.Contains(t))
            {
                return t;
            }
            else
            {
                return null;
            }
        }
        public static Termin ZakaziPregled(Termin t)
        {
            sviTermini.Add(t);

            PrikazTerminaPacijent.Termini.Add(t);

            if (sviTermini.Contains(t))
            {
                return t;
            }
            else
            {
                return null;
            }
        }

        public static Boolean OtkaziTermin(String idTermina)
        {
            Termin t = null;

            foreach (Termin termin in sviTermini)
            {
                if (termin.IdTermina.Equals(idTermina))
                    t = termin;
            }

            if (t == null)
            {
                return false;
            }

            sviTermini.Remove(t);
            PrikazTerminaLekara.Termini.Remove(t);

            if (sviTermini.Contains(t) || PrikazTerminaLekara.Termini.Contains(t))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean OtkaziPregled(String idTermina) {

            Termin t = PretraziPoId(idTermina);
            sviTermini.Remove(t);
            PrikazTerminaPacijent.Termini.Remove(t);

            if (t == null)
                return false;

            return true;
        }

        public Boolean IzmeniTermin(String idTermina)
        {
            throw new NotImplementedException();
        }
        public Boolean IzmeniPregled(String idTermina, String lekarW, String datumW, String vremeW)
        {
            Termin t = PretraziPoId(idTermina);
            if (!t.Lekar.korisnickoIme.Equals(lekarW))
            {
                t.Lekar.korisnickoIme = lekarW;
            }

            if (!t.Datum.Equals(datumW))
            {
                t.Datum = datumW;
            }

            if (!t.PocetnoVreme.Equals(vremeW))
            {
                t.PocetnoVreme = vremeW;
            }

            OtkaziPregled(idTermina);
            ZakaziPregled(t);



            return true;

        }

        public Termin PretraziPoId(String idTermina)
        {
            foreach(Termin termin in sviTermini)
            {
                if (termin.IdTermina.Equals(idTermina))
                    return termin;
            }
            return null;
        }

        public List<Termin> PretraziPoLekaru(String korImeLekara)
        {
            throw new NotImplementedException();
        }

        public List<Termin> PretraziPoProstoriji(String idProstorije)
        {
            throw new NotImplementedException();
        }

        public List<Termin> PretraziPoPacijentu(String korImePacijenta)
        {
            throw new NotImplementedException();
        }

        public static List<Termin> DobaviSveTermine()
        {
            return sviTermini;
        }

        public static List<Termin> sviTermini = new List<Termin>();

    }
}
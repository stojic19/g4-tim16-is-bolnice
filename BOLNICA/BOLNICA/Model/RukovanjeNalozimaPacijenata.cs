
using Bolnica;
using System;
using System.Collections.Generic;

namespace Model
{
    public class RukovanjeNalozimaPacijenata
    {
        private String imeFajla;

        public static List<Pacijent> sviNaloziPacijenata = new List<Pacijent>();

        public static Pacijent DodajNalog(Pacijent p)
        {
            sviNaloziPacijenata.Add(p);
            PrikazNalogaSekretar.NaloziPacijenata.Add(p);

            if (sviNaloziPacijenata.Contains(p))
            {
                return p;
            }
            else
            {
                return null;
            }
        }

        public static Boolean IzmeniNalog(String idNaloga, String ime, String prezime, DateTime datum, String jmbg, String adresa, String telefon, String email)
        {
            Pacijent p = PretraziPoId(idNaloga);

            p.ime = ime;
            p.prezime = prezime;
            p.datumRodjenja = datum;
            p.jmbg = adresa;
            p.kontaktTelefon = telefon;
            p.email = email;

            int indeks = PrikazNalogaSekretar.NaloziPacijenata.IndexOf(p);
            PrikazNalogaSekretar.NaloziPacijenata.RemoveAt(indeks);
            PrikazNalogaSekretar.NaloziPacijenata.Insert(indeks, p);

            return true;
        }

        public static Boolean UkolniNalog(String idNaloga)
        {
            Pacijent p = PretraziPoId(idNaloga);

            if (p == null)
            {
                return false;
            }

            sviNaloziPacijenata.Remove(p);
            PrikazNalogaSekretar.NaloziPacijenata.Remove(p);

            if (sviNaloziPacijenata.Contains(p) || PrikazNalogaSekretar.NaloziPacijenata.Contains(p))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Pacijent PretraziPoId(String idNaloga)
        {
            foreach (Pacijent p in sviNaloziPacijenata)
            {
                if (p.korisnickoIme.Equals(idNaloga))
                    return p;
            }
            return null;
        }

        public static List<Pacijent> SviNalozi()
        {
            return sviNaloziPacijenata;
        }

    }
}
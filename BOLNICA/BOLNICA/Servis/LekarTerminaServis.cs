using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Servis
{
    public class LekarTerminaServis
    {
        public bool TerminJeOdIzabranogLekaraOpstePrakse(Termin termin, String korisnickoImeLekara)
        {
            if (termin.Lekar.KorisnickoIme.Equals(korisnickoImeLekara) &&
                termin.Lekar.Specijalizacija == SpecijalizacijeLekara.nema) return true;
            return false;
        }

        public bool LekariTerminaSuIsti(String lekarTermina, String izabraniLekar)
        {
            if (lekarTermina.Equals(izabraniLekar)) return true;
            return false;
        }

        public List<Termin> PretraziTerminePoLekaru(List<Termin> terminiUIntervalu, String korisnickoImeLekara)
        {
            List<Termin> terminiKodIzabranog = new List<Termin>();
            foreach (Termin termin in terminiUIntervalu)
            {
                if (TerminJeOdIzabranogLekaraOpstePrakse(termin, korisnickoImeLekara))
                    terminiKodIzabranog.Add(termin);
            }
            return terminiKodIzabranog;
        }

        public List<Termin> DobaviSlobodneTermineLekara(List<Termin> slobodniTermini, int brojTermina)
        {
            List<Termin> krajnjiTermini = new List<Termin>();
            brojTermina--;

            for (int i = 0; i < slobodniTermini.Count(); i++)
            {
                if (i + brojTermina >= slobodniTermini.Count()) continue;

                if (DateTime.Compare(slobodniTermini[i + brojTermina].Datum, slobodniTermini[i].Datum.AddMinutes(brojTermina * 30)) == 0)
                {
                    krajnjiTermini.Add(slobodniTermini[i]);
                }
            }

            return krajnjiTermini;
        }
    }
}

using Bolnica.Repozitorijum.Interfejsi;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum
{
    public class SlobodniTerminiRepozitorijum : GlavniRepozitorijum<Termin>, SlobodniTerminiRepozitorijumInterfejs
    {
        public SlobodniTerminiRepozitorijum()
        {
            imeFajla = "slobodniTermini.xml";
        }

        public List<Termin> DobaviSlobodneTerminePoIdLekara(string idLekara)
        {
            List<Termin> termini = new List<Termin>();
            foreach (Termin termin in DobaviSveObjekte())
            {
                if (termin.Lekar.KorisnickoIme.Equals(idLekara))
                {
                    termini.Add(termin);
                }
            }
            return termini;
        }

        public void IzmeniTermin(Termin termin)
        {
            ObrisiObjekat("//ArrayOfTermin/Termin[IdTermina='" + termin.IdTermina + "']");
            DodajObjekat(termin);
        }
        public void UkloniTermin(Termin termin)
        {
            ObrisiObjekat("//ArrayOfTermin/Termin[IdTermina='" + termin.IdTermina + "']");
        }
        
        public Termin PretraziSlobodnePoId(String idTermina)
        {
            return PretraziPoId("//ArrayOfTermin/Termin[IdTermina='" + idTermina + "']");
        }

        public List<Termin> DobaviSlobodneTermineLekara(Termin terminZaPoredjenje, String izabranLekar)
        {
            List<Termin> slobodniTermini = new List<Termin>();
            foreach (Termin t in DobaviSlobodneTerminePoIdLekara(izabranLekar))
            {
                if (t.Datum.Date.CompareTo(terminZaPoredjenje.Datum.Date) == 0 && t.VrstaTermina.Equals(terminZaPoredjenje.VrstaTermina))
                {
                    slobodniTermini.Add(t);
                }
            }

            return slobodniTermini.OrderBy(user => user.Datum).ToList();
            //return slobodniTermini;
        }
    }
}

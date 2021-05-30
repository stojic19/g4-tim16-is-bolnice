using Bolnica.Repozitorijum.Interfejsi;
using Bolnica.Sekretar.Pregled;
using Bolnica.Servis;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bolnica.Repozitorijum
{
    public class ZakazaniTerminiRepozitorijum : GlavniRepozitorijum<Termin>, ZakazaniTerminiRepozitorijumInterfejs
    {
        public ZakazaniTerminiRepozitorijum()
        {
            imeFajla = "termini.xml";
        }

        public void IzmeniTermin(Termin termin)
        {
            ObrisiObjekat("//ArrayOfTermin/Termin[IdTermina='" + termin.IdTermina + "']");
            DodajObjekat(termin);
        }

        public Boolean DaLiPostojiTermin(Termin termin)
        {
            foreach(Termin t in DobaviSveObjekte())
            {
                if (t.IdTermina.Equals(termin.IdTermina)) return true;
            }

            return false;
        }

        public Boolean OtkaziTerminLekar(String idTermina)
        {
            Termin terminZaBrisanje = DobaviZakazanTerminPoId(idTermina);

            if (terminZaBrisanje == null) return false;

            ObrisiZakazanTermin(terminZaBrisanje.IdTermina);
            terminZaBrisanje.Pacijent = null;

            if (DobaviSveObjekte().Contains(terminZaBrisanje))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Termin> PretraziPoLekaru(String korImeLekara)
        {

            List<Termin> lekaroviTermini = new List<Termin>();

            foreach (Termin t in DobaviSveObjekte())
            {
                if (t.Lekar.KorisnickoIme.Equals(korImeLekara))
                {
                    lekaroviTermini.Add(t);
                }

            }
            return lekaroviTermini;
        }

        public List<Termin> DobaviSveZakazaneTermine()
        {
            return DobaviSveObjekte();
        }

        public List<Termin> DobaviSveZakazaneTerminePacijenta(String pacijentKorisnickoIme)
        {
            List<Termin> sviTerminiPacijenta = new List<Termin>();
            foreach (Termin termin in DobaviSveZakazaneTermine())
            {
                if (termin.Pacijent.KorisnickoIme.Equals(pacijentKorisnickoIme))
                    sviTerminiPacijenta.Add(termin);
            }
            return sviTerminiPacijenta;
        }

        public Termin DobaviZakazanTerminPoId(String idTermina)
        {
            return PretraziPoId("//ArrayOfTermin/Termin[IdTermina='" + idTermina + "']");
        }
        public void ObrisiZakazanTermin(String terminZaBrisanje)
        {
            ObrisiObjekat("//ArrayOfTermin/Termin[IdTermina='" + terminZaBrisanje + "']");
        }

    }
}

using Bolnica.Repozitorijum.Interfejsi;
using Bolnica.Sekretar.Pregled;
using Bolnica.Servis;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Bolnica.Repozitorijum
{
    public class TerminRepozitorijum : GlavniRepozitorijum<Termin>, TerminiRepozitorijumInterfejs
    {
        NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();
        SlobodniTerminiServis slobodniTerminiServis = new SlobodniTerminiServis();

        public TerminRepozitorijum()
        {
            imeFajla = "termini.xml";
        }
        
        public Termin ZakaziTermin(Termin t, String lekar)
        {
            DodajObjekat(t);
            foreach (Termin term in slobodniTerminiServis.DobaviSveSlobodneTermine())
            {
                if (term.IdTermina.Equals(t.IdTermina))
                {
                    slobodniTerminiServis.UkloniSlobodanTermin(term);
                }
            }


            if (t.Lekar.KorisnickoIme.Equals(lekar))
            {
                PrikazTerminaLekara.Termini.Add(t);
            }

            if (DobaviSveObjekte().Contains(t))
            {
                return t;
            }
            else
            {
                return null;
            }
        }

        public Boolean OtkaziTermin(String idTermina)
        {
            Termin t = PretraziPoId(idTermina);

            if (t == null)
            {
                return false;
            }

            ObrisiZakazanTermin(t);
            t.Pacijent = null;
            slobodniTerminiServis.DodajSlobodanTerminZaPregled(t);

            PrikazTerminaLekara.Termini.Remove(t);

            if (DobaviSveObjekte().Contains(t) || PrikazTerminaLekara.Termini.Contains(t))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Boolean OtkaziPregledSekretar(String idTermina)
        {
            Termin termin = PretraziPoId(idTermina);

            if (termin == null)
            {
                return false;
            }

            ObrisiZakazanTermin(termin);
            termin.Pacijent = null;
            slobodniTerminiServis.DodajSlobodanTerminZaPregled(termin);

            TerminiPregledaSekretar.TerminiPregleda.Remove(termin);

            return !DaLiListeSadrzeTerminSekretar(termin);
        }
        private bool DaLiListeSadrzeTerminSekretar(Termin termin)
        {
            return DobaviSveObjekte().Contains(termin) || TerminiPregledaSekretar.TerminiPregleda.Contains(termin);
        }

        public Boolean IzmeniTermin(Termin stari, Termin novi, String korisnik)
        {

            foreach (Termin t in slobodniTerminiServis.DobaviSveSlobodneTermine())
            {
                if (t.IdTermina.Equals(novi.IdTermina))
                {
                    slobodniTerminiServis.UkloniSlobodanTermin(t);
                    DodajObjekat(t);
                }

            }

            foreach (Termin t in DobaviSveObjekte().ToList())
            {
                if (t.IdTermina.Equals(stari.IdTermina))
                {
                    ObrisiZakazanTermin(t);
                    slobodniTerminiServis.DodajSlobodanTerminZaPregled(stari);
                }
            }

            if (novi.Lekar.KorisnickoIme.Equals(korisnik))
            {
                int indeks = PrikazTerminaLekara.Termini.IndexOf(stari);
                PrikazTerminaLekara.Termini.RemoveAt(indeks);
                PrikazTerminaLekara.Termini.Insert(indeks, novi);
            }

            return true;
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
        //OVO SU NOVE METODE ZA DIREKTNO CITANJE IZ DATOTEKE KOJE SVI TREBA DA KORISTE

        public List<Termin> DobaviSveSlobodneTermine()
        {
            return slobodniTerminiServis.DobaviSveSlobodneTermine();
        }
        public  List<Termin> DobaviSveZakazaneTermine()
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

        public Termin DobaviSlobodanTerminPoId(String idTermina)
        {
            return slobodniTerminiServis.PretraziPoId(idTermina);
        }

        public Termin DobaviZakazanTerminPoId(String idTermina)
        {
            return PretraziPoId("//ArrayOfTermin/Termin[IdTermina='" + idTermina + "']");
        }
        public void ObrisiZakazanTermin(Termin terminZaBrisanje)
        {
            ObrisiObjekat("//ArrayOfTermin/Termin[IdTermina='" + terminZaBrisanje.IdTermina + "']");
        }
        public void ObrisiSlobodanTermin(Termin terminZaBrisanje)
        {
            slobodniTerminiServis.UkloniSlobodanTermin(terminZaBrisanje);
        }
        public void SacuvajSlobodanTermin(Termin terminZaUpis)
        {
            slobodniTerminiServis.DodajSlobodanTerminZaPregled(terminZaUpis);
        }
        public void SacuvajZakazanTermin(Termin terminZaUpis)
        {
            DodajObjekat(terminZaUpis);
        }

        public void ZakaziPregled(Termin termin)
        {
            SacuvajZakazanTermin(termin);
            ObrisiSlobodanTermin(termin);
        }

        public void OtkaziPregledPacijent(String idTermina)
        {
            Termin t = DobaviZakazanTerminPoId(idTermina);
            ObrisiZakazanTermin(t);
            t.Pacijent = null;
            SacuvajSlobodanTermin(t);
            DetektujZloupotrebuSistema(PacijentGlavniProzor.ulogovani);
        }
        public static bool DetektujZloupotrebuSistema(Pacijent pacijent)
        {
            int broj = pacijent.ZloupotrebioSistem + 1;
            pacijent.ZloupotrebioSistem = broj;
            if (pacijent.ZloupotrebioSistem > 5)
            {
                pacijent.Blokiran = true;
                return true;
            }
            return false;

        }

        public void PomeriPregledPacijent(String idTermina)
        {
            Termin stari = PretraziPoId(PrikazRasporedaPacijent.TerminZaPomeranje.IdTermina);
            PretraziPoId(PrikazRasporedaPacijent.TerminZaPomeranje.IdTermina).Pacijent = null;
            Termin noviTermin = slobodniTerminiServis.PretraziPoId(idTermina);
            noviTermin.Pacijent = naloziPacijenataServis.PretraziPoId(PacijentGlavniProzor.ulogovani.KorisnickoIme);
            ZameniTermine(stari,noviTermin);
            DetektujZloupotrebuSistema(PacijentGlavniProzor.ulogovani);
        }

        public void ZameniTermine(Termin stariTermin, Termin noviTermin)
        {
            SacuvajSlobodanTermin(stariTermin);
            SacuvajZakazanTermin(noviTermin);
            ObrisiSlobodanTermin(noviTermin);
            ObrisiZakazanTermin(stariTermin);
        }

      

    }
}

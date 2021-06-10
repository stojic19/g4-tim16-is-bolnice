using Bolnica;
using Bolnica.Model;
using Bolnica.Repozitorijum;
using Bolnica.Repozitorijum.Interfejsi;
using Bolnica.Sekretar.Pregled;
using Bolnica.Servis;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Model
{
    public class ZakazaniTerminiServis
    {
        ZakazaniTerminiRepozitorijum zakazaniTerminiRepozitorijum = new ZakazaniTerminiRepozitorijum();
        SlobodniTerminiServis slobodniTerminiServis = new SlobodniTerminiServis();
        NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();
        ObavestenjaServis obavestenjaServis = new ObavestenjaServis();

        public List<Termin> PretraziPoLekaru(string korisnickoIme)
        {
            return zakazaniTerminiRepozitorijum.PretraziPoLekaru(korisnickoIme);
        }

        public void OtkaziPregledSekretar(string terminZaOtkazivanje)
        {
            Termin termin = DobaviZakazanTerminPoId(terminZaOtkazivanje);
            termin.Pacijent = null;
            slobodniTerminiServis.DodajSlobodanTerminZaPregled(termin);
            zakazaniTerminiRepozitorijum.ObrisiZakazanTermin(terminZaOtkazivanje);
        }

        public Boolean OtkaziTerminLekar(string idTermina)
        {
            Termin terminZaBrisanje = DobaviZakazanTerminPoId(idTermina);
            slobodniTerminiServis.DodajSlobodanTerminZaPregled(terminZaBrisanje);
            return zakazaniTerminiRepozitorijum.OtkaziTerminLekar(idTermina);
        }

        public Boolean ZakaziTerminLekar(Termin termin)
        {
            zakazaniTerminiRepozitorijum.DodajObjekat(termin);
            slobodniTerminiServis.Ukloni(termin);
            return zakazaniTerminiRepozitorijum.DaLiPostojiTermin(termin);

        }

        public Termin DobaviZakazanTerminPoId(string idTermina)
        {
            return zakazaniTerminiRepozitorijum.PretraziPoId("//ArrayOfTermin/Termin[IdTermina='" + idTermina + "']");
        }

        public void IzmeniTermin(Termin stariTermin, Termin noviTermin)
        {
            noviTermin = KopirajPodatke(stariTermin, noviTermin);
            stariTermin.Trajanje = 30;
            stariTermin.Pacijent = null;
            zakazaniTerminiRepozitorijum.ObrisiZakazanTermin(stariTermin.IdTermina);
            slobodniTerminiServis.DodajSlobodanTerminZaPregled(stariTermin);
            ZakaziTerminLekar(noviTermin);
        }

        public Termin KopirajPodatke(Termin stari, Termin novi)
        {
            novi.Lekar = stari.Lekar;
            novi.Pacijent = stari.Pacijent;
            return novi;
        }

        public List<Termin> DobaviSveZakazaneTermine()
        {
            return zakazaniTerminiRepozitorijum.DobaviSveZakazaneTermine();
        }

        public List<Termin> DobaviSveZakazaneTerminePacijenta(String pacijentKorisnickoIme)
        {
            List<Termin> terminiPacijenta = new List<Termin>();
            foreach (Termin termin in zakazaniTerminiRepozitorijum.DobaviSveZakazaneTerminePacijenta(pacijentKorisnickoIme))
            {
                if (TerminJeUBuducnosti(termin))
                    terminiPacijenta.Add(termin);
            }
            return terminiPacijenta;
        }
        private bool TerminJeUBuducnosti(Termin termin)
        {
            if (DateTime.Compare(DateTime.Now,termin.Datum) < 0)
                return true;
            return false;
        }
        public void OtkaziPregledPacijent(Termin terminZaOtkazivanje)
        {
            naloziPacijenataServis.IzmeniStanjeNalogaPacijenta(terminZaOtkazivanje.Pacijent);
            zakazaniTerminiRepozitorijum.ObrisiZakazanTermin(terminZaOtkazivanje.IdTermina);
            terminZaOtkazivanje.Pacijent = null;
            terminZaOtkazivanje.Prostor = null;
            slobodniTerminiServis.DodajSlobodanTerminZaPregled(terminZaOtkazivanje);
        }


        public void PomeriPregledPacijent(Termin stariTermin, Termin noviTermin)
        {
            noviTermin.Pacijent = stariTermin.Pacijent;
            stariTermin.Pacijent = null;
            stariTermin.Prostor = null;
            ZameniTermine(stariTermin, noviTermin);
            naloziPacijenataServis.IzmeniStanjeNalogaPacijenta(noviTermin.Pacijent);
            obavestenjaServis.DodajObavestenjeOPomerenomPregledu(noviTermin, stariTermin);
        }

        public void ZameniTermine(Termin stariTermin, Termin noviTermin)
        {
            slobodniTerminiServis.DodajSlobodanTerminZaPregled(stariTermin);
            zakazaniTerminiRepozitorijum.DodajObjekat(noviTermin);
            slobodniTerminiServis.Ukloni(noviTermin);
            zakazaniTerminiRepozitorijum.ObrisiZakazanTermin(stariTermin.IdTermina);
        }


        public bool ProveriMogucnostPomeranjaDatum(DateTime datumPregleda)
        {
            if (DateTime.Compare(DateTime.Now.AddDays(1).Date, datumPregleda.Date) == 0)
                return true;
            return false;
        }

        public bool ProveriMogucnostPomeranjaVreme(String vreme)
        {
            DateTime vremePregleda = KonverzijaPocetnogVremena(vreme);
            if (!SatPregledaJeRanijiOdSadasnjegSata(vremePregleda)) return false;
            else if (!SatPregledaJeJednakSadasnjemSatu(vremePregleda) && !MinutPregledaJeJednakSasanjemMinutu(vremePregleda)) return false;
            else if (!SatPregledaJeJednakSadasnjemSatu(vremePregleda) && !MinutPregledaJeKasnijiOdSadasnjeg(vremePregleda)) return false;
            return true;
        }

        private DateTime KonverzijaPocetnogVremena(String vremePregleda)
        {
            return DateTime.ParseExact(vremePregleda, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        }

        private bool SatPregledaJeRanijiOdSadasnjegSata(DateTime vremePregleda)
        {
            if (vremePregleda.Hour < DateTime.Now.Hour)
                return false;
            return true;
        }
        private bool SatPregledaJeJednakSadasnjemSatu(DateTime vremePregleda)
        {
            if (vremePregleda.Hour == DateTime.Now.Hour)
                return false;
            return true;

        }

        private bool MinutPregledaJeJednakSasanjemMinutu(DateTime vremePregleda)
        {
            if (DateTime.Now.Minute == vremePregleda.Minute)
                return false;
            return true;
        }
        private bool MinutPregledaJeKasnijiOdSadasnjeg(DateTime vremePregleda)
        {
            if (DateTime.Now.Minute > vremePregleda.Minute)
                return false;
            return true;
        }


        public void ZakaziPregled(Termin termin, String korisnickoImePacijenta)
        {
            termin.Pacijent = naloziPacijenataServis.PretraziPoId(korisnickoImePacijenta);
            zakazaniTerminiRepozitorijum.DodajObjekat(termin);
            slobodniTerminiServis.Ukloni(termin);
            obavestenjaServis.DodajObavestenjeOZakazanomPregledu(korisnickoImePacijenta, termin);
        }

    }
}
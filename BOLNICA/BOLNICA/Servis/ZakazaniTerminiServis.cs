using Bolnica;
using Bolnica.Model;
using Bolnica.Repozitorijum;
using Bolnica.Repozitorijum.Factory;
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
        ZakazaniTerminiRepozitorijumInterfejs zakazaniTerminiRepozitorijum = ZakazaniTerminiFactory.DobaviRepozitorijum();
        SlobodniTerminiServis slobodniTerminiServis = new SlobodniTerminiServis();
        NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();
        ObavestenjaServis obavestenjaServis = new ObavestenjaServis();
        DatumTerminaServis datumServis = new DatumTerminaServis();

        public List<Termin> DobaviSveZakazaneTermine()
        {
            return zakazaniTerminiRepozitorijum.DobaviSveZakazaneTermine();
        }
        public Termin DobaviZakazanTerminPoId(string idTermina)
        {
            return zakazaniTerminiRepozitorijum.DobaviZakazanTerminPoId(idTermina);
        }

        public List<Termin> DobaviSveZakazaneTerminePacijenta(String pacijentKorisnickoIme)
        {
            List<Termin> terminiPacijenta = new List<Termin>();
            foreach (Termin termin in zakazaniTerminiRepozitorijum.DobaviSveZakazaneTerminePacijenta(pacijentKorisnickoIme))
            {
                if (datumServis.TerminJeUBuducnosti(termin.Datum)) terminiPacijenta.Add(termin);
            }
            return terminiPacijenta;
        }
      
        public void OtkaziPregledPacijent(Termin terminZaOtkazivanje)
        {
            naloziPacijenataServis.IzmeniStanjeNalogaPacijenta(terminZaOtkazivanje.Pacijent);
            zakazaniTerminiRepozitorijum.ObrisiZakazanTermin(terminZaOtkazivanje.IdTermina);
            terminZaOtkazivanje.Pacijent = null;
            terminZaOtkazivanje.Prostor = null;
            slobodniTerminiServis.Dodaj(terminZaOtkazivanje);
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
            slobodniTerminiServis.Dodaj(stariTermin);
            zakazaniTerminiRepozitorijum.DodajObjekat(noviTermin);
            slobodniTerminiServis.Ukloni(noviTermin);
            zakazaniTerminiRepozitorijum.ObrisiZakazanTermin(stariTermin.IdTermina);
        }

        public void ZakaziPregled(Termin termin, String korisnickoImePacijenta)
        {
            termin.Pacijent = naloziPacijenataServis.PretraziPoId(korisnickoImePacijenta);
            zakazaniTerminiRepozitorijum.DodajObjekat(termin);
            slobodniTerminiServis.Ukloni(termin);
            obavestenjaServis.DodajObavestenjeOZakazanomPregledu(korisnickoImePacijenta, termin);
        }
        public void OtkaziPregledSekretar(string terminZaOtkazivanje)
        {
            Termin termin = DobaviZakazanTerminPoId(terminZaOtkazivanje);
            termin.Pacijent = null;
            slobodniTerminiServis.Dodaj(termin);
            zakazaniTerminiRepozitorijum.ObrisiZakazanTermin(terminZaOtkazivanje);
        }


        public Boolean OtkaziTerminLekar(string idTermina)
        {
            Termin terminZaBrisanje = DobaviZakazanTerminPoId(idTermina);
            slobodniTerminiServis.DodajSledece(terminZaBrisanje);
            slobodniTerminiServis.Dodaj(terminZaBrisanje);
            return zakazaniTerminiRepozitorijum.OtkaziTerminLekar(idTermina);
        }

        public Boolean ZakaziTerminLekar(Termin termin)
        {
            zakazaniTerminiRepozitorijum.DodajObjekat(termin);
            slobodniTerminiServis.UkloniSledece(termin);
            slobodniTerminiServis.Ukloni(termin);
            return zakazaniTerminiRepozitorijum.DaLiPostojiTermin(termin);

        }

        public void IzmeniTermin(Termin stariTermin, Termin noviTermin)
        {
            noviTermin = KopirajPodatke(stariTermin, noviTermin);
            stariTermin.Pacijent = null;
            ZakaziTerminLekar(noviTermin);
            OtkaziTerminLekar(stariTermin.IdTermina);
        }

        public Termin KopirajPodatke(Termin stari, Termin novi)
        {
            novi.Lekar = stari.Lekar;
            novi.Pacijent = stari.Pacijent;
            return novi;
        }


        public List<Termin> DobaviZakazaneTermineLekara(string korisnickoIme)
        {
            return zakazaniTerminiRepozitorijum.PretraziPoLekaru(korisnickoIme);
        }

    }
}
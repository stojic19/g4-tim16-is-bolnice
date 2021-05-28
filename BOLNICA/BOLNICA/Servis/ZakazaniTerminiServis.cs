using Bolnica;
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
        SlobodniTerminiServis slobodniTerminiServis = new SlobodniTerminiServis();
        NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();
        private ZakazaniTerminiRepozitorijumInterfejs zakazaniTerminiRepozitorijum = new ZakazaniTerminiRepozitorijum();
        LekariServis lekariServis = new LekariServis();

        public List<Termin> PretraziPoLekaru(string korisnickoIme)
        {
            return zakazaniTerminiRepozitorijum.PretraziPoLekaru(korisnickoIme);
        }

        public void OtkaziPregledSekretar(string terminZaOtkazivanje)
        {
            zakazaniTerminiRepozitorijum.OtkaziPregledSekretar(terminZaOtkazivanje);
        }

        public void OtkaziTermin(string idTermina)
        {
            zakazaniTerminiRepozitorijum.OtkaziTermin(idTermina);
        }

        public void ZakaziTermin(Termin termin, string korisnickoIme)
        {
            zakazaniTerminiRepozitorijum.ZakaziTermin(termin, korisnickoIme);
        }

        public Termin PretraziZakazanePoId(string idTermina)
        {
            return zakazaniTerminiRepozitorijum.PretraziPoId(idTermina);
        }

        public void IzmeniTermin(Termin stariTermin, Termin noviTermin, string korisnik)
        {
            zakazaniTerminiRepozitorijum.IzmeniTermin(stariTermin, noviTermin, korisnik);
        }

      
        public List<Termin> DobaviSveZakazaneTermine()
        {
            return zakazaniTerminiRepozitorijum.DobaviSveZakazaneTermine();
        }

        public List<Termin> DobaviSveZakazaneTerminePacijenta(String pacijentKorisnickoIme)
        {
            return zakazaniTerminiRepozitorijum.DobaviSveZakazaneTerminePacijenta(pacijentKorisnickoIme);
        }

        public void OtkaziPregledPacijent(Termin terminZaOtkazivanje)
        {
            naloziPacijenataServis.IzmeniStanjeNalogaPacijenta(terminZaOtkazivanje.Pacijent);
            zakazaniTerminiRepozitorijum.ObrisiZakazanTermin(terminZaOtkazivanje);
            terminZaOtkazivanje.Pacijent = null;
            slobodniTerminiServis.DodajSlobodanTerminZaPregled(terminZaOtkazivanje);
        }


        public void PomeriPregledPacijent(Termin stariTermin,Termin noviTermin)
        {
            noviTermin.Pacijent = stariTermin.Pacijent;
            stariTermin.Pacijent = null;
            ZameniTermine(stariTermin, noviTermin);
            naloziPacijenataServis.IzmeniStanjeNalogaPacijenta(noviTermin.Pacijent);
        }

        public void ZameniTermine(Termin stariTermin, Termin noviTermin)
        {
            slobodniTerminiServis.DodajSlobodanTerminZaPregled(stariTermin);
            zakazaniTerminiRepozitorijum.DodajObjekat(noviTermin);
            slobodniTerminiServis.UkloniSlobodanTermin(noviTermin);
            zakazaniTerminiRepozitorijum.ObrisiZakazanTermin(stariTermin);
        }
       

        public bool ProveriMogucnostPomeranjaDatum(DateTime datumPregleda)
        {
            if (DateTime.Compare(DateTime.Now.AddDays(1).Date, datumPregleda.Date) == 0)
                return true;
            return false;
        }

        public bool ProveriMogucnostPomeranjaVreme(String vreme)
        {
            DateTime vremePregleda = DateTime.ParseExact(vreme, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            if (vremePregleda.Hour < DateTime.Now.Hour)
                return false;
            else if (vremePregleda.Hour == DateTime.Now.Hour && DateTime.Now.Minute == vremePregleda.Minute)
                return false;
            else if (vremePregleda.Hour == DateTime.Now.Hour && DateTime.Now.Minute > vremePregleda.Minute)
                return false;
            return true;
        }


         public void ZakaziPregled(Termin termin,String korisnickoImePacijenta)
        {
            termin.Pacijent = naloziPacijenataServis.PretraziPoId(korisnickoImePacijenta);
            zakazaniTerminiRepozitorijum.SacuvajZakazanTermin(termin);
            slobodniTerminiServis.UkloniSlobodanTermin(termin);
        }
    }
}
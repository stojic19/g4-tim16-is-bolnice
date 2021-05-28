using Bolnica.Servis;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Kontroler
{
    public class TerminKontroler
    {
        private ZakazaniTerminiServis zakazaniTerminiServis=new ZakazaniTerminiServis();
        private SlobodniTerminiServis slobodniTerminiServis=new SlobodniTerminiServis();
        public List<Termin> DobaviSveSlobodneTermine()
        {
            return slobodniTerminiServis.DobaviSveSlobodneTermine();
        }
        public List<Termin> DobaviSveZakazaneTermine()
        {
            return zakazaniTerminiServis.DobaviSveZakazaneTermine();
        }

        public List<Termin> DobaviSveZakazaneTerminePacijenta(String pacijentKorisnickoIme)
        {
            return zakazaniTerminiServis.DobaviSveZakazaneTerminePacijenta(pacijentKorisnickoIme);
        }


        public Termin DobaviSlobodanTerminPoId(String idTermina)
        {
            return slobodniTerminiServis.PretraziPoId(idTermina);
        }

        public Termin DobaviZakazanTerminPoId(String idTermina)
        {
            return zakazaniTerminiServis.PretraziZakazanePoId(idTermina);
        }

        public List<Termin> PretraziPoLekaru(string korisnickoIme)
        {
            return zakazaniTerminiServis.PretraziPoLekaru(korisnickoIme);
        }

        public void ZakaziPregled(Termin termin,String korisnickoImePacijenta)
        {
          //  slobodniTerminiServis.ZakaziPregled(termin, korisnickoImePacijenta);
        }

        public void OtkaziPregledPacijent(Termin termin)
        {
            zakazaniTerminiServis.OtkaziPregledPacijent(termin);
        }

        public void PomeriPregledPacijent(Termin stariTermin,Termin noviTermin)
        {
            zakazaniTerminiServis.PomeriPregledPacijent(stariTermin, noviTermin);
        }

        public void OtkaziPregledSekretar(string terminZaOtkazivanje)
        {
            zakazaniTerminiServis.OtkaziPregledSekretar(terminZaOtkazivanje);
        }

        public List<Termin> PretraziPoLekaruUIntervalu(List<Termin> terminiUIntervalu, String korisnickoImeLekara)
        {
            return slobodniTerminiServis.PretraziPoLekaruUIntervalu(terminiUIntervalu, korisnickoImeLekara);
        }

        public List<Termin> NadjiTermineUIntervalu(DateTime pocetakIntervala, DateTime krajIntervala)
        {
            return slobodniTerminiServis.NadjiTermineUIntervalu(pocetakIntervala, krajIntervala);
        }

        public bool ProveriMogucnostPomeranjaDatum(DateTime datumPregleda)
        {
            return zakazaniTerminiServis.ProveriMogucnostPomeranjaDatum(datumPregleda);
        }

        public void OtkaziTermin(string idTermina)
        {
            zakazaniTerminiServis.OtkaziTermin(idTermina);
        }

        public bool ProveriMogucnostPomeranjaVreme(String vreme)
        {
            return zakazaniTerminiServis.ProveriMogucnostPomeranjaVreme(vreme);
        }

        public List<Termin> NadjiVremeTermina(Termin izabraniTermin)
        {
            return slobodniTerminiServis.NadjiVremeTermina(izabraniTermin);
        }

        public void ZakaziTermin(Termin termin, string korisnickoIme)
        {
            zakazaniTerminiServis.ZakaziTermin(termin, korisnickoIme);
        }

        public Termin PretraziPoId(string idTermina)
        {
            return zakazaniTerminiServis.PretraziZakazanePoId(idTermina);
        }

        public void IzmeniTermin(Termin stariTermin, Termin noviTermin, string korisnik)
        {
            zakazaniTerminiServis.IzmeniTermin(stariTermin, noviTermin, korisnik);
        }
    }
}

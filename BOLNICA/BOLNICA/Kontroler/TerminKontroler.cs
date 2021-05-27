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
        private TerminiServis terminiServis=new TerminiServis();
        public List<Termin> DobaviSveSlobodneTermine()
        {
            return terminiServis.DobaviSveSlobodneTermine();
        }
        public List<Termin> DobaviSveZakazaneTermine()
        {
            return terminiServis.DobaviSveZakazaneTermine();
        }

        public List<Termin> DobaviSveZakazaneTerminePacijenta(String pacijentKorisnickoIme)
        {
            return terminiServis.DobaviSveZakazaneTerminePacijenta(pacijentKorisnickoIme);
        }


        public Termin DobaviSlobodanTerminPoId(String idTermina)
        {
            return terminiServis.DobaviSlobodanTerminPoId(idTermina);
        }

        public Termin DobaviZakazanTerminPoId(String idTermina)
        {
            return terminiServis.DobaviZakazanTerminPoId(idTermina);
        }

        public Termin PretraziSlobodnePoId(string idTermina)
        {
            return terminiServis.PretraziSlobodnePoId(idTermina);
        }

        public List<Termin> PretraziPoLekaru(string korisnickoIme)
        {
            return terminiServis.PretraziPoLekaru(korisnickoIme);
        }

        public void ZakaziPregled(Termin termin)
        {
            terminiServis.ZakaziPregled(termin);
        }

        public void OtkaziPregledPacijent(String idTermina)
        {
            terminiServis.OtkaziPregledPacijent(idTermina);
        }

        public void PomeriPregledPacijent(String idTermina)
        {
            terminiServis.PomeriPregledPacijent(idTermina);
        }

        public void OtkaziPregledSekretar(string terminZaOtkazivanje)
        {
            terminiServis.OtkaziPregledSekretar(terminZaOtkazivanje);
        }

        public List<Termin> PretraziPoLekaruUIntervalu(List<Termin> terminiUIntervalu, String korisnickoImeLekara)
        {
            return terminiServis.PretraziPoLekaruUIntervalu(terminiUIntervalu, korisnickoImeLekara);
        }

        public List<Termin> NadjiTermineUIntervalu(DateTime pocetakIntervala, DateTime krajIntervala)
        {
            return terminiServis.NadjiTermineUIntervalu(pocetakIntervala, krajIntervala);
        }

        public bool ProveriMogucnostPomeranjaDatum(DateTime datumPregleda)
        {
            return terminiServis.ProveriMogucnostPomeranjaDatum(datumPregleda);
        }

        public void OtkaziTermin(string idTermina)
        {
            terminiServis.OtkaziTermin(idTermina);
        }

        public bool ProveriMogucnostPomeranjaVreme(String vreme)
        {
            return terminiServis.ProveriMogucnostPomeranjaVreme(vreme);
        }

        public List<Termin> NadjiVremeTermina(Termin izabraniTermin)
        {
            return terminiServis.NadjiVremeTermina(izabraniTermin);
        }

        public void ZakaziTermin(Termin termin, string korisnickoIme)
        {
            terminiServis.ZakaziTermin(termin, korisnickoIme);
        }

        public Termin PretraziPoId(string idTermina)
        {
            return terminiServis.PretraziPoId(idTermina);
        }

        public void IzmeniTermin(Termin stariTermin, Termin noviTermin, string korisnik)
        {
            terminiServis.IzmeniTermin(stariTermin, noviTermin, korisnik);
        }
    }
}

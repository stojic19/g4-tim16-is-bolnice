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

        public void ZakaziPregledPacijent(Termin termin)
        {
            terminiServis.ZakaziPregledPacijent(termin);
        }

        public void OtkaziPregledPacijent(String idTermina)
        {
            terminiServis.OtkaziPregledPacijent(idTermina);
        }

        public void PomeriPregledPacijent(String idTermina)
        {
            terminiServis.PomeriPregledPacijent(idTermina);
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

        public bool ProveriMogucnostPomeranjaVreme(String vreme)
        {
            return terminiServis.ProveriMogucnostPomeranjaVreme(vreme);
        }

        public List<Termin> NadjiVremeTermina(Termin izabraniTermin)
        {
            return terminiServis.NadjiVremeTermina(izabraniTermin);
        }

      
    }
}

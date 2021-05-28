using Bolnica.DTO;
using Bolnica.Konverter;
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
        private TerminKonverter terminKonverter = new TerminKonverter();
        public List<Termin> DobaviSveSlobodneTermine()
        {
            return slobodniTerminiServis.DobaviSveSlobodneTermine();
        }
        public List<Termin> DobaviSveZakazaneTermine()
        {
            return zakazaniTerminiServis.DobaviSveZakazaneTermine();
        }

        public List<TerminDTO> DobaviSveZakazaneTerminePacijenta(String korisnickoIme)
        {
            List<TerminDTO> terminiPacijenta = new List<TerminDTO>();
            foreach (Termin termin in zakazaniTerminiServis.DobaviSveZakazaneTerminePacijenta(korisnickoIme))
                terminiPacijenta.Add(terminKonverter.ZakazaniTerminModelUDTO(termin, korisnickoIme));
            return terminiPacijenta;
        }


        public Termin DobaviSlobodanTerminPoId(String idTermina)
        {
            return slobodniTerminiServis.PretraziPoId(idTermina);
        }

        public Termin DobaviZakazanTerminPoId(String idTermina)
        {
            return zakazaniTerminiServis.DobaviZakazanTerminPoId(idTermina);
        }

        public List<Termin> PretraziPoLekaru(string korisnickoIme)
        {
            return zakazaniTerminiServis.PretraziPoLekaru(korisnickoIme);
        }

        public void ZakaziPregled(TerminDTO termin,String korisnickoImePacijenta)
        {
            Termin noviTermin=slobodniTerminiServis.PretraziPoId(termin.IdTermina);
            zakazaniTerminiServis.ZakaziPregled(noviTermin, korisnickoImePacijenta);
        }

        public void OtkaziPregledPacijent(TerminDTO termin)
        {
           
            Termin terminZaOtkazivanje = DobaviZakazanTerminPoId(termin.IdTermina);
            zakazaniTerminiServis.OtkaziPregledPacijent(terminZaOtkazivanje);
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

        public List<TerminDTO> NadjiTermineUIntervalu(DateTime pocetakIntervala, DateTime krajIntervala)
        {
            List<TerminDTO> termini = new List<TerminDTO>();
            List<Termin> terminiUIntervalu = slobodniTerminiServis.NadjiTermineUIntervalu(pocetakIntervala, krajIntervala);
            foreach (Termin termin in terminiUIntervalu)
                termini.Add(terminKonverter.SlobodniTerminModelUDTO(termin));


            Console.WriteLine("SERVIIIIIIIIIIIIIIIIIIIIIIIS" + terminiUIntervalu.Count);
            Console.WriteLine("KONTOLREEEEEEEEEEEEEEEER" + termini.Count);
            return termini;
        }
        public List<Termin> NadjiTermineUIntervaluSekretar(DateTime pocetakIntervala, DateTime krajIntervala)
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

        public List<TerminDTO> NadjiVremeTermina(TerminDTO izabraniTermin)
        {
            List<TerminDTO> vremenaTermina = new List<TerminDTO>();
            Termin terminIzabrani=slobodniTerminiServis.PretraziPoId(izabraniTermin.IdTermina);
            foreach (Termin termin in slobodniTerminiServis.NadjiVremeTermina(terminIzabrani))
                vremenaTermina.Add(terminKonverter.SlobodniTerminModelUDTO(termin));
            return vremenaTermina;
        }

        public void ZakaziTermin(Termin termin, string korisnickoIme)
        {
            zakazaniTerminiServis.ZakaziTermin(termin, korisnickoIme);
        }

        public Termin PretraziPoId(string idTermina)
        {
            return zakazaniTerminiServis.DobaviZakazanTerminPoId(idTermina);
        }

        public void IzmeniTermin(Termin stariTermin, Termin noviTermin, string korisnik)
        {
            zakazaniTerminiServis.IzmeniTermin(stariTermin, noviTermin, korisnik);
        }
        public List<TerminDTO> DobaviSlobodneTermineZaZakazivanje(List<DateTime> interval, String lekar)
        {
            List<TerminDTO> termini = new List<TerminDTO>();
            foreach (Termin termin in slobodniTerminiServis.DobaviSlobodneTermineZaZakazivanje(interval, lekar))
                termini.Add(terminKonverter.SlobodniTerminModelUDTO(termin));
            return termini;
        }
    }
}

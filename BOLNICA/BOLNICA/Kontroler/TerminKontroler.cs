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
        private ZakazaniTerminiServis zakazaniTerminiServis = new ZakazaniTerminiServis();
        private SlobodniTerminiServis slobodniTerminiServis = new SlobodniTerminiServis();
        private TerminKonverter terminKonverter = new TerminKonverter();
        LekariServis lekariServis = new LekariServis();
        NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();


        public List<TerminDTO> DobaviSveSlobodneTermine()
        {
            List<TerminDTO> termini = new List<TerminDTO>();
            foreach (Termin termin in slobodniTerminiServis.DobaviSveSlobodneTermine())
                termini.Add(terminKonverter.SlobodniTerminModelUDTO(termin));
            return termini;
        }
        public List<TerminDTO> DobaviSveZakazaneTermine()
        {
            List<TerminDTO> termini = new List<TerminDTO>();
            foreach (Termin termin in zakazaniTerminiServis.DobaviSveZakazaneTermine())
                termini.Add(terminKonverter.ZakazaniTerminModelUDTO(termin, termin.Pacijent.KorisnickoIme));
            return termini;
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

        public TerminDTO DobaviZakazanTerminDTO(String idTermina, String lekar)
        {
            Termin t = zakazaniTerminiServis.DobaviZakazanTerminPoId(idTermina);
            return terminKonverter.ZakazaniTerminModelUDTO(t, lekar);
        }

        public List<TerminDTO> PretraziPoLekaru(string korisnickoIme)
        {
            List<TerminDTO> terminiDTO = new List<TerminDTO>();

            foreach (Termin termin in zakazaniTerminiServis.PretraziPoLekaru(korisnickoIme))
            {
                terminiDTO.Add(terminKonverter.ZakazaniTerminModelUDTO(termin, korisnickoIme));
            }
            return terminiDTO;

        }

        public void ZakaziPregledPacijent(TerminDTO termin, String korisnickoImePacijenta)
        {
            Termin noviTermin = slobodniTerminiServis.PretraziPoId(termin.IdTermina);
            zakazaniTerminiServis.ZakaziPregled(noviTermin, korisnickoImePacijenta);
        }

        public void OtkaziPregledPacijent(TerminDTO termin)
        {
            Termin terminZaOtkazivanje = DobaviZakazanTerminPoId(termin.IdTermina);
            zakazaniTerminiServis.OtkaziPregledPacijent(terminZaOtkazivanje);
        }

        public void PomeriPregledPacijent(TerminDTO stariTermin, TerminDTO noviTermin)
        {
            Termin stari = zakazaniTerminiServis.DobaviZakazanTerminPoId(stariTermin.IdTermina);
            Termin novi = slobodniTerminiServis.PretraziPoId(noviTermin.IdTermina);
            zakazaniTerminiServis.PomeriPregledPacijent(stari, novi);
        }

        public void OtkaziPregledSekretar(string terminZaOtkazivanje)
        {
            zakazaniTerminiServis.OtkaziPregledSekretar(terminZaOtkazivanje);
        }

        public List<TerminDTO> PretraziPoLekaruUIntervalu(List<Termin> terminiUIntervalu, String korisnickoImeLekara)
        {
            List<TerminDTO> termini = new List<TerminDTO>();
            foreach (Termin termin in slobodniTerminiServis.PretraziPoLekaruUIntervalu(terminiUIntervalu, korisnickoImeLekara))
                termini.Add(terminKonverter.SlobodniTerminModelUDTO(termin));
            return termini;
        }

        public List<TerminDTO> NadjiTermineUIntervalu(DateTime pocetakIntervala, DateTime krajIntervala)
        {
            List<TerminDTO> termini = new List<TerminDTO>();
            List<Termin> terminiUIntervalu = slobodniTerminiServis.NadjiTermineUIntervalu(pocetakIntervala, krajIntervala);
            foreach (Termin termin in terminiUIntervalu)
                termini.Add(terminKonverter.SlobodniTerminModelUDTO(termin));
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

        public Boolean OtkaziTerminLekar(string idTermina)
        {
            return zakazaniTerminiServis.OtkaziTerminLekar(idTermina);
        }

        public bool ProveriMogucnostPomeranjaVreme(String vreme)
        {
            return zakazaniTerminiServis.ProveriMogucnostPomeranjaVreme(vreme);
        }

        public List<TerminDTO> NadjiVremeTermina(TerminDTO izabraniTermin)
        {
            List<TerminDTO> vremenaTermina = new List<TerminDTO>();
            Termin terminIzabrani = slobodniTerminiServis.PretraziPoId(izabraniTermin.IdTermina);
            foreach (Termin termin in slobodniTerminiServis.NadjiVremeTermina(terminIzabrani))
                vremenaTermina.Add(terminKonverter.SlobodniTerminModelUDTO(termin));
            return vremenaTermina;
        }

        public Boolean ZakaziTerminLekar(TerminDTO termin)
        {
            Termin noviTermin = slobodniTerminiServis.PretraziPoId(termin.IdTermina);
            noviTermin.Lekar = lekariServis.PretraziPoId(termin.Lekar.KorisnickoIme);
            noviTermin.Pacijent = naloziPacijenataServis.PretraziPoId(termin.Pacijent.KorisnickoIme);
            noviTermin.Trajanje = termin.TrajanjeDouble;

            return zakazaniTerminiServis.ZakaziTerminLekar(noviTermin);
        }

        public void IzmeniTerminLekar(TerminDTO stariTermin, TerminDTO noviTermin)
        {
            Termin stari = DobaviZakazanTerminPoId(stariTermin.IdTermina);
            Termin novi = DobaviSlobodanTerminPoId(noviTermin.IdTermina);
            zakazaniTerminiServis.IzmeniTermin(stari, novi);
        }
        public List<TerminDTO> DobaviSlobodneTermineZaZakazivanje(List<DateTime> interval, String lekar)
        {
            List<TerminDTO> termini = new List<TerminDTO>();
            foreach (Termin termin in slobodniTerminiServis.DobaviSlobodneTermineZaZakazivanje(interval, lekar))
                termini.Add(terminKonverter.SlobodniTerminModelUDTO(termin));
            return termini;
        }

        public List<TerminDTO> DobaviSveSlobodneDatumeZaPomeranje(TerminDTO terminZaPomeranje, String idLekara)
        {
            Termin terminIzabrani = zakazaniTerminiServis.DobaviZakazanTerminPoId(terminZaPomeranje.IdTermina);
            List<TerminDTO> termini = new List<TerminDTO>();
            foreach (Termin termin in slobodniTerminiServis.DobaviSveSlobodneDatumeZaPomeranje(terminIzabrani, idLekara))
                termini.Add(terminKonverter.SlobodniTerminModelUDTO(termin));
            return termini;
        }

        public List<TerminDTO> DobaviSlobodneTermineLekara(TerminDTO terminZaPoredjenje, String izabranLekar)
        {
            Termin podaci = terminKonverter.PodaciZaSlobodanTermin(terminZaPoredjenje);
            List<TerminDTO> slobodniTermini = new List<TerminDTO>();

            foreach (Termin t in slobodniTerminiServis.DobaviSlobodneTermineLekara(podaci, izabranLekar))
            {
                slobodniTermini.Add(terminKonverter.SlobodniTerminModelUDTO(t));
            }
            return slobodniTermini;
        }
    }
}

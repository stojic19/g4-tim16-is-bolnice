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
    public class SlobodniTerminiKontroler
    {
        TerminKonverter terminKonverter = new TerminKonverter();
        DatumTerminaServis datumTerminaServis = new DatumTerminaServis();
        LekarTerminaServis lekarTerminaServis = new LekarTerminaServis();
        SlobodniTerminiServis slobodniTerminiServis = new SlobodniTerminiServis();
        ZakazaniTerminiServis zakazaniTerminiServis = new ZakazaniTerminiServis();
        public List<TerminDTO> DobaviSveSlobodneTermine()
        {
            List<TerminDTO> termini = new List<TerminDTO>();
            foreach (Termin termin in slobodniTerminiServis.DobaviSve())
                termini.Add(terminKonverter.SlobodniTerminModelUDTO(termin));
            return termini;
        }
        public List<TerminDTO> NadjiTermineUIntervalu(List<DateTime> interval)
        {
            List<TerminDTO> termini = new List<TerminDTO>();
            List<Termin> sviTermini = slobodniTerminiServis.DobaviSve();
            List<Termin> terminiUIntervalu = datumTerminaServis.NadjiTermineUIntervalu(interval, sviTermini);
            foreach (Termin termin in terminiUIntervalu)
                termini.Add(terminKonverter.SlobodniTerminModelUDTO(termin));
            return termini;
        }
        public List<Termin> NadjiTermineUIntervaluSekretar(DateTime pocetakIntervala, DateTime krajIntervala)
        {
            return slobodniTerminiServis.NadjiTermineUIntervaluSekretar(pocetakIntervala, krajIntervala);
        }
        public List<TerminDTO> NadjiVremeTermina(TerminDTO izabraniTermin)
        {
            List<TerminDTO> vremenaTermina = new List<TerminDTO>();
            Termin terminIzabrani = slobodniTerminiServis.PretraziPoId(izabraniTermin.IdTermina);
            foreach (Termin termin in slobodniTerminiServis.NadjiZeljeniTermin(terminIzabrani))
                vremenaTermina.Add(terminKonverter.SlobodniTerminModelUDTO(termin));
            return vremenaTermina;
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
            foreach (Termin termin in slobodniTerminiServis.DobaviSveSlobodneTermineZaPomeranje(terminIzabrani, idLekara))
                termini.Add(terminKonverter.SlobodniTerminModelUDTO(termin));
            return termini;
        }

        public List<TerminDTO> DobaviSlobodneTermineLekara(TerminDTO terminZaPoredjenje, String izabranLekar, int brojTermina)
        {
            Termin podaci = terminKonverter.PodaciZaSlobodanTermin(terminZaPoredjenje);
            List<TerminDTO> slobodniTermini = new List<TerminDTO>();

            foreach (Termin t in slobodniTerminiServis.DobaviSlobodneTermineLekara(podaci, izabranLekar, brojTermina))
            {
                slobodniTermini.Add(terminKonverter.SlobodniTerminModelUDTO(t));
            }
            return slobodniTermini;
        }

        public List<TerminDTO> PretraziPoLekaruUIntervalu(List<Termin> terminiUIntervalu, String korisnickoImeLekara)
        {
            List<TerminDTO> termini = new List<TerminDTO>();
            foreach (Termin termin in lekarTerminaServis.PretraziTerminePoLekaru(terminiUIntervalu, korisnickoImeLekara))
                termini.Add(terminKonverter.SlobodniTerminModelUDTO(termin));
            return termini;
        }

    }
}

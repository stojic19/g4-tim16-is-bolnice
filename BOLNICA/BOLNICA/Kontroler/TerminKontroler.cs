﻿using Bolnica.DTO;
using Bolnica.Konverter;
using Bolnica.Model;
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
        ProstoriServis prostoriServis = new ProstoriServis();
        DatumTerminaServis datumTerminaServis = new DatumTerminaServis();
        LekarTerminaServis lekarTerminaServis = new LekarTerminaServis();
        public List<TerminDTO> DobaviSveSlobodneTermine()
        {
            List<TerminDTO> termini = new List<TerminDTO>();
            foreach (Termin termin in slobodniTerminiServis.DobaviSve())
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

        public TerminDTO DobaviZakazanTerminDTO(String idTermina)
        {
            Termin t = zakazaniTerminiServis.DobaviZakazanTerminPoId(idTermina);
            return terminKonverter.ZakazaniTerminModelUDTO(t, t.Pacijent.KorisnickoIme);
        }

        public List<TerminDTO> PretraziPoLekaru(string korisnickoIme)
        {
            List<TerminDTO> terminiDTO = new List<TerminDTO>();

            foreach (Termin termin in zakazaniTerminiServis.DobaviZakazaneTermineLekara(korisnickoIme))
            {
                terminiDTO.Add(terminKonverter.ZakazaniTerminModelUDTO(termin, termin.Pacijent.KorisnickoIme));
            }
            return terminiDTO.OrderBy(user => user.Datum).ToList();

        }

        public void ZakaziPregledPacijent(TerminDTO termin, String korisnickoImePacijenta)
        {
            Termin noviTermin = slobodniTerminiServis.PretraziPoId(termin.IdTermina);
            noviTermin.Prostor = prostoriServis.DodeliProstorZaTermin(termin.Datum);
            zakazaniTerminiServis.ZakaziPregled(noviTermin, korisnickoImePacijenta);
        }

        public void OtkaziPregledPacijent(TerminDTO termin)
        {
            Termin terminZaOtkazivanje = zakazaniTerminiServis.DobaviZakazanTerminPoId(termin.IdTermina);
            zakazaniTerminiServis.OtkaziPregledPacijent(terminZaOtkazivanje);
        }

        public void PomeriPregledPacijent(TerminDTO stariTermin, TerminDTO noviTermin)
        {
            Termin stari = zakazaniTerminiServis.DobaviZakazanTerminPoId(stariTermin.IdTermina);
            Termin novi = slobodniTerminiServis.PretraziPoId(noviTermin.IdTermina);
            novi.Prostor = prostoriServis.DodeliProstorZaTermin(novi.Datum);
            zakazaniTerminiServis.PomeriPregledPacijent(stari, novi);
        }

        public void OtkaziPregledSekretar(string terminZaOtkazivanje)
        {
            zakazaniTerminiServis.OtkaziPregledSekretar(terminZaOtkazivanje);
        }

        public List<TerminDTO> PretraziPoLekaruUIntervalu(List<Termin> terminiUIntervalu, String korisnickoImeLekara)
        {
            List<TerminDTO> termini = new List<TerminDTO>();
            foreach (Termin termin in lekarTerminaServis.PretraziTerminePoLekaru(terminiUIntervalu, korisnickoImeLekara))
                termini.Add(terminKonverter.SlobodniTerminModelUDTO(termin));
            return termini;
        }

        public List<TerminDTO> NadjiTermineUIntervalu(List<DateTime> interval)
        {
            List<TerminDTO> termini = new List<TerminDTO>();
            List<Termin> sviTermini = slobodniTerminiServis.DobaviSve();
            List<Termin> terminiUIntervalu = datumTerminaServis.NadjiTermineUIntervalu(interval,sviTermini);
            foreach (Termin termin in terminiUIntervalu)
                termini.Add(terminKonverter.SlobodniTerminModelUDTO(termin));
            return termini;
        }

        public bool ProveriMogucnostPomeranjaTermina(TerminDTO terminZaPomeranje)
        {
            return datumTerminaServis.ProveriMogucnostPomeranjaTermina(terminKonverter.ZakazaniTerminDTOUModel(terminZaPomeranje));
        }
        public List<Termin> NadjiTermineUIntervaluSekretar(DateTime pocetakIntervala, DateTime krajIntervala)
        {
            return slobodniTerminiServis.NadjiTermineUIntervaluSekretar(pocetakIntervala, krajIntervala);
        }

        public Boolean OtkaziTerminLekar(string idTermina)
        {
            return zakazaniTerminiServis.OtkaziTerminLekar(idTermina);
        }

        public List<TerminDTO> NadjiVremeTermina(TerminDTO izabraniTermin)
        {
            List<TerminDTO> vremenaTermina = new List<TerminDTO>();
            Termin terminIzabrani = slobodniTerminiServis.PretraziPoId(izabraniTermin.IdTermina);
            foreach (Termin termin in slobodniTerminiServis.NadjiZeljeniTermin(terminIzabrani))
                vremenaTermina.Add(terminKonverter.SlobodniTerminModelUDTO(termin));
            return vremenaTermina;
        }

        public Boolean ZakaziTerminLekar(TerminDTO termin)
        {
            Termin noviTermin = slobodniTerminiServis.PretraziPoId(termin.IdTermina);
            noviTermin.Lekar = lekariServis.PretraziPoId(termin.Lekar.KorisnickoIme);
            noviTermin.Pacijent = naloziPacijenataServis.PretraziPoId(termin.Pacijent.KorisnickoIme);
            noviTermin.Trajanje = termin.TrajanjeDouble;
            if(noviTermin.VrstaTermina == VrsteTermina.operacija)
            {
                noviTermin.Prostor = prostoriServis.DodeliProstorZaOperaciju(noviTermin.Datum);
            }
            else
            {
                noviTermin.Prostor = prostoriServis.DodeliProstorZaTermin(noviTermin.Datum);
            }
            
            return zakazaniTerminiServis.ZakaziTerminLekar(noviTermin);
        }

        public void IzmeniTerminLekar(TerminDTO stariTermin, TerminDTO noviTermin)
        {
            Termin stari = zakazaniTerminiServis.DobaviZakazanTerminPoId(stariTermin.IdTermina);
            Termin novi = slobodniTerminiServis.PretraziPoId(noviTermin.IdTermina);
            novi.Trajanje = noviTermin.TrajanjeDouble;

            if (novi.VrstaTermina == VrsteTermina.operacija)
            {
                novi.Prostor = prostoriServis.DodeliProstorZaOperaciju(novi.Datum);
            }
            else
            {
                novi.Prostor = prostoriServis.DodeliProstorZaTermin(novi.Datum);
            }

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

        public bool ProveriZaOtkazivanje(String izabranTermin)
        {
            Termin termin = zakazaniTerminiServis.DobaviZakazanTerminPoId(izabranTermin);
            return datumTerminaServis.ProveriDatumZaOtkazivanje(termin.Datum);
        }
    }
}

﻿using Bolnica.Interfejsi.Sekretar;
using Bolnica.Model;
using Bolnica.Repozitorijum;
using Bolnica.Repozitorijum.Interfejsi;
using Model;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Servis
{
    public class SlobodniTerminiServis : CRUDInterfejs<Termin>
    {
        SlobodniTerminiRepozitorijumInterfejs slobodniTerminiRepozitorijum = new SlobodniTerminiRepozitorijum();
        DatumTerminaServis datumServis = new DatumTerminaServis();
        LekarTerminaServis lekarTerminaServis = new LekarTerminaServis();

        public List<Termin> DobaviSve()
        {
            ObrisiStareSlobodneTermine();
            return slobodniTerminiRepozitorijum.DobaviSveObjekte();
        }

        public void Ukloni(Termin termin)
        {
            slobodniTerminiRepozitorijum.UkloniTermin(termin);
        }

        public void Dodaj(Termin termin)
        {
            slobodniTerminiRepozitorijum.DodajObjekat(termin);
        }

        public void Izmeni(Termin termin)
        {
            slobodniTerminiRepozitorijum.IzmeniTermin(termin);
        }

        public void ObrisiStareSlobodneTermine()
        {
            List<Termin> termini = slobodniTerminiRepozitorijum.DobaviSveObjekte();
            foreach (Termin termin in termini)
            {
                if (!datumServis.TerminJeUBuducnosti(termin.Datum)) Ukloni(termin);
            }
        }
        public List<Termin> DobaviSlobodneTermineZaLekara(string idLekara)
        {
            ObrisiStareSlobodneTermine();
            return slobodniTerminiRepozitorijum.DobaviSlobodneTerminePoIdLekara(idLekara);
        }

        public List<Termin> DobaviSveSlobodneTermineZaOperacije()
        {
            ObrisiStareSlobodneTermine();
            List<Termin> termini = new List<Termin>();
            foreach (Termin termin in slobodniTerminiRepozitorijum.DobaviSveObjekte())
            {
                if (termin.VrstaTermina == VrsteTermina.operacija) termini.Add(termin);
            }
            return termini;
        }
        public Termin PretraziPoId(String idTermina)
        {
            return slobodniTerminiRepozitorijum.PretraziSlobodnePoId(idTermina);
        }
        public List<Termin> NadjiZeljeniTermin(Termin izabraniTermin)
        {
            List<Termin> termini = new List<Termin>();
            foreach (Termin termin in DobaviSve())
            {
                if (datumServis.DatumiTerminaSuIsti(termin.Datum, izabraniTermin.Datum) &&
                 lekarTerminaServis.LekariTerminaSuIsti(termin.Lekar.KorisnickoIme, izabraniTermin.Lekar.KorisnickoIme))
                    termini.Add(termin);
            }
            return datumServis.SortTerminaPoPocetnomVremenu(termini);
        }

        public List<Termin> DobaviSveSlobodneTermineZaPomeranje(Termin termin, String idLekara)
        {
            List<DateTime> intervalPomeranja = datumServis.PodesiIntervalPomeranjaTermina(termin.Datum);
            List<Termin> datumiUIntervalu = datumServis.NadjiTermineUIntervalu(intervalPomeranja, DobaviSve());
            List<Termin> sviSlobodniDatumi = lekarTerminaServis.PretraziTerminePoLekaru(datumiUIntervalu, idLekara);
            return sviSlobodniDatumi;
        }

        public List<Termin> DobaviSlobodneTermineZaZakazivanje(List<DateTime> intervalZakazivanja, String idLekara)
        {
            List<Termin> sviTermini = DobaviSve();
            List<Termin> terminiIntervala = datumServis.NadjiTermineUIntervalu(intervalZakazivanja, sviTermini);
            List<Termin> terminiIzabranogLekara = lekarTerminaServis.PretraziTerminePoLekaru(terminiIntervala, idLekara);
            return terminiIzabranogLekara;
        }

        public void DodajSledece(Termin terminZaBrisanje)
        {
            Double brojZaDodavanje = terminZaBrisanje.Trajanje / 30;
            brojZaDodavanje--;
            DateTime datum = terminZaBrisanje.Datum;

            for(int j = 0; j < brojZaDodavanje; j++)
            {
                datum =  datum.AddMinutes(30);
                slobodniTerminiRepozitorijum.DodajObjekat(new Termin(Guid.NewGuid().ToString(),terminZaBrisanje.VrstaTermina,datum.ToString("HH:mm"),30,datum,null,null,terminZaBrisanje.Lekar));
            }
        }

        public List<Termin> DobaviSlobodneTermineLekara(Termin terminZaPoredjenje, String izabranLekar, int brojTermina)
        {
            List<Termin> slobodniTermini = slobodniTerminiRepozitorijum.DobaviSlobodneTermineLekara(terminZaPoredjenje, izabranLekar);
            List<Termin> krajnjiTermini = lekarTerminaServis.DobaviSlobodneTermineLekara(slobodniTermini, brojTermina);
            return krajnjiTermini;
        }

        public List<Termin> NadjiTermineUIntervaluSekretar(DateTime pocetakIntervala, DateTime krajIntervala)
        {
            List<Termin> terminiUIntervalu = new List<Termin>();
            foreach (Termin termin in slobodniTerminiRepozitorijum.DobaviSveObjekte())
            {
                if (datumServis.DatumPregledaJeKasnijiOdPocetkaIntervala(termin, pocetakIntervala) &&
                    datumServis.DatumPregledaJeRanijiOdKrajaIntervala(termin, krajIntervala))
                    terminiUIntervalu.Add(termin);
            }
            return terminiUIntervalu;
        }

        public List<Termin> DobaviZaLekaraIDatum(Termin terminZaPoredjenje, String izabranLekar)
        {
            return slobodniTerminiRepozitorijum.DobaviSlobodneTermineLekara(terminZaPoredjenje, izabranLekar);
        }

        public void UkloniSledece(Termin termin)
        {
            Double brojTermina = termin.Trajanje / 30;
            brojTermina--;
            List<Termin> terminiLekara = DobaviZaLekaraIDatum(termin, termin.Lekar.KorisnickoIme);

            for (int i = 0; i < terminiLekara.Count(); i++)
            {
                if (terminiLekara[i].IdTermina.Equals(termin.IdTermina))
                {
                    for (int j = 1; j <= brojTermina; j++)
                    {
                        Ukloni(terminiLekara[i + j]);
                    }
                }
            }
        }
    }
}

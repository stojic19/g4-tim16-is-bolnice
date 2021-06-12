﻿using Model;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Servis
{
    public class DatumTerminaServis
    {

        public List<Termin> SortTerminaPoPocetnomVremenu(List<Termin> nesortiraniTermini)
        {
            return nesortiraniTermini.OrderBy(user => user.Datum.TimeOfDay).ToList();

        }
        public List<Termin> SortTerminaPoDatumu(List<Termin> nesrotiraniDatumi)
        {
            return nesrotiraniDatumi.OrderBy(user => user.Datum.Date).ToList();
        }

        public bool ProveriMogucnostPomeranjaVreme(String vreme)
        {
            DateTime vremePregleda = KonverzijaPocetnogVremena(vreme);
            if (!SatPregledaJeRanijiOdSadasnjegSata(vremePregleda)) return false;
            else if (!SatPregledaJeJednakSadasnjemSatu(vremePregleda) && !MinutPregledaJeJednakSasanjemMinutu(vremePregleda)) return false;
            else if (!SatPregledaJeJednakSadasnjemSatu(vremePregleda) && !MinutPregledaJeKasnijiOdSadasnjeg(vremePregleda)) return false;
            return true;
        }

        public DateTime KonverzijaPocetnogVremena(String vremePregleda)
        {
            return DateTime.ParseExact(vremePregleda, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        }

        private bool SatPregledaJeRanijiOdSadasnjegSata(DateTime vremePregleda)
        {
            if (vremePregleda.Hour < DateTime.Now.Hour)
                return false;
            return true;
        }
        private bool SatPregledaJeJednakSadasnjemSatu(DateTime vremePregleda)
        {
            if (vremePregleda.Hour == DateTime.Now.Hour)
                return false;
            return true;

        }
        private bool MinutPregledaJeJednakSasanjemMinutu(DateTime vremePregleda)
        {
            if (DateTime.Now.Minute == vremePregleda.Minute)
                return false;
            return true;
        }
        private bool MinutPregledaJeKasnijiOdSadasnjeg(DateTime vremePregleda)
        {
            if (DateTime.Now.Minute > vremePregleda.Minute)
                return false;
            return true;
        }
        public bool TerminJeUBuducnosti(DateTime datumTermina)
        {
            if (DateTime.Compare(DateTime.Now, datumTermina) < 0)
                return true;
            return false;
        }
        public bool ProveriMogucnostPomeranjaTermina(Termin terminZaPomeranje)
        {
            if (!TerminJeUBuducnosti(terminZaPomeranje.Datum)) return false;

            else if (TerminJeDanas(terminZaPomeranje))
            {
                if (!ProveriMogucnostPomeranjaVreme(terminZaPomeranje.PocetnoVreme)) return false;
            }
            return true;
        }
       
        public bool DatumiTerminaSuIsti(Termin termin, Termin izabraniTermin)
        {
            if (DateTime.Compare(termin.Datum.Date, izabraniTermin.Datum.Date) == 0) return true;
            return false;
        }
        public bool DatumPregledaJeKasnijiOdPocetkaIntervala(Termin termin, DateTime pocetakIntervala)
        {
            if (DateTime.Compare(termin.Datum, pocetakIntervala) >= 0) return true;
            return false;
        }
        public bool DatumPregledaJeRanijiOdKrajaIntervala(Termin termin, DateTime krajIntervala)
        {
            if (DateTime.Compare(termin.Datum, krajIntervala) <= 0) return true;
            return false;
        }

        public List<Termin> UkloniDupleDatumeTermina(List<Termin> dupliTermini)
        {
            List<Termin> jedinstveniTermini = new List<Termin>();
            foreach (Termin termin in dupliTermini.DistinctBy(t => t.Datum.Date))
                jedinstveniTermini.Add(termin);
            return jedinstveniTermini;
        }

        public List<Termin> ObrisiDatumeTerminaIzProslosti(List<Termin> sviTermini)
        {
            List<Termin> terminiUBuducnosti = new List<Termin>();
            foreach (Termin termin in sviTermini)
            {
                if (!TerminJeUProslosti(termin.Datum)) terminiUBuducnosti.Add(termin);
            }
            return terminiUBuducnosti;
        }

        public bool ProveriZaOtkazivanje(DateTime datumTerminaZaOtkazivanje)
        {
            if (DateTime.Compare(datumTerminaZaOtkazivanje, DateTime.Now) <= 0) return false;
            return true;
        }

        public bool TerminJeUProslosti(DateTime datumTermina)
        {
            if (DateTime.Compare(datumTermina, DateTime.Now.AddDays(1)) > 0) return false;
            return true;
        }

        private bool TerminJeDanas(Termin termin)
        {
            if (DateTime.Compare(termin.Datum.Date, DateTime.Now.AddDays(1).Date) == 0) return true;
            return false;
        }

        public List<Termin> NadjiTermineUIntervalu(List<DateTime> interval,List<Termin> sviTermini)
        {
            List<Termin> terminiUIntervalu = new List<Termin>();
            foreach (Termin termin in sviTermini)
            {
                if (DatumPregledaJeKasnijiOdPocetkaIntervala(termin, interval[0]) &&
                    DatumPregledaJeRanijiOdKrajaIntervala(termin, interval[1]))
                    terminiUIntervalu.Add(termin);
            }
            return terminiUIntervalu;
        }

        public List<DateTime> PodesiIntervalPomeranja(DateTime datumTermina)
        {
            List<DateTime> intervalPomeranja = new List<DateTime>();
            intervalPomeranja.Add(datumTermina.AddDays(-2));
            intervalPomeranja.Add(datumTermina.AddDays(2));
            return intervalPomeranja;
        }
    }
}

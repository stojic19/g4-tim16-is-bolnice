using Model;
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
        public List<DateTime> PodesiIntervalPomeranjaTermina(DateTime datumTermina)
        {
            List<DateTime> intervalPomeranja = new List<DateTime>();
            intervalPomeranja.Add(datumTermina.AddDays(-2));
            intervalPomeranja.Add(datumTermina.AddDays(2));
            return intervalPomeranja;
        }
        public bool ProveriMogucnostPomeranjaTermina(Termin terminZaPomeranje)
        {
            if (!TerminJeUBuducnosti(terminZaPomeranje.Datum)) return false;

            else if (TerminJeSutra(terminZaPomeranje.Datum))
            {
                if (!ProveriMogucnostPomeranjaVreme(terminZaPomeranje.PocetnoVreme)) return false;
            }
            return true;
        }
        public bool ProveriMogucnostPomeranjaVreme(String vreme)
        {
            DateTime vremePregleda = KonverzijaPocetnogVremena(vreme);
            if (!SatPregledaJeRanijiOdSadasnjegSata(vremePregleda)) return false;
            else if (!SatPregledaJeJednakSadasnjemSatu(vremePregleda) && !MinutPregledaJeJednakSasanjemMinutu(vremePregleda)) return false;
            else if (!SatPregledaJeJednakSadasnjemSatu(vremePregleda) && !MinutPregledaJeKasnijiOdSadasnjeg(vremePregleda)) return false;
            return true;
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
        public List<Termin> NadjiTermineUIntervalu(List<DateTime> interval, List<Termin> sviTermini)
        {
            List<Termin> terminiUIntervalu = new List<Termin>();
            foreach (Termin termin in sviTermini)
            {
                if (DatumPregledaJeKasnijiOdPocetkaIntervala(termin, interval[0]) &&
                    DatumPregledaJeRanijiOdKrajaIntervala(termin, interval[1]))
                    terminiUIntervalu.Add(termin);
            }
            return UkloniDupleDatumeTermina(SortTerminaPoDatumu(terminiUIntervalu));
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
        public bool DatumiTerminaSuIsti(DateTime datumTermina, DateTime datumIzabranog)
        {
            if (DateTime.Compare(datumTermina.Date, datumIzabranog.Date) == 0) return true;
            return false;
        }
       
        public List<Termin> UkloniDupleDatumeTermina(List<Termin> dupliTermini)
        {
            List<Termin> jedinstveniTermini = new List<Termin>();
            foreach (Termin termin in dupliTermini.DistinctBy(t => t.Datum.Date))
                jedinstveniTermini.Add(termin);
            return jedinstveniTermini;
        }

        public bool ProveriDatumZaOtkazivanje(DateTime datumTerminaZaOtkazivanje)
        {
            if (DateTime.Compare(datumTerminaZaOtkazivanje, DateTime.Now) <= 0) return false;
            return true;
        }

        private bool TerminJeSutra(DateTime datumTermina)
        {
            if (DateTime.Compare(datumTermina.Date, DateTime.Now.AddDays(1).Date) == 0) return true;
            return false;
        }

        public List<Termin> DobaviZakazaneTermineZaVreme(DateTime datum, List<Termin> termini)
        {
            List<Termin> pogodniTermini = new List<Termin>();
            foreach (Termin termin in termini)
            {
                if (DatumiTerminaSuIsti(termin.Datum, datum))
                {
                    pogodniTermini.Add(termin);
                }
            }
            return pogodniTermini;
        }
    }
}

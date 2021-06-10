using Bolnica.Interfejsi.Sekretar;
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
        LekariServis lekariServis = new LekariServis();

        public List<Termin> DobaviSve()
        {
            ObrisiStareSlobodneTermine();
            return slobodniTerminiRepozitorijum.DobaviSveObjekte();
        }

        public void Ukloni(Termin termin)
        {
            slobodniTerminiRepozitorijum.ObrisiObjekat("//ArrayOfTermin/Termin[IdTermina='" + termin.IdTermina + "']");
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
            foreach(Termin termin in termini)
            {
                if(DateTime.Compare(termin.Datum, DateTime.Now)<0)
                {
                    Ukloni(termin);
                }
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
                if (termin.VrstaTermina == VrsteTermina.operacija)
                    termini.Add(termin);
            }
            return termini;
        }
        public Termin PretraziPoId(String idTermina)
        {
            return slobodniTerminiRepozitorijum.PretraziPoId("//ArrayOfTermin/Termin[IdTermina='" + idTermina + "']");
        }
        public List<Termin> NadjiVremeTermina(Termin izabraniTermin)
        {
            List<Termin> termini = new List<Termin>();
            foreach (Termin termin in slobodniTerminiRepozitorijum.DobaviSveObjekte())
            {
                if (DatumiTerminaSuIsti(termin, izabraniTermin) &&
                 LekariTerminaSuIsti(termin, izabraniTermin))
                {
                    termini.Add(termin);
                }
            }
            return SortTerminaPoPocetnomVremenu(termini);
        }

        private bool DatumiTerminaSuIsti(Termin termin,Termin izabraniTermin)
        {
            if (DateTime.Compare(termin.Datum.Date, izabraniTermin.Datum.Date) == 0) return true;
            return false;
        }
        private bool LekariTerminaSuIsti(Termin termin, Termin izabraniTermin)
        {
            if (izabraniTermin.Lekar.KorisnickoIme.Equals(termin.Lekar.KorisnickoIme)) return true;
            return false;
        }

        private List<Termin> UkloniDupleDatume(List<Termin> dupliTermini)
        {
            List<Termin> jedinstveniTermini = new List<Termin>();
            foreach (Termin termin in dupliTermini.DistinctBy(t => t.Datum.Date))
                jedinstveniTermini.Add(termin);
            return jedinstveniTermini;
        }

        private List<Termin> SortTerminaPoPocetnomVremenu(List<Termin> nesortiraniTermini)
        {
            return nesortiraniTermini.OrderBy(user => user.Datum.TimeOfDay).ToList();

        }

        private List<Termin> SortTerminaPoDatumu(List<Termin> nesrotiraniDatumi)
        {
            return nesrotiraniDatumi.OrderBy(user => user.Datum.Date).ToList();
        }

        public List<Termin> PretraziPoLekaruUIntervalu(List<Termin> terminiUIntervalu, String korisnickoImeLekara)
        {
            List<Termin> terminiKodIzabranog = new List<Termin>();
            foreach (Termin termin in terminiUIntervalu)
            {
                if (TerminJeOdIzabranogLekara(termin, korisnickoImeLekara))
                    terminiKodIzabranog.Add(termin);
            }
            return terminiKodIzabranog;
        }
        private bool TerminJeOdIzabranogLekara(Termin termin, String korisnickoImeLekara)
        {
            if (termin.Lekar.KorisnickoIme.Equals(korisnickoImeLekara) &&
                termin.Lekar.Specijalizacija == SpecijalizacijeLekara.nema) return true;
            return false;
        }

        public List<Termin> NadjiTermineUIntervalu(DateTime pocetakIntervala, DateTime krajIntervala)
        {
            List<Termin> terminiUIntervalu = new List<Termin>();
            foreach (Termin termin in slobodniTerminiRepozitorijum.DobaviSveObjekte())
            {
                if (DatumPregledaJeKasnijiOdPocetkaIntervala(termin, pocetakIntervala) &&
                    DatumPregledaJeRanijiOdKrajaIntervala(termin, krajIntervala))
                    terminiUIntervalu.Add(termin);
            }
            return FiltrirajTerminePoSpecijalizaciji(terminiUIntervalu);
        }

        private bool DatumPregledaJeKasnijiOdPocetkaIntervala(Termin termin,DateTime pocetakIntervala)
        {
            if (DateTime.Compare(termin.Datum, pocetakIntervala) >= 0) return true;
            return false;
        }
        private bool DatumPregledaJeRanijiOdKrajaIntervala(Termin termin, DateTime krajIntervala)
        {
            if (DateTime.Compare(termin.Datum, krajIntervala) <= 0) return true;
            return false;
        }


        private List<Termin> FiltrirajTerminePoSpecijalizaciji(List<Termin> terminiSvihLekara)
        {
            List<Termin> terminiOpstePrakse = new List<Termin>();
            foreach (Termin termin in terminiSvihLekara)
            {
                if (termin.Lekar.Specijalizacija.Equals(SpecijalizacijeLekara.nema))
                    terminiOpstePrakse.Add(termin);
            }
            return UkloniDupleDatume(SortTerminaPoDatumu(terminiOpstePrakse));
        }

        public List<Termin> DobaviSlobodneTermineZaZakazivanje(List<DateTime> interval, String lekar)
        {
            List<Termin> datumiUIntervalu = NadjiTermineUIntervalu(interval[0], interval[1]);
            List<Termin> terminiKodIzabranogLekara = PretraziPoLekaruUIntervalu(datumiUIntervalu, lekar);
            return ObrisiDatumeIzProslosti(terminiKodIzabranogLekara);
        }

        public List<Termin> DobaviSveSlobodneDatumeZaPomeranje(Termin termin, String idLekara)
        {
            List<Termin> datumiUIntervalu = NadjiTermineUIntervalu(termin.Datum.AddDays(-2), termin.Datum.AddDays(2));
            List<Termin> sviSlobodniDatumi = PretraziPoLekaruUIntervalu(datumiUIntervalu, idLekara);
            return ObrisiDatumeIzProslosti(sviSlobodniDatumi); 
        }
        private List<Termin> ObrisiDatumeIzProslosti(List<Termin> sviDatumiTermina)
        {
            List<Termin> terminiUBuducnosti = new List<Termin>();
            foreach (Termin termin in sviDatumiTermina)
            {
                if (TerminJeUBuducnosti(termin)) terminiUBuducnosti.Add(termin);
            }
            return terminiUBuducnosti;
        }
        private bool TerminJeUBuducnosti(Termin termin)
        {
            if (DateTime.Compare(termin.Datum, DateTime.Now.AddDays(1)) > 0) return true;
            return false;
        }

        public List<Termin> DobaviSlobodneTermineLekara(Termin terminZaPoredjenje, String izabranLekar, int brojTermina)
        {
            List<Termin> slobodniTermini = slobodniTerminiRepozitorijum.DobaviSlobodneTermineLekara(terminZaPoredjenje, izabranLekar);
            List<Termin> krajnjiTermini = new List<Termin>();
            brojTermina--;

            for (int i = 0; i < slobodniTermini.Count(); i++)
            {
                if (i + brojTermina >= slobodniTermini.Count()) continue;

                if (DateTime.Compare(slobodniTermini[i + brojTermina].Datum, slobodniTermini[i].Datum.AddMinutes(brojTermina * 30)) == 0)
                {
                    krajnjiTermini.Add(slobodniTermini[i]);
                }
            }

            return krajnjiTermini;
        }
    }
}

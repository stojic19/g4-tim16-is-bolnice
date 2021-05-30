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
    public class SlobodniTerminiServis
    {
        SlobodniTerminiRepozitorijumInterfejs slobodniTerminiRepozitorijum = new SlobodniTerminiRepozitorijum();
        LekariServis lekariServis = new LekariServis();

        public List<Termin> DobaviSveSlobodneTermine()
        {
            return slobodniTerminiRepozitorijum.DobaviSveObjekte();
        }
        public List<Termin> DobaviSlobodneTermineZaLekara(string idLekara)
        {
            return slobodniTerminiRepozitorijum.DobaviSlobodneTerminePoIdLekara(idLekara);
        }

        public void UkloniRadniDan(string idLekara, RadniDan radniDan)
        {
            List<Termin> termini = DobaviSlobodneTermineZaLekaraNaRadniDan(idLekara, radniDan);
            foreach (Termin termin in termini)
            {
                UkloniSlobodanTermin(termin);
            }
        }

        public List<Termin> DobaviSveSlobodneTermineZaOperacije()
        {
            List<Termin> termini = new List<Termin>();
            foreach (Termin termin in slobodniTerminiRepozitorijum.DobaviSveObjekte())
            {
                if (termin.VrstaTermina == VrsteTermina.operacija)
                    termini.Add(termin);
            }
            return termini;
        }

        private void DodajSlobodanTermin(Termin termin)
        {
            slobodniTerminiRepozitorijum.DodajObjekat(termin);
        }
        public void UkloniSlobodanTermin(Termin termin)
        {
            slobodniTerminiRepozitorijum.ObrisiObjekat("//ArrayOfTermin/Termin[IdTermina='" + termin.IdTermina + "']");
        }
        public Termin PretraziPoId(String idTermina)
        {
            return slobodniTerminiRepozitorijum.PretraziPoId("//ArrayOfTermin/Termin[IdTermina='" + idTermina + "']");
        }
        public void DodajSlobodneTermineZaOpstuPraksu(String idLekara, RadniDan radniDan)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            for (DateTime datum = radniDan.PocetakSmene; DateTime.Compare(datum, radniDan.KrajSmene) < 0; datum = datum.AddMinutes(30))
            {
                DodajSlobodanTermin(new Termin(VrsteTermina.pregled, datum.ToString("HH:mm"), 30, datum, lekar));
            }
        }

        public void PromeniSmenu(string idLekara, RadniDan radniDanStari, RadniDan radniDanNovi)
        {
            List<Termin> termini = DobaviSlobodneTermineZaLekaraNaRadniDan(idLekara, radniDanStari);
            double novaSmena = DobaviNovuSmenu(radniDanStari, radniDanNovi);
            foreach (Termin termin in termini)
            {
                termin.Datum = termin.Datum.AddMinutes(novaSmena);
                termin.PocetnoVreme = termin.Datum.ToString("HH:mm");
                slobodniTerminiRepozitorijum.IzmeniTermin(termin);
            }
        }

        private double DobaviNovuSmenu(RadniDan radniDanStari, RadniDan radniDanNovi)
        {
            return radniDanNovi.PocetakSmene.TimeOfDay.TotalMinutes - radniDanStari.PocetakSmene.TimeOfDay.TotalMinutes;
        }

        private List<Termin> DobaviSlobodneTermineZaLekaraNaRadniDan(string idLekara, RadniDan radniDanStari)
        {
            List<Termin> termini = DobaviSlobodneTermineZaLekara(idLekara);
            List<Termin> novaLista = new List<Termin>();
            foreach (Termin termin in termini)
            {
                if (DateTime.Compare(termin.Datum, radniDanStari.PocetakSmene) >= 0 && DateTime.Compare(termin.Datum, radniDanStari.KrajSmene) < 0)
                {
                    novaLista.Add(termin);
                }
            }
            return novaLista;
        }

        public void DodajSlobodneTermineZaSpecijalistu(string idLekara, RadniDan radniDan)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            DodajSlobodanTermin(new Termin(VrsteTermina.operacija, radniDan.PocetakSmene.ToString("HH:mm"), 240, radniDan.PocetakSmene, lekar));
        }

        public void DodajSlobodanTerminZaOperaciju(Termin ostatak)
        {
            slobodniTerminiRepozitorijum.DodajObjekat(ostatak);
        }
        public void DodajSlobodanTerminZaPregled(Termin slobodanTermin)
        {
            slobodniTerminiRepozitorijum.DodajObjekat(slobodanTermin);
        }


        public List<Termin> NadjiVremeTermina(Termin izabraniTermin)
        {

            List<Termin> dupliTermini = new List<Termin>();
            foreach (Termin termin in slobodniTerminiRepozitorijum.DobaviSveObjekte())
            {
                if (DateTime.Compare(termin.Datum.Date, izabraniTermin.Datum.Date) == 0 &&
                 izabraniTermin.Lekar.KorisnickoIme.Equals(termin.Lekar.KorisnickoIme))
                {
                    dupliTermini.Add(termin);
                }
            }
            return SortTerminaPoPocetnomVremenu(dupliTermini);
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
                if (termin.Lekar.KorisnickoIme.Equals(korisnickoImeLekara) && termin.Lekar.Specijalizacija == SpecijalizacijeLekara.nema)
                    terminiKodIzabranog.Add(termin);
            }
            return terminiKodIzabranog;
        }

        public List<Termin> NadjiTermineUIntervalu(DateTime pocetakIntervala, DateTime krajIntervala)
        {
            List<Termin> terminiUIntervalu = new List<Termin>();
            foreach (Termin termin in slobodniTerminiRepozitorijum.DobaviSveObjekte())
            {
                if (DateTime.Compare(termin.Datum, pocetakIntervala) >= 0 && DateTime.Compare(termin.Datum, krajIntervala) <= 0)
                    terminiUIntervalu.Add(termin);
            }
            return FiltrirajTerminePoSpecijalizaciji(terminiUIntervalu);
        }

        private bool ProveriMogucnostPomeranjaVreme(String vreme)
        {
            DateTime vremePregleda = DateTime.ParseExact(vreme, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            if (vremePregleda.Hour < DateTime.Now.Hour)
                return false;
            else if (vremePregleda.Hour == DateTime.Now.Hour && DateTime.Now.Minute == vremePregleda.Minute)
                return false;
            else if (vremePregleda.Hour == DateTime.Now.Hour && DateTime.Now.Minute > vremePregleda.Minute)
                return false;
            return true;
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
            List<Termin> terminiKodIzabranogLekara = new List<Termin>();
            List<Termin> datumiUIntervalu = NadjiTermineUIntervalu(interval[0], interval[1]);
            terminiKodIzabranogLekara = PretraziPoLekaruUIntervalu(datumiUIntervalu, lekar);
            return terminiKodIzabranogLekara;
        }

        public List<Termin> DobaviSveSlobodneDatumeZaPomeranje(Termin termin, String idLekara)
        {
            List<Termin> sviSlobodniDatumi = new List<Termin>();
            List<Termin> datumiUIntervalu = NadjiTermineUIntervalu(termin.Datum.AddDays(-2), termin.Datum.AddDays(2));
            sviSlobodniDatumi = PretraziPoLekaruUIntervalu(datumiUIntervalu, idLekara);
            ObrisiDatumeIzProslosti(sviSlobodniDatumi);
            return sviSlobodniDatumi;
        }


        private List<Termin> ObrisiDatumeIzProslosti(List<Termin> sviSlobodniTermini)
        {
            List<Termin> terminiUBuducnosti = new List<Termin>();
            foreach (Termin termin in sviSlobodniTermini)
            {
                if (NasaoDatumUProslosti(termin))
                    terminiUBuducnosti.Add(termin);
            }

            return terminiUBuducnosti;
        }
        private bool NasaoDatumUProslosti(Termin termin)
        {
            if (DateTime.Compare(termin.Datum.Date, DateTime.Now.Date) > 0)
            {
                return true;
            }
            else if (DateTime.Compare(termin.Datum.Date, DateTime.Now.AddDays(1).Date) == 0)
            {
                if (ProveriMogucnostPomeranjaVreme(termin.PocetnoVreme))
                    return true;
            }
            return false;
        }

        public List<Termin> DobaviSlobodneTermineLekara(Termin terminZaPoredjenje, String izabranLekar)
        {
            return slobodniTerminiRepozitorijum.DobaviSlobodneTermineLekara(terminZaPoredjenje, izabranLekar);
        }
    }
}

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
        //ZakazaniTerminiServis zakazaniTerminiServis = new ZakazaniTerminiServis();
        NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();
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
            foreach(Termin termin in termini)
            {
                UkloniSlobodanTermin(termin);
            }
        }

        public List<Termin> DobaviSveSlobodneTermineZaOperacije()
        {
            List<Termin> termini = new List<Termin>();
            foreach(Termin termin in slobodniTerminiRepozitorijum.DobaviSveObjekte())
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
        public void DodajSlobodneTermineZaOpstuPraksu(String idLekara,RadniDan radniDan)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            for (DateTime datum = radniDan.PocetakSmene;DateTime.Compare(datum,radniDan.KrajSmene)<0;datum = datum.AddMinutes(30))
            {
                DodajSlobodanTermin(new Termin(VrsteTermina.pregled, datum.ToString("H:mm"), 30, datum, lekar));
            }
        }

        public void PromeniSmenu(string idLekara, RadniDan radniDanStari, RadniDan radniDanNovi)
        {
            List<Termin> termini = DobaviSlobodneTermineZaLekaraNaRadniDan(idLekara,radniDanStari);
            double novaSmena = DobaviNovuSmenu(radniDanStari, radniDanNovi);
            foreach(Termin termin in termini)
            {
                termin.Datum = termin.Datum.AddMinutes(novaSmena);
                termin.PocetnoVreme = termin.Datum.ToString("H:mm");
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
            foreach(Termin termin in termini)
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
            DodajSlobodanTermin(new Termin(VrsteTermina.operacija, radniDan.PocetakSmene.ToString("H:mm"), 240, radniDan.PocetakSmene, lekar));
        }

        public void DodajSlobodanTerminZaOperaciju(Termin ostatak)
        {
            slobodniTerminiRepozitorijum.DodajObjekat(ostatak);
        }
        public void DodajSlobodanTerminZaPregled(Termin ostatak)
        {
            slobodniTerminiRepozitorijum.DodajObjekat(ostatak);
        }




        public List<Termin> NadjiVremeTermina(Termin izabraniTermin)
        {
            List<Termin> dupliTermini = new List<Termin>();
            foreach (Termin termin in DobaviSveSlobodneTermine())
            {
                if (termin.Datum.Equals(izabraniTermin.Datum) &&
                 izabraniTermin.Lekar.KorisnickoIme.Equals(termin.Lekar.KorisnickoIme))
                    dupliTermini.Add(termin);
            }
            return SortTerminaPoPocetnomVremenu(UkloniDupleDatume(dupliTermini));
        }

        private List<Termin> UkloniDupleDatume(List<Termin> dupliTermini)
        {
            List<Termin> jedinstveniTermini = new List<Termin>();
            foreach (Termin termin in dupliTermini.DistinctBy(t => t.Datum))
                jedinstveniTermini.Add(termin);
            return jedinstveniTermini;
        }

        private List<Termin> SortTerminaPoPocetnomVremenu(List<Termin> nesortiraniTermini)
        {
            return nesortiraniTermini.OrderBy(user => DateTime.ParseExact(user.PocetnoVreme, "HH:mm", null)).ToList();
        }

        private List<Termin> SortTerminaPoDatumu(List<Termin> nesrotiraniDatumi)
        {
            return nesrotiraniDatumi.OrderBy(user => user.Datum).ToList();
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
            foreach (Termin t in DobaviSveSlobodneTermine())
            {
                if (DateTime.Compare(t.Datum, pocetakIntervala) >= 0 && DateTime.Compare(t.Datum, krajIntervala) <= 0)
                    terminiUIntervalu.Add(t);
            }
            return FiltrirajTerminePoSpecijalizaciji(terminiUIntervalu);
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

      

    }
}

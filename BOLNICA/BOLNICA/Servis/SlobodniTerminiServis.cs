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
            foreach(Termin termin in termini)
            {
                if(DateTime.Compare(termin.Datum, DateTime.Now)<0) Ukloni(termin);
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
                if (termin.VrstaTermina == VrsteTermina.operacija)  termini.Add(termin);
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
            foreach (Termin termin in slobodniTerminiRepozitorijum.DobaviSveObjekte())
            {
                if (datumServis.DatumiTerminaSuIsti(termin, izabraniTermin) &&
                 lekarTerminaServis.LekariTerminaSuIsti(termin, izabraniTermin))
                    termini.Add(termin);
            }
            return datumServis.SortTerminaPoPocetnomVremenu(termini);
        }
        public List<Termin> NadjiTermineUIntervalu(DateTime pocetakIntervala, DateTime krajIntervala)
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
        public List<Termin> DobaviSlobodneTermineZaZakazivanje(List<DateTime> interval, String idLekara)
        {
            List<Termin> terminiIntervala = NadjiTermineUIntervalu(interval[0], interval[1]);
            List<Termin> terminiIzabranogLekara = lekarTerminaServis.PretraziTerminePoLekaru(terminiIntervala, idLekara);
            List<Termin> jedinstveniTerminiLekara = datumServis.UkloniDupleDatumeTermina(terminiIzabranogLekara);
            return datumServis.ObrisiDatumeTerminaIzProslosti(datumServis.SortTerminaPoDatumu(jedinstveniTerminiLekara));
        }

        public List<Termin> DobaviSveSlobodneDatumeZaPomeranje(Termin termin, String idLekara)
        {
            List<Termin> datumiUIntervalu = NadjiTermineUIntervalu(termin.Datum.AddDays(-2), termin.Datum.AddDays(2));
            List<Termin> sviSlobodniDatumi = lekarTerminaServis.PretraziTerminePoLekaru(datumiUIntervalu, idLekara);
            return datumServis.ObrisiDatumeTerminaIzProslosti(sviSlobodniDatumi); 
        }
        public List<Termin> DobaviSlobodneTermineLekara(Termin terminZaPoredjenje, String izabranLekar, int brojTermina)
        {
            List<Termin> slobodniTermini = slobodniTerminiRepozitorijum.DobaviSlobodneTermineLekara(terminZaPoredjenje, izabranLekar);
            List<Termin> krajnjiTermini = lekarTerminaServis.DobaviSlobodneTermineLekara(slobodniTermini, brojTermina);
            return krajnjiTermini;
        }
    }
}

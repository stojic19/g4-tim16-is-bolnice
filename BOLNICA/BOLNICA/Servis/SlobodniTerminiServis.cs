using Bolnica.Model;
using Bolnica.Repozitorijum;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Servis
{
    class SlobodniTerminiServis
    {
        SlobodniTerminiRepozitorijum slobodniTerminiRepozitorijum = new SlobodniTerminiRepozitorijum();
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
    }
}

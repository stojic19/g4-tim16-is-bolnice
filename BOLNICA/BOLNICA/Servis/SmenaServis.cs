using Bolnica.Interfejsi.Sekretar;
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
    class SmenaServis : CRUDInterfejs<RadniDan>
    {
        SlobodniTerminiServis slobodniTerminiServis = new SlobodniTerminiServis();
        OperacijeRepozitorijum operacijeRepozitorijum = new OperacijeRepozitorijum();
        ZakazaniTerminiRepozitorijum zakazaniTerminiRepozitorijum = new ZakazaniTerminiRepozitorijum();
        LekariServis lekariServis = new LekariServis();
        ObavestenjaServis obavestenjaServis = new ObavestenjaServis();
        String idLekara;
        public SmenaServis(String idLekara)
        {
            this.idLekara = idLekara;
        }

        public List<RadniDan> DobaviSve()
        {
            return lekariServis.DobaviRadneDanePoIdLekara(idLekara);
        }

        public void Dodaj(RadniDan radniDan)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            if (lekar.JeSpecijalista())
            {
                slobodniTerminiServis.Dodaj(new Termin(VrsteTermina.operacija, radniDan.PocetakSmene.ToString("HH:mm"), 480, radniDan.PocetakSmene, lekar));
            }
            else
            {
                for (DateTime datum = radniDan.PocetakSmene; DateTime.Compare(datum, radniDan.KrajSmene) < 0; datum = datum.AddMinutes(30))
                {
                    slobodniTerminiServis.Dodaj(new Termin(VrsteTermina.pregled, datum.ToString("HH:mm"), 30, datum, lekar));
                }
            }
        }

        public void Izmeni(string stariId, RadniDan radniDanNovi)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            RadniDan radniDanStari = lekar.DobaviRadniDanPoId(stariId);
            double novaSmena = DobaviNovuSmenu(radniDanStari, radniDanNovi);
            PromeniVremeSlobodnihTermina(radniDanStari, radniDanNovi);
            if (lekar.JeSpecijalista())
            {
                List<Termin> termini = DobaviOperacijeZaLekaraNaRadniDan(radniDanStari);
                    
                    foreach (Termin termin in termini)
                    {
                        termin.Datum = termin.Datum.AddMinutes(novaSmena);
                        termin.PocetnoVreme = termin.Datum.ToString("HH:mm");
                        operacijeRepozitorijum.IzmeniTermin(termin);
                        obavestenjaServis.DodajObavestenjeOPromeniTerminaOperacije(termin);
                    }
            }
            else
            {
                
                List<Termin> termini = DobaviZakazaneTermineZaLekaraNaRadniDan(radniDanStari);
                foreach (Termin termin in termini)
                {
                    termin.Datum = termin.Datum.AddMinutes(novaSmena);
                    termin.PocetnoVreme = termin.Datum.ToString("H:mm");
                    zakazaniTerminiRepozitorijum.IzmeniTermin(termin);
                    obavestenjaServis.DodajObavestenjeOPromeniTerminaPregleda(termin);
                }
            }
        }
        
        public RadniDan PretraziPoId(string id)
        {
            throw new NotImplementedException();
        }

        public void Ukloni(RadniDan radniDan)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            UkloniSlobodneTermine(radniDan);
            if (lekar.JeSpecijalista())
            {
                List<Termin> termini = DobaviOperacijeZaLekaraNaRadniDan(radniDan);
                foreach (Termin termin in termini)
                {
                    if (DateTime.Compare(DateTime.Now, termin.Datum) < 0)
                    {
                        operacijeRepozitorijum.UkloniOperaciju(termin);
                        obavestenjaServis.DodajObavestenjeOOtkazivanjuOperacije(termin);
                    }
                }
            }
            else
            {
                List<Termin> termini = DobaviZakazaneTermineZaLekaraNaRadniDan(radniDan);
                foreach (Termin termin in termini)
                {
                    if (DateTime.Compare(DateTime.Now, termin.Datum) < 0)
                    {
                        zakazaniTerminiRepozitorijum.ObrisiZakazanTermin(termin.IdTermina);
                        obavestenjaServis.DodajObavestenjeOOtkazivanjuPregleda(termin);
                    }
                }
            }
        }
        private void UkloniSlobodneTermine(RadniDan radniDan)
        {
            List<Termin> termini = DobaviSlobodneTermineZaLekaraNaRadniDan(radniDan);
            foreach (Termin termin in termini)
            {
                slobodniTerminiServis.Ukloni(termin);
            }
        }
        private void PromeniVremeSlobodnihTermina(RadniDan radniDanStari, RadniDan radniDanNovi)
        {
            List<Termin> termini = DobaviSlobodneTermineZaLekaraNaRadniDan(radniDanStari);
            double novaSmena = DobaviNovuSmenu(radniDanStari, radniDanNovi);
            foreach (Termin termin in termini)
            {
                termin.Datum = termin.Datum.AddMinutes(novaSmena);
                termin.PocetnoVreme = termin.Datum.ToString("HH:mm");
                slobodniTerminiServis.Izmeni(termin.IdTermina, termin);
            }
        }
        private List<Termin> DobaviSlobodneTermineZaLekaraNaRadniDan(RadniDan radniDanStari)
        {
            List<Termin> termini = slobodniTerminiServis.DobaviSlobodneTermineZaLekara(idLekara);
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
        private List<Termin> DobaviZakazaneTermineZaLekara(string idLekara)
        {
            return zakazaniTerminiRepozitorijum.PretraziPoLekaru(idLekara);
        }
        private List<Termin> DobaviZakazaneTermineZaLekaraNaRadniDan(RadniDan radniDanStari)
        {
            List<Termin> termini = DobaviZakazaneTermineZaLekara(idLekara);
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
        private List<Termin> DobaviOperacijeZaLekaraNaRadniDan(RadniDan radniDanStari)
        {
            List<Termin> termini = DobaviOperacijeZaLekara();
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
        private List<Termin> DobaviOperacijeZaLekara()
        {
            return operacijeRepozitorijum.DobaviOperacijePoIdLekara(idLekara);
        }
        private double DobaviNovuSmenu(RadniDan radniDanStari, RadniDan radniDanNovi)
        {
            return radniDanNovi.PocetakSmene.TimeOfDay.TotalMinutes - radniDanStari.PocetakSmene.TimeOfDay.TotalMinutes;
        }
    }
}

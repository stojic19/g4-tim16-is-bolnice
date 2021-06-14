using Bolnica.DTO;
using Bolnica.Interfejsi.Lekar;
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
    public class ZakazaniTerminiKontroler
    {
        private ZakazaniTerminiServis zakazaniTerminiServis = new ZakazaniTerminiServis();
        private SlobodniTerminiServis slobodniTerminiServis = new SlobodniTerminiServis();
        private NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();
        private DatumTerminaServis datumTerminaServis = new DatumTerminaServis();
        private LekariServis lekariServis = new LekariServis();
        private TerminKonverter terminKonverter = new TerminKonverter();

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
            noviTermin.Prostor = ((TipTerminaInterfejs)noviTermin.VrstaTerminaInterfejs).DodeliProstorTerminu(noviTermin.Datum);
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
            novi.Prostor = ((TipTerminaInterfejs)novi.VrstaTerminaInterfejs).DodeliProstorTerminu(novi.Datum);
            zakazaniTerminiServis.PomeriPregledPacijent(stari, novi);
        }

        public void OtkaziPregledSekretar(string terminZaOtkazivanje)
        {
            zakazaniTerminiServis.OtkaziPregledSekretar(terminZaOtkazivanje);
        }
        public bool ProveriMogucnostPomeranjaTermina(TerminDTO terminZaPomeranje)
        {
            return datumTerminaServis.ProveriMogucnostPomeranjaTermina(terminKonverter.ZakazaniTerminDTOUModel(terminZaPomeranje));
        }
        public Boolean OtkaziTerminLekar(string idTermina)
        {
            return zakazaniTerminiServis.OtkaziTerminLekar(idTermina);
        }

        public Boolean ZakaziTerminLekar(TerminDTO termin)
        {
            Termin noviTermin = slobodniTerminiServis.PretraziPoId(termin.IdTermina);
            noviTermin.Lekar = lekariServis.PretraziPoId(termin.Lekar.KorisnickoIme);
            noviTermin.Pacijent = naloziPacijenataServis.PretraziPoId(termin.Pacijent.KorisnickoIme);
            noviTermin.Trajanje = termin.TrajanjeDouble;
            //if (noviTermin.VrstaTermina == VrsteTermina.operacija)
            //{
            //    noviTermin.Prostor = prostoriServis.DodeliProstorZaOperaciju(noviTermin.Datum);
            //}
            //else
            //{
            //    noviTermin.Prostor = prostoriServis.DodeliProstorZaTermin(noviTermin.Datum);
            //}

            noviTermin.Prostor = ((TipTerminaInterfejs)noviTermin.VrstaTerminaInterfejs).DodeliProstorTerminu(noviTermin.Datum);
            return zakazaniTerminiServis.ZakaziTerminLekar(noviTermin);
        }

        public void IzmeniTerminLekar(TerminDTO stariTermin, TerminDTO noviTermin)
        {
            Termin stari = zakazaniTerminiServis.DobaviZakazanTerminPoId(stariTermin.IdTermina);
            Termin novi = slobodniTerminiServis.PretraziPoId(noviTermin.IdTermina);
            novi.Trajanje = noviTermin.TrajanjeDouble;

            //if (novi.VrstaTermina == VrsteTermina.operacija)
            //{
            //    novi.Prostor = prostoriServis.DodeliProstorZaOperaciju(novi.Datum);
            //}
            //else
            //{
            //    novi.Prostor = prostoriServis.DodeliProstorZaTermin(novi.Datum);
            //}
            novi.Prostor = ((TipTerminaInterfejs)novi.VrstaTerminaInterfejs).DodeliProstorTerminu(novi.Datum);
            zakazaniTerminiServis.IzmeniTermin(stari, novi);
        }

        public TerminDTO DobaviZakazanTerminDTO(String idTermina)
        {
            Termin t = zakazaniTerminiServis.DobaviZakazanTerminPoId(idTermina);
            return terminKonverter.ZakazaniTerminModelUDTO(t, t.Pacijent.KorisnickoIme);
        }
        public bool ProveriZaOtkazivanje(String izabranTermin)
        {
            Termin termin = zakazaniTerminiServis.DobaviZakazanTerminPoId(izabranTermin);
            return datumTerminaServis.ProveriDatumZaOtkazivanje(termin.Datum);
        }
    }
}

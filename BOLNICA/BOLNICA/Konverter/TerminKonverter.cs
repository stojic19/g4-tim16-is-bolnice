using Bolnica.DTO;
using Model;
using System;

namespace Bolnica.Konverter
{
    public class TerminKonverter
    {
        LekarKonverter lekarKonverter = new LekarKonverter();
        ProstoriServis prostoriServis = new ProstoriServis();
        public TerminDTO ZakazaniTerminModelUDTO(Termin termin, String korisnickoIme)
        {
            PacijentDTO pacijent = new PacijentDTO(termin.Pacijent.Ime, termin.Pacijent.Prezime, termin.Pacijent.Jmbg, korisnickoIme);
            LekarDTO lekar = new LekarDTO(termin.Lekar.Ime + termin.Lekar.Prezime, termin.Lekar.KorisnickoIme, termin.Lekar.Specijalizacija);
            if(termin.Prostor != null)
                return new TerminDTO(termin.IdTermina, termin.Datum, termin.PocetnoVreme, lekar, termin.Trajanje.ToString(), termin.Prostor.IdProstora, termin.VrstaTermina.ToString(), korisnickoIme, termin.Trajanje, pacijent);
            else
                return new TerminDTO(termin.IdTermina, termin.Datum, termin.PocetnoVreme, lekar, termin.Trajanje.ToString(), null, termin.VrstaTermina.ToString(), korisnickoIme, termin.Trajanje, pacijent);
        }

        public TerminDTO SlobodniTerminModelUDTO(Termin termin)
        {
            LekarDTO lekar = new LekarDTO(termin.Lekar.Ime + termin.Lekar.Prezime, termin.Lekar.KorisnickoIme, termin.Lekar.Specijalizacija);
            return new TerminDTO(termin.IdTermina, termin.Datum, termin.PocetnoVreme, lekar, termin.Trajanje.ToString(), null, termin.VrstaTermina.ToString(), termin.Trajanje);
        }

        public Termin PodaciZaSlobodanTermin(TerminDTO terminSaPodacima)
        {
            return new Termin(getVrstaTermina(terminSaPodacima.TipTermina), terminSaPodacima.Datum, null);
        }

        public VrsteTermina getVrstaTermina(String vrstaTermina)
        {

            if (vrstaTermina.Equals("operacija"))
            {
                return VrsteTermina.operacija;
            }
            else
            {
                return VrsteTermina.pregled;
            }
        }

        public Termin TerminZaIzmenu(TerminDTO terminSaPodacima)
        {
            return new Termin(getVrstaTermina(terminSaPodacima.TipTermina), terminSaPodacima.Datum, null, terminSaPodacima.Vreme);
        }
        public Termin ZakazaniTerminDTOUModel(TerminDTO termin)
        {
            PacijentKonverter pacijentKonverter = new PacijentKonverter();

            return new Termin(termin.IdTermina, getVrstaTermina(termin.TipTermina), termin.Vreme, double.Parse(termin.Trajanje), termin.Datum, prostoriServis.PretraziPoId(termin.Prostor),pacijentKonverter.PacijentDTOUModel(termin.Pacijent), lekarKonverter.LekarDTOUModel(termin.Lekar));
        }

    }
}

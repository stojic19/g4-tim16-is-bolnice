using Bolnica.DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class TerminKonverter
    {

        public TerminDTO ZakazaniTerminModelUDTO(Termin termin, String korisnickoIme)
        {
            LekarDTO lekar = new LekarDTO(termin.Lekar.Ime + termin.Lekar.Prezime, termin.Lekar.KorisnickoIme, termin.Lekar.Specijalizacija);
            return new TerminDTO(termin.IdTermina, termin.Datum, termin.PocetnoVreme, lekar, termin.Trajanje.ToString(), null, termin.VrstaTermina.ToString(), korisnickoIme); 
        }

        public TerminDTO SlobodniTerminModelUDTO(Termin termin)
        {
            LekarDTO lekar = new LekarDTO(termin.Lekar.Ime + termin.Lekar.Prezime, termin.Lekar.KorisnickoIme, termin.Lekar.Specijalizacija);
            return new TerminDTO(termin.IdTermina, termin.Datum, termin.PocetnoVreme, lekar, termin.Trajanje.ToString(), null, termin.VrstaTermina.ToString());
        }


    }
}

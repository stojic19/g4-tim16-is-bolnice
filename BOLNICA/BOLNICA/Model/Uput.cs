using Bolnica.Model.Enumi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Uput
    {
        public String IDUputa { get; set; }
        public TipoviUputa TipUputa { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public String IDLekaraKojiUpucuje { get; set; }
        public String ImePrezimeLekar { get; set; }
        public String IDLekaraSpecijaliste { get; set; }
        public String IDPacijenta { get; set; }
        public String NalazMisljenje { get; set; }

        public Uput() { }
        public Uput(string iDUputa, TipoviUputa tipUputa, DateTime datumIzdavanja, string iDLekaraKojiUpucuje, string imePrezimeLekar, string iDLekaraSpecijaliste, string iDPacijenta, string nalazMisljenje)
        {
            IDUputa = iDUputa;
            TipUputa = tipUputa;
            DatumIzdavanja = datumIzdavanja;
            IDLekaraKojiUpucuje = iDLekaraKojiUpucuje;
            ImePrezimeLekar = imePrezimeLekar;
            IDLekaraSpecijaliste = iDLekaraSpecijaliste;
            IDPacijenta = iDPacijenta;
            NalazMisljenje = nalazMisljenje;
        }

        public String TipUputaTekst()
        {
            if (TipUputa.Equals(TipoviUputa.SPECIJALISTA))
            {
                return "Specijalistički pregled";
            }
            else if (TipUputa.Equals(TipoviUputa.LABORATORIJA))
            {
                return "Laboratorija";
            }
            else { return "Stacionarno lečenje"; }
        }
    }
}

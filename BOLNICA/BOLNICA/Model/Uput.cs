using Bolnica.Model.Enumi;
using Model;
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
        public String ImePrezimeLekar { get; set; }
        public String IDLekaraSpecijaliste { get; set; }
        public String NalazMisljenje { get; set; }
        public DateTime PocetakStacionarnog { get; set; }
        public DateTime KrajStacionarnog { get; set; }
        public Prostor Prostor { get; set; } = null;

        public Uput() { }
        public Uput(string iDUputa, TipoviUputa tipUputa, DateTime datumIzdavanja, string iDLekaraSpecijaliste, string nalazMisljenje, string imeprezime)
        {
            IDUputa = iDUputa;
            TipUputa = tipUputa;
            DatumIzdavanja = datumIzdavanja;
            ImePrezimeLekar = imeprezime;
            IDLekaraSpecijaliste = iDLekaraSpecijaliste;
            NalazMisljenje = nalazMisljenje;
        }

        public Uput(string iDUputa, TipoviUputa tipUputa, DateTime datumIzdavanja, string imePrezimeLekar, string iDLekaraSpecijaliste, string nalazMisljenje, DateTime pocetakStacionarnog, DateTime krajStacionarnog, Prostor prostor)
        {
            IDUputa = iDUputa;
            TipUputa = tipUputa;
            DatumIzdavanja = datumIzdavanja;
            ImePrezimeLekar = imePrezimeLekar;
            IDLekaraSpecijaliste = iDLekaraSpecijaliste;
            NalazMisljenje = nalazMisljenje;
            PocetakStacionarnog = pocetakStacionarnog;
            KrajStacionarnog = krajStacionarnog;
            Prostor = prostor;
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

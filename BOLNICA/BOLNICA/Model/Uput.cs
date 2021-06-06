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
        private String iDUputa;
        private TipoviUputa tipUputa;
        private DateTime datumIzdavanja;
        private String imePrezimeLekar;
        private String iDLekaraSpecijaliste;
        private String nalazMisljenje;
        private DateTime pocetakStacionarnog;
        private DateTime krajStacionarnog;
        private Prostor prostor = null;

        public string IDUputa { get => iDUputa; set => iDUputa = value; }
        public TipoviUputa TipUputa { get => tipUputa; set => tipUputa = value; }
        public DateTime DatumIzdavanja { get => datumIzdavanja; set => datumIzdavanja = value; }
        public string ImePrezimeLekar { get => imePrezimeLekar; set => imePrezimeLekar = value; }
        public string IDLekaraSpecijaliste { get => iDLekaraSpecijaliste; set => iDLekaraSpecijaliste = value; }
        public string NalazMisljenje { get => nalazMisljenje; set => nalazMisljenje = value; }
        public DateTime PocetakStacionarnog { get => pocetakStacionarnog; set => pocetakStacionarnog = value; }
        public DateTime KrajStacionarnog { get => krajStacionarnog; set => krajStacionarnog = value; }
        public Prostor Prostor { get => prostor; set => prostor = value; }

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

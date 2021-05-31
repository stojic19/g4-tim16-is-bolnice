using Bolnica.Model.Enumi;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class UputDTO
    {

        private String idUputa;
        private String tipUputa;
        private TipoviUputa tipUputaEnum;
        private DateTime datumIzdavanja;
        private String lekarOpstePrakse;
        private String nalazMisljenje;
        private DateTime pocetakStacionarnog;
        private DateTime krajStacionarnog;
        private ProstorDTO prostor;
        private String idLekaraSpecijaliste;
        public String IdUputa
        {
            get { return idUputa; }
            set { idUputa = value; }
        }
        public String TipUputa
        {
            get { return tipUputa; }
            set { tipUputa = value; }
        }
        public DateTime DatumIzdavanja
        {
            get { return datumIzdavanja; }
            set { datumIzdavanja = value; }
        }
        public String Lekar
        {
            get { return lekarOpstePrakse; }
            set { lekarOpstePrakse = value; }
        }
        public String NalazMisljenje
        {
            get { return nalazMisljenje; }
            set { nalazMisljenje = value; }
        }

        public DateTime PocetakStacionarnog
        {
            get { return pocetakStacionarnog; }
            set { pocetakStacionarnog = value; }
        }
        public DateTime KrajStacionarnog
        {
            get { return krajStacionarnog; }
            set { krajStacionarnog = value; }
        }
        public ProstorDTO Prostor
        {
            get { return prostor; }
            set { prostor = value; }
        }

        public TipoviUputa TipUputaEnum
        {
            get { return tipUputaEnum; }
            set { tipUputaEnum = value; }
        }

        public String IdLekaraSpecijaliste
        {
            get { return idLekaraSpecijaliste; }
            set { idLekaraSpecijaliste = value; }
        }

        public UputDTO() { }

        public UputDTO(string idUputa, string tipUputa, DateTime datumIzdavanja, string lekar, string idLekaraSpecijaliste, string nalaz, ProstorDTO prostor, DateTime pocetakStac, DateTime krajStac)
        {
            this.idUputa = idUputa;
            this.tipUputa = tipUputa;
            this.datumIzdavanja = datumIzdavanja;
            this.lekarOpstePrakse = lekar;
            this.idLekaraSpecijaliste = idLekaraSpecijaliste;
            this.nalazMisljenje = nalaz;
            this.prostor = prostor;
            this.pocetakStacionarnog = pocetakStac;
            this.krajStacionarnog = krajStac;
        }

        public UputDTO(string idUputa, TipoviUputa tipUputa, DateTime datumIzdavanja, string lekar, string idLekaraSpecijaliste, string nalaz)
        {
            this.idUputa = idUputa;
            this.tipUputaEnum = tipUputa;
            this.datumIzdavanja = datumIzdavanja;
            this.lekarOpstePrakse = lekar;
            this.idLekaraSpecijaliste = idLekaraSpecijaliste;
            this.nalazMisljenje = nalaz;
        }

        public UputDTO(string idUputa, TipoviUputa tipUputaEnum, DateTime datumIzdavanja, string nalazMisljenje, string lekarOpstePrakse,
                        DateTime pocetakStacionarnog, DateTime krajStacionarnog, ProstorDTO prostor)
        {
            this.idUputa = idUputa;
            this.tipUputaEnum = tipUputaEnum;
            this.datumIzdavanja = datumIzdavanja;
            this.lekarOpstePrakse = lekarOpstePrakse;
            this.nalazMisljenje = nalazMisljenje;
            this.pocetakStacionarnog = pocetakStacionarnog;
            this.krajStacionarnog = krajStacionarnog;
            this.prostor = prostor;
        }
    }
}

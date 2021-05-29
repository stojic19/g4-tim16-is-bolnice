using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class TerapijaDTO
    {
        private String idTerapije;
        private String idAnamneze;
        private DateTime pocetakTerapije;
        private DateTime krajTerapije;
        private String kolicina;
        private String satnica;
        private String uputsvoKonzumiranja;
        private LekDTO lek;

        public String IdTerapije
        {
            get { return idTerapije; }
            set { idTerapije = value; }
        }
        public String IdAnamneze
        {
            get { return idAnamneze; }
            set { idAnamneze = value; }
        }
        public DateTime PocetakTerapije
        {
            get { return pocetakTerapije; }
            set { pocetakTerapije = value; }
        }
        public DateTime KrajTerapije
        {
            get { return krajTerapije; }
            set { krajTerapije = value; }
        }
        public String Kolicina
        {
            get { return kolicina; }
            set { kolicina = value; }
        }
        public String Satnica
        {
            get { return satnica; }
            set { satnica = value; }
        }
        public String UputsvoKonzumiranja
        {
            get { return uputsvoKonzumiranja; }
            set { uputsvoKonzumiranja = value; }
        }
        public LekDTO Lek
        {
            get { return lek; }
            set { lek = value; }
        }

        public TerapijaDTO(string idTerapije, string idAnamneze, DateTime pocetakTerapije, DateTime krajTerapije, string kolicina, string satnica, string uputsvoKonzumiranja, LekDTO lek)
        {
            this.idTerapije = idTerapije;
            this.idAnamneze = idAnamneze;
            this.pocetakTerapije = pocetakTerapije;
            this.krajTerapije = krajTerapije;
            this.kolicina = kolicina;
            this.satnica = satnica;
            this.uputsvoKonzumiranja = uputsvoKonzumiranja;
            this.lek = lek;
        }
    }
}

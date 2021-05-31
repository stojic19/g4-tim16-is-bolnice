using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class RenoviranjeDTO
    {
        private String idRenoviranja;
        private ProstorDTO prostor;
        private DateTime pocetniDatum;
        private DateTime datumKraja;
        private List<ProstorDTO> prostoriKojiSeBrisu;
        private List<ProstorDTO> prostoriKojiSeDodaju;

        public String IdRenoviranja
        {
            get { return idRenoviranja; }
            set { idRenoviranja = value; }
        }

        public ProstorDTO Prostor
        {
            get { return prostor; }
            set { prostor = value; }
        }

        public DateTime PocetniDatum
        {
            get { return pocetniDatum; }
            set { pocetniDatum = value; }
        }

        public DateTime DatumKraja
        {
            get { return datumKraja; }
            set { datumKraja = value; }
        }

        public List<ProstorDTO> ProstoriKojiSeBrisu
        {
            get { return prostoriKojiSeBrisu; }
            set { prostoriKojiSeBrisu = value; }
        }

        public List<ProstorDTO> ProstoriKojiSeDodaju
        {
            get { return prostoriKojiSeDodaju; }
            set { prostoriKojiSeDodaju = value; }
        }
        RenoviranjeDTO() { }

        public RenoviranjeDTO(string idRenoviranja, ProstorDTO prostor, DateTime pocetniDatum, DateTime datumKraja)
        {
            this.idRenoviranja = idRenoviranja;
            this.prostor = prostor;
            this.pocetniDatum = pocetniDatum;
            this.datumKraja = datumKraja;
        }
    }
}

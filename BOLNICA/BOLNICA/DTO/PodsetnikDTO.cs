using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class PodsetnikDTO
    {
        private String naslov;
        private String tekst;
        private DateTime datumOD;
        private DateTime datumDO;
        private DateTime vreme;

        public String Naslov
        {
            get { return naslov; }
            set { naslov = value; }
        }
        public String Tekst
        {
            get { return tekst; }
            set { tekst = value; }
        }
        public DateTime DatumOd
        {
            get { return datumOD; }
            set { datumOD = value; }
        }
        public DateTime DatumDo
        {
            get { return datumDO; }
            set { datumDO = value; }
        }
        public DateTime Vreme
        {
            get { return vreme; }
            set { vreme = value; }
        }

        public PodsetnikDTO() { }

        public PodsetnikDTO(string naslov, string tekst, DateTime datumOD, DateTime datumDO, DateTime vreme)
        {
            this.naslov = naslov;
            this.tekst = tekst;
            this.datumOD = datumOD;
            this.datumDO = datumDO;
            this.vreme = vreme;
        }
    }
}

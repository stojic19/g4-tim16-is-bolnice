using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class ReceptDTO
    {
        private String idRecepta;
        private DateTime datum;
        private LekDTO lek;


        public String IdRecepta
        {
            get { return idRecepta; }
            set { idRecepta = value; }
        }
        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        public LekDTO Lek
        {
            get { return lek; }
            set { lek = value; }
        }
        ReceptDTO() { }

        public ReceptDTO(string idRecepta, DateTime datum, LekDTO lek)
        {
            this.idRecepta = idRecepta;
            this.datum = datum;
            this.lek = lek;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class BeleskaDTO
    {
        private DateTime datum;
        private String tekst;
        private String idBeleske;
        private AnamnezaDTO anamneza;

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        public String Tekst
        {
            get { return tekst; }
            set { tekst = value; }
        }
        public String IdBeleske
        {
            get { return idBeleske; }
            set { idBeleske = value; }
        }
        public AnamnezaDTO Anamneza
        {
            get { return anamneza; }
            set { anamneza = value; }
        }

        public BeleskaDTO(DateTime datum, string tekst, string idBeleske, AnamnezaDTO anamneza)
        {
            this.datum = datum;
            this.tekst = tekst;
            this.idBeleske = idBeleske;
            this.anamneza = anamneza;
        }

        public BeleskaDTO() { }
    }
}

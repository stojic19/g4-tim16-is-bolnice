using Bolnica.Model.Enumi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class ZahtjevDTO
    {
        private String idZahtjeva;
        private LekDTO lek;
        private VrsteOdgovora odgovor;
        private String razlogOdbijanja;
        private DateTime datumSlanja;

        public String IDZahtjeva
        {
            get { return idZahtjeva; }
            set { idZahtjeva = value; }
        }

        public LekDTO Lek
        {
            get { return lek; }
            set { lek = value; }
        }

        public VrsteOdgovora Odgovor
        {
            get { return odgovor; }
            set { odgovor = value; }
        }

        public String RazlogOdbijanja
        {
            get { return razlogOdbijanja; }
            set { razlogOdbijanja = value; }
        }

        public DateTime DatumSlanja
        {
            get { return datumSlanja; }
            set { datumSlanja = value; }
        }

        ZahtjevDTO() { }
        public ZahtjevDTO(string idZahtjeva, LekDTO lek, VrsteOdgovora odgovor, string razlogOdbijanja, DateTime datumSlanja)
        {
            this.idZahtjeva = idZahtjeva;
            this.lek = lek;
            this.odgovor = odgovor;
            this.razlogOdbijanja = razlogOdbijanja;
            this.datumSlanja = datumSlanja;
        }

        public ZahtjevDTO(string idZahtjeva, LekDTO lek, DateTime datumSlanja)
        {
            this.idZahtjeva = idZahtjeva;
            this.lek = lek;
            this.datumSlanja = datumSlanja;
        }
    }
}

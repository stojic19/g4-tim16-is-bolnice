using Bolnica.Model.Enumi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    class ZahtevDTO
    {
        private String idZahteva;
        private LekDTO lek;
        private VrsteOdgovora odgovor;
        private String razlogOdbijanja;
        private DateTime datumSlanja;

        public String IDZahteva
        {
            get { return idZahteva; }
            set { idZahteva = value; }
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

        public ZahtevDTO(string idZahteva, LekDTO lek, VrsteOdgovora odgovor, string razlogOdbijanja, DateTime datumSlanja)
        {
            this.idZahteva = idZahteva;
            this.lek = lek;
            this.odgovor = odgovor;
            this.razlogOdbijanja = razlogOdbijanja;
            this.datumSlanja = datumSlanja;
        }
    }
}

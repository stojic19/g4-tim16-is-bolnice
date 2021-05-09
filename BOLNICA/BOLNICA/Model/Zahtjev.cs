using Bolnica.Model.Enumi;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Zahtjev
    {
        public String IdZahtjeva { get; set; }
        public Lek Lijek { get; set; }
        public VrsteOdgovora Odgovor { get; set; }
        public String RazlogOdbijanja { get; set; }
        public DateTime DatumSlanja { get; set; }


        public Zahtjev(String idZahtjeva, Lek lijek, String razlogOdobrenja, DateTime datumSlanja)
        {
            IdZahtjeva = idZahtjeva;
            Lijek = lijek;
            Odgovor = VrsteOdgovora.Čekanje;
            RazlogOdbijanja = razlogOdobrenja;
            datumSlanja = datumSlanja;
        }

        public Zahtjev() { }
    }
}

using Bolnica.DTO;
using Bolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class ZahtjevKonverter
    {
        LekKonverter lekKonverter = new LekKonverter();
        public ZahtjevDTO ZahtjevModelUDTO(Zahtjev zahtjev)
        {
            return new ZahtjevDTO(zahtjev.IdZahtjeva, lekKonverter.LekModelUDTO(zahtjev.Lijek), zahtjev.Odgovor, zahtjev.RazlogOdbijanja, zahtjev.DatumSlanja);
        }
        public Zahtjev ZahtjevDTOUModel(ZahtjevDTO zahtjev)
        {
            return new Zahtjev(zahtjev.IDZahtjeva, lekKonverter.LekDTOUModel(zahtjev.Lek), zahtjev.RazlogOdbijanja, zahtjev.DatumSlanja);
        }

    }
}

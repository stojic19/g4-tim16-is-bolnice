using Bolnica.DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class LekKonverter
    {
        public LekDTO LekModelULekDTO(Lek lek)
        {
            return new LekDTO(lek.IDLeka, lek.NazivLeka, lek.Jacina);
        }
        public Lek LekDTOUModel(LekDTO lek)
        {
            return new Lek(lek.IdLeka, lek.NazivLeka, lek.Jacina);
        }

        public LekDTO LekSaKolicinomDTO(Lek lek)
        {
            return new LekDTO(lek.IDLeka, lek.NazivLeka, lek.Jacina, lek.Kolicina);
        }

        public Lek LekSaKolicinomModel(LekDTO lek)
        {
            return new Lek(lek.IdLeka, lek.NazivLeka, lek.Jacina, lek.Kolicina);
        }
    }
}

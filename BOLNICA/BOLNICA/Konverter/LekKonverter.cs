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
    }
}

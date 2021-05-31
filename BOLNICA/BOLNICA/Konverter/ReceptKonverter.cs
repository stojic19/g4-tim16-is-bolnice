using Bolnica.DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class ReceptKonverter
    {
        public ReceptDTO ReceptModelUDTO(Recept recept)
        {
            LekKonverter lekKonverter = new LekKonverter();
            return new ReceptDTO(recept.IDRecepta, recept.Datum, lekKonverter.LekModelULekDTO(recept.Lek));
        }
    }
}

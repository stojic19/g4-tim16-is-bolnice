using Bolnica.DTO;
using Bolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class BeleskaKonverter
    {
        public BeleskaDTO BeleskaModelUBeleskaDTO(Beleska beleska)
        {
            AnamnezaKonverter anamnezaKonverter = new AnamnezaKonverter();
            return new BeleskaDTO(beleska.Datum,beleska.Tekst,beleska.IdBeleske,anamnezaKonverter.AnamnezaModelUDTO(beleska.Anamneza));
        }

        public Beleska BeleskaDTOUBeleskaModel(BeleskaDTO beleska)
        {
            AnamnezaKonverter anamnezaKonverter = new AnamnezaKonverter();
            return new Beleska(beleska.Datum, beleska.Tekst, beleska.IdBeleske, anamnezaKonverter.AnamnezaDTOUModel(beleska.Anamneza));
        }
    }
}

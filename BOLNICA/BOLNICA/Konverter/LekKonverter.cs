using Bolnica.DTO;
using Bolnica.Model;
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
        SastojciKonverter sastojciKonverter = new SastojciKonverter();
        public LekDTO LekModelULekDTO(Lek lek)
        {
            return new LekDTO(lek.IDLeka, lek.NazivLeka, lek.Jacina);
        }
        public Lek LekDTOULekModel(LekDTO lek)
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

        public LekDTO LekModelUDTO(Lek lek)
        {
            List<SastojakDTO> sastojci = new List<SastojakDTO>();
            foreach (Sastojak s in lek.Sastojci)
                sastojci.Add(sastojciKonverter.SastojakModelUDTO(s));
            return new LekDTO(lek.IDLeka, lek.NazivLeka, lek.Jacina, lek.Kolicina, sastojci, lek.Proizvodjac);
        }

        public Lek LekDTOUModel(LekDTO lek)
        {
            List<Sastojak> sastojci = new List<Sastojak>();
            foreach (SastojakDTO s in lek.Sastojci)
                sastojci.Add(sastojciKonverter.SastojakDTOuModel(s));
            return new Lek(lek.IdLeka, lek.NazivLeka, lek.Jacina, lek.Kolicina, sastojci, lek.Proizvodjac);
        }
    }
}

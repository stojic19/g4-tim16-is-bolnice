using Bolnica.DTO;
using Bolnica.Model;
using Model;

namespace Bolnica.Konverter
{
    public class SastojciKonverter
    {
        public SastojakDTO SastojakModelUDTO(Sastojak sastojak)
        {
            return new SastojakDTO(sastojak.Naziv, sastojak.Kolicina);
        }

        public Sastojak SastojakDTOuModel(SastojakDTO sastojak)
        {
            return new Sastojak(sastojak.Naziv, sastojak.Kolicina);
        }
    }
}

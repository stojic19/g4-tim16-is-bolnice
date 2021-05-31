using Bolnica.DTO;
using Model;

namespace Bolnica.Konverter
{
    public class ReceptKonverter
    {
        LekKonverter lekKonverter = new LekKonverter();

        public ReceptDTO ReceptModelUDTO(Recept recept)
        {
            return new ReceptDTO(recept.IDRecepta, recept.Datum, lekKonverter.LekModelULekDTO(recept.Lek));
        }

        public Recept ReceptDTOuModel(ReceptDTO recept)
        {
            return new Recept(recept.IdRecepta, recept.Datum, lekKonverter.LekDTOUModel(recept.Lek));
        }
    }
}

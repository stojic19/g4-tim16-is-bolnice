using Bolnica.DTO;
using Bolnica.Konverter;
using Bolnica.Model.Rukovanja;
using Bolnica.Servis;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Kontroler
{
    class AlergeniKontroler
    {
        AlergeniServis alergeniServis;
        LekoviServis lekoviServis = new LekoviServis();
        AlergeniKonverter alergeniKonverter = new AlergeniKonverter();
        LekKonverter lekKonverter = new LekKonverter();
        public AlergeniKontroler(String idPacijenta)
        {
            alergeniServis = new AlergeniServis(idPacijenta);
        }
        public List<LekDTO> DobaviLekoveZaDodavanje()
        {
            List<LekDTO> lekovi = new List<LekDTO>();
            foreach (Lek lek in lekoviServis.DobaviSveLekove())
                lekovi.Add(lekKonverter.LekModelULekDTO(lek));
            return lekovi;
        }
        public List<AlergeniPrikazDTO> DobaviAlergene()
        {
            List<AlergeniPrikazDTO> alergeniPacijenta = new List<AlergeniPrikazDTO>();
            foreach (Alergeni alergen in alergeniServis.DobaviSve())
                alergeniPacijenta.Add(alergeniKonverter.AlergeniModelPrikazUDTO(alergen));
            return alergeniPacijenta;
        }

        public void UkloniAlergen(string idAlergena)
        {
            Alergeni alergen = alergeniServis.PretraziPoId(idAlergena);
            alergeniServis.Ukloni(alergen);
        }

        public AlergenDTO DobaviAlergenPacijentaPoId(string idAlergena)
        {
            return alergeniKonverter.AlergeniModelUDTO(alergeniServis.PretraziPoId(idAlergena));
        }
        public void DodajAlergen(AlergenDTO alergenZaDodavanje)
        {
            alergeniServis.Dodaj(alergeniKonverter.AlergenDTOUModel(alergenZaDodavanje));
        }

        public void IzmeniAlergen(AlergenDTO alergenZaIzmenu)
        {
            alergeniServis.Izmeni(alergenZaIzmenu.IdAlergena, alergeniKonverter.AlergenDTOUModel(alergenZaIzmenu));
        }

        public bool DaLiLekVecPostojiUAlergenimaPacijenta(string idLeka)
        {
            return alergeniServis.DaLiLekVecPostojiUAlergenimaPacijenta(idLeka);
        }
    }
}

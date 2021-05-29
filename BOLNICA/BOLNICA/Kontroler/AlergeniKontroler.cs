using Bolnica.DTO;
using Bolnica.Konverter;
using Bolnica.Model.Rukovanja;
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
        NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();
        LekoviServis lekoviServis = new LekoviServis();
        AlergeniKonverter alergeniKonverter = new AlergeniKonverter();
        LekKonverter lekKonverter = new LekKonverter();
        public List<LekDTO> DobaviLekoveZaDodavanje()
        {
            List<LekDTO> lekovi = new List<LekDTO>();
            foreach (Lek lek in lekoviServis.DobaviSveLekove())
                lekovi.Add(lekKonverter.LekModelULekDTO(lek));
            return lekovi;
        }
        public List<AlergeniPrikazDTO> DobaviAlergenePoIdPacijenta(String idPacijenta)
        {
            List<AlergeniPrikazDTO> alergeniPacijenta = new List<AlergeniPrikazDTO>();
            foreach (Alergeni alergen in naloziPacijenataServis.DobaviAlergenePoIdPacijenta(idPacijenta))
                alergeniPacijenta.Add(alergeniKonverter.AlergeniModelPrikazUDTO(alergen));
            return alergeniPacijenta;
        }

        public void UkloniAlergen(string izabranPacijent, string idAlergena)
        {
            Alergeni alergen = naloziPacijenataServis.DobaviAlergenPacijentaPoId(izabranPacijent, idAlergena);
            naloziPacijenataServis.UkloniAlergen(izabranPacijent, alergen);
        }

        public AlergenDTO DobaviAlergenPacijentaPoId(string izabranPacijent, string idAlergena)
        {
            return alergeniKonverter.AlergeniModelUDTO(naloziPacijenataServis.DobaviAlergenPacijentaPoId(izabranPacijent, idAlergena));
        }
        public void DodajAlergen(string izabranPacijent, AlergenDTO alergenZaDodavanje)
        {
            naloziPacijenataServis.DodajAlergen(izabranPacijent, alergeniKonverter.AlergenDTOUModel(alergenZaDodavanje));
        }

        public void IzmeniAlergen(string izabranPacijent, AlergenDTO alergenZaIzmenu)
        {
            naloziPacijenataServis.IzmeniAlergen(izabranPacijent, alergeniKonverter.AlergenDTOUModel(alergenZaIzmenu));
        }

        public AlergenDTO AlergeniPrikazDTOUAlergeniDTO(AlergeniPrikazDTO alergeniPrikazDTO)
        {
            return alergeniKonverter.AlergeniPrikazDTOUAlergenDTO(alergeniPrikazDTO);
        }

        public bool DaLiLekVecPostojiUAlergenimaPacijenta(string idPacijenta, string idLeka)
        {
            return naloziPacijenataServis.DaLiLekVecPostojiUAlergenimaPacijenta(idPacijenta, idLeka);
        }
    }
}

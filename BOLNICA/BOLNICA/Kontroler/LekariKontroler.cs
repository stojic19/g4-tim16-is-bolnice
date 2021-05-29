using Bolnica.DTO;
using Bolnica.Konverter;
using Bolnica.Servis;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Kontroler
{
    class LekariKontroler
    {
        LekariServis lekariServis = new LekariServis();
        LekarKonverter lekarKonverter = new LekarKonverter();

        public List<Lekar> DobaviSveLekare()
        {
            return lekariServis.SviLekari();
        }

        public List<LekarDTO> DobaviSveLekareDTO()
        {
            List<LekarDTO> sviLekari = new List<LekarDTO>();

            foreach (Lekar lekar in lekariServis.SviLekari())
            {
                sviLekari.Add(lekarKonverter.LekarZaZakazivanjeUDTO(lekar));
            }
            return sviLekari;
        }
        public List<Lekar> DobaviSpecijaliste()
        {
            return lekariServis.DobaviSpecijaliste();
        }
        public String ImeiPrezime(String idLekara)
        {
            return lekariServis.ImeiPrezime(idLekara);
        }
        public Lekar PretraziPoId(String idLekara)
        {
            return lekariServis.PretraziPoId(idLekara);
        }
        public List<LekarDTO> DobaviLekareOpstePrakse()
        {
            List<LekarDTO> lekariOpstePrakse = new List<LekarDTO>();
            foreach (Lekar lekar in lekariServis.DobaviLekareOpstePrakse())
                lekariOpstePrakse.Add(lekarKonverter.LekarModelUDTO(lekar));
            return lekariOpstePrakse;
        }
    }
}

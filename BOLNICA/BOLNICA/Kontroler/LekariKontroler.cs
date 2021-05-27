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
        LekariServis lekariServis= new LekariServis();
        
        public List<Lekar> DobaviSveLekare()
        {
            return lekariServis.SviLekari();
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
    }
}

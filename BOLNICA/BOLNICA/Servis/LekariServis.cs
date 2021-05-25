using Bolnica.Model;
using Bolnica.Repozitorijum;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Servis
{
    class LekariServis
    {
        LekariRepozitorijum lekariRepozitorijum = new LekariRepozitorijum();

        public Lekar PretraziPoId(String idLekara)
        {
            return lekariRepozitorijum.PretraziPoId("//ArrayOfLekar/Lekar[KorisnickoIme='" + idLekara + "']");
        }
        public List<Lekar> SviLekari()
        {
            return lekariRepozitorijum.DobaviSveObjekte();
        }
        public void IzmeniLekara(Lekar lekar)
        {
            lekariRepozitorijum.IzmeniLekara(lekar);
        }
        public List<RadniDan> DobaviRadneDanePoIdLekara(string idLekara)
        {
            return PretraziPoId(idLekara).DobaviRadneDane();
        }
        public List<Odsustvo> DobaviOdsustvoPoIdLekara(string idLekara)
        {
            return PretraziPoId(idLekara).DobaviSlobodneDane();
        }
    }
}

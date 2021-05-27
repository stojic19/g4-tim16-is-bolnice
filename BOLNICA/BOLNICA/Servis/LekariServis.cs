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
        public List<Lekar> DobaviSpecijaliste()
        {
            List<Lekar> specijaliste = new List<Lekar>();
            foreach (Lekar l in SviLekari())
            {
                if (l.Specijalizacija != SpecijalizacijeLekara.nema) specijaliste.Add(l);
            }
            return specijaliste;
        }
        public String ImeiPrezime(String id)
        {
            foreach (Lekar l in SviLekari())
            {

                if (l.KorisnickoIme.Equals(id))
                {
                    return l.Ime + " " + l.Prezime;
                }
            }

            return null;
        }
    }
}

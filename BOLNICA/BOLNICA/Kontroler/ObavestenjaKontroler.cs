using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Kontroler
{
    class ObavestenjaKontroler
    {
        ObavestenjaServis obavestenjaServis = new ObavestenjaServis();

        public List<Obavestenje> DobaviSvaObavestenja()
        {
            return obavestenjaServis.SvaObavestenja();
        }

        public void DodajObavestenje(Obavestenje obavestenje)
        {
            obavestenjaServis.DodajObavestenje(obavestenje);
        }

        public void DodajObavestenjePacijentu(Obavestenje obavestenje)
        {
            obavestenjaServis.DodajObavestenjePacijentu(obavestenje);
        }

        public Obavestenje PretraziPoId(string idObavestenja)
        {
            return obavestenjaServis.PretraziObavestenjaPoId(idObavestenja);
        }

        public void UkolniObavestenje(string izabranoZaUklanjanje)
        {
            obavestenjaServis.UkolniObavestenje(izabranoZaUklanjanje);
        }

        public string[] DobaviPrimaoceZaObavestenje(string izabranoObavestenje)
        {
            return PretraziPoId(izabranoObavestenje).DobaviPrimaoce();
        }

        public void IzmeniObavestenje(Obavestenje obavestenje)
        {
            obavestenjaServis.IzmeniObavestenje(obavestenje);
        }
        public Obavestenje PretraziObavestenjaPoId(String idObavestenja)
        {
            return obavestenjaServis.PretraziObavestenjaPoId(idObavestenja);
        }
        public List<Obavestenje> DobaviSvaObavestenjaOsobe(String IdOsobe)
        {
            return obavestenjaServis.DobaviSvaObavestenjaOsobe(IdOsobe);
        }
    }
}

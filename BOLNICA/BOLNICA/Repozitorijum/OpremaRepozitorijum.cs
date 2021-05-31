using Bolnica.Repozitorijum.Interfejsi;
using Model;
using System;

namespace Bolnica.Repozitorijum
{
    public class OpremaRepozitorijum : GlavniRepozitorijum<Oprema>, OpremaRepozitorijumInterfejs
    {
        public OpremaRepozitorijum()
        {
            imeFajla = "oprema.xml";
        }

        public Oprema PretraziOpremuPoId(String idOpreme)
        {
            return PretraziPoId("//ArrayOfOprema/Oprema[IdOpreme='" + idOpreme + "']");
        }


        public void IzmenaOpreme(Oprema noviPodaci)
        {
            ObrisiObjekat("//ArrayOfOprema/Oprema[IdOpreme='" + noviPodaci.IdOpreme + "']");
            DodajObjekat(noviPodaci);
        }
    }
}
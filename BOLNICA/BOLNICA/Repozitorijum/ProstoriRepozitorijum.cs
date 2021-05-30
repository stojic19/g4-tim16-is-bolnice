using Bolnica.Repozitorijum.Interfejsi;
using Model;
using System;

namespace Bolnica.Repozitorijum
{
    public class ProstoriRepozitorijum : GlavniRepozitorijum<Prostor>, ProstoriRepozitorijumInterfejs
    {
        public ProstoriRepozitorijum()
        {
            imeFajla = "prostori.xml";
        }

        public Prostor PretraziProstorPoId(String idProstora)
        {
            return PretraziPoId("//ArrayOfProstor/Prostor[IdProstora='" + idProstora + "']");
        }


        public void IzmenaProstora(Prostor noviPodaci)
        {
            ObrisiObjekat("//ArrayOfProstor/Prostor[IdProstora='" + noviPodaci.IdProstora + "']");
            DodajObjekat(noviPodaci);
        }
    }
}
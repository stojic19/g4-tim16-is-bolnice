using Bolnica.Model;
using Bolnica.Repozitorijum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Servis
{
    public class BeleskaServis
    {
        private BeleskaRepozitorijum beleskaRepozitorijum = new BeleskaRepozitorijum();

        public String PronadjiTekstBeleske(String idAnamneze)
        {
            Beleska beleska= beleskaRepozitorijum.PretraziBeleskuPoAnamnezi(idAnamneze);
            if (beleska == null)
                return "";
            return beleska.Tekst;
        }
        public void SacuvajBelesku(Beleska beleska)
        {
            beleskaRepozitorijum.DodajObjekat(beleska);
        }
    }
}

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


        public void SacuvajBelesku(Beleska beleska)
        {
            beleskaRepozitorijum.DodajObjekat(beleska);
        }

        public void IzmeniBelesku(Beleska beleska)
        {
            beleskaRepozitorijum.ObrisiBelesku(beleska.IdBeleske);
            beleskaRepozitorijum.DodajObjekat(beleska);
        }

        public Beleska PretraziBeleskePoIdAnaneze(String idAnamneze)
        {
            return beleskaRepozitorijum.PretraziBeleskuPoAnamnezi(idAnamneze);
        }
    }
}

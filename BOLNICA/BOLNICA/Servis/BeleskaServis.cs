using Bolnica.Model;
using Bolnica.Repozitorijum;
using Bolnica.Repozitorijum.Factory;
using Bolnica.Repozitorijum.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Servis
{
    public class BeleskaServis
    {
        private BeleskaRepozitorijumInterfejs beleskaRepozitorijum = BeleskaFactory.DobaviRepozitorijum();

        public void SacuvajBelesku(Beleska beleska)
        {
            beleskaRepozitorijum.DodajObjekat(beleska);
        }

        public void IzmeniBelesku(Beleska beleska)
        {
            beleskaRepozitorijum.ObrisiBelesku(beleska.Id);
            beleskaRepozitorijum.DodajObjekat(beleska);
        }

        public Beleska PretraziBeleskePoIdAnaneze(String idAnamneze)
        {
            return beleskaRepozitorijum.PretraziBeleskuPoAnamnezi(idAnamneze);
        }
    }
}

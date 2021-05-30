using Bolnica.DTO;
using Bolnica.Konverter;
using Bolnica.Model;
using Bolnica.Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Kontroler
{
    public class BeleskaKontroler
    {
        BeleskaServis beleskaServis = new BeleskaServis();
        BeleskaKonverter beleskaKonverter = new BeleskaKonverter();


        public void SacuvajBelesku(BeleskaDTO beleska)
        {
            beleskaServis.SacuvajBelesku(beleskaKonverter.BeleskaDTOUBeleskaModel(beleska));
        }
        public void IzmeniBelesku(BeleskaDTO beleska)
        {
            Beleska beleskaZaIzmenu = beleskaKonverter.BeleskaDTOUBeleskaModel(beleska);
            beleskaServis.IzmeniBelesku(beleskaZaIzmenu);
        }

        public BeleskaDTO PretraziBeleskePoIdAnamneze(String idAnamneze)
        {
            Beleska beleska = beleskaServis.PretraziBeleskePoIdAnaneze(idAnamneze);
            if (beleska != null)
                return beleskaKonverter.BeleskaModelUBeleskaDTO(beleska);
            return null;
        }
    }
}

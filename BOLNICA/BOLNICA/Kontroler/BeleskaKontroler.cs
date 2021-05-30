using Bolnica.DTO;
using Bolnica.Konverter;
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

        public String PronadjiTekstBeleske(String idAnamneze)
        {
            return beleskaServis.PronadjiTekstBeleske(idAnamneze);
        }
        public void SacuvajBelesku(BeleskaDTO beleska)
        {
            beleskaServis.SacuvajBelesku(beleskaKonverter.BeleskaDTOUBeleskaModel(beleska));
        }
    }
}

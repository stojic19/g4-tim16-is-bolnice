using Bolnica.DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class TerapijaKonverter
    {
        public TerapijaDTO TerapijaModelUDTO(Terapija terapija)
        {
            LekKonverter lekKonverter = new LekKonverter();
            return new TerapijaDTO(terapija.IDTerapije, terapija.IDAnamneze, terapija.PocetakTerapije,
                terapija.KrajTerapije, terapija.Kolicina, terapija.Satnica, terapija.UputsvoKonzumiranja,
                lekKonverter.LekModelULekDTO(terapija.PreporucenLek));
        }
    }
}

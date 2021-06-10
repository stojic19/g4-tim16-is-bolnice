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
    class RadniDanLekaraKontroler
    {
        RadniDaniLekaraServis rasporedLekaraServis;
        
        RadniDanKonverter radniDanKonverter = new RadniDanKonverter();

        public RadniDanLekaraKontroler(String idLekara)
        {
            rasporedLekaraServis = new RadniDaniLekaraServis(idLekara);
            ProveriDaLiTrebaDodatiDaneZaGodisnji();
        }
        private void ProveriDaLiTrebaDodatiDaneZaGodisnji()
        {
            rasporedLekaraServis.ProveriDaLiTrebaDodatiDaneZaGodisnji();
        }
        public void UkloniRadniDan(RadniDanDTO radniDan)
        {
            rasporedLekaraServis.Ukloni(radniDan);
        }
        public void PromeniSmenu(String idRadnogDana, RadniDanDTO radniDan)
        {
            rasporedLekaraServis.Izmeni(idRadnogDana, radniDan);
        }
        public void DodajRadneDane(RadniDanDTO radniDan)
        {
            rasporedLekaraServis.Dodaj(radniDan);
        }
        public bool DaLiJeMoguceRaditiUZadatomPeriodu(RadniDanDTO radniDan)
        {
            return rasporedLekaraServis.DaLiJeMoguceRaditiUZadatomPeriodu(radniDanKonverter.RadniDanDTOUModel(radniDan));
        }
        public List<RadniDanDTO> DobaviRadneDane()
        {
            return rasporedLekaraServis.DobaviSve();
        }
        public bool DaLiJeMogucePromenitiSmenu(RadniDanDTO radniDanZaPromenuSmene)
        {
            return rasporedLekaraServis.DaLiJeMogucePromenitiSmenu(radniDanKonverter.RadniDanDTOUModel(radniDanZaPromenuSmene));
        }
    }
}

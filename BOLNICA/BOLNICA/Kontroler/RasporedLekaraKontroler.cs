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
    class RasporedLekaraKontroler
    {
        RasporedLekaraServis rasporedLekaraServis = new RasporedLekaraServis();
        RadniDanKonverter radniDanKonverter = new RadniDanKonverter();
        OdsustvoKonverter odsustvoKonverter = new OdsustvoKonverter();

        public RasporedLekaraKontroler()
        {
            ProveriDaLiTrebaDodatiDaneZaGodisnji();
        }
        private void ProveriDaLiTrebaDodatiDaneZaGodisnji()
        {
            rasporedLekaraServis.ProveriDaLiTrebaDodatiDaneZaGodisnji();
        }
        public void UkloniRadniDan(String idLekara, RadniDanDTO radniDan)
        {
            rasporedLekaraServis.UkloniRadniDan(idLekara, radniDanKonverter.RadniDanDTOUModel(radniDan));
        }
        public void PromeniSmenu(String idLekara, RadniDanDTO radniDan, string smena)
        {
            rasporedLekaraServis.PromeniSmenu(idLekara, radniDanKonverter.RadniDanDTOUModel(radniDan), smena);
        }
        public void DodajRadneDane(String idLekara, RadniDanDTO radniDan, string smena)
        {
            rasporedLekaraServis.DodajRadneDane(idLekara, radniDanKonverter.RadniDanDTOUModel(radniDan), smena);
        }
        public void DodajSlobodneDane(String idLekara, OdsustvoDTO odsustvo)
        {
            rasporedLekaraServis.DodajSlobodneDane(idLekara, odsustvoKonverter.OdsustvoDTOUModel(odsustvo));
        }
        public void UkloniSlobodneDane(String idLekara, OdsustvoDTO odsustvo)
        {
            rasporedLekaraServis.UkloniSlobodneDane(idLekara, odsustvoKonverter.OdsustvoDTOUModel(odsustvo));
        }
        public void IzmeniSlobodneDane(String idLekara, OdsustvoDTO staroOdsustvo, OdsustvoDTO novoOdsustvo)
        {
            rasporedLekaraServis.IzmeniSlobodneDane(idLekara, odsustvoKonverter.OdsustvoDTOUModel(staroOdsustvo), odsustvoKonverter.OdsustvoDTOUModel(novoOdsustvo));
        }
        public bool DaLiJeMogucGodisnjiUZadatomPeriodu(String idLekara, OdsustvoDTO odsustvo)
        {
            return rasporedLekaraServis.DaLiJeMogucGodisnjiUZadatomPeriodu(idLekara, odsustvoKonverter.OdsustvoDTOUModel(odsustvo));
        }
        public bool DaLiJeMoguceRaditiUZadatomPeriodu(string idLekara, RadniDanDTO radniDan)
        {
            return rasporedLekaraServis.DaLiJeMoguceRaditiUZadatomPeriodu(idLekara, radniDanKonverter.RadniDanDTOUModel(radniDan));
        }
        public List<RadniDanDTO> DobaviRadneDanePoIdLekara(string idLekara)
        {
            List<RadniDanDTO> radniDani = new List<RadniDanDTO>();
            foreach(RadniDan radniDan in rasporedLekaraServis.DobaviRadneDanePoIdLekara(idLekara))
            {
                radniDani.Add(radniDanKonverter.RadniDanModelUDTO(radniDan));
            }
            return radniDani;
        }
        public List<OdsustvoDTO> DobaviOdsustvoPoIdLekara(string idLekara)
        {
            List<OdsustvoDTO> odsustva = new List<OdsustvoDTO>();
            foreach (Odsustvo odsustvo in rasporedLekaraServis.DobaviOdsustvoPoIdLekara(idLekara))
            {
                odsustva.Add(odsustvoKonverter.OdsustvoModelUDTO(odsustvo));
            }
            return odsustva;
        }

        public bool DaLiJeMogucePromenitiSmenu(RadniDanDTO radniDanZaPromenuSmene)
        {
            return rasporedLekaraServis.DaLiJeMogucePromenitiSmenu(radniDanKonverter.RadniDanDTOUModel(radniDanZaPromenuSmene));
        }
    }
}

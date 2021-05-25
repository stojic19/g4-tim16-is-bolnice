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
        public void UkloniRadniDan(String idLekara, RadniDan radniDan)
        {
            rasporedLekaraServis.UkloniRadniDan(idLekara, radniDan);
        }
        public void PromeniSmenu(String idLekara, RadniDan radniDan, string smena)
        {
            rasporedLekaraServis.PromeniSmenu(idLekara, radniDan, smena);
        }
        public void DodajRadneDane(String idLekara, RadniDan radniDan, string smena)
        {
            rasporedLekaraServis.DodajRadneDane(idLekara, radniDan, smena);
        }
        public void DodajSlobodneDane(String idLekara, Odsustvo odsustvo)
        {
            rasporedLekaraServis.DodajSlobodneDane(idLekara, odsustvo);
        }
        public void UkloniSlobodneDane(String idLekara, Odsustvo odsustvo)
        {
            rasporedLekaraServis.UkloniSlobodneDane(idLekara, odsustvo);
        }
        public void IzmeniSlobodneDane(String idLekara, Odsustvo staroOdsustvo, Odsustvo novoOdsustvo)
        {
            rasporedLekaraServis.IzmeniSlobodneDane(idLekara, staroOdsustvo, novoOdsustvo);
        }
        public bool DaLiJeMogucGodisnjiUZadatomPeriodu(String idLekara, Odsustvo odsustvo)
        {
            return rasporedLekaraServis.DaLiJeMogucGodisnjiUZadatomPeriodu(idLekara, odsustvo);
        }
        public bool DaLiJeMoguceRaditiUZadatomPeriodu(string idLekara, RadniDan radniDan)
        {
            return rasporedLekaraServis.DaLiJeMoguceRaditiUZadatomPeriodu(idLekara, radniDan);
        }
        public List<RadniDan> DobaviRadneDanePoIdLekara(string idLekara)
        {
            return rasporedLekaraServis.DobaviRadneDanePoIdLekara(idLekara);
        }
        public List<Odsustvo> DobaviOdsustvoPoIdLekara(string idLekara)
        {
            return rasporedLekaraServis.DobaviOdsustvoPoIdLekara(idLekara);
        }
    }
}

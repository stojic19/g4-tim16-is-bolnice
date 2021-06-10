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
    class OdsustvoKontroler
    {
        OdsustvoLekaraServis odsustvoLekaraServis;
        OdsustvoKonverter odsustvoKonverter = new OdsustvoKonverter();

        public OdsustvoKontroler(String idLekara)
        {
            odsustvoLekaraServis = new OdsustvoLekaraServis(idLekara);
        }
        public void DodajSlobodneDane(OdsustvoDTO odsustvo)
        {
            odsustvoLekaraServis.Dodaj(odsustvoKonverter.OdsustvoDTOUModel(odsustvo));
        }
        public void UkloniSlobodneDane(OdsustvoDTO odsustvo)
        {
            odsustvoLekaraServis.Ukloni(odsustvoKonverter.OdsustvoDTOUModel(odsustvo));
        }
        public void IzmeniSlobodneDane(OdsustvoDTO novoOdsustvo)
        {
            odsustvoLekaraServis.Izmeni(odsustvoKonverter.OdsustvoDTOUModel(novoOdsustvo));
        }
        public bool DaLiJeMogucGodisnjiUZadatomPeriodu(OdsustvoDTO odsustvo)
        {
            return odsustvoLekaraServis.DaLiJeMogucGodisnjiUZadatomPeriodu(odsustvoKonverter.OdsustvoDTOUModel(odsustvo));
        }
        public List<OdsustvoDTO> DobaviOdsustvo()
        {
            List<OdsustvoDTO> odsustva = new List<OdsustvoDTO>();
            foreach (Odsustvo odsustvo in odsustvoLekaraServis.DobaviSve())
            {
                odsustva.Add(odsustvoKonverter.OdsustvoModelUDTO(odsustvo));
            }
            return odsustva;
        }
    }
}

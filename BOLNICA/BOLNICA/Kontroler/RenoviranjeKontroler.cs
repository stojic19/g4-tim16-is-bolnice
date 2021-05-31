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
    class RenoviranjeKontroler
    {
        RenoviranjeServis renoviranjeServis = new RenoviranjeServis();
        RenoviranjeKonverter renoviranjeKonverter = new RenoviranjeKonverter();

        public List<RenoviranjeDTO> SvaRenoviranja()
        {
            List<RenoviranjeDTO> renoviranje = new List<RenoviranjeDTO>();
            foreach (Renoviranje r in renoviranjeServis.SvaRenoviranja())
                renoviranje.Add(renoviranjeKonverter.RenoviranjeModelUDTO(r));
            return renoviranje;
        }
        public void DodajZaRenoviranje(RenoviranjeDTO renoviranje)
        {
            renoviranjeServis.DodajZaRenoviranje(renoviranjeKonverter.RenoviranjeDTOUModel(renoviranje));

        }

        public void ProveriRenoviranje()
        {
            renoviranjeServis.ProveriRenoviranje();
        }

        public void UkloniRenoviranje(RenoviranjeDTO renoviranje)
        {
            renoviranjeServis.UkloniRenoviranje(renoviranjeKonverter.RenoviranjeDTOUModel(renoviranje));
        }

        /*public bool provjeraDatuma(DateTime datumPocetka, DateTime datumKraja)
        {
            if (renoviranjeServis.provjeraDatuma(datumPocetka,datumKraja))
            {
                return true;
            }
            return false;
        }

        public void PostaviDaSeRenovira(Renoviranje r)
        {
            renoviranjeServis.PostaviDaSeRenovira(r);
        }

        public void PostaviDaSeNeRenovira(Renoviranje r)
        {
            renoviranjeServis.PostaviDaSeNeRenovira(r);
        }*/
    }
}

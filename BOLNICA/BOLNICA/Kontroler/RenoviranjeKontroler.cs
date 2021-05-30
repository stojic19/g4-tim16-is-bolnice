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

        public List<Renoviranje> SvaRenoviranja()
        {
            return renoviranjeServis.SvaRenoviranja();
        }
        public void DodajZaRenoviranje(Renoviranje renoviranje)
        {
            renoviranjeServis.DodajZaRenoviranje(renoviranje);

        }

        public void ProveriRenoviranje()
        {
            renoviranjeServis.ProveriRenoviranje();
        }

        public void UkloniRenoviranje(Renoviranje renoviranje)
        {
            renoviranjeServis.UkloniRenoviranje(renoviranje);
        }

        public bool provjeraDatuma(DateTime datumPocetka, DateTime datumKraja)
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
        }
    }
}

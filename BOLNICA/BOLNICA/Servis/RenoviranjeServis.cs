using Bolnica.Model;
using Bolnica.Repozitorijum;
using Bolnica.UpravnikFolder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bolnica.Servis
{
    class RenoviranjeServis
    {
        RenoviranjeRepozitorijum renoviranjeRepozitorijum = new RenoviranjeRepozitorijum();

        public List<Renoviranje> SvaRenoviranja()
        {
            return renoviranjeRepozitorijum.DobaviSveObjekte();
        }
        public void DodajZaRenoviranje(Renoviranje renoviranje)
        {
            renoviranjeRepozitorijum.DodajObjekat(renoviranje);
 
        }

       

        public  void ProveriRenoviranje()
        {
            foreach (Renoviranje r in SvaRenoviranja())
            {
                if (provjeraDatuma(r.PocetniDatum.Date, r.DatumKraja.Date))
                {
                    PostaviDaSeRenovira(r);
                }
                else
                {
                    PostaviDaSeNeRenovira(r);
                }
            }
        }

        public void UkloniRenoviranje(Renoviranje renoviranje)
        {
            renoviranjeRepozitorijum.ObrisiRenoviranje(renoviranje.IdRenoviranja);
        }

        public bool provjeraDatuma(DateTime datumPocetka, DateTime datumKraja)
        {
            if (DateTime.Compare(datumPocetka.Date, DateTime.Now.Date) <= 0 && DateTime.Compare(DateTime.Now.Date, datumKraja.Date) <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void PostaviDaSeRenovira(Renoviranje r)
        {
            /* foreach (Prostor p in prostori)
             {
                 if (p.IdProstora.Equals(r.RoomId))
                 {
                     p.JeRenoviranje = true;
                     break;
                 }
             }*/
        }

        public  void PostaviDaSeNeRenovira(Renoviranje r)
        {
            /*  foreach (Prostor p in prostori)
              {
                  if (p.IdProstora.Equals(r.RoomId))
                  {
                      p.JeRenoviranje = false;
                      break;
                  }
              }*/
        }

    }
}

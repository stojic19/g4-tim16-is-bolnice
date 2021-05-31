using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Kontroler
{
    class ProstoriKontroler
    {
        ProstoriServis prostoriServis = new ProstoriServis();

        public void DodajProstor(Prostor p)
        {
            prostoriServis.DodajProstor(p);
        }

        public void IzmeniProstor(Prostor noviPodaci)
        {
            prostoriServis.IzmeniProstor(noviPodaci);
        }

        public void UkloniProstor(String idProstora)
        {
            prostoriServis.UkloniProstor(idProstora);
        }

        public Prostor PretraziProstorPoId(String idProstora)
        {
            return prostoriServis.PretraziPoId(idProstora);
        }

        public void ProvjeriDaLiJeProstorRenoviran()
        {
            prostoriServis.ProvjeriDaLiJeProstorRenoviran();
        }

        public List<Prostor> SviProstori()
        {
            return prostoriServis.SviProstori();
        }

        public void OduzmiKolicinuOpreme(Prostor prostorIzKojegPremjestamo,Oprema oprema, int kolicina)
        {
            prostoriServis.OduzmiKolicinuOpreme(prostorIzKojegPremjestamo, oprema, kolicina);
        }

        public void PremjestiOpremu(Prostor prostorUKojiPremjestamo,Oprema oprema, int kolicina)
        {
            prostoriServis.PremjestiOpremuUDrugiProstor(prostorUKojiPremjestamo, oprema, kolicina);
        }

        /*public void DodajSamoKolicinu(Prostor prostorUKojiPrebacujemo, Oprema oprema, int kolicina)
        {
            prostoriServis.DodajSamoKolicinu(prostorUKojiPrebacujemo, oprema, kolicina);
        }

        public void DodajOpremuProstoru(Prostor prostorUKojiPrebacujemo, Oprema oprema)
        {
            prostoriServis.DodajOpremuProstoru(prostorUKojiPrebacujemo, oprema);
        }*/

        public Boolean ProvjeriZakazaneTermine(DateTime pocetniDatum, DateTime zavrsniDatum)
        {
            if(prostoriServis.ProvjeriZakazaneTermine(pocetniDatum, zavrsniDatum))
            {
                return true;
            }
            return false;
        }
    }
}

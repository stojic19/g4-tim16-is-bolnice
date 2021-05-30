using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Kontroler
{
    class OpremaKontroler
    {
        OpremaServis opremaServis = new OpremaServis();

        public void DodajOpremu(Oprema o)
        {
            opremaServis.DodajOpremu(o);
        }

        public void IzmeniOpremu(Oprema novaOprema)
        {
            opremaServis.IzmeniOpremu(novaOprema);
        }

        public void UkloniOpremu(String idOpreme)
        {
            opremaServis.UkloniOpremu(idOpreme);
        }

        public Oprema PretraziPoId(String idOpreme)
        {
            return opremaServis.PretraziPoId(idOpreme);
        }

        public List<Oprema> SvaOprema()
        {
            return opremaServis.SvaOprema();
        }

        public void PremjestiKolicinuOpreme(Prostor prostorUKojiPrebacujemo, Oprema opremaKojuPrebacujemo, int kolicina)
        {
            opremaServis.PremjestiKolicinuOpreme(prostorUKojiPrebacujemo, opremaKojuPrebacujemo, kolicina);
        }

        public bool ProvjeriKolicinuKojuPremjestamo(Oprema oprema, int kolicina)
        {
            if (opremaServis.ProvjeriKolicinuKojuPremjestamo(oprema,kolicina))
            {
                return true;
            }
            return false;
        }
    }
}

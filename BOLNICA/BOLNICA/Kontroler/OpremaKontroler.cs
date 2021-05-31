using Bolnica.DTO;
using Bolnica.Konverter;
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
        ProstorKonverter prostorKonverter = new ProstorKonverter();
        OpremaKonverter opremaKonverter = new OpremaKonverter();

        public void DodajOpremu(OpremaDTO o)
        {
            opremaServis.DodajOpremu(opremaKonverter.OpremaDTOUModel(o));
        }

        public void IzmeniOpremu(OpremaDTO novaOprema)
        {
            opremaServis.IzmeniOpremu(opremaKonverter.OpremaDTOUModel(novaOprema));
        }

        public void UkloniOpremu(String idOpreme)
        {
            opremaServis.UkloniOpremu(idOpreme);
        }

        public Boolean ProvjeriValidnostNaziva(String nazivOpreme)
        {
            if (opremaServis.ProvjeriValidnostNaziva(nazivOpreme))
                return true;
            return false;
        }

        public OpremaDTO PretraziPoId(String idOpreme)
        {
            return opremaKonverter.OpremaModelUOpremaDTO(opremaServis.PretraziPoId(idOpreme));
        }

        public List<OpremaDTO> SvaOprema()
        {
            List<OpremaDTO> oprema = new List<OpremaDTO>();
            foreach (Oprema o in opremaServis.SvaOprema())
                oprema.Add(opremaKonverter.OpremaModelUOpremaDTO(o));
            return oprema;
        }

        public void PremjestiKolicinuOpreme(ProstorDTO prostorUKojiPrebacujemo, OpremaDTO opremaKojuPrebacujemo, int kolicina)
        {
            opremaServis.PremjestiKolicinuOpreme(prostorKonverter.ProstorDTOUModel(prostorUKojiPrebacujemo), opremaKonverter.OpremaDTOUModel(opremaKojuPrebacujemo), kolicina);
        }

        public bool ProvjeriKolicinuKojuPremjestamo(OpremaDTO oprema, int kolicina)
        {
            if (opremaServis.ProvjeriKolicinuKojuPremjestamo(opremaKonverter.OpremaDTOUModel(oprema),kolicina))
            {
                return true;
            }
            return false;
        }
    }
}

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
    class ProstoriKontroler
    {
        ProstoriServis prostoriServis = new ProstoriServis();
        ProstorKonverter prostorKonverter = new ProstorKonverter();
        OpremaKonverter opremaKonverter = new OpremaKonverter();

        public void DodajProstor(ProstorDTO p)
        {
            prostoriServis.DodajProstor(prostorKonverter.ProstorDTOUModel(p));
        }

        public void IzmeniProstor(ProstorDTO noviPodaci)
        {
            prostoriServis.IzmeniProstor(prostorKonverter.ProstorDTOUModel(noviPodaci));
        }

        public void UkloniProstor(String idProstora)
        {
            prostoriServis.UkloniProstor(idProstora);
        }

        public ProstorDTO PretraziProstorPoId(String idProstora)
        {
            return prostorKonverter.ProstorModelUProstorDTO(prostoriServis.PretraziPoId(idProstora));
        }

        public void ProvjeriDaLiJeProstorRenoviran()
        {
            prostoriServis.ProvjeriDaLiJeProstorRenoviran();
        }

        public List<ProstorDTO> SviProstori()
        {
            List<ProstorDTO> prostori = new List<ProstorDTO>();
            foreach (Prostor prostor in prostoriServis.SviProstori())
                prostori.Add(prostorKonverter.ProstorModelUProstorDTO(prostor));
            return prostori;
        }

        public void OduzmiKolicinuOpreme(ProstorDTO prostorIzKojegPremjestamo, OpremaDTO oprema, int kolicina)
        {
            prostoriServis.OduzmiKolicinuOpreme(prostorKonverter.ProstorDTOUModel(prostorIzKojegPremjestamo), opremaKonverter.OpremaDTOUModel(oprema), kolicina);
        }

        public void PremjestiOpremu(ProstorDTO prostorUKojiPremjestamo, OpremaDTO oprema, int kolicina)
        {
            prostoriServis.PremjestiOpremuUDrugiProstor(prostorKonverter.ProstorDTOUModel(prostorUKojiPremjestamo), opremaKonverter.OpremaDTOUModel(oprema), kolicina);
        }

        public Boolean ProvjeriValidnostNaziva(String nazivProstora)
        {
            if (prostoriServis.ProvjeriValidnostNaziva(nazivProstora))
                return true;
            return false;
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
            if (prostoriServis.ProvjeriZakazaneTermine(pocetniDatum, zavrsniDatum))
            {
                return true;
            }
            return false;
        }

        public List<ProstorDTO> DobaviSveSlobodneSobe(DateTime krajLecenja)
        {
            List<ProstorDTO> slobodneSobe = new List<ProstorDTO>();

            foreach (Prostor prostor in prostoriServis.DobaviSlobodneSobe(krajLecenja))
            {
                slobodneSobe.Add(prostorKonverter.ProstorModelUProstorDTO(prostor));
            }
            return slobodneSobe;

        }

        public void SmanjiBrojSlobodnihKreveta(String idProstora)
        {
            prostoriServis.SmanjiBrojSlobodnihKreveta(idProstora);
        }

        public Boolean DaLiSeSobaRenovira(String idProstora, DateTime krajLecenja)
        {
            return prostoriServis.ProveraRenoviranjaUBuducnosti(idProstora, krajLecenja);
        }

        public List<Prostor> DobaviProstoreModel()
        {
            return prostoriServis.SviProstori();
        }

        public List<Termin> DobaviZakazaneTermineZaVreme(DateTime datum)
        {
            return prostoriServis.DobaviZakazaneTermineZaVreme(datum);
        }
    }
}

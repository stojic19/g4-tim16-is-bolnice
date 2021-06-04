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
    class ObavestenjaKontroler
    {
        ObavestenjaServis obavestenjaServis = new ObavestenjaServis();
        ObavestenjeKonverter obavestenjeKonverter = new ObavestenjeKonverter();
        TerapijaKonverter terapijaKonverter = new TerapijaKonverter();

        public List<ObavestenjeDTO> DobaviSvaObavestenja()
        {
            List<ObavestenjeDTO> obavestenja = new List<ObavestenjeDTO>();
            foreach(Obavestenje obavestenje in obavestenjaServis.SvaObavestenja())
            {
                obavestenja.Add(obavestenjeKonverter.ObavestenjeModelUDTO(obavestenje));
            }
            return obavestenja;
        }

        public List<ObavestenjeDTO> DobaviSvaObavestenjaPacijenta(String korisnickoIme)
        {
            List<ObavestenjeDTO> obavestenja = new List<ObavestenjeDTO>();
            foreach (Obavestenje obavestenje in DobaviSvaObavestenjaOsobe(korisnickoIme))
            {
                obavestenja.Add(obavestenjeKonverter.ObavestenjeModelUDTO(obavestenje));
            }
            return PrikaziSamoObavestenjaUSadasnjosti(obavestenja);
        }
        private List<ObavestenjeDTO> PrikaziSamoObavestenjaUSadasnjosti(List<ObavestenjeDTO> obavestenja)
        {
            List<ObavestenjeDTO> obavestenjaUSadasnjosti = new List<ObavestenjeDTO>();
            foreach(ObavestenjeDTO obavestenje in obavestenja)
            {
                if (DateTime.Compare(DateTime.Now, obavestenje.Datum) >= 0)
                    obavestenjaUSadasnjosti.Add(obavestenje);
            }
            return obavestenjaUSadasnjosti;
        }

        public void DodajObavestenje(ObavestenjeDTO obavestenje)
        {
            obavestenjaServis.DodajObavestenje(obavestenjeKonverter.ObavestenjeDTOUModel(obavestenje));
        }

        public void DodajObavestenjePacijentu(Obavestenje obavestenje)
        {
            obavestenjaServis.DodajObavestenjePacijentu(obavestenje);
        }

        public ObavestenjeDTO PretraziPoId(string idObavestenja)
        {
            return obavestenjeKonverter.ObavestenjeModelUDTO(obavestenjaServis.PretraziObavestenjaPoId(idObavestenja));
        }

        public void UkolniObavestenje(string izabranoZaUklanjanje)
        {
            obavestenjaServis.UkolniObavestenje(izabranoZaUklanjanje);
        }

        public string[] DobaviPrimaoceZaObavestenje(string izabranoObavestenje)
        {
            return PretraziPoId(izabranoObavestenje).DobaviPrimaoce();
        }
        public void IzmeniObavestenje(ObavestenjeDTO obavestenje)
        {
            obavestenjaServis.IzmeniObavestenje(obavestenjeKonverter.ObavestenjeDTOUModel(obavestenje));
        }
        public List<Obavestenje> DobaviSvaObavestenjaOsobe(String IdOsobe)
        {
            return obavestenjaServis.DobaviSvaObavestenjaOsobe(IdOsobe);
        }
        public void DodajPodsetnikOAnamnezi(PodsetnikDTO podsetnik, String idPacijenta)
        {
            obavestenjaServis.DodajPodsetnikOAnamnezi(podsetnik, idPacijenta);
        }
       

        public void DodajObavestenjeOTerapiji(TerapijaDTO terapijaZaUpis, String korisnickoIme)
        {
            Terapija terapija = terapijaKonverter.TerapijaDTOUModel(terapijaZaUpis);
            obavestenjaServis.DodajObavestenjeOTerapiji(terapija, korisnickoIme);
        }
    }
}

using Bolnica.DTO;
using Bolnica.Konverter;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Kontroler
{
    class ZahtjeviKontroler
    {
        ZahtjeviServis zahtjeviServis = new ZahtjeviServis();
        ZahtjevKonverter zahtjevKonverter = new ZahtjevKonverter();
        LekKonverter lekKonverter = new LekKonverter();
        SastojciKonverter sastojciKonverter = new SastojciKonverter();
        public ZahtjevDTO PretraziPoId(String idZahtjeva)
        {
            return zahtjevKonverter.ZahtjevModelUDTO(zahtjeviServis.PretraziPoId(idZahtjeva));
        }

        public List<ZahtjevDTO> SviZahtjevi()
        {
            List<ZahtjevDTO> zahtjevi = new List<ZahtjevDTO>();
            foreach (Zahtjev z in zahtjeviServis.SviZahtjevi())
                zahtjevi.Add(zahtjevKonverter.ZahtjevModelUDTO(z));
            return zahtjevi;
        }

        public ZahtjevDTO PretraziPoIdLijeka(String idLeka)
        {
            return zahtjevKonverter.ZahtjevModelUDTO(zahtjeviServis.PretraziPoIdLijeka(idLeka));
        }

        public Boolean OdobriZahtev(String idZahteva)
        {
            if (zahtjeviServis.OdobriZahtev(idZahteva))
                return true;
            return false;
        }

        public void OdbijZahtev(String idZahteva, String razlogOdbijanja)
        {
            zahtjeviServis.OdbijZahtev(idZahteva, razlogOdbijanja);
        }

        public void DodajZahtjev(ZahtjevDTO zahtjev)
        {
            zahtjeviServis.DodajZahtjev(zahtjevKonverter.ZahtjevDTOUModel(zahtjev));
        }

        public void IzmeniLek(LekDTO noviPodaci)
        {
            zahtjeviServis.IzmeniLek(lekKonverter.LekDTOUModel(noviPodaci));
        }

        public void UklanjanjeLeka(String idLeka)
        {
            zahtjeviServis.UklanjanjeLeka(idLeka);
        }

        public void DodajSastojak(SastojakDTO sastojak, String idLeka)
        {
            zahtjeviServis.DodajSastojak(sastojciKonverter.SastojakDTOuModel(sastojak), idLeka);
        }

        public LekDTO pretraziLekPoId(String idLeka)
        {
            return lekKonverter.LekModelULekDTO(zahtjeviServis.pretraziLekPoId(idLeka));
        }

        public List<SastojakDTO> DobaviSastojkeLeka(String idLeka)
        {
            List<SastojakDTO> sastojciLeka = new List<SastojakDTO>();

            foreach (Sastojak s in zahtjeviServis.pretraziLekPoId(idLeka).Sastojci)
            {
                sastojciLeka.Add(sastojciKonverter.SastojakModelUDTO(s));
            }

            return sastojciLeka;
        }

    }
}

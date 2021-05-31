
using Bolnica.DTO;
using Bolnica.Konverter;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
using Model;
using System;
using System.Collections.Generic;

namespace Bolnica.Kontroler
{
    class LekoviKontroler
    {

        LekoviServis lekoviServis = new LekoviServis();
        LekKonverter lekKonverter = new LekKonverter();
        SastojciKonverter sastojciKonverter = new SastojciKonverter();

        public List<LekDTO> DobaviSveLekove()
        {
            List<LekDTO> sviLekoviDTO = new List<LekDTO>();
            foreach (Lek l in lekoviServis.DobaviSveLekove())
            {
                sviLekoviDTO.Add(lekKonverter.LekSaKolicinomDTO(l));
            }
            return sviLekoviDTO;
        }

        public void DodajLek(Lek noviLek)
        {
            lekoviServis.DodajLek(noviLek);
        }

        public LekDTO PretraziPoID(String sifraLeka)
        {
            Lek pronadjenLek = lekoviServis.PretraziPoID(sifraLeka);
            return lekKonverter.LekModelULekDTO(pronadjenLek);
        }

        public void IzmenaLeka(LekDTO noviPodaci, List<SastojakDTO> noviSastojci)
        {
            List<Sastojak> konvertovaniSastojci = new List<Sastojak>();
            foreach (SastojakDTO s in noviSastojci)
            {
                konvertovaniSastojci.Add(sastojciKonverter.SastojakDTOuModel(s));
            }
            lekoviServis.IzmenaLeka(lekKonverter.LekDTOUModel(noviPodaci), konvertovaniSastojci);
        }

        public void IzmenaZamenskihLekova(String idLeka, List<LekDTO> noviZamenski)
        {
            List<Lek> zamenskiLekovi = new List<Lek>();
            foreach (LekDTO zamena in noviZamenski)
            {
                zamenskiLekovi.Add(lekKonverter.LekDTOUModel(zamena));
            }

            lekoviServis.IzmenaZamenskihLekova(idLeka, zamenskiLekovi);
        }

        public List<SastojakDTO> DobaviSastojkeLeka(String idLeka)
        {
            List<SastojakDTO> sastojciLeka = new List<SastojakDTO>();

            foreach (Sastojak s in lekoviServis.PretraziPoID(idLeka).Sastojci)
            {
                sastojciLeka.Add(sastojciKonverter.SastojakModelUDTO(s));
            }

            return sastojciLeka;
        }

        public List<LekDTO> DobaviZameneLeka(String idLeka)
        {
            List<LekDTO> zameneLeka = new List<LekDTO>();

            foreach (Lek l in lekoviServis.PretraziPoID(idLeka).Zamene)
            {
                zameneLeka.Add(lekKonverter.LekModelULekDTO(l));
            }
            return zameneLeka;
        }
    }
}

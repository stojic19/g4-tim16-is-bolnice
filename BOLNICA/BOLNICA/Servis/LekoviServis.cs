using Bolnica.Repozitorijum;
using Bolnica.Repozitorijum.Factory;
using Bolnica.Repozitorijum.Interfejsi;
using Model;
using System;
using System.Collections.Generic;

namespace Bolnica.Model.Rukovanja
{
    class LekoviServis
    {
        private LekoviRepozitorijumInterfejs lekoviRepozitorijum = LekoviFactory.DobaviRepozitorijum();

        public List<Lek> DobaviSveLekove()
        {
            return lekoviRepozitorijum.DobaviSveObjekte();
        }

        public void DodajLek(Lek noviLek)
        {
            lekoviRepozitorijum.DodajObjekat(noviLek);
        }

        public void UkloniLijek(String idLijeka)
        {
            lekoviRepozitorijum.ObrisiObjekat("//ArrayOfLek/Lek[IDLeka='" + idLijeka + "']");
        }

        public Lek PretraziPoID(String sifraLeka)
        {
            return lekoviRepozitorijum.PretraziLekPoId(sifraLeka);
        }

        public void IzmenaLeka(Lek noviPodaci, List<Sastojak> noviSastojci)
        {
            Lek stariPodaci = lekoviRepozitorijum.PretraziLekPoId(noviPodaci.IDLeka);
            Lek izmenjenLek = KopiranjePodatakaLeka(stariPodaci, noviPodaci, noviSastojci);

            lekoviRepozitorijum.IzmenaLeka(izmenjenLek);

        }

        public void IzmijeniLijek(Lek noviPodaci)
        {
            lekoviRepozitorijum.IzmenaLeka(noviPodaci);
        }

        public Lek KopiranjePodatakaLeka(Lek stariPodaci, Lek noviPodaci, List<Sastojak> noviSastojci)
        {
            stariPodaci.NazivLeka = noviPodaci.NazivLeka;
            stariPodaci.Jacina = noviPodaci.Jacina;
            stariPodaci.Sastojci.Clear();
            foreach (Sastojak s in noviSastojci)
            {
                stariPodaci.Sastojci.Add(s);
            }
            return stariPodaci;
        }

        public void IzmenaZamenskihLekova(String idLeka, List<Lek> noviZamenski)
        {
            Lek l = lekoviRepozitorijum.PretraziLekPoId(idLeka);
            l.Zamene.Clear();
            foreach (Lek zamena in noviZamenski)
            {
                l.Zamene.Add(zamena);
            }

            lekoviRepozitorijum.IzmenaLeka(l);
        }

    }
}

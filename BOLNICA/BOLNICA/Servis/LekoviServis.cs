using Bolnica.Repozitorijum;
using Model;
using System;
using System.Collections.Generic;

namespace Bolnica.Model.Rukovanja
{
    class LekoviServis
    {
        private LekoviRepozitorijum lekoviRepozitorijum = new LekoviRepozitorijum();

        public List<Lek> DobaviSveLekove()
        {
            return lekoviRepozitorijum.DobaviSveObjekte();
        }

        public void DodajLek(Lek noviLek)
        {
            lekoviRepozitorijum.DodajObjekat(noviLek);
        }

        public Lek PretraziPoID(String sifraLeka)
        {
            return lekoviRepozitorijum.PretraziLekPoId(sifraLeka);
        }

        public void IzmenaLeka(Lek noviPodaci)
        {
            Lek stariPodaci = lekoviRepozitorijum.PretraziLekPoId(noviPodaci.IDLeka);
            KopiranjePodatakaLeka(stariPodaci, noviPodaci);

            lekoviRepozitorijum.IzmenaLeka(noviPodaci);

        }

        public void KopiranjePodatakaLeka(Lek stariPodaci, Lek noviPodaci)
        {
            stariPodaci.NazivLeka = noviPodaci.NazivLeka;
            stariPodaci.Jacina = noviPodaci.Jacina;
            stariPodaci.Sastojci.Clear();
            foreach (Sastojak s in noviPodaci.Sastojci)
            {
                stariPodaci.Sastojci.Add(s);
            }
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

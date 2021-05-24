
using Bolnica.Model.Rukovanja;
using Model;
using System;
using System.Collections.Generic;

namespace Bolnica.Kontroler
{
    class LekoviKontroler
    {

        private LekoviServis lekoviServis = new LekoviServis();

        public List<Lek> DobaviSveLekove()
        {
            return lekoviServis.DobaviSveLekove();
        }

        public void DodajLek(Lek noviLek)
        {
            lekoviServis.DodajLek(noviLek);
        }

        public Lek PretraziPoID(String sifraLeka)
        {
            return lekoviServis.PretraziPoID(sifraLeka);
        }

        public void IzmenaLeka(Lek noviPodaci)
        {
            lekoviServis.IzmenaLeka(noviPodaci);
        }

        public void IzmenaZamenskihLekova(String idLeka, List<Lek> noviZamenski)
        {
            lekoviServis.IzmenaZamenskihLekova(idLeka, noviZamenski);

        }
    }
}

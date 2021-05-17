using Bolnica.Repozitorijum;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bolnica.Model.Rukovanja
{
    class LekoviServis
    {

        public static Lek PretraziPoID(String sifraLeka)
        {
            foreach (Lek l in Repozitorijum.LekoviRepozitorijum.SviLekovi)
            {

                if (l.IDLeka.Equals(sifraLeka))
                {
                    return l;
                }
            }

            return null;
        }

        public static Boolean IzmenaLeka(Lek noviLek)
        {

            foreach (Lek l in Repozitorijum.LekoviRepozitorijum.SviLekovi)
            {
                if (l.IDLeka.Equals(noviLek.IDLeka))
                {
                    KopiranjePodatakaLeka(l, noviLek);
                    return true;
                }

            }
            return false;
        }

        public static void KopiranjePodatakaLeka(Lek original, Lek noviPodaci)
        {
            original.NazivLeka = noviPodaci.NazivLeka;
            original.Jacina = noviPodaci.Jacina;
            original.Sastojci.Clear();
            foreach (Sastojak s in noviPodaci.Sastojci)
            {
                original.Sastojci.Add(s);
            }
        }

        public static Boolean IzmenaZamenskihLekova(String idLeka, List<Lek> noviZamenski)
        {
            foreach (Lek l in Repozitorijum.LekoviRepozitorijum.SviLekovi)
            {
                if (l.IDLeka.Equals(idLeka))
                {
                    l.Zamene.Clear();
                    foreach (Lek zamena in noviZamenski)
                    {
                        l.Zamene.Add(zamena);
                    }

                    return true;
                }

            }

            return false;

        }

    }
}

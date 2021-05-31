using Bolnica.Kontroler;
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
    public class ZahtjeviServis
    {
        ZahtjeviRepozitorijum zahtjeviRepozitorijum = new ZahtjeviRepozitorijum();

        public Zahtjev PretraziPoId(String idZahtjeva)
        {
            return zahtjeviRepozitorijum.PretraziZahtjevPoId(idZahtjeva);
        }

        public List<Zahtjev> SviZahtjevi()
        {
            return zahtjeviRepozitorijum.DobaviSveObjekte();
        }

        public Zahtjev PretraziPoIdLijeka(String idLeka)
        {
            foreach (Zahtjev z in zahtjeviRepozitorijum.DobaviSveObjekte())
            {
                if (z.Lijek.IDLeka.Equals(idLeka))
                {
                    return z;
                }
            }
            return null;
        }

        public  Boolean OdobriZahtev(String idZahteva)
        {
            foreach(Zahtjev z in zahtjeviRepozitorijum.DobaviSveObjekte())
            {
                if (z.IdZahtjeva.Equals(idZahteva))
                {
                    z.Odgovor = Enumi.VrsteOdgovora.Odobren;
                    z.Lijek.Verifikacija = true;
                    return true;
                }
            }
            return false;
        }

        public void OdbijZahtev(String idZahteva, String razlogOdbijanja)
        {
            foreach (Zahtjev z in zahtjeviRepozitorijum.DobaviSveObjekte())
            {
                if (z.IdZahtjeva.Equals(idZahteva))
                {
                    z.Odgovor = Enumi.VrsteOdgovora.Odbijen;
                    z.RazlogOdbijanja = razlogOdbijanja;
                    zahtjeviRepozitorijum.IzmenaZahtjeva(z);
                }
            }
        }

        public void DodajZahtjev(Zahtjev zahtjev)
        {
            zahtjeviRepozitorijum.DodajObjekat(zahtjev);
        }

        public void IzmeniLek(Lek noviPodaci)
        {
            Zahtjev z = PretraziPoIdLijeka(noviPodaci.IDLeka);
            z.Lijek.NazivLeka = noviPodaci.NazivLeka;
            z.Lijek.Jacina = noviPodaci.Jacina;
            z.Lijek.Kolicina = int.Parse(noviPodaci.Kolicina.ToString());
            z.Lijek.Proizvodjac = noviPodaci.Proizvodjac;

            zahtjeviRepozitorijum.IzmenaZahtjeva(z);
        }

        public void UklanjanjeLeka(String idLeka)
        {
            zahtjeviRepozitorijum.ObrisiObjekat(idLeka);
        }

        public void DodajSastojak(Sastojak sastojak, String idLeka)
        {
            foreach (Zahtjev z in zahtjeviRepozitorijum.DobaviSveObjekte())
            {
                if (z.Lijek.IDLeka.Equals(idLeka))
                {
                    z.Lijek.Sastojci.Add(sastojak);
                    zahtjeviRepozitorijum.IzmenaZahtjeva(z);
                    break;
                }
            }

        }

        public Lek pretraziLekPoId(String idLeka)
        {
            foreach (Zahtjev z in zahtjeviRepozitorijum.DobaviSveObjekte())
            {
                if (z.Lijek.IDLeka.Equals(idLeka))
                {
                    return z.Lijek;
                }
            }
            return null;
        }
    }
}

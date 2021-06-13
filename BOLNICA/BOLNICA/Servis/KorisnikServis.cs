using Bolnica.Model;
using Bolnica.Model.Enumi;
using Bolnica.Repozitorijum;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Servis
{
    public class KorisnikServis
    {
        NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();
        SekretariServis sekretariServis = new SekretariServis();
        LekariServis lekariServis = new LekariServis();
       
        KorisnikRepozitorijum korisnikRepozitorijum = new KorisnikRepozitorijum();

        public bool ProveriPostojanje(String korIme)
        {
            foreach(Korisnik k in korisnikRepozitorijum.DobaviSveObjekte())
            {
                if (k.KorisnickoIme.Equals(korIme)) return true;
            }

            return false;
        }

        public TipoviKorisnika ProveriLozinkuITip(String idOsobe, String sifra)
        {
            Korisnik k = korisnikRepozitorijum.PretraziKorisnikaPoKorImenu(idOsobe);

            if (k.Lozinka.Equals(sifra)) return k.TipKorisnika;


            return (TipoviKorisnika)(-1);
        }

        public void DodajPacijenta(Pacijent pacijent)
        {
            korisnikRepozitorijum.DodajObjekat(new Korisnik(pacijent.IdOsobe, pacijent.KorisnickoIme, pacijent.Lozinka, TipoviKorisnika.PACIJENT));
        }

        public void IzmeniPacijenta(Pacijent pacijent)
        {
            korisnikRepozitorijum.ObrisiKorisnika(pacijent.IdOsobe);
            korisnikRepozitorijum.DodajObjekat(new Korisnik(pacijent.IdOsobe, pacijent.KorisnickoIme, pacijent.Lozinka, TipoviKorisnika.PACIJENT));
        }

        public void ObrisiKorisnikaPoKorImenu(String korIme)
        {
            korisnikRepozitorijum.ObrisiKorisnikaPoKorImenu(korIme);
        }
    }
}

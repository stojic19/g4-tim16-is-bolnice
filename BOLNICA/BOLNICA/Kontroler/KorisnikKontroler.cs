using Bolnica.DTO;
using Bolnica.Konverter;
using Bolnica.Model.Enumi;
using Bolnica.Servis;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Kontroler
{
    public class KorisnikKontroler
    {
        
        KorisnikServis korisnikServis = new KorisnikServis();
        PacijentKonverter pacijentKonverter = new PacijentKonverter();
       
        public Boolean ProveriPostojanje(String korisnickoIme)
        {
            return korisnikServis.ProveriPostojanje(korisnickoIme);
        }

        public TipoviKorisnika ProveriLozinkuITip(String idOsobe, String password)
        {
            return korisnikServis.ProveriLozinkuITip(idOsobe, password);
        }

        public void DodajPacijenta(PacijentDTO korisnik)
        {
            korisnikServis.DodajPacijenta(pacijentKonverter.PacijentDTOUModel(korisnik));
        }


        public void IzmeniPacijenta(PacijentDTO pacijent)
        {
            korisnikServis.IzmeniPacijenta(pacijentKonverter.PacijentDTOUModel(pacijent));
        }

        public void ObrisiKorisnikaPoKorImenu(String korIme)
        {
            korisnikServis.ObrisiKorisnikaPoKorImenu(korIme);
        }

    }
}

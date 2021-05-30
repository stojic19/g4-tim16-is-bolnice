
using Bolnica;
using Bolnica.Model.Rukovanja;
using Bolnica.Repozitorijum;
using Bolnica.Repozitorijum.Interfejsi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Model
{
    public class NaloziPacijenataServis
    {
        private NaloziPacijenataRepozitorijum naloziPacijenataRepozitorijum = new NaloziPacijenataRepozitorijum();
        private LekoviRepozitorijumInterfejs lekoviRepozitorijum = new LekoviRepozitorijum();
        public void DodajNalog(Pacijent pacijentZaDodavanje)
        {
            naloziPacijenataRepozitorijum.DodajObjekat(pacijentZaDodavanje);
        }
        
        public void IzmeniNalog(String stariId, Pacijent pacijentZaIZmenu)
        {
            Pacijent pacijentKojiSeMenja = PretraziPoId(stariId);

            pacijentKojiSeMenja.KorisnickoIme = pacijentZaIZmenu.KorisnickoIme;
            pacijentKojiSeMenja.Ime = pacijentZaIZmenu.Ime;
            pacijentKojiSeMenja.Prezime = pacijentZaIZmenu.Prezime;
            pacijentKojiSeMenja.DatumRodjenja = pacijentZaIZmenu.DatumRodjenja;
            pacijentKojiSeMenja.Pol = pacijentZaIZmenu.Pol;
            pacijentKojiSeMenja.Jmbg = pacijentZaIZmenu.Jmbg;
            pacijentKojiSeMenja.AdresaStanovanja = pacijentZaIZmenu.AdresaStanovanja;
            pacijentKojiSeMenja.KontaktTelefon = pacijentZaIZmenu.KontaktTelefon;
            pacijentKojiSeMenja.Email = pacijentZaIZmenu.Email;
            pacijentKojiSeMenja.VrstaNaloga = pacijentZaIZmenu.VrstaNaloga;
            pacijentKojiSeMenja.ZdravstveniKarton.IDPacijenta = pacijentZaIZmenu.KorisnickoIme;

            naloziPacijenataRepozitorijum.IzmeniPacijentaSaKorisnickim(stariId, pacijentKojiSeMenja);
        }

        public void UkolniNalog(String idNalogaZaUklanjanje)
        {
            Pacijent pacijentZaUklanjanje = PretraziPoId(idNalogaZaUklanjanje);
            naloziPacijenataRepozitorijum.ObrisiObjekat("//ArrayOfPacijent/Pacijent[KorisnickoIme='" + idNalogaZaUklanjanje + "']");

        }
        
        public bool DaLiLekVecPostojiUAlergenimaPacijenta(string idPacijenta, string idLeka)
        {
            foreach (Alergeni alergeni in DobaviAlergenePoIdPacijenta(idPacijenta))
            {
                if (alergeni.IdAlergena.Equals(idLeka))
                {
                    return true;
                }
            }
            return false;
        }
        public Alergeni DobaviAlergenPacijentaPoId(String idPacijenta, String idAlergena)
        {
            foreach (Alergeni alergen in DobaviAlergenePoIdPacijenta(idPacijenta))
            {
                if (alergen.IdAlergena.Equals(idAlergena))
                {
                    return alergen;
                }
            }
            return null;
        }
        public Pacijent PretraziPoId(String idNaloga)
        {
            return naloziPacijenataRepozitorijum.PretraziPoId("//ArrayOfPacijent/Pacijent[KorisnickoIme='" + idNaloga + "']");
        }

        public List<Pacijent> SviNalozi()
        {
            return naloziPacijenataRepozitorijum.DobaviSveObjekte();
        }
        public List<Alergeni> DobaviAlergenePoIdPacijenta(String idPacijenta)
        {
            return naloziPacijenataRepozitorijum.DobaviAlergenePacijenta(idPacijenta);
        }
        public Boolean UkloniAlergen(String idPacijenta,Alergeni alergen)
        {
            Pacijent pacijent = PretraziPoId(idPacijenta);
            pacijent.UkloniAlergen(alergen);
            naloziPacijenataRepozitorijum.IzmeniPacijenta(pacijent);
            return true;
        }
        public Boolean IzmeniAlergen(String idPacijenta,Alergeni alergen)
        {
            Pacijent pacijent = PretraziPoId(idPacijenta);
            pacijent.IzmeniAlergen(alergen);
            naloziPacijenataRepozitorijum.IzmeniPacijenta(pacijent);
            return true;
        }
        public Boolean DodajAlergen(String idPacijenta,Alergeni alergen)
        {
            alergen.Lek = lekoviRepozitorijum.PretraziLekPoId(alergen.IdAlergena);
            Pacijent pacijent = PretraziPoId(idPacijenta);
            pacijent.DodajAlergen(alergen);
            naloziPacijenataRepozitorijum.IzmeniPacijenta(pacijent);
            return true;
        }

        public void IzmeniStanjeNalogaPacijenta(Pacijent pacijentZaIzmenu)
        {
            Pacijent pacijent = DetektujZloupotrebuSistema(pacijentZaIzmenu);
            if (pacijent.ZloupotrebioSistem > 5)
                pacijent.Blokiran = true;
            naloziPacijenataRepozitorijum.IzmeniPacijenta(pacijent);
        }


        public Pacijent DetektujZloupotrebuSistema(Pacijent pacijent)
        {
            int brojZloupotreba = pacijent.ZloupotrebioSistem + 1;
            pacijent.ZloupotrebioSistem = brojZloupotreba;
            return pacijent;
        }

        public bool NalogJeBlokiran(String korisnickoIme)
        {
            if (PretraziPoId(korisnickoIme).Blokiran)
                return true;
            return false;
        }

        public void OdblokirajNalog(String idPacijenta)
        {
            Pacijent pacijent = PretraziPoId(idPacijenta);
            pacijent.Blokiran = false;
            naloziPacijenataRepozitorijum.IzmeniPacijenta(pacijent);
        }

        public bool DaLiJeKorisnickoImeJedinstveno(String korisnickoIme)
        {
            foreach (Pacijent pacijentZaProveru in SviNalozi())
            {
                if (pacijentZaProveru.KorisnickoIme.Equals(korisnickoIme))
                {
                    return false;
                }
            }
            return true;
        }
        public bool DaLiJeJmbgJedinstven(String jmbg)
        {
            foreach (Pacijent pacijentZaProveru in SviNalozi())
            {
                if (pacijentZaProveru.Jmbg.Equals(jmbg))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
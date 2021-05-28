
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
        public Pacijent DodajNalog(Pacijent pacijentZaDodavanje)
        {
            naloziPacijenataRepozitorijum.DodajObjekat(pacijentZaDodavanje);
            PrikazNalogaSekretar.NaloziPacijenata.Add(pacijentZaDodavanje);

            if (SviNalozi().Contains(pacijentZaDodavanje))
            {
                return pacijentZaDodavanje;
            }
            else
            {
                return null;
            }
        }

        
        public Boolean IzmeniNalog(String stariId, Pacijent pacijentZaIZmenu)
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

            //int indeks = PrikazNalogaSekretar.NaloziPacijenata.IndexOf(pacijentKojiSeMenja);
            //PrikazNalogaSekretar.NaloziPacijenata.RemoveAt(indeks);
            //PrikazNalogaSekretar.NaloziPacijenata.Insert(indeks, pacijentKojiSeMenja);

            naloziPacijenataRepozitorijum.IzmeniPacijenta(pacijentKojiSeMenja);

            return true;
        }

        public Boolean UkolniNalog(String idNalogaZaUklanjanje)
        {
            Pacijent pacijentZaUklanjanje = PretraziPoId(idNalogaZaUklanjanje);

            if (pacijentZaUklanjanje == null)
            {
                return false;
            }

            naloziPacijenataRepozitorijum.ObrisiObjekat("//ArrayOfPacijent/Pacijent[KorisnickoIme='" + idNalogaZaUklanjanje + "']");
            PrikazNalogaSekretar.NaloziPacijenata.Remove(pacijentZaUklanjanje);

            if (SviNalozi().Contains(pacijentZaUklanjanje) || PrikazNalogaSekretar.NaloziPacijenata.Contains(pacijentZaUklanjanje))
            {
                return false;
            }
            else
            {
                return true;
            }
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
            // AlergeniSekretar.AlergeniPacijenta.Remove(alergen);
            pacijent.UkloniAlergen(alergen);
            naloziPacijenataRepozitorijum.IzmeniPacijenta(pacijent);
            return true;
        }
        public Boolean IzmeniAlergen(String idPacijenta,Alergeni alergen)
        {
            Pacijent pacijent = PretraziPoId(idPacijenta);
            pacijent.IzmeniAlergen(alergen);
            naloziPacijenataRepozitorijum.IzmeniPacijenta(pacijent);
            // AzurirajPrikazAlergena(alergen);
            return true;
        }
        public Boolean DodajAlergen(String idPacijenta,Alergeni alergen)
        {
            alergen.Lek = lekoviRepozitorijum.PretraziLekPoId(alergen.IdAlergena);
            Pacijent pacijent = PretraziPoId(idPacijenta);
            pacijent.DodajAlergen(alergen);
            naloziPacijenataRepozitorijum.IzmeniPacijenta(pacijent);
            AlergeniSekretar.AlergeniPacijenta.Add(alergen);
            return true;
        }
        private void AzurirajPrikazAlergena(Alergeni a1)
        {
            int indeks = AlergeniSekretar.AlergeniPacijenta.IndexOf(a1);
            AlergeniSekretar.AlergeniPacijenta.RemoveAt(indeks);
            AlergeniSekretar.AlergeniPacijenta.Insert(indeks, a1);
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

    }
}
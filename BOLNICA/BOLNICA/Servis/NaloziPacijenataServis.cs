
using Bolnica;
using Bolnica.Model.Rukovanja;
using Bolnica.Repozitorijum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Model
{
    public class NaloziPacijenataServis
    {

        public static Pacijent DodajNalog(Pacijent pacijentZaDodavanje)
        {
            NaloziPacijenataRepozitorijum.DodajPacijenta(pacijentZaDodavanje);
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

        
        public static Boolean IzmeniNalog(String stariId, String idNaloga, String ime, String prezime, DateTime datum,Pol pol, String jmbg, String adresa, String telefon, String email, VrsteNaloga vrstaNaloga)
        {
            Pacijent pacijentKojiSeMenja = PretraziPoId(stariId);

            pacijentKojiSeMenja.KorisnickoIme = idNaloga;
            pacijentKojiSeMenja.Ime = ime;
            pacijentKojiSeMenja.Prezime = prezime;
            pacijentKojiSeMenja.DatumRodjenja = datum;
            pacijentKojiSeMenja.Pol = pol;
            pacijentKojiSeMenja.Jmbg = jmbg;
            pacijentKojiSeMenja.AdresaStanovanja = adresa;
            pacijentKojiSeMenja.KontaktTelefon = telefon;
            pacijentKojiSeMenja.Email = email;
            pacijentKojiSeMenja.VrstaNaloga = vrstaNaloga;
            pacijentKojiSeMenja.ZdravstveniKarton.IDPacijenta = idNaloga;

            //int indeks = PrikazNalogaSekretar.NaloziPacijenata.IndexOf(pacijentKojiSeMenja);
            //PrikazNalogaSekretar.NaloziPacijenata.RemoveAt(indeks);
            //PrikazNalogaSekretar.NaloziPacijenata.Insert(indeks, pacijentKojiSeMenja);

            NaloziPacijenataRepozitorijum.IzmeniPacijenta(pacijentKojiSeMenja);

            return true;
        }

        public static Boolean UkolniNalog(String idNalogaZaUklanjanje)
        {
            Pacijent pacijentZaUklanjanje = PretraziPoId(idNalogaZaUklanjanje);

            if (pacijentZaUklanjanje == null)
            {
                return false;
            }

            NaloziPacijenataRepozitorijum.ObrisiPacijenta(pacijentZaUklanjanje);
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

        public static Pacijent PretraziPoId(String idNaloga)
        {
            foreach (Pacijent pacijent in SviNalozi())
            {
                if (pacijent.KorisnickoIme.Equals(idNaloga))
                {

                    return pacijent;
                }
            }
            return null;
        }

        public static List<Pacijent> SviNalozi()
        {
            return NaloziPacijenataRepozitorijum.DobaviSveNalogePacijenata();
        }
        public static List<Alergeni> DobaviAlergenePoIdPacijenta(String idPacijenta)
        {
            return PretraziPoId(idPacijenta).DobaviAlergene();
        }
        public static Boolean UkloniAlergen(String idPacijenta,Alergeni alergen)
        {
            Pacijent pacijent = PretraziPoId(idPacijenta);
            // AlergeniSekretar.AlergeniPacijenta.Remove(alergen);
            pacijent.UkloniAlergen(alergen);
            NaloziPacijenataRepozitorijum.IzmeniPacijenta(pacijent);
            return true;
        }
        public static Boolean IzmeniAlergen(String idPacijenta,Alergeni alergen)
        {
            Pacijent pacijent = PretraziPoId(idPacijenta);
            pacijent.IzmeniAlergen(alergen);
            NaloziPacijenataRepozitorijum.IzmeniPacijenta(pacijent);
            // AzurirajPrikazAlergena(alergen);
            return true;
        }
        public static Boolean DodajAlergen(String idPacijenta,Alergeni alergen)
        {
            alergen.Lek = LekoviServis.PretraziPoID(alergen.IdAlergena);
            Pacijent pacijent = PretraziPoId(idPacijenta);
            pacijent.DodajAlergen(alergen);
            NaloziPacijenataRepozitorijum.IzmeniPacijenta(pacijent);
            AlergeniSekretar.AlergeniPacijenta.Add(alergen);
            return true;
        }
        private static void AzurirajPrikazAlergena(Alergeni a1)
        {
            int indeks = AlergeniSekretar.AlergeniPacijenta.IndexOf(a1);
            AlergeniSekretar.AlergeniPacijenta.RemoveAt(indeks);
            AlergeniSekretar.AlergeniPacijenta.Insert(indeks, a1);
        }

    }
}
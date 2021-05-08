
using Bolnica;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Model
{
    public class RukovanjeNalozimaPacijenata
    {
        private String imeFajla;

        public static List<Pacijent> sviNaloziPacijenata = new List<Pacijent>();

        
        public static Pacijent DodajNalog(Pacijent p)
        {
            sviNaloziPacijenata.Add(p);
            PrikazNalogaSekretar.NaloziPacijenata.Add(p);

            Sacuvaj();

            if (sviNaloziPacijenata.Contains(p))
            {
                return p;
            }
            else
            {
                return null;
            }
        }

        public static Boolean IzmeniNalog(String idNaloga, String ime, String prezime, DateTime datum, String jmbg, String adresa, String telefon, String email,VrsteNaloga vrstaNaloga)
        {
            Pacijent p = PretraziPoId(idNaloga);

            p.Ime = ime;
            p.Prezime = prezime;
            p.DatumRodjenja = datum;
            p.Jmbg = jmbg;
            p.AdresaStanovanja = adresa;
            p.KontaktTelefon = telefon;
            p.Email = email;
            p.VrstaNaloga = vrstaNaloga;

            int indeks = PrikazNalogaSekretar.NaloziPacijenata.IndexOf(p);
            PrikazNalogaSekretar.NaloziPacijenata.RemoveAt(indeks);
            PrikazNalogaSekretar.NaloziPacijenata.Insert(indeks, p);

            Sacuvaj();

            return true;
        }

        public static Boolean UkolniNalog(String idNaloga)
        {
            Pacijent p = PretraziPoId(idNaloga);

            if (p == null)
            {
                return false;
            }

            sviNaloziPacijenata.Remove(p);
            PrikazNalogaSekretar.NaloziPacijenata.Remove(p);

            Sacuvaj();

            if (sviNaloziPacijenata.Contains(p) || PrikazNalogaSekretar.NaloziPacijenata.Contains(p))
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
            foreach (Pacijent p in sviNaloziPacijenata)
            {
                if (p.KorisnickoIme.Equals(idNaloga))
                {

                    return p;
                }
            }
            return null;
        }

        public static List<Pacijent> SviNalozi()
        {
            return sviNaloziPacijenata;
        }
        public static List<Alergeni> DobaviAlergenePoIdPacijenta(String idPacijenta)
        {
            return PretraziPoId(idPacijenta).ZdravstveniKarton.Alergeni;
        }
        public static Boolean UkloniAlergen(String idPacijenta,Alergeni alergen)
        {
            PretraziPoId(idPacijenta).ZdravstveniKarton.Alergeni.Remove(alergen);
            AlergeniSekretar.AlergeniPacijenta.Remove(alergen);

            RukovanjeNalozimaPacijenata.Sacuvaj();
            return true;
        }
        public static Boolean IzmeniAlergen(String idPacijenta,Alergeni alergen)
        {
            foreach (Alergeni a1 in DobaviAlergenePoIdPacijenta(idPacijenta))
            {
                if (a1.IdAlergena.Equals(alergen.IdAlergena))
                {
                    a1.OpisReakcije = alergen.OpisReakcije;
                    a1.VremeZaPojavu = alergen.VremeZaPojavu;
                    AzurirajPrikazAlergena(a1);

                    RukovanjeNalozimaPacijenata.Sacuvaj();
                    return true;
                }
            }
            return false;
        }
        public static Boolean DodajAlergen(String idPacijenta,Alergeni alergen)
        {
            RukovanjeNalozimaPacijenata.PretraziPoId(idPacijenta).ZdravstveniKarton.Alergeni.Add(alergen);
            AlergeniSekretar.AlergeniPacijenta.Add(alergen);
            RukovanjeNalozimaPacijenata.Sacuvaj();
            return true;
        }
        private static void AzurirajPrikazAlergena(Alergeni a1)
        {
            int indeks = AlergeniSekretar.AlergeniPacijenta.IndexOf(a1);
            AlergeniSekretar.AlergeniPacijenta.RemoveAt(indeks);
            AlergeniSekretar.AlergeniPacijenta.Insert(indeks, a1);
        }

        public static List<Pacijent> Ucitaj()
        {
            if (File.ReadAllText("pacijenti.xml").Trim().Equals(""))
            {
                return new List<Pacijent>();
            }
            else
            {
                FileStream fileStream = File.OpenRead("pacijenti.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(List<Pacijent>));
                sviNaloziPacijenata = (List<Pacijent>)serializer.Deserialize(fileStream);
                fileStream.Close();
                return sviNaloziPacijenata;
            }
        }

        public static void Sacuvaj()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Pacijent>));
            TextWriter fileStream = new StreamWriter("pacijenti.xml");
            serializer.Serialize(fileStream, sviNaloziPacijenata);
            fileStream.Close();
        }
    }
}
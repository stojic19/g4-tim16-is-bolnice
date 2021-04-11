
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

            foreach (Pacijent pac in sviNaloziPacijenata)
            {
                Console.WriteLine(pac.KorisnickoIme);
            }

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

        public static Boolean IzmeniNalog(String stariId, String idNaloga, String ime, String prezime, DateTime datum, String jmbg, String adresa, String telefon, String email, VrsteNaloga vrstaNaloga)
        {
            Pacijent p = PretraziPoId(stariId);

            p.KorisnickoIme = idNaloga;
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
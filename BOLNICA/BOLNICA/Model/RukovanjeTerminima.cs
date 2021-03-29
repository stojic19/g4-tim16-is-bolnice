using Bolnica;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Model
{
    public class RukovanjeTerminima
    {
        private String imeFajla;

        public static List<Termin> sviTermini = new List<Termin>();
        public static List<Lekar> sviLekari = new List<Lekar>();

        public static void PrivremenaInicijalizacijaLekara()
        {

            sviLekari.Add(new Lekar("AleksaStojic", "Aleksa", "Stojic"));
            sviLekari.Add(new Lekar("MarkoAndjelic", "Marko", "Andjelic"));
            sviLekari.Add(new Lekar("MagdalenaReljin", "Magdalena", "Reljin"));
            sviLekari.Add(new Lekar("JelenaHrnjak", "Jelena", "Hrnjak"));

        }

        public static Lekar pretraziLekare(String id)
        {
            foreach(Lekar l in sviLekari)
            {

                if (l.KorisnickoIme.Equals(id))
                {
                    return l;
                }
            }

            return null;
        }

        public static Termin ZakaziTermin(Termin t)
        {
            sviTermini.Add(t);
            PrikazTerminaLekara.Termini.Add(t);

            if (sviTermini.Contains(t))
            {
                return t;
            }
            else
            {
                return null;
            }
        }
        public static Termin ZakaziPregled(Termin t)
        {
            sviTermini.Add(t);

            PrikazTerminaPacijent.Termini.Add(t);

            if (sviTermini.Contains(t))
            {
                return t;
            }
            else
            {
                return null;
            }
        }

        public static Boolean OtkaziTermin(String idTermina)
        {

            Termin t = PretraziPoId(idTermina);

            if (t == null)
            {
                return false;
            }

            sviTermini.Remove(t);
            PrikazTerminaLekara.Termini.Remove(t);

            if (sviTermini.Contains(t) || PrikazTerminaLekara.Termini.Contains(t))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Boolean OtkaziPregled(String idTermina) {

            Termin t = PretraziPoId(idTermina);

            if (t == null)
            {
                return false;
            }

            sviTermini.Remove(t);
            PrikazTerminaPacijent.Termini.Remove(t);

            if (sviTermini.Contains(t) || PrikazTerminaPacijent.Termini.Contains(t))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Boolean IzmeniTermin(String idTermina, String idLekara, int vrstaTermina, String idProstorije, String datum, String pocVr, String trajanje, int hMin)
        {
            Termin t = PretraziPoId(idTermina);


            t.Lekar = pretraziLekare(idLekara);

            if (vrstaTermina == 0)
            {
                t.VrstaTermina = VrsteTermina.pregled;
            }
            else
            {
                t.VrstaTermina = VrsteTermina.operacija;
            }


            t.Prostor = RukovanjeProstorom.PretraziPoId(idProstorije);
            t.Datum = datum;
            t.PocetnoVreme = pocVr;

            if (hMin == 0)
            {
                t.Trajanje = Double.Parse(trajanje);
            }
            else
            {
                t.Trajanje = Double.Parse(trajanje) * 60;
            }

            int indeks = PrikazTerminaLekara.Termini.IndexOf(t);
            PrikazTerminaLekara.Termini.RemoveAt(indeks);
            PrikazTerminaLekara.Termini.Insert(indeks, t);

            return true;
        }

        public static Boolean IzmeniPregled(String idTermina, String lekarW, String datumW, String vremeW)
        {
            Termin t = PretraziPoId(idTermina);
            if (!t.Lekar.KorisnickoIme.Equals(lekarW))
            {
                t.Lekar = pretraziLekare(lekarW);
            }

            if (!t.Datum.Equals(datumW))
            {
                t.Datum = datumW;
            }

            if (!t.PocetnoVreme.Equals(vremeW))
            {
                t.PocetnoVreme = vremeW;
            }

            int indeks = PrikazTerminaPacijent.Termini.IndexOf(t);
            PrikazTerminaPacijent.Termini.RemoveAt(indeks);
            PrikazTerminaPacijent.Termini.Insert(indeks, t);

            return true;

        }

        public static Termin PretraziPoId(String idTermina)
        {
            foreach(Termin termin in sviTermini)
            {
                if (termin.IdTermina.Equals(idTermina))
                    return termin;
            }
            return null;
        }

        public static String generisiIDTermina()
        {
            bool pronadjen = false;

            int i = 0;

            for (i = 0 ; i < sviTermini.Count ; i++)
            {
                foreach(Termin t in sviTermini)
                {
                    if(t.IdTermina.Equals("T" + i.ToString()))
                    {
                        pronadjen = true;
                        break;
                    }
                  
                }

                if (!pronadjen)
                {
                    return ("T" + i.ToString()) ;
                    
                }
                pronadjen = false;
            }

            return ("T" + i.ToString());
        }

        public List<Termin> PretraziPoLekaru(String korImeLekara)
        {
            throw new NotImplementedException();
        }

        public List<Termin> PretraziPoProstoriji(String idProstorije)
        {
            throw new NotImplementedException();
        }

        public List<Termin> PretraziPoPacijentu(String korImePacijenta)
        {
            throw new NotImplementedException();
        }



        public static List<Termin> DobaviSveTermine()
        {
            return sviTermini;
        }


        public static List<Termin> DeserijalizacijaTermina()
        {
            if (File.ReadAllText("termini.xml").Trim().Equals(""))
            {
                return sviTermini;
            }
            else
            {
                FileStream fileStream = File.OpenRead("termini.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
                sviTermini = (List<Termin>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sviTermini;

            }

        }

        public static void SerijalizacijaTermina()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
            TextWriter tw = new StreamWriter("termini.xml");
            xmlSerializer.Serialize(tw, sviTermini);
            tw.Close();

        }



    }
}
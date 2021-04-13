using Bolnica;
using Bolnica.Sekretar.Pregled;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Model
{
    public class RukovanjeTerminima
    {
        private String imeFajla;

        public static List<Termin> sviTermini = new List<Termin>();
        public static List<Termin> slobodniTermini = new List<Termin>();

        public static List<Lekar> sviLekari = new List<Lekar>();

        public static void PrivremenaInicijalizacijaLekara()
        {

            sviLekari.Add(new Lekar("AleksaStojic", "Aleksa", "Stojic"));
            sviLekari.Add(new Lekar("MarkoAndjelic", "Marko", "Andjelic"));
            sviLekari.Add(new Lekar("MagdalenaReljin", "Magdalena", "Reljin"));
            sviLekari.Add(new Lekar("JelenaHrnjak", "Jelena", "Hrnjak"));

        }
        public static void InicijalizacijaSTermina()
        {


            slobodniTermini.Add(new Termin("T11", VrsteTermina.pregled, "09:00", 30, "22/04/2021", RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T12", VrsteTermina.pregled, "09:30", 30, "22/04/2021", RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T13", VrsteTermina.pregled, "11:00", 30, "22/04/2021", RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T14", VrsteTermina.pregled, "08:00", 30, "22/04/2021", RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T19", VrsteTermina.pregled, "09:00", 30, "19/04/2021", RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T20", VrsteTermina.pregled, "19:00", 30, "19/04/2021", RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T21", VrsteTermina.pregled, "11:00", 30, "24/04/2021", RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T22", VrsteTermina.pregled, "08:00", 30, "18/04/2021", RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T23", VrsteTermina.pregled, "15:00", 30, "18/04/2021", RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("MagdalenaReljin")));


            slobodniTermini.Add(new Termin("T15", VrsteTermina.pregled, "19:00", 30, "16/04/2021", RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T16", VrsteTermina.pregled, "19:30", 30, "16/04/2021", RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T17", VrsteTermina.pregled, "11:00", 30, "30/04/2021", RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T18", VrsteTermina.pregled, "09:00", 30, "13/05/2021", RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T24", VrsteTermina.pregled, "09:00", 30, "15/04/2021", RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T25", VrsteTermina.pregled, "09:30", 30, "15/04/2021", RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T26", VrsteTermina.pregled, "11:00", 30, "11/04/2021", RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T27", VrsteTermina.pregled, "09:00", 30, "12/05/2021", RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T28", VrsteTermina.pregled, "11:00", 30, "01/05/2021", RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T29", VrsteTermina.pregled, "09:00", 30, "03/05/2021", RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("JelenaHrnjak")));
        }
        public static List<Termin> nadjiVremeTermina(Termin izabraniTermin)
        {
            List<Termin> pomocna = new List<Termin>();

            foreach (Termin t in slobodniTermini)
            {

                if (t.Datum.Equals(izabraniTermin.Datum) && izabraniTermin.Lekar.KorisnickoIme.Equals(t.Lekar.KorisnickoIme))
                {
                    pomocna.Add(t);
                   


                }


            }

            List<Termin> vreme = pomocna.OrderBy(user => DateTime.ParseExact(user.PocetnoVreme, "HH:mm", null)).ToList();

            return vreme;
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
            slobodniTermini.Remove(t);
            SerijalizacijaSlobodnihTermina();
            SerijalizacijaTermina();

            if (sviTermini.Contains(t))
            {
                return t;
            }
            else
            {
                return null;
            }
        }

        public static Termin ZakaziPregledSekretar(Termin t)
        {
            sviTermini.Add(t);
            slobodniTermini.Remove(t);
            SerijalizacijaSlobodnihTermina();
            SerijalizacijaTermina();
            TerminiPregledaSekretar.TerminiPregleda.Add(t);

            if (sviTermini.Contains(t))
            {
                return t;
            }
            else
            {
                return null;
            }
        }

        public static List<Termin> PretraziPoLekaruIIntervalu(DateTime pocetni, DateTime krajnji, String kImeLekara)
        {
            List<Termin> datumi = new List<Termin>();
            List<Termin> konacna = new List<Termin>();

            datumi = ProveriDatum(pocetni, krajnji);

            foreach (Termin termin in datumi)
            {
                if (termin.Lekar.KorisnickoIme.Equals(kImeLekara))
                    konacna.Add(termin);
            }




            return konacna;
        }

        public static Boolean OtkaziTermin(String idTermina)
        {

            Termin t = PretraziPoId(idTermina);

            if (t == null)
            {
                return false;
            }

            sviTermini.Remove(t);
            t.Pacijent = null;
            slobodniTermini.Add(t);
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
        public static Boolean OtkaziPregledSekretar(String idTermina)
        {

            Termin t = PretraziPoId(idTermina);

            if (t == null)
            {
                return false;
            }

            sviTermini.Remove(t);
            t.Pacijent = null;
            slobodniTermini.Add(t);
            TerminiPregledaSekretar.TerminiPregleda.Remove(t);

            SerijalizacijaSlobodnihTermina();
            SerijalizacijaTermina();

            if (sviTermini.Contains(t) || TerminiPregledaSekretar.TerminiPregleda.Contains(t))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static Boolean OtkaziPregled(String idTermina)
        {

            Termin t = PretraziPoId(idTermina);

            if (t == null)
            {
                return false;
            }

            sviTermini.Remove(t);
            t.Pacijent = null;
            slobodniTermini.Add(t);
            PrikazRasporedaPacijent.Termini.Remove(t);

            if (sviTermini.Contains(t) || PrikazRasporedaPacijent.Termini.Contains(t))
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

            int indeks = PrikazRasporedaPacijent.Termini.IndexOf(t);
            PrikazRasporedaPacijent.Termini.RemoveAt(indeks);
            PrikazRasporedaPacijent.Termini.Insert(indeks, t);

            return true;

        }

        public static void PomeriPregled(String idTermina)
        {
            // PrikazTerminaPacijent.TerminZaPomeranje.Pacijent=null;
            PretraziPoId(PrikazRasporedaPacijent.TerminZaPomeranje.IdTermina).Pacijent = null;
            Termin novi = PretraziSlobodnePoId(idTermina);
            novi.Pacijent = RukovanjeNalozimaPacijenata.PretraziPoId("leksann");

            sviTermini.Remove(PrikazRasporedaPacijent.TerminZaPomeranje);
            sviTermini.Add(novi);
            slobodniTermini.Remove(novi);
            slobodniTermini.Add(PrikazRasporedaPacijent.TerminZaPomeranje);

            int indeks = PrikazRasporedaPacijent.Termini.IndexOf(PrikazRasporedaPacijent.TerminZaPomeranje);
            PrikazRasporedaPacijent.Termini.RemoveAt(indeks);
            PrikazRasporedaPacijent.Termini.Insert(indeks, novi);
            PrikazRasporedaPacijent.TerminZaPomeranje = null;

        }

        public static Termin PretraziSlobodnePoId(String idTermina)
        {
            foreach (Termin termin in slobodniTermini)
            {
                if (termin.IdTermina.Equals(idTermina))
                    return termin;
            }
            return null;
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

        public static List<Termin> ProveriDatum(DateTime d1, DateTime d2)
        {
            List<Termin> pomocna = new List<Termin>();



            foreach (Termin t in slobodniTermini)
            {
                DateTime datum = DateTime.ParseExact(t.Datum, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                if (DateTime.Compare(datum, d1) >= 0 && DateTime.Compare(datum, d2) <= 0)
                {
                    pomocna.Add(t);

                }

            }

            List<Termin> datumi = pomocna.OrderBy(user => DateTime.ParseExact(user.Datum, "dd/MM/yyyy", null)).ToList();


            return datumi;
        }

        public static List<Termin> ProveriDatumILekara(DateTime d1, DateTime d2)
        {
            List<Termin> pomocna = new List<Termin>();

            foreach (Termin t in slobodniTermini)
            {
                DateTime datum = DateTime.ParseExact(t.Datum, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                if (DateTime.Compare(datum, d1) >= 0 && DateTime.Compare(datum, d2) <= 0)
                {
                    pomocna.Add(t);



                }

            }

            List<Termin> datumi = pomocna.OrderBy(user => DateTime.ParseExact(user.Datum, "dd/MM/yyyy", null)).ToList();
            return datumi;
        }



        public static bool ProveriMogucnostPomeranjaDatum(string datumPregleda)
        {
            DateTime trenutni1 = DateTime.Now;
            DateTime trenutni = trenutni1.AddDays(1);

            String[] sadasnji = trenutni.ToString().Split(' ');

            String KONACNI = "";

            String[] brojevi = sadasnji[0].Split('/');

            if (brojevi[1].Length == 1)
                KONACNI += "0" + brojevi[1] + "/";
            else
                KONACNI += brojevi[1] + "/";



            if (brojevi[0].Length == 1)
                KONACNI += "0" + brojevi[0] + "/";
            else
                KONACNI += brojevi[0] + "/";





            KONACNI += brojevi[2];
            //Console.WriteLine("konacniiiiiiiiiiiiiiiiiiiiiiiiiii   " + KONACNI);
           // Console.WriteLine("pregledeeeeeeeeeeeeeeeeeeeeeeeeeeeeed   " + datumPregleda);
            if (datumPregleda.Equals(KONACNI))
                return true;



            return false;
        }

        public static bool ProveriMogucnostPomeranjaVreme(String vreme)
        {

            String sadasnji = DateTime.Now.ToString("HH:mm");
            Console.WriteLine(sadasnji);
            // string []splits1= sadasnji.Split(' ');
            string[] splits2 = sadasnji.Split(':');

            string[] pregled = vreme.Split(':');
            int sat = Int32.Parse(splits2[0]);
            int minut = Int32.Parse(splits2[1]);
            //Console.WriteLine("**********************************SADA");
           // Console.WriteLine(sat);
           // Console.WriteLine(minut);
            int satPregleda = Int32.Parse(pregled[0]);
            int minutPregleda = Int32.Parse(pregled[1]);

           // Console.WriteLine("**********************************PREGLED");
            //Console.WriteLine(satPregleda);
           // Console.WriteLine(minutPregleda);

            if (satPregleda < sat)
                return false;
            else if (satPregleda == sat && minut == minutPregleda)
                return false;
            else if (satPregleda == sat && minut > minutPregleda)
                return false;



            return true;
        }
        public static List<Termin> NadjiDatumeZaPomeranje(Termin izabraniTermin)
        {
            List<Termin> povratna = new List<Termin>();


            DateTime pocetni = DateTime.ParseExact(izabraniTermin.Datum, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime pocetnaGranica = pocetni.AddDays(-2);
            DateTime krajnjaGranica = pocetni.AddDays(2);

            foreach (Termin t in slobodniTermini)
            {
                DateTime d = DateTime.ParseExact(t.Datum, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                if (DateTime.Compare(pocetnaGranica, d) <= 0 && DateTime.Compare(d, krajnjaGranica) <= 0 && izabraniTermin.Lekar.KorisnickoIme.Equals(t.Lekar.KorisnickoIme))
                {

                    povratna.Add(t);
                }

            }


            return povratna;
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


        public static List<Termin> DeserijalizacijaSlobodnihTermina()
        {
            if (File.ReadAllText("slobodniTermini.xml").Trim().Equals(""))
            {
                return slobodniTermini;
            }
            else
            {
                FileStream fileStream = File.OpenRead("slobodniTermini.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
                slobodniTermini = (List<Termin>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return slobodniTermini;

            }

        }


        public static void SerijalizacijaSlobodnihTermina()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
            TextWriter tw = new StreamWriter("slobodniTermini.xml");
            xmlSerializer.Serialize(tw, slobodniTermini);
            tw.Close();

        }


    }
}
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
        private static String imeFajla = "termini.xml";

        public static List<Termin> sviTermini = new List<Termin>();
        public static List<Termin> slobodniTermini = new List<Termin>();

        public static List<Lekar> sviLekari = new List<Lekar>();

        public static int brojac { get; set; } = 0;

        public static void PrivremenaInicijalizacijaLekara()
        {

            sviLekari.Add(new Lekar("AleksaStojic", "Aleksa", "Stojic", DateTime.Now, Pol.muski, "421", "Adresa Adresić 123", "06332", "leksa@lekar.com", "aleksastojic"));
            sviLekari.Add(new Lekar("MarkoAndjelic", "Marko", "Andjelic", DateTime.Now, Pol.muski, "43413", "Adresa Adresić 343", "06342", "markic@lekar.com", "markoandjelic"));
            sviLekari.Add(new Lekar("MagdalenaReljin", "Magdalena", "Reljin", DateTime.Now, Pol.zenski, "33313", "Adresa Adresić 353", "0634", "reljinn@lekar.com", "ajdemolimte"));
            sviLekari.Add(new Lekar("JelenaHrnjak", "Jelena", "Hrnjak", DateTime.Now, Pol.zenski, "431", "Adresa Adresić 9", "06343", "jelenah@lekar.com", "jelenahrnjak"));

            foreach (Lekar l in sviLekari)
            {
                if (l.KorisnickoIme.Equals("AleksaStojic"))
                {

                    l.setSpecijalizacija(SpecijalizacijeLekara.neurohirurg);
                }
            }

        }

        public static String ImeiPrezime(String id)
        {
            foreach (Lekar l in sviLekari)
            {

                if (l.KorisnickoIme.Equals(id))
                {
                    return l.Ime + l.Prezime;
                }
            }

            return null;
        }
        public static void InicijalizacijaSTermina()
        {



            slobodniTermini.Add(new Termin("T12", VrsteTermina.pregled, "14:30", 30, new DateTime(2021,5,22), RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T13", VrsteTermina.pregled, "11:00", 30, new DateTime(2021, 5, 24), RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T14", VrsteTermina.pregled, "08:00", 30, new DateTime(2021, 5, 24), RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T19", VrsteTermina.pregled, "19:00", 30, new DateTime(2021, 5, 24), RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T29", VrsteTermina.pregled, "13:00", 30, new DateTime(2021, 5, 26), RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T30", VrsteTermina.pregled, "16:00", 30, new DateTime(2021, 5, 26), RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T35", VrsteTermina.pregled, "16:00", 30, new DateTime(2021, 5, 30), RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("MagdalenaReljin")));
                                                                                                        
            slobodniTermini.Add(new Termin("T15", VrsteTermina.pregled, "16:30", 30, new DateTime(2021, 5, 21), RukovanjeProstorom.PretraziPoId("P2"), null, pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T16", VrsteTermina.pregled, "19:30", 30, new DateTime(2021, 5, 27), RukovanjeProstorom.PretraziPoId("P2"), null, pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T17", VrsteTermina.pregled, "11:00", 30, new DateTime(2021, 5, 27), RukovanjeProstorom.PretraziPoId("P2"), null, pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T18", VrsteTermina.pregled, "09:00", 30, new DateTime(2021, 4, 27), RukovanjeProstorom.PretraziPoId("P2"), null, pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T24", VrsteTermina.pregled, "09:00", 30, new DateTime(2021, 4, 26), RukovanjeProstorom.PretraziPoId("P2"), null, pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T25", VrsteTermina.pregled, "09:30", 30, new DateTime(2021, 4, 28), RukovanjeProstorom.PretraziPoId("P2"), null, pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T26", VrsteTermina.pregled, "11:00", 30, new DateTime(2021, 4, 25), RukovanjeProstorom.PretraziPoId("P2"), null, pretraziLekare("JelenaHrnjak")));




            slobodniTermini.Add(new Termin("T100", VrsteTermina.operacija, "11:00", 120, new DateTime(2021, 4, 27), RukovanjeProstorom.PretraziPoId("OP1"), null, pretraziLekare("AleksaStojic")));
            slobodniTermini.Add(new Termin("T200", VrsteTermina.operacija, "09:00", 120, new DateTime(2021, 5, 3), RukovanjeProstorom.PretraziPoId("OP1"), null, pretraziLekare("AleksaStojic")));
            slobodniTermini.Add(new Termin("T300", VrsteTermina.operacija, "09:00", 120, new DateTime(2021, 6, 3), RukovanjeProstorom.PretraziPoId("OP1"), null, pretraziLekare("AleksaStojic")));
        }

        
        public static List<Termin> nadjiVremeTermina(Termin izabraniTermin)
        {
            List<Termin> pomocna = new List<Termin>();
            List<Termin> pomocna2 = new List<Termin>();
            foreach (Termin t in slobodniTermini)
            {

                if (t.Datum.Equals(izabraniTermin.Datum) && izabraniTermin.Lekar.KorisnickoIme.Equals(t.Lekar.KorisnickoIme))
                {
                    pomocna.Add(t);


                    Console.WriteLine("VREME VRACA" + t.PocetnoVreme);
                }


            }

            // List<Termin> vreme = pomocna.OrderBy(user => DateTime.ParseExact(user.PocetnoVreme, "HH:mm", null)).ToList();
            bool nasao = false;
            foreach (Termin ter1 in pomocna)
            {
                nasao = false;
                foreach (Termin ter2 in pomocna2)
                {
                    if (ter2.PocetnoVreme.Equals(ter1.PocetnoVreme))
                    {
                        nasao = true;
                        break;
                    }
                }
                if (!nasao)
                {

                    pomocna2.Add(ter1);
                    Console.WriteLine("POMOCNA2 VRATILA " + ter1.PocetnoVreme);
                }

            }

            List<Termin> vreme = pomocna2.OrderBy(user => DateTime.ParseExact(user.PocetnoVreme, "HH:mm", null)).ToList();
            return vreme;
        }
        public static Lekar pretraziLekare(String id)
        {
            foreach (Lekar l in sviLekari)
            {

                if (l.KorisnickoIme.Equals(id))
                {
                    return l;
                }
            }

            return null;
        }

        public static Termin ZakaziTermin(Termin t, String lekar)
        {
            sviTermini.Add(t);

            foreach (Termin term in slobodniTermini.ToList())
            {
                if (term.IdTermina.Equals(t.IdTermina))
                {
                    slobodniTermini.Remove(term);
                }
            }


            if (t.Lekar.KorisnickoIme.Equals(lekar))
            {
                PrikazTerminaLekara.Termini.Add(t);
            }

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
                if (termin.Lekar.KorisnickoIme.Equals(kImeLekara) && termin.Lekar.specijalizacija == SpecijalizacijeLekara.nema)
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

        public static Boolean IzmeniTermin(Termin stari, Termin novi, String korisnik)
        {

            foreach (Termin t in slobodniTermini.ToList())
            {
                if (t.IdTermina.Equals(novi.IdTermina))
                {
                    slobodniTermini.Remove(t);
                    sviTermini.Add(novi);
                }

            }

            foreach (Termin t in sviTermini.ToList())
            {
                if (t.IdTermina.Equals(stari.IdTermina))
                {
                    sviTermini.Remove(t);
                    slobodniTermini.Add(stari);
                }
            }

            if (novi.Lekar.KorisnickoIme.Equals(korisnik))
            {
                int indeks = PrikazTerminaLekara.Termini.IndexOf(stari);
                PrikazTerminaLekara.Termini.RemoveAt(indeks);
                PrikazTerminaLekara.Termini.Insert(indeks, novi);
            }

            return true;
        }

        public static void PomeriPregled(String idTermina)
        {
            // PrikazTerminaPacijent.TerminZaPomeranje.Pacijent=null;
            PretraziPoId(PrikazRasporedaPacijent.TerminZaPomeranje.IdTermina).Pacijent = null;
            Termin novi = PretraziSlobodnePoId(idTermina);
            novi.Pacijent = RukovanjeNalozimaPacijenata.PretraziPoId(PacijentGlavniProzor.ulogovani.KorisnickoIme);

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
            foreach (Termin termin in sviTermini)
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
                DateTime datum = t.Datum; // DateTime.ParseExact(t.Datum, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                if (DateTime.Compare(datum, d1) >= 0 && DateTime.Compare(datum, d2) <= 0)
                {
                    pomocna.Add(t);

                }

            }

            List<Termin> datumi = pomocna.OrderBy(user => user.Datum).ToList();

            List<Termin> pomocna1 = new List<Termin>();
            foreach (Termin ter in datumi)
            {
                if (ter.Lekar.specijalizacija.Equals(SpecijalizacijeLekara.nema))
                {
                    pomocna1.Add(ter);
                }
            }


            return pomocna1;
        }

        public static List<Termin> ProveriDatumILekara(DateTime d1, DateTime d2)
        {
            List<Termin> pomocna = new List<Termin>();

            foreach (Termin t in slobodniTermini)
            {
                DateTime datum = t.Datum; //DateTime.ParseExact(t.Datum, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                if (DateTime.Compare(datum, d1) >= 0 && DateTime.Compare(datum, d2) <= 0)
                {
                    pomocna.Add(t);



                }

            }

            List<Termin> datumi = pomocna.OrderBy(user => user.Datum).ToList();
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


            DateTime pocetni = izabraniTermin.Datum;// DateTime.ParseExact(izabraniTermin.Datum, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime pocetnaGranica = pocetni.AddDays(-2);
            DateTime krajnjaGranica = pocetni.AddDays(2);

            foreach (Termin t in slobodniTermini)
            {
                DateTime d = t.Datum;//DateTime.ParseExact(t.Datum, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
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

            for (i = 0; i < sviTermini.Count; i++)
            {
                foreach (Termin t in sviTermini)
                {
                    if (t.IdTermina.Equals("T" + i.ToString()))
                    {
                        pronadjen = true;
                        break;
                    }

                }

                if (!pronadjen)
                {
                    return ("T" + i.ToString());

                }
                pronadjen = false;
            }

            return ("T" + i.ToString());
        }

        public static List<Termin> PretraziPoLekaru(String korImeLekara)
        {

            List<Termin> lekaroviTermini = new List<Termin>();

            foreach (Termin t in sviTermini)
            {
                if (t.Lekar.KorisnickoIme.Equals(korImeLekara))
                {
                    lekaroviTermini.Add(t);
                }

            }

            return lekaroviTermini;
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
            if (File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return sviTermini;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
                sviTermini = (List<Termin>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sviTermini;

            }

        }

        public static void SerijalizacijaTermina()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
            TextWriter tw = new StreamWriter(imeFajla);
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
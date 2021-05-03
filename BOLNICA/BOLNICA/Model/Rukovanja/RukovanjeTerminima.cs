using Bolnica;
using Bolnica.Sekretar.Pregled;
using MoreLinq;
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
            slobodniTermini.Add(new Termin("T12", VrsteTermina.pregled, "15:30", 30, new DateTime(2021,5,22), RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("MagdalenaReljin")));
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
            slobodniTermini.Add(new Termin("T25", VrsteTermina.pregled, "16:30", 30, new DateTime(2021, 5, 4), RukovanjeProstorom.PretraziPoId("P2"), null, pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T26", VrsteTermina.pregled, "11:00", 30, new DateTime(2021, 5, 4), RukovanjeProstorom.PretraziPoId("P2"), null, pretraziLekare("JelenaHrnjak")));




            slobodniTermini.Add(new Termin("T100", VrsteTermina.operacija, "11:00", 120, new DateTime(2021, 4, 27), RukovanjeProstorom.PretraziPoId("OP1"), null, pretraziLekare("AleksaStojic")));
            slobodniTermini.Add(new Termin("T200", VrsteTermina.operacija, "09:00", 120, new DateTime(2021, 5, 3), RukovanjeProstorom.PretraziPoId("OP1"), null, pretraziLekare("AleksaStojic")));
            slobodniTermini.Add(new Termin("T300", VrsteTermina.operacija, "09:00", 120, new DateTime(2021, 6, 3), RukovanjeProstorom.PretraziPoId("OP1"), null, pretraziLekare("AleksaStojic")));
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


        public static void ZakaziPregledPacijent(Termin t)
        {
            sviTermini.Add(t);
            slobodniTermini.Remove(t);
            SerijalizacijaSlobodnihTermina();
            SerijalizacijaTermina();
        }

        public static void OtkaziPregledPacijent(String idTermina)
        {
            Termin t = PretraziPoId(idTermina);
            sviTermini.Remove(t);
            t.Pacijent = null;
            slobodniTermini.Add(t);
            PrikazRasporedaPacijent.TerminiPacijenta.Remove(t);
        }

        public static void PomeriPregledPacijent(String idTermina)
        {
            PretraziPoId(PrikazRasporedaPacijent.TerminZaPomeranje.IdTermina).Pacijent = null;
            Termin noviTermin = PretraziSlobodnePoId(idTermina);
            noviTermin.Pacijent = RukovanjeNalozimaPacijenata.PretraziPoId(PacijentGlavniProzor.ulogovani.KorisnickoIme);
        }

        public static void ZameniTermine(Termin noviTermin)
        {
            sviTermini.Remove(PrikazRasporedaPacijent.TerminZaPomeranje);
            sviTermini.Add(noviTermin);
            slobodniTermini.Remove(noviTermin);
            slobodniTermini.Add(PrikazRasporedaPacijent.TerminZaPomeranje);
        }

        public static void OsveziPrikazPoslePomeranja(Termin noviTermin)
        {
            int indeks = PrikazRasporedaPacijent.TerminiPacijenta.IndexOf(PrikazRasporedaPacijent.TerminZaPomeranje);
            PrikazRasporedaPacijent.TerminiPacijenta.RemoveAt(indeks);
            PrikazRasporedaPacijent.TerminiPacijenta.Insert(indeks, noviTermin);
            PrikazRasporedaPacijent.TerminZaPomeranje = null;
        }

        public static List<Termin> PretraziPoLekaruUIntervalu(List<Termin> terminiUIntervalu, String korisnickoImeLekara)
        {
            List<Termin> terminiKodIzabranog = new List<Termin>();
            foreach (Termin termin in terminiUIntervalu)
            {
                if (termin.Lekar.KorisnickoIme.Equals(korisnickoImeLekara) && termin.Lekar.specijalizacija == SpecijalizacijeLekara.nema)
                    terminiKodIzabranog.Add(termin);
            }
            return terminiKodIzabranog;
        }

        public static List<Termin> NadjiTermineUIntervalu (DateTime pocetakIntervala, DateTime krajIntervala)
        {
            List<Termin> terminiUIntervalu = new List<Termin>();
            foreach (Termin t in slobodniTermini)
            {
                if (DateTime.Compare(t.Datum, pocetakIntervala) >= 0 && DateTime.Compare(t.Datum, krajIntervala) <= 0)
                    terminiUIntervalu.Add(t);
            }
            return FiltrirajTerminePoSpecijalizaciji(terminiUIntervalu);
        }

        private static List<Termin> FiltrirajTerminePoSpecijalizaciji(List<Termin> terminiSvihLekara)
        {
            List<Termin> terminiOpstePrakse = new List<Termin>();
            foreach (Termin termin in terminiSvihLekara)
            {
                if (termin.Lekar.specijalizacija.Equals(SpecijalizacijeLekara.nema))
                    terminiOpstePrakse.Add(termin);
            }
            return terminiOpstePrakse.OrderBy(user => user.Datum).ToList();
        }

        public static bool ProveriMogucnostPomeranjaDatum(DateTime datumPregleda)
        {
            if (DateTime.Compare(DateTime.Now.AddDays(1).Date,datumPregleda.Date)==0)
                return true;
            return false;
        }

        public static bool ProveriMogucnostPomeranjaVreme(String vreme)
        {
            DateTime vremePregleda = DateTime.ParseExact(vreme,"HH:mm",System.Globalization.CultureInfo.InvariantCulture);
            if (vremePregleda.Hour < DateTime.Now.Hour)
                return false;
            else if (vremePregleda.Hour == DateTime.Now.Hour && DateTime.Now.Minute == vremePregleda.Minute)
                return false;
            else if (vremePregleda.Hour == DateTime.Now.Hour && DateTime.Now.Minute > vremePregleda.Minute)
                return false;
            return true;
        }

        public static List<Termin> NadjiVremeTermina(Termin izabraniTermin)
        {
            List<Termin> pomocna = new List<Termin>();
            foreach (Termin termin in slobodniTermini)
            {
                if (termin.Datum.Equals(izabraniTermin.Datum) && 
                 izabraniTermin.Lekar.KorisnickoIme.Equals(termin.Lekar.KorisnickoIme))
                    pomocna.Add(termin);
            }
            return UkloniDupleTermine(pomocna);
        }

        public static List<Termin> UkloniDupleTermine(List<Termin> dupliTermini)
        {
            List<Termin> jedinstveniTermini = new List<Termin>();
            foreach (Termin termin in dupliTermini.DistinctBy(t => t.Datum))
                jedinstveniTermini.Add(termin);
            return SortTerminaPoPocetnomVremenu(jedinstveniTermini);
        }

        public static List<Termin> SortTerminaPoPocetnomVremenu(List<Termin> nesortiraniTermini)
        {
            return nesortiraniTermini.OrderBy(user => DateTime.ParseExact(user.PocetnoVreme, "HH:mm", null)).ToList();
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
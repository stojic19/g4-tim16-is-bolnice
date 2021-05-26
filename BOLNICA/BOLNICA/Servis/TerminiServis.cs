using Bolnica;
using Bolnica.Repozitorijum;
using Bolnica.Sekretar.Pregled;
using Bolnica.Servis;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Model
{
    public class TerminiServis
    {
        private TerminRepozitorijum terminRepozitorijum = new TerminRepozitorijum();
        LekariServis lekariServis = new LekariServis();
        public static List<Lekar> sviLekari = new List<Lekar>();
        public static int brojac { get; set; } = 0;

        public void PrivremenaInicijalizacijaLekara()
        {
            List<Lekar> lekari = new List<Lekar>();
            lekari.Add(new Lekar("AleksaStojic", "Aleksa", "Stojic", DateTime.Now, Pol.muski, "421", "Adresa Adresić 123", "06332", "leksa@lekar.com", "aleksastojic", SpecijalizacijeLekara.neurohirurg));
            lekari.Add(new Lekar("MarkoAndjelic", "Marko", "Andjelic", DateTime.Now, Pol.muski, "43413", "Adresa Adresić 343", "06342", "markic@lekar.com", "markoandjelic", SpecijalizacijeLekara.neurohirurg));
            lekari.Add(new Lekar("MagdalenaReljin", "Magdalena", "Reljin", DateTime.Now, Pol.zenski, "33313", "Adresa Adresić 353", "0634", "reljinn@lekar.com", "ajdemolimte", SpecijalizacijeLekara.nema));
            lekari.Add(new Lekar("JelenaHrnjak", "Jelena", "Hrnjak", DateTime.Now, Pol.zenski, "431", "Adresa Adresić 9", "06343", "jelenah@lekar.com", "jelenahrnjak",SpecijalizacijeLekara.nema));
            lekari.Add(new Lekar("KristinaStojic", "Kristina", "Stojic", DateTime.Now, Pol.zenski, "43121", "Adresa Adresić 54", "0634313", "kristojic@lekar.com", "kristinastojic", SpecijalizacijeLekara.internista));

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Lekar>));
            TextWriter tw = new StreamWriter("lekari.xml");
            xmlSerializer.Serialize(tw, lekari);
            tw.Close();
        }
        public void Serijalizuj()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Lekar>));
            TextWriter tw = new StreamWriter("lekari.xml");
            xmlSerializer.Serialize(tw, sviLekari);
            tw.Close();
        }

        public List<Termin> PretraziPoLekaru(string korisnickoIme)
        {
            return terminRepozitorijum.PretraziPoLekaru(korisnickoIme);
        }

        public Termin PretraziSlobodnePoId(string idTermina)
        {
            return terminRepozitorijum.PretraziSlobodnePoId(idTermina);
        }

        public void OtkaziPregledSekretar(string terminZaOtkazivanje)
        {
            terminRepozitorijum.OtkaziPregledSekretar(terminZaOtkazivanje);
        }

        public static List<Lekar> DobaviSpecijaliste()
        {
            List<Lekar> specijaliste = new List<Lekar>();

            foreach(Lekar l in sviLekari)
            {
                if (l.Specijalizacija != SpecijalizacijeLekara.nema) specijaliste.Add(l);
            }

            return specijaliste;
        }

        public static String ImeiPrezime(String id)
        {
            foreach (Lekar l in sviLekari)
            {

                if (l.KorisnickoIme.Equals(id))
                {
                    return l.Ime + " " + l.Prezime;
                }
            }

            return null;
        }

        public void OtkaziTermin(string idTermina)
        {
            terminRepozitorijum.OtkaziTermin(idTermina);
        }

        public void ZakaziPregledSekretar(Termin termin)
        {
            terminRepozitorijum.ZakaziPregledSekretar(termin);
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

        public void ZakaziTermin(Termin termin, string korisnickoIme)
        {
            terminRepozitorijum.ZakaziTermin(termin, korisnickoIme);
        }

        public Termin PretraziPoId(string idTermina)
        {
            return terminRepozitorijum.PretraziPoId(idTermina);
        }

        public void IzmeniTermin(Termin stariTermin, Termin noviTermin, string korisnik)
        {
            terminRepozitorijum.IzmeniTermin(stariTermin, noviTermin, korisnik);
        }

        //ovo su metode servisa,sve iznad treva prebaciti u LekarServis
        public List<Termin> DobaviSveSlobodneTermine()
        {
            return terminRepozitorijum.DobaviSveSlobodneTermine();
        }
        public List<Termin> DobaviSveZakazaneTermine()
        {
            return terminRepozitorijum.DobaviSveZakazaneTermine();
        }

        public List<Termin> DobaviSveZakazaneTerminePacijenta(String pacijentKorisnickoIme)
        {
            return terminRepozitorijum.DobaviSveZakazaneTerminePacijenta(pacijentKorisnickoIme);
        }


        public Termin DobaviSlobodanTerminPoId(String idTermina)
        {
            return terminRepozitorijum.DobaviSlobodanTerminPoId(idTermina);
        }

        public Termin DobaviZakazanTerminPoId(String idTermina)
        {
            return terminRepozitorijum.DobaviZakazanTerminPoId(idTermina);
        }

        public void ZakaziPregledPacijent(Termin termin)
        {
            terminRepozitorijum.ZakaziPregledPacijent(termin);
        }

        public void OtkaziPregledPacijent(String idTermina)
        {
            terminRepozitorijum.OtkaziPregledPacijent(idTermina);
        }
        public static bool DetektujZloupotrebuSistema(Pacijent pacijent)
        {
            int broj = pacijent.ZloupotrebioSistem + 1;
            pacijent.ZloupotrebioSistem = broj;
            if (pacijent.ZloupotrebioSistem > 5)
            {
                pacijent.Blokiran = true;
                return true;
            }
            return false;
        }

        public void PomeriPregledPacijent(String idTermina)
        {
            terminRepozitorijum.PomeriPregledPacijent(idTermina);
        }


        public List<Termin> PretraziPoLekaruUIntervalu(List<Termin> terminiUIntervalu, String korisnickoImeLekara)
        {
            List<Termin> terminiKodIzabranog = new List<Termin>();
            foreach (Termin termin in terminiUIntervalu)
            {
                if (termin.Lekar.KorisnickoIme.Equals(korisnickoImeLekara) && termin.Lekar.Specijalizacija == SpecijalizacijeLekara.nema)
                    terminiKodIzabranog.Add(termin);
            }
            return terminiKodIzabranog;
        }

        public List<Termin> NadjiTermineUIntervalu(DateTime pocetakIntervala, DateTime krajIntervala)
        {
            List<Termin> terminiUIntervalu = new List<Termin>();
            foreach (Termin t in terminRepozitorijum.DobaviSveSlobodneTermine())
            {
                if (DateTime.Compare(t.Datum, pocetakIntervala) >= 0 && DateTime.Compare(t.Datum, krajIntervala) <= 0)
                    terminiUIntervalu.Add(t);
            }
            return FiltrirajTerminePoSpecijalizaciji(terminiUIntervalu);
        }

        private List<Termin> FiltrirajTerminePoSpecijalizaciji(List<Termin> terminiSvihLekara)
        {
            List<Termin> terminiOpstePrakse = new List<Termin>();
            foreach (Termin termin in terminiSvihLekara)
            {
                if (termin.Lekar.Specijalizacija.Equals(SpecijalizacijeLekara.nema))
                    terminiOpstePrakse.Add(termin);
            }
            return UkloniDupleDatume(SortTerminaPoDatumu(terminiOpstePrakse));
        }

        public bool ProveriMogucnostPomeranjaDatum(DateTime datumPregleda)
        {
            if (DateTime.Compare(DateTime.Now.AddDays(1).Date, datumPregleda.Date) == 0)
                return true;
            return false;
        }

        public bool ProveriMogucnostPomeranjaVreme(String vreme)
        {
            DateTime vremePregleda = DateTime.ParseExact(vreme, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            if (vremePregleda.Hour < DateTime.Now.Hour)
                return false;
            else if (vremePregleda.Hour == DateTime.Now.Hour && DateTime.Now.Minute == vremePregleda.Minute)
                return false;
            else if (vremePregleda.Hour == DateTime.Now.Hour && DateTime.Now.Minute > vremePregleda.Minute)
                return false;
            return true;
        }

        public List<Termin> NadjiVremeTermina(Termin izabraniTermin)
        {
            List<Termin> dupliTermini = new List<Termin>();
            foreach (Termin termin in terminRepozitorijum.DobaviSveSlobodneTermine())
            {
                if (termin.Datum.Equals(izabraniTermin.Datum) &&
                 izabraniTermin.Lekar.KorisnickoIme.Equals(termin.Lekar.KorisnickoIme))
                    dupliTermini.Add(termin);
            }
            return SortTerminaPoPocetnomVremenu(UkloniDupleDatume(dupliTermini));
        }

        private List<Termin> UkloniDupleDatume(List<Termin> dupliTermini)
        {
            List<Termin> jedinstveniTermini = new List<Termin>();
            foreach (Termin termin in dupliTermini.DistinctBy(t => t.Datum))
                jedinstveniTermini.Add(termin);
            return jedinstveniTermini;
        }

        private List<Termin> SortTerminaPoPocetnomVremenu(List<Termin> nesortiraniTermini)
        {
            return nesortiraniTermini.OrderBy(user => DateTime.ParseExact(user.PocetnoVreme, "HH:mm", null)).ToList();
        }

        private List<Termin> SortTerminaPoDatumu(List<Termin> nesrotiraniDatumi)
        {
            return nesrotiraniDatumi.OrderBy(user => user.Datum).ToList();
        }

    }
}
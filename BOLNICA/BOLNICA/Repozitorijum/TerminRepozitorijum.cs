using Bolnica.Sekretar.Pregled;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Bolnica.Repozitorijum
{
    public class TerminRepozitorijum
    {
        private static String zakazaniTerminiFajl = "termini.xml";
        private static String slobodniTerminiFajl = "slobodniTermini.xml";

        NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();
       //-------------------OVE LISTE TREBA OBRISATI KADA SVI URADE SERIJALIZACIJU KAKO TREBA
        public static List<Termin> sviTermini = new List<Termin>();
        public static List<Termin> slobodniTermini = new List<Termin>();
        // --------------------------
        public static void InicijalizacijaSTermina()
        {
            slobodniTermini.Add(new Termin("T12", VrsteTermina.pregled, "14:30", 30, new DateTime(2021, 5, 22), ProstoriServis.PretraziPoId("P1"), null, TerminiServis.pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T12", VrsteTermina.pregled, "15:30", 30, new DateTime(2021, 5, 22), ProstoriServis.PretraziPoId("P1"), null, TerminiServis.pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T13", VrsteTermina.pregled, "11:00", 30, new DateTime(2021, 5, 24), ProstoriServis.PretraziPoId("P1"), null, TerminiServis.pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T14", VrsteTermina.pregled, "08:00", 30, new DateTime(2021, 5, 24), ProstoriServis.PretraziPoId("P1"), null, TerminiServis.pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T19", VrsteTermina.pregled, "19:00", 30, new DateTime(2021, 5, 24), ProstoriServis.PretraziPoId("P1"), null, TerminiServis.pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T29", VrsteTermina.pregled, "13:00", 30, new DateTime(2021, 5, 26), ProstoriServis.PretraziPoId("P1"), null, TerminiServis.pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T30", VrsteTermina.pregled, "16:00", 30, new DateTime(2021, 5, 26), ProstoriServis.PretraziPoId("P1"), null, TerminiServis.pretraziLekare("MagdalenaReljin")));
            slobodniTermini.Add(new Termin("T35", VrsteTermina.pregled, "16:00", 30, new DateTime(2021, 5, 30), ProstoriServis.PretraziPoId("P1"), null, TerminiServis.pretraziLekare("MagdalenaReljin")));
                                                                                                                                                        
            slobodniTermini.Add(new Termin("T15", VrsteTermina.pregled, "16:30", 30, new DateTime(2021, 5, 21), ProstoriServis.PretraziPoId("P2"), null, TerminiServis.pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T16", VrsteTermina.pregled, "19:30", 30, new DateTime(2021, 5, 27), ProstoriServis.PretraziPoId("P2"), null, TerminiServis.pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T17", VrsteTermina.pregled, "11:00", 30, new DateTime(2021, 5, 27), ProstoriServis.PretraziPoId("P2"), null, TerminiServis.pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T18", VrsteTermina.pregled, "09:00", 30, new DateTime(2021, 4, 27), ProstoriServis.PretraziPoId("P2"), null, TerminiServis.pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T24", VrsteTermina.pregled, "09:00", 30, new DateTime(2021, 4, 26), ProstoriServis.PretraziPoId("P2"), null, TerminiServis.pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T25", VrsteTermina.pregled, "16:30", 30, new DateTime(2021, 5, 4), ProstoriServis.PretraziPoId("P2"), null, TerminiServis.pretraziLekare("JelenaHrnjak")));
            slobodniTermini.Add(new Termin("T26", VrsteTermina.pregled, "11:00", 30, new DateTime(2021, 5, 4), ProstoriServis.PretraziPoId("P2"), null, TerminiServis.pretraziLekare("JelenaHrnjak")));

            slobodniTermini.Add(new Termin("T100", VrsteTermina.pregled, "11:00", 120, new DateTime(2021, 5, 27), ProstoriServis.PretraziPoId("OP1"), null, TerminiServis.pretraziLekare("AleksaStojic")));
            slobodniTermini.Add(new Termin("T200", VrsteTermina.operacija, "09:00", 120, new DateTime(2021, 5, 3), ProstoriServis.PretraziPoId("OP1"), null, TerminiServis.pretraziLekare("AleksaStojic")));
            slobodniTermini.Add(new Termin("T300", VrsteTermina.operacija, "09:00", 120, new DateTime(2021, 6, 3), ProstoriServis.PretraziPoId("OP1"), null, TerminiServis.pretraziLekare("AleksaStojic")));
        }
        public static void SerijalizacijaTermina()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
            TextWriter tw = new StreamWriter(zakazaniTerminiFajl);
            xmlSerializer.Serialize(tw, sviTermini);
            tw.Close();

        }
        public static void SerijalizacijaSlobodnihTermina()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
            TextWriter tw = new StreamWriter("slobodniTermini.xml");
            xmlSerializer.Serialize(tw, slobodniTermini);
            tw.Close();

        }
        public Termin ZakaziTermin(Termin t, String lekar)
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
        public Termin nadjiSlobodanTerminPoId(String id)
        {
            Termin t = new Termin();

            return t;
        }
        public Termin ZakaziPregledSekretar(Termin t)
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
        public Boolean OtkaziTermin(String idTermina)
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

        public Termin PretraziSlobodnePoId(String idTermina)
        {
            foreach (Termin termin in slobodniTermini)
            {
                if (termin.IdTermina.Equals(idTermina))
                    return termin;
            }
            return null;
        }

        public Termin PretraziPoId(String idTermina)
        {
            foreach (Termin termin in sviTermini)
            {
                if (termin.IdTermina.Equals(idTermina))
                    return termin;
            }
            return null;
        }
        public Boolean OtkaziPregledSekretar(String idTermina)
        {

            Termin termin = PretraziPoId(idTermina);

            if (termin == null)
            {
                return false;
            }

            sviTermini.Remove(termin);
            termin.Pacijent = null;
            slobodniTermini.Add(termin);
            TerminiPregledaSekretar.TerminiPregleda.Remove(termin);

            SerijalizacijaSlobodnihTermina();
            SerijalizacijaTermina();

            return !DaLiListeSadrzeTerminSekretar(termin);
        }
        private bool DaLiListeSadrzeTerminSekretar(Termin termin)
        {
            return sviTermini.Contains(termin) || TerminiPregledaSekretar.TerminiPregleda.Contains(termin);
        }

        public Boolean IzmeniTermin(Termin stari, Termin novi, String korisnik)
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

        public List<Termin> DobaviSveTermine()
        {
            return sviTermini;
        }

        public List<Termin> PretraziPoLekaru(String korImeLekara)
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
        public List<Termin> DeserijalizacijaTermina()
        {
            if (File.ReadAllText(zakazaniTerminiFajl).Trim().Equals(""))
            {
                return sviTermini;
            }
            else
            {
                FileStream fileStream = File.OpenRead(zakazaniTerminiFajl);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
                sviTermini = (List<Termin>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sviTermini;

            }

        }


        //OVO SU NOVE METODE ZA DIREKTNO CITANJE IZ DATOTEKE KOJE SVI TREBA DA KORISTE

        public List<Termin> DobaviSveSlobodneTermine()
        {
            List<Termin> sviSlobodniTermini = new List<Termin>();
            if (File.ReadAllText(slobodniTerminiFajl).Trim().Equals(""))
            {
                return sviSlobodniTermini;
            }
            else
            {
                FileStream fileStream = File.OpenRead(slobodniTerminiFajl);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
                sviSlobodniTermini = (List<Termin>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sviSlobodniTermini;
            }
   
        }
        public  List<Termin> DobaviSveZakazaneTermine()
        {
            List<Termin> sviZakazaniTermini = new List<Termin>();
            if (File.ReadAllText(slobodniTerminiFajl).Trim().Equals(""))
            {
                return sviZakazaniTermini;
            }
            else
            {
                FileStream fileStream = File.OpenRead(slobodniTerminiFajl);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
                sviZakazaniTermini = (List<Termin>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sviZakazaniTermini;
            }

        }

        public List<Termin> DobaviSveZakazaneTerminePacijenta(String pacijentKorisnickoIme)
        {
            List<Termin> sviTerminiPacijenta = new List<Termin>();
            foreach (Termin termin in DobaviSveZakazaneTermine())
            {
                if (termin.Pacijent.KorisnickoIme.Equals(pacijentKorisnickoIme))
                    sviTerminiPacijenta.Add(termin);
            }
            return sviTerminiPacijenta;
        }


        public Termin DobaviSlobodanTerminPoId(String idTermina)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(slobodniTerminiFajl);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode node = root.SelectSingleNode("//ArrayOfTermin/Termin[IdTermina='" + idTermina + "']", nsmgr);
            Termin termin = KonvertujCvorUObjekat(node);
            return termin;

        }

        public Termin DobaviZakazanTerminPoId(String idTermina)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(zakazaniTerminiFajl);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode node = root.SelectSingleNode("//ArrayOfTermin/Termin[IdTermina='" + idTermina + "']", nsmgr);
            Termin termin = KonvertujCvorUObjekat(node);
            return termin;

        }


        private Termin KonvertujCvorUObjekat(XmlNode cvorTermina)
        {
            MemoryStream stm = new MemoryStream();
            StreamWriter stw = new StreamWriter(stm);
            stw.Write(cvorTermina.OuterXml);
            stw.Flush();
            stm.Position = 0;
            XmlSerializer ser = new XmlSerializer(typeof(Termin));
            return (ser.Deserialize(stm) as Termin);
        }

        private List<Termin> KonvertujSveCvoroveUObjekte(XmlNodeList cvoroviTermina)
        {
            List<Termin> objektiTermina = new List<Termin>();
            foreach (XmlNode node in cvoroviTermina)
            {
                objektiTermina.Add(KonvertujCvorUObjekat(node));
            }
            return objektiTermina;
        }
        public void ObrisiZakazanTermin(Termin terminZaBrisanje)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(zakazaniTerminiFajl);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode node = root.SelectSingleNode("//ArrayOfTermin/Termin[IdTermina='" + terminZaBrisanje.IdTermina + "']", nsmgr);
            XmlNode parent = node.ParentNode;
            parent.RemoveChild(node);
            doc.Save(@zakazaniTerminiFajl);
        }
        public void ObrisiSlobodanTermin(Termin terminZaBrisanje)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(slobodniTerminiFajl);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode node = root.SelectSingleNode("//ArrayOfTermin/Termin[IdTermina='" + terminZaBrisanje.IdTermina + "']", nsmgr);
            XmlNode parent = node.ParentNode;
            parent.RemoveChild(node);
            doc.Save(slobodniTerminiFajl);

        }
        public void SacuvajSlobodanTermin(Termin terminZaUpis)
        {
            List<Termin> termini = DobaviSveSlobodneTermine();
            termini.Add(terminZaUpis);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
            TextWriter tw = new StreamWriter(slobodniTerminiFajl);
            xmlSerializer.Serialize(tw, termini);
            tw.Close();

        }
        public void SacuvajZakazanTermin(Termin terminZaUpis)
        {
            List<Termin> termini = DobaviSveZakazaneTermine();
            termini.Add(terminZaUpis);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
            TextWriter tw = new StreamWriter(zakazaniTerminiFajl);
            xmlSerializer.Serialize(tw, termini);
            tw.Close();
        }

        public void ZakaziPregledPacijent(Termin termin)
        {
            SacuvajZakazanTermin(termin);
            ObrisiSlobodanTermin(termin);
        }

        public void OtkaziPregledPacijent(String idTermina)
        {
            Termin t = DobaviZakazanTerminPoId(idTermina);
            ObrisiZakazanTermin(t);
            t.Pacijent = null;
            SacuvajSlobodanTermin(t);
            DetektujZloupotrebuSistema(PacijentGlavniProzor.ulogovani);
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
            Termin stari = PretraziPoId(PrikazRasporedaPacijent.TerminZaPomeranje.IdTermina);
            PretraziPoId(PrikazRasporedaPacijent.TerminZaPomeranje.IdTermina).Pacijent = null;
            Termin noviTermin = PretraziSlobodnePoId(idTermina);
            noviTermin.Pacijent = naloziPacijenataServis.PretraziPoId(PacijentGlavniProzor.ulogovani.KorisnickoIme);
            ZameniTermine(stari,noviTermin);
            DetektujZloupotrebuSistema(PacijentGlavniProzor.ulogovani);
        }

        public void ZameniTermine(Termin stariTermin, Termin noviTermin)
        {
            SacuvajSlobodanTermin(stariTermin);
            SacuvajZakazanTermin(noviTermin);
            ObrisiSlobodanTermin(noviTermin);
            ObrisiZakazanTermin(stariTermin);
        }

      

    }
}

using Bolnica.SekretarFolder.Operacija;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    class RukovanjeOperacijama
    {
        //private static String imeFajla = "terminiOperacija.xml";

        public static List<Termin> sviTermini = new List<Termin>();
        public static List<Termin> slobodniTermini = new List<Termin>();

        public static List<Lekar> sviLekari = new List<Lekar>();

        public static void PrivremenaInicijalizacijaLekara()
        {

            sviLekari.Add(new Lekar("AleksaStojic", "Aleksa", "Stojic", DateTime.Now, Pol.muski, "421", "Adresa Adresić 123", "06332", "leksa@lekar.com", "aleksastojic"));
            sviLekari.Add(new Lekar("NinaStojic", "Nina", "Stojic", DateTime.Now, Pol.zenski, "33313", "Adresa Adresić 353", "0634", "nina@lekar.com", "ninastojic"));
            sviLekari.Add(new Lekar("MicaUbica", "Mica", "Ubica", DateTime.Now, Pol.zenski, "431", "Adresa Adresić 9", "06343", "jelenah@lekar.com", "micaubica"));

            foreach (Lekar l in sviLekari)
            {
                if (l.KorisnickoIme.Equals("AleksaStojic"))
                {
                    l.setSpecijalizacija(SpecijalizacijeLekara.neurohirurg);
                }
                if (l.KorisnickoIme.Equals("NinaStojic"))
                {
                    l.setSpecijalizacija(SpecijalizacijeLekara.kardiohirurg);
                }
                if (l.KorisnickoIme.Equals("MicaUbica"))
                {
                    l.setSpecijalizacija(SpecijalizacijeLekara.kardiohirurg);
                }
            }
            slobodniTermini.Add(new Termin("T12", VrsteTermina.pregled, "14:00", 420, DateTime.Now, RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("AleksaStojic")));
            slobodniTermini.Add(new Termin("T13", VrsteTermina.pregled, "14:00", 420, DateTime.Now.AddDays(1), RukovanjeProstorom.PretraziPoId("P1"), null, pretraziLekare("AleksaStojic")));
            sviTermini.Add(new Termin("T14", VrsteTermina.pregled, "20:00", 420, DateTime.Now, RukovanjeProstorom.PretraziPoId("P2"), RukovanjeNalozimaPacijenata.PretraziPoId("magdalena"), pretraziLekare("NinaStojic")));
            slobodniTermini.Add(new Termin("T19", VrsteTermina.pregled, "14:00", 420, DateTime.Now.AddDays(2), RukovanjeProstorom.PretraziPoId("P2"), null, pretraziLekare("NinaStojic")));
            sviTermini.Add(new Termin("T29", VrsteTermina.pregled, "20:00", 420, DateTime.Now, RukovanjeProstorom.PretraziPoId("P3"), RukovanjeNalozimaPacijenata.PretraziPoId("magdalena"), pretraziLekare("MicaUbica")));
            slobodniTermini.Add(new Termin("T30", VrsteTermina.pregled, "14:00", 420, DateTime.Now.AddDays(3), RukovanjeProstorom.PretraziPoId("P3"), null, pretraziLekare("MicaUbica")));
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
        public static void OsveziSlobodneTermine(int trenutniSat, int trenutniMinut)
        {
            string[] vreme;
            int pocetniSatTermina, pocetniMinutTermina, trajanje;
            List<Termin> pomocni = new List<Termin>();
            foreach (Termin t in slobodniTermini)
            {
                Termin termin = t;
                vreme = termin.PocetnoVreme.Split(':');
                pocetniSatTermina = Convert.ToInt32(vreme[0]);
                pocetniMinutTermina = Convert.ToInt32(vreme[1]);
                if (DaLiJeTerminPreDanasnjegDana(t))
                {
                    continue;
                }
                else if (DaLiJeTerminPoceoRanijeDanas(trenutniSat, trenutniMinut, pocetniSatTermina, pocetniMinutTermina, t))
                {
                    trajanje = 0;
                    IzracunajKrajnjiDatumTermina(ref pocetniSatTermina, ref pocetniMinutTermina, ref termin);
                    if(TerminSeZavrsio(trenutniSat, trenutniMinut, pocetniSatTermina, pocetniMinutTermina))
                    {
                        continue;
                    }
                    NovoPocetnoVremeTermina(trenutniSat, trenutniMinut, ref termin);
                    PreostaloVremeTermina(trenutniSat, trenutniMinut, vreme, trajanje,ref termin);
                    pomocni.Add(termin);
                }
                else
                {
                    pomocni.Add(termin);
                }
            }
            slobodniTermini = pomocni;
        }

        private static bool TerminSeZavrsio(int trenutniSat,int trenutniMinut,int pocetniSatTermina,int pocetniMinutTermina)
        {
            if (pocetniSatTermina < trenutniSat)
            {
                return true;
            }
            else if (pocetniSatTermina == trenutniSat && pocetniMinutTermina < trenutniMinut)
            {
                return true;
            }
            return false;
        }

        private static void PreostaloVremeTermina(int trenutniSat, int trenutniMinut, string[] vreme, int trajanje,ref Termin termin)
        {
            if (Convert.ToInt32(vreme[0]) > trenutniSat)
            {
                trajanje += (trenutniSat - (Convert.ToInt32(vreme[0]) - 24)) * 60;
            }
            else
            {
                trajanje += (trenutniSat - Convert.ToInt32(vreme[0])) * 60;
            }
            trajanje += trenutniMinut - Convert.ToInt32(vreme[1]);
            termin.Trajanje -= trajanje;
        }

        private static void NovoPocetnoVremeTermina(int trenutniSat, int trenutniMinut,ref Termin termin)
        {
            if (trenutniMinut >= 0 && trenutniMinut <= 9)
            {
                termin.PocetnoVreme = trenutniSat + ":0" + trenutniMinut;
            }
            else
            {
                termin.PocetnoVreme = trenutniSat + ":" + trenutniMinut;
            }
        }

        private static void IzracunajKrajnjiDatumTermina(ref int pocetniSatTermina, ref int pocetniMinutTermina,ref Termin termin)
        {
            pocetniSatTermina += (int)termin.Trajanje / 60;
            pocetniMinutTermina += (int)termin.Trajanje % 60;
            if (pocetniMinutTermina >= 60)
            {
                pocetniSatTermina++;
                pocetniMinutTermina -= 60;
            }
            if (pocetniSatTermina >= 24)
            {
                pocetniSatTermina -= 24;
                termin.Datum = DateTime.Now;
            }
        }

        private static bool DaLiJeTerminPoceoRanijeDanas(int Sat, int Minut, int sat, int minut, Termin t)
        {
            return DateTime.Compare(t.Datum.Date, DateTime.Now.Date) == 0 && (sat < Sat || (sat == Sat && minut < Minut));
        }

        private static bool DaLiJeTerminPreDanasnjegDana(Termin t)
        {
            return DateTime.Compare(t.Datum.Date, DateTime.Now.Date) < 0;
        }

        public static void ProveriTermineZaSpajanje()
        {
            String[] vreme;
            OsveziSlobodneTermine(Convert.ToInt32(DateTime.Now.ToString("HH")), Convert.ToInt32(DateTime.Now.ToString("mm")));
            List<Termin> pomocni = new List<Termin>();
            foreach (Termin termin in slobodniTermini)
            {
                int sat, minut;
                string krajTermina = "";
                vreme = termin.PocetnoVreme.Split(':');
                sat = Convert.ToInt32(vreme[0]);
                minut = Convert.ToInt32(vreme[1]);
                IzracunajKrajTermina(ref sat, ref minut, (int)termin.Trajanje, ref krajTermina);
                if (KrajTerminaSutra(Convert.ToInt32(vreme[0]), sat))   //Kraj termina je sutradan
                {
                    pomocni.Add(termin);
                    foreach (Termin termin1 in slobodniTermini)
                    {
                        if (TerminiSeNastavljaju(termin, krajTermina, termin1))
                        {
                            pomocni.Remove(termin);
                            termin.Trajanje += termin1.Trajanje;
                            pomocni.Add(termin);
                            break;
                        }
                    }
                }
                else                                //Kraj termina je isti dan
                {
                    pomocni.Add(termin);
                    foreach (Termin termin1 in slobodniTermini)
                    {
                        if (TerminiSeNastavljajuIstiDan(termin, krajTermina, termin1))
                        {
                            pomocni.Remove(termin);
                            termin.Trajanje += termin1.Trajanje;
                            pomocni.Add(termin);
                            break;
                        }
                    }
                }
            }
            slobodniTermini = pomocni;
        }

        private static bool TerminiSeNastavljajuIstiDan(Termin termin, string krajTermina, Termin termin1)
        {
            return !termin1.IdTermina.Equals(termin.IdTermina) && termin1.PocetnoVreme.Equals(krajTermina) && DateTime.Compare(termin1.Datum.Date, termin.Datum.Date) == 0;
        }

        private static bool TerminiSeNastavljaju(Termin termin, string krajTermina, Termin termin1)
        {
            return !termin1.IdTermina.Equals(termin.IdTermina) && termin1.PocetnoVreme.Equals(krajTermina) && DateTime.Compare(termin1.Datum.Date, termin.Datum.AddDays(1).Date) == 0;
        }

        private static bool KrajTerminaSutra(int Sat, int sat)
        {
            return Sat > sat;
        }

        private static void IzracunajKrajTermina(ref int sat,ref int minut, int trajanje,ref string krajTermina)
        {
            sat += trajanje/60;
            minut += trajanje % 60;
            if(minut>=60)
            {
                minut -= 60;
                sat++;
            }
            if(sat>=24)
            {
                sat -= 24;
            }
            if (minut >= 0 && minut <= 9)
            {
                krajTermina = sat + ":0" + minut;
            }
            else
            {
                krajTermina = sat + ":" + minut;
            }
        }
        public static List<Termin> HitnaOperacijaSlobodniTermini(SpecijalizacijeLekara oblastLekara, int trajanje)
        {
            List<Termin> pomocna = new List<Termin>();
            List<String> vreme = new List<string>();
            int sat = Convert.ToInt32(DateTime.Now.ToString("HH"));
            int minut = Convert.ToInt32(DateTime.Now.ToString("mm"));
            OsveziSlobodneTermine(sat, minut);

            vreme = DobaviPocetkeTermina(ref sat, ref minut);
            foreach (Termin t in slobodniTermini)
            {
                if (TerminOdgovaraHitnojOperaciji(oblastLekara, trajanje, t))
                {
                    foreach (String cas in vreme)
                    {
                        if (cas.Equals(t.PocetnoVreme))
                        {
                            pomocna.Add(t);
                            break;
                        }
                    }
                }
            }
            return pomocna;
        }

        private static bool TerminOdgovaraHitnojOperaciji(SpecijalizacijeLekara oblastLekara, int trajanje, Termin t)
        {
            return DateTime.Compare(t.Datum.Date, DateTime.Now.Date) == 0 && t.Lekar.specijalizacija.Equals(oblastLekara) && t.Trajanje >= trajanje;
        }

        private static List<String> DobaviPocetkeTermina(ref int sat, ref int minut)
        {
            List<String> vreme = new List<string>();
            minut--;
            if (minut < 0)
            {
                minut = 59;
                sat--;
                if (sat < 0)
                {
                    sat = 23;
                }
            }
            for (int i = 0; i < 60; i++)    //Trazi slobodne termine koji pocinju u narednih sat vremena
            {
                if (minut >= 0 && minut <= 9)
                {
                    vreme.Add(sat + ":0" + minut);
                }
                else
                {
                    vreme.Add(sat + ":" + minut);
                }
                minut++;
                if (minut == 60)
                {
                    minut = 0;
                    sat++;
                    if (sat == 24)
                    {
                        sat = 0;
                    }
                }
            }
            return vreme;
        }

        public static Dictionary<Termin, int> HitnaOperacijaTerminiZaPomeranje(SpecijalizacijeLekara oblastLekara, int trajanje)
        {
            List<Termin> pomocna = new List<Termin>();
            List<String> vreme = new List<string>();
            int sat = Convert.ToInt32(DateTime.Now.ToString("HH"));
            int minut = Convert.ToInt32(DateTime.Now.ToString("mm"));
            vreme = DobaviPocetkeTermina(ref sat, ref minut);
            foreach (Termin t in sviTermini)
            {
                if (sat != 23 && DateTime.Compare(t.Datum.Date, DateTime.Now.Date) == 0 && t.Lekar.specijalizacija.Equals(oblastLekara) && t.Trajanje >= trajanje)
                {
                    foreach (String cas in vreme)
                    {
                        if (cas.Equals(t.PocetnoVreme))
                        {
                            pomocna.Add(t);
                            break;
                        }
                    }
                }
                else if ((DateTime.Compare(t.Datum.Date, DateTime.Now.Date) == 0 || DateTime.Compare(t.Datum.Date, DateTime.Now.AddDays(1).Date) == 0) && t.Lekar.specijalizacija.Equals(oblastLekara) && t.Trajanje >= trajanje)
                {
                    foreach (String cas in vreme)
                    {
                        if (cas.Equals(t.PocetnoVreme))
                        {
                            pomocna.Add(t);
                            break;
                        }
                    }
                }

            }
            var map = new Dictionary<Termin, int>();
            foreach (Termin t in pomocna)
            {
                map.Add(t, PomeranjeOperacije(t));
            }
            return map;
        }
        public static int PomeranjeOperacije(Termin termin)
        {
            List<Termin> pomocna = new List<Termin>();
            TimeSpan vreme;
            int danaPomereno = -1;
            foreach (Termin t in slobodniTermini)
            {
                if (TerminPogodanZaPomeranje(termin, t))
                {
                    vreme = t.Datum.Subtract(termin.Datum);
                    if (danaPomereno == -1)
                    {
                        danaPomereno = (int)vreme.TotalDays;
                    }
                    else if ((int)vreme.TotalDays < danaPomereno)
                    {
                        danaPomereno = (int)vreme.TotalDays;
                    }
                }
            }
            return danaPomereno;
        }

        private static bool TerminPogodanZaPomeranje(Termin termin, Termin t)
        {
            return DateTime.Compare(t.Datum.Date, DateTime.Now.Date) >= 0 && t.Lekar.Equals(termin.Lekar) && t.Trajanje >= termin.Trajanje;
        }

        public static void PomeriTerminUSledeciSlobodan(Termin termin,int brojDana)
        {
            List<Termin> pomocna = new List<Termin>();
            TimeSpan vreme;
            foreach (Termin t in slobodniTermini)
            {
                if (TerminPogodanZaPomeranje(termin, t))
                {
                    vreme = t.Datum.Subtract(termin.Datum);
                    if ((int)vreme.TotalDays == brojDana)
                    {
                        t.Pacijent = termin.Pacijent;
                        ZakazivanjeHitneOperacije(t,(int)termin.Trajanje);
                        sviTermini.Remove(termin);
                        termin.Pacijent = null;   
                        slobodniTermini.Add(termin);
                        break;
                    }
                }
            }
        }
        public static bool PomeriOperacijuIZakaziNovu(Termin termin,int brojDana,Pacijent pacijent,int trajanje)
        {
            PomeriTerminUSledeciSlobodan(termin, brojDana);
            termin.Pacijent = pacijent;
            bool povratnaVrednost = ZakazivanjeHitneOperacije(termin, trajanje);
            ProveriTermineZaSpajanje();
            return povratnaVrednost;
        }
        public static bool OtkazivanjeOperacije(Termin termin)
        {
            int sat = Convert.ToInt32(DateTime.Now.ToString("HH"));
            int minut = Convert.ToInt32(DateTime.Now.ToString("mm"));
            string[] vreme = termin.PocetnoVreme.Split(':');
            if (DateTime.Compare(termin.Datum, DateTime.Now) < 0)
            {
                return false;
            }
            else if (Convert.ToInt32(vreme[0]) < sat)
            {
                return false;
            }
            else if (Convert.ToInt32(vreme[0]) == sat && Convert.ToInt32(vreme[1]) < minut)
            {
                return false;
            }
            sviTermini.Remove(termin);
            termin.Pacijent = null;
            slobodniTermini.Add(termin);
            ProveriTermineZaSpajanje();
            return true;
        }
        public static bool ZakazivanjeHitneOperacije(Termin termin,int trajanje)
        {
            int sat = Convert.ToInt32(DateTime.Now.ToString("HH"));
            int minut = Convert.ToInt32(DateTime.Now.ToString("mm"));
            string trenutnoVreme;
            string[] vreme = termin.PocetnoVreme.Split(':');
            if (minut >= 0 && minut <= 9)
            {
                trenutnoVreme = sat + ":0" + minut;
            }
            else
            {
                trenutnoVreme = sat + ":" + minut;
            }
            int preostaloVreme = (int)termin.Trajanje;
            if (DateTime.Compare(termin.Datum.Date, DateTime.Now.Date) == 0 && (sat > Convert.ToInt32(vreme[0]) || (sat == Convert.ToInt32(vreme[0]) && minut > Convert.ToInt32(vreme[1]))))
            { 
                if((sat - Convert.ToInt32(vreme[0]))<0)
                {
                    preostaloVreme -= (sat - Convert.ToInt32(vreme[0]) + 24) * 60 + (minut - Convert.ToInt32(vreme[1]));
                }
                else
                {
                    preostaloVreme -= (sat - Convert.ToInt32(vreme[0])) * 60 + (minut - Convert.ToInt32(vreme[1]));
                }    
                if(preostaloVreme < trajanje)
                {
                    Console.WriteLine(preostaloVreme + " " + trajanje);
                    return false;
                }
                termin.PocetnoVreme = trenutnoVreme;
            }
            termin.Trajanje = trajanje;
            foreach (Termin t in slobodniTermini)
            {
                if (t.IdTermina.Equals(termin.IdTermina))
                {
                    slobodniTermini.Remove(t);
                    break;
                }
            }
            sviTermini.Add(termin);
            if (preostaloVreme - trajanje == 0)
            {    
                Termin ostatak;
                sat = Convert.ToInt32(vreme[0]);
                minut = Convert.ToInt32(vreme[1]);
                 sat += trajanje / 60;
                minut += trajanje % 60;
                if (minut >= 60)
                {
                   sat++;
                   minut -= 60;
                }
                if (sat >= 24)
                {
                    sat -= 24;
                    if (minut >= 0 && minut <= 9)
                    {
                        trenutnoVreme = sat + ":0" + minut;
                    }
                    else
                    {
                        trenutnoVreme = sat + ":" + minut;
                    }
                    ostatak = new Termin(generisiID(), VrsteTermina.operacija, trenutnoVreme, preostaloVreme - trajanje, DateTime.Now.AddDays(1), termin.Prostor, termin.Pacijent, termin.Lekar); ;
                }
                else
                {
                    if (minut >= 0 && minut <= 9)
                    {
                        trenutnoVreme = sat + ":0" + minut;
                    }
                    else
                    {
                       trenutnoVreme = sat + ":" + minut;
                    }
                    ostatak = new Termin(generisiID(), VrsteTermina.operacija, trenutnoVreme, preostaloVreme - trajanje, DateTime.Now, termin.Prostor, termin.Pacijent, termin.Lekar);
                }
                slobodniTermini.Add(ostatak);
            }
            return true;
        }
        public static string generisiID()
        {
            return Guid.NewGuid().ToString();
        }
    }   
}
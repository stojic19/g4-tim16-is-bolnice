using Bolnica.DTO;
using Bolnica.Konverter;
using Bolnica.Repozitorijum;
using Bolnica.SekretarFolder.Operacija;
using Bolnica.Servis;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    class OperacijeServis
    {
        SlobodniTerminiServis slobodniTerminiServis = new SlobodniTerminiServis();
        OperacijeRepozitorijum operacijeRepozitorijum = new OperacijeRepozitorijum();
        NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();
        ObavestenjaServis obavestenjaServis = new ObavestenjaServis();
        LekariServis lekariServis = new LekariServis();
        PacijentKonverter pacijentKonverter = new PacijentKonverter();
        TerminKonverter terminKonverter = new TerminKonverter();
        ProstoriServis prostoriServis = new ProstoriServis();

        public List<Termin> DobaviSveOperacije()
        {
            return operacijeRepozitorijum.DobaviSveObjekte();
        }

        private double DobaviNovuSmenu(RadniDan radniDanStari, RadniDan radniDanNovi)
        {
            return radniDanNovi.PocetakSmene.TimeOfDay.TotalMinutes - radniDanStari.PocetakSmene.TimeOfDay.TotalMinutes;
        }
        
        public void OsveziSlobodneTermine()
        {
            List<Termin> termini = slobodniTerminiServis.DobaviSveSlobodneTermineZaOperacije();
            foreach (Termin termin in termini)
            {
                if (DaLiJeTerminPreDanasnjegDana(termin))
                {
                    slobodniTerminiServis.Ukloni(termin);
                }
                else if (DaLiJeTerminPoceoRanijeDanas(termin))
                {
                    if(TerminSeZavrsio(termin))
                    {
                        slobodniTerminiServis.Ukloni(termin);
                    }
                    else
                    {
                        slobodniTerminiServis.Izmeni(termin.IdTermina, NovoPocetnoVremeITrajanjeTermina(termin));
                    }
                }
            }
        }

        private bool TerminSeZavrsio(Termin termin)
        {
            return DateTime.Compare(termin.Datum.AddMinutes(termin.Trajanje), DateTime.Now) <= 0;
        }

        private Termin NovoPocetnoVremeITrajanjeTermina(Termin termin)
        {
            TimeSpan preostaloVremeTermina = termin.Datum.AddMinutes(termin.Trajanje) - DateTime.Now;
            return new Termin(termin.IdTermina,VrsteTermina.operacija, DateTime.Now.ToString("HH:mm"), (int)preostaloVremeTermina.TotalMinutes, DateTime.Now, new Prostor(),new Pacijent(),termin.Lekar);
        }

        private bool DaLiJeTerminPoceoRanijeDanas(Termin termin)
        {
            return DateTime.Compare(termin.Datum, DateTime.Now) < 0;
        }

        private bool DaLiJeTerminPreDanasnjegDana(Termin termin)
        {
            return DateTime.Compare(termin.Datum.Date, DateTime.Now.Date.AddDays(-1)) < 0;
        }

        public void ProveriTermineZaSpajanje()
        {
            OsveziSlobodneTermine();
            List<Termin> termini = slobodniTerminiServis.DobaviSveSlobodneTermineZaOperacije();
            foreach (Termin termin in termini)
            {
                DateTime krajTermina = DobaviKrajTermina(termin);
                foreach (Termin terminZaUporedjivanje in termini)
                {
                    if (TerminiSeNastavljaju(krajTermina, terminZaUporedjivanje) && TerminiPripadajuIstomLekaru(termin, terminZaUporedjivanje))
                    {
                        slobodniTerminiServis.Ukloni(terminZaUporedjivanje);
                        slobodniTerminiServis.Izmeni(termin.IdTermina, SpojiTermine(termin, terminZaUporedjivanje));
                        break;
                    }
                }
            }
        }

        private static bool TerminiPripadajuIstomLekaru(Termin termin, Termin terminZaUporedjivanje)
        {
            return termin.Lekar.KorisnickoIme.Equals(terminZaUporedjivanje.Lekar.KorisnickoIme);
        }

        private bool TerminiSeNastavljaju(DateTime krajTermina, Termin terminZaUporedjivanje)
        {
            return DateTime.Compare(krajTermina, terminZaUporedjivanje.Datum) == 0;
        }

        private Termin SpojiTermine(Termin termin, Termin terminZaUporedjivanje)
        {
            return new Termin(termin.IdTermina, termin.VrstaTermina, termin.PocetnoVreme, termin.Trajanje + terminZaUporedjivanje.Trajanje, termin.Datum, termin.Prostor, termin.Pacijent, termin.Lekar);
        }

        private DateTime DobaviKrajTermina(Termin termin)
        {
            return termin.Datum.AddMinutes(termin.Trajanje);
        }

        public List<Termin> HitnaOperacijaSlobodniTermini(SpecijalizacijeLekara oblastLekara, int trajanje)
        {
            List<Termin> pomocna = new List<Termin>();
            List<String> vreme = new List<string>();
            int sat = Convert.ToInt32(DateTime.Now.ToString("HH"));
            int minut = Convert.ToInt32(DateTime.Now.ToString("mm"));
            OsveziSlobodneTermine();

            vreme = DobaviPocetkeTermina(ref sat, ref minut);
            foreach (Termin t in slobodniTerminiServis.DobaviSveSlobodneTermineZaOperacije())
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

        private bool TerminOdgovaraHitnojOperaciji(SpecijalizacijeLekara oblastLekara, int trajanje, Termin t)
        {
            return DateTime.Compare(t.Datum.Date, DateTime.Now.Date) == 0 && t.Lekar.Specijalizacija.Equals(oblastLekara) && t.Trajanje >= trajanje;
        }

        private List<String> DobaviPocetkeTermina(ref int sat, ref int minut)
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

        public Dictionary<TerminDTO, int> HitnaOperacijaTerminiZaPomeranje(SpecijalizacijeLekara oblastLekara, int trajanje)
        {
            List<TerminDTO> pomocna = new List<TerminDTO>();
            List<String> vreme = new List<string>();
            int sat = Convert.ToInt32(DateTime.Now.ToString("HH"));
            int minut = Convert.ToInt32(DateTime.Now.ToString("mm"));
            vreme = DobaviPocetkeTermina(ref sat, ref minut);
            foreach (Termin t in slobodniTerminiServis.DobaviSveSlobodneTermineZaOperacije())
            {
                if (sat != 23 && DateTime.Compare(t.Datum.Date, DateTime.Now.Date) == 0 && t.Lekar.Specijalizacija.Equals(oblastLekara) && t.Trajanje >= trajanje)
                {
                    foreach (String cas in vreme)
                    {
                        if (cas.Equals(t.PocetnoVreme))
                        {
                            pomocna.Add(terminKonverter.SlobodniTerminModelUDTO(t));
                            break;
                        }
                    }
                }
                else if ((DateTime.Compare(t.Datum.Date, DateTime.Now.Date) == 0 || DateTime.Compare(t.Datum.Date, DateTime.Now.AddDays(1).Date) == 0) && t.Lekar.Specijalizacija.Equals(oblastLekara) && t.Trajanje >= trajanje)
                {
                    foreach (String cas in vreme)
                    {
                        if (cas.Equals(t.PocetnoVreme))
                        {
                            pomocna.Add(terminKonverter.SlobodniTerminModelUDTO(t));
                            break;
                        }
                    }
                }

            }
            var map = new Dictionary<TerminDTO, int>();
            foreach (TerminDTO t in pomocna)
            {
                map.Add(t, PomeranjeOperacije(t));
            }
            return map;
        }
        public int PomeranjeOperacije(TerminDTO noviTermin)
        {
            Lekar lekar = lekariServis.PretraziPoId(noviTermin.Lekar.KorisnickoIme);
            Termin termin = new Termin(noviTermin.IdTermina, VrsteTermina.operacija, noviTermin.Vreme, double.Parse(noviTermin.Trajanje), noviTermin.Datum, new Prostor(), new Pacijent(), lekar);

            List<TerminDTO> pomocna = new List<TerminDTO>();
            TimeSpan vreme;
            int danaPomereno = -1;
            foreach (Termin t in slobodniTerminiServis.DobaviSveSlobodneTermineZaOperacije())
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

        private bool TerminPogodanZaPomeranje(Termin termin, Termin t)
        {
            return DateTime.Compare(t.Datum.Date, DateTime.Now.Date) >= 0 && t.Lekar.Equals(termin.Lekar) && t.Trajanje >= termin.Trajanje;
        }

        public void PomeriTerminUSledeciSlobodan(Termin termin,int brojDana)
        {
            List<Termin> pomocna = new List<Termin>();
            TimeSpan vreme;
            foreach (Termin t in slobodniTerminiServis.DobaviSveSlobodneTermineZaOperacije())
            {
                if (TerminPogodanZaPomeranje(termin, t))
                {
                    vreme = t.Datum.Subtract(termin.Datum);
                    if ((int)vreme.TotalDays == brojDana)
                    {
                        t.Pacijent = termin.Pacijent;
                        ZakazivanjeHitneOperacije(terminKonverter.SlobodniTerminModelUDTO(t),(int)termin.Trajanje);
                        UkloniOperaciju(termin);
                        termin.Pacijent = null;
                        slobodniTerminiServis.DodajSlobodanTerminZaOperaciju(termin);
                        break;
                    }
                }
            }
        }
        public bool PomeriOperacijuIZakaziNovu(TerminDTO noviTermin,int brojDana,PacijentDTO pacijentDTO,int trajanje)
        {
            Pacijent pacijent = pacijentKonverter.PacijentDTOUModel(pacijentDTO);
            Lekar lekar = lekariServis.PretraziPoId(noviTermin.Lekar.KorisnickoIme);
            Termin termin = new Termin(noviTermin.IdTermina, VrsteTermina.operacija, noviTermin.Vreme, trajanje, noviTermin.Datum, prostoriServis.DodeliProstorZaOperaciju(noviTermin.Datum), pacijent, lekar);
            PomeriTerminUSledeciSlobodan(termin, brojDana);
            termin.Pacijent = pacijent;
            bool povratnaVrednost = ZakazivanjeHitneOperacije(noviTermin, trajanje);
            ProveriTermineZaSpajanje();
            return povratnaVrednost;
        }
        public bool OtkazivanjeOperacije(TerminDTO noviTermin)
        {
            Pacijent pacijent = naloziPacijenataServis.PretraziPoId(noviTermin.Pacijent.KorisnickoIme);
            Lekar lekar = lekariServis.PretraziPoId(noviTermin.Lekar.KorisnickoIme);
            Termin termin = new Termin(noviTermin.IdTermina, VrsteTermina.operacija, noviTermin.Vreme, noviTermin.TrajanjeDouble, noviTermin.Datum, new Prostor(), pacijent, lekar);

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
            UkloniOperaciju(termin);
            termin.Pacijent = null;
            slobodniTerminiServis.DodajSlobodanTerminZaOperaciju(termin);
            ProveriTermineZaSpajanje();
            return true;
        }
        public bool ZakazivanjeHitneOperacije(TerminDTO noviTermin, int trajanje)
        {
            Pacijent pacijent = naloziPacijenataServis.PretraziPoId(noviTermin.IdPacijenta);
            Lekar lekar = lekariServis.PretraziPoId(noviTermin.Lekar.KorisnickoIme);
            Termin termin = new Termin(noviTermin.IdTermina, VrsteTermina.operacija, noviTermin.Vreme, double.Parse(noviTermin.Trajanje), noviTermin.Datum, prostoriServis.DodeliProstorZaOperaciju(noviTermin.Datum), pacijent, lekar);
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
            foreach (Termin t in slobodniTerminiServis.DobaviSveSlobodneTermineZaOperacije())
            {
                if (t.IdTermina.Equals(termin.IdTermina))
                {
                    slobodniTerminiServis.Ukloni(termin);
                    break;
                }
            }
            operacijeRepozitorijum.DodajObjekat(termin);
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
                slobodniTerminiServis.DodajSlobodanTerminZaOperaciju(ostatak);
            }
            return true;
        }
        public string generisiID()
        {
            return Guid.NewGuid().ToString();
        }
        public void UkloniOperaciju(Termin termin)
        {
            operacijeRepozitorijum.ObrisiObjekat("//ArrayOfTermin/Termin[IdTermina='" + termin.IdTermina + "']");
        }
    }   
}
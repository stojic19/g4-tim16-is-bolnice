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

        public List<Termin> DobaviSveOperacije()
        {
            return operacijeRepozitorijum.DobaviSveObjekte();
        }
        public void UkloniRadniDan(string idLekara, RadniDan radniDan)
        {
            List<Termin> termini = DobaviOperacijeZaLekaraNaRadniDan(idLekara, radniDan);
            foreach (Termin termin in termini)
            {
                if (DateTime.Compare(DateTime.Now, termin.Datum) < 0)
                {
                    operacijeRepozitorijum.UkloniOperaciju(termin);
                    obavestenjaServis.DodajObavestenje(ObavestenjeOOtkazivanjuOperacije(termin));
                }
            }
        }
        private Obavestenje ObavestenjeOOtkazivanjuOperacije(Termin termin)
        {
            return new Obavestenje("Otkazivanje operacije " + termin.IdTermina, "Operacije za dan " + termin.Datum.Date + " je otkazana.", DateTime.Now, termin.Pacijent.KorisnickoIme + " " + termin.Lekar.KorisnickoIme);
        }
        public void PromeniSmenu(string idLekara, RadniDan radniDanStari, RadniDan radniDanNovi)
        {
            List<Termin> termini = DobaviOperacijeZaLekaraNaRadniDan(idLekara, radniDanStari);
            double novaSmena = DobaviNovuSmenu(radniDanStari, radniDanNovi);
            foreach (Termin termin in termini)
            {
                termin.Datum = termin.Datum.AddMinutes(novaSmena);
                termin.PocetnoVreme = termin.Datum.ToString("HH:mm");
                operacijeRepozitorijum.IzmeniTermin(termin);
                obavestenjaServis.DodajObavestenje(ObavestenjeOPromeniSmene(termin));
            }
        }

        private Obavestenje ObavestenjeOPromeniSmene(Termin termin)
        {
            return new Obavestenje("Pomeranje operacije " + termin.IdTermina, "Operacija za dan " + termin.Datum.Date + " je pomerena na " + termin.Datum.ToString("H:mm") + ".", DateTime.Now, termin.Pacijent.KorisnickoIme + " " + termin.Lekar.KorisnickoIme);
        }

        private double DobaviNovuSmenu(RadniDan radniDanStari, RadniDan radniDanNovi)
        {
            return radniDanNovi.PocetakSmene.TimeOfDay.TotalMinutes - radniDanStari.PocetakSmene.TimeOfDay.TotalMinutes;
        }
        private List<Termin> DobaviOperacijeZaLekaraNaRadniDan(string idLekara, RadniDan radniDanStari)
        {
            List<Termin> termini = DobaviOperacijeZaLekara(idLekara);
            List<Termin> novaLista = new List<Termin>();
            foreach (Termin termin in termini)
            {
                if (DateTime.Compare(termin.Datum, radniDanStari.PocetakSmene) >= 0 && DateTime.Compare(termin.Datum, radniDanStari.KrajSmene) < 0)
                {
                    novaLista.Add(termin);
                }
            }
            return novaLista;
        }
        public List<Termin> DobaviOperacijeZaLekara(string idLekara)
        {
            return operacijeRepozitorijum.DobaviOperacijePoIdLekara(idLekara);
        }
        public void OsveziSlobodneTermine(int trenutniSat, int trenutniMinut)
        {
            string[] vreme;
            int pocetniSatTermina, pocetniMinutTermina, trajanje;
            List<Termin> pomocni = new List<Termin>();
            foreach (Termin t in slobodniTerminiServis.DobaviSveSlobodneTermineZaOperacije())
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
            foreach (Termin termin in slobodniTerminiServis.DobaviSveSlobodneTermineZaOperacije())
                slobodniTerminiServis.UkloniSlobodanTermin(termin);

            foreach (Termin termin in pomocni)
                slobodniTerminiServis.DodajSlobodanTerminZaOperaciju(termin);

        }

        private bool TerminSeZavrsio(int trenutniSat,int trenutniMinut,int pocetniSatTermina,int pocetniMinutTermina)
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

        private void PreostaloVremeTermina(int trenutniSat, int trenutniMinut, string[] vreme, int trajanje,ref Termin termin)
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

        private void NovoPocetnoVremeTermina(int trenutniSat, int trenutniMinut,ref Termin termin)
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

        private void IzracunajKrajnjiDatumTermina(ref int pocetniSatTermina, ref int pocetniMinutTermina,ref Termin termin)
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

        private bool DaLiJeTerminPoceoRanijeDanas(int Sat, int Minut, int sat, int minut, Termin t)
        {
            return DateTime.Compare(t.Datum.Date, DateTime.Now.Date) == 0 && (sat < Sat || (sat == Sat && minut < Minut));
        }

        private bool DaLiJeTerminPreDanasnjegDana(Termin t)
        {
            return DateTime.Compare(t.Datum.Date, DateTime.Now.Date) < 0;
        }

        public void ProveriTermineZaSpajanje()
        {
            String[] vreme;
            OsveziSlobodneTermine(Convert.ToInt32(DateTime.Now.ToString("HH")), Convert.ToInt32(DateTime.Now.ToString("mm")));
            List<Termin> pomocni = new List<Termin>();
            foreach (Termin termin in slobodniTerminiServis.DobaviSveSlobodneTermineZaOperacije())
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
                    foreach (Termin termin1 in slobodniTerminiServis.DobaviSveSlobodneTermineZaOperacije())
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
                    foreach (Termin termin1 in slobodniTerminiServis.DobaviSveSlobodneTermineZaOperacije())
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
            foreach (Termin termin in slobodniTerminiServis.DobaviSveSlobodneTermineZaOperacije())
                slobodniTerminiServis.UkloniSlobodanTermin(termin);

            foreach (Termin termin in pomocni)
                slobodniTerminiServis.DodajSlobodanTerminZaOperaciju(termin);
        }

        private bool TerminiSeNastavljajuIstiDan(Termin termin, string krajTermina, Termin termin1)
        {
            return !termin1.IdTermina.Equals(termin.IdTermina) && termin1.PocetnoVreme.Equals(krajTermina) && DateTime.Compare(termin1.Datum.Date, termin.Datum.Date) == 0;
        }

        private bool TerminiSeNastavljaju(Termin termin, string krajTermina, Termin termin1)
        {
            return !termin1.IdTermina.Equals(termin.IdTermina) && termin1.PocetnoVreme.Equals(krajTermina) && DateTime.Compare(termin1.Datum.Date, termin.Datum.AddDays(1).Date) == 0;
        }

        private bool KrajTerminaSutra(int Sat, int sat)
        {
            return Sat > sat;
        }

        private void IzracunajKrajTermina(ref int sat,ref int minut, int trajanje,ref string krajTermina)
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
        public List<Termin> HitnaOperacijaSlobodniTermini(SpecijalizacijeLekara oblastLekara, int trajanje)
        {
            List<Termin> pomocna = new List<Termin>();
            List<String> vreme = new List<string>();
            int sat = Convert.ToInt32(DateTime.Now.ToString("HH"));
            int minut = Convert.ToInt32(DateTime.Now.ToString("mm"));
            OsveziSlobodneTermine(sat, minut);

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
            Termin termin = new Termin(noviTermin.IdTermina, VrsteTermina.operacija, noviTermin.Vreme, trajanje, noviTermin.Datum, new Prostor(), pacijent, lekar);
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
            Termin termin = new Termin(noviTermin.IdTermina, VrsteTermina.operacija, noviTermin.Vreme, double.Parse(noviTermin.Trajanje), noviTermin.Datum, new Prostor(), pacijent, lekar);
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
                    slobodniTerminiServis.UkloniSlobodanTermin(termin);
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
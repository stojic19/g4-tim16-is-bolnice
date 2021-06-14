using Bolnica.DTO;
using Bolnica.Interfejsi.Sekretar;
using Bolnica.Konverter;
using Bolnica.Repozitorijum;
using Bolnica.Repozitorijum.Factory;
using Bolnica.Repozitorijum.Interfejsi;
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
    class OperacijeServis : CRUDInterfejs<Termin>
    {
        SlobodniTerminiServis slobodniTerminiServis = new SlobodniTerminiServis();
        OperacijeRepozitorijumInterfejs operacijeRepozitorijum = OperacijeFactory.DobaviRepozitorijum();
        NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();
        LekariServis lekariServis = new LekariServis();
        PacijentKonverter pacijentKonverter = new PacijentKonverter();
        TerminKonverter terminKonverter = new TerminKonverter();
        ProstoriServis prostoriServis = new ProstoriServis();

        public List<Termin> DobaviSve()
        {
            return operacijeRepozitorijum.DobaviSveObjekte();
        }

        public Termin PretraziPoId(string id)
        {
            return operacijeRepozitorijum.PretraziPoId("//ArrayOfTermin/Termin[IdTermina='" + id + "']");
        }

        public void Ukloni(Termin termin)
        {
            operacijeRepozitorijum.ObrisiObjekat("//ArrayOfTermin/Termin[IdTermina='" + termin.IdTermina + "']");
        }

        public void Dodaj(Termin termin)
        {
            operacijeRepozitorijum.DodajObjekat(termin);
        }

        public void Izmeni(Termin termin)
        {
            operacijeRepozitorijum.IzmeniTermin(termin);
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
                        slobodniTerminiServis.Izmeni(NovoPocetnoVremeITrajanjeTermina(termin));
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

        private void ProveriTermineZaSpajanje()
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
                        slobodniTerminiServis.Izmeni(SpojiTermine(termin, terminZaUporedjivanje));
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
            foreach (Termin termin in slobodniTerminiServis.DobaviSveSlobodneTermineZaOperacije())
            {
                if (TerminOdgovaraHitnojOperaciji(oblastLekara, trajanje, termin))
                {
                    for (DateTime datum = DateTime.Now.AddMinutes(-1); DateTime.Compare(datum, DateTime.Now.AddMinutes(60))<0;datum = datum.AddMinutes(1))
                    {
                        if (DateTime.Compare(datum, termin.Datum)==0 || datum.ToString("HH:mm").Equals(termin.PocetnoVreme))
                        {
                            pomocna.Add(termin);
                            break;
                        }
                    }
                }
            }
            return pomocna;
        }

        private bool TerminOdgovaraHitnojOperaciji(SpecijalizacijeLekara oblastLekara, int trajanje, Termin termin)
        {
            return (DateTime.Compare(termin.Datum.Date, DateTime.Now.Date) == 0 || DateTime.Compare(termin.Datum.Date,DateTime.Now.AddDays(1)) == 0) && termin.Lekar.Specijalizacija.Equals(oblastLekara) && termin.Trajanje >= trajanje;
        }

        public Dictionary<TerminDTO, int> HitnaOperacijaTerminiZaPomeranje(SpecijalizacijeLekara oblastLekara, int trajanje)
        {
            List<TerminDTO> pomocna = new List<TerminDTO>();
            foreach (Termin termin in slobodniTerminiServis.DobaviSveSlobodneTermineZaOperacije())
            {
                if (TerminOdgovaraHitnojOperaciji(oblastLekara,trajanje,termin))
                {
                    for (DateTime datum = DateTime.Now.AddMinutes(-1); DateTime.Compare(datum, DateTime.Now.AddMinutes(60)) < 0; datum = datum.AddMinutes(1))
                    {
                        if (DateTime.Compare(datum, termin.Datum) == 0 || datum.ToString("HH:mm").Equals(termin.PocetnoVreme))
                        {
                            pomocna.Add(terminKonverter.SlobodniTerminModelUDTO(termin));
                            break;
                        }
                    }
                }

            }
            var map = new Dictionary<TerminDTO, int>();
            int minimalanBrojDana = 0;
            foreach (TerminDTO termin in pomocna)
            {
                minimalanBrojDana = MinimalanBrojDanaZaPomeranjeOperacije(termin);
                if (minimalanBrojDana != -1)
                    map.Add(termin, minimalanBrojDana);
            }
            return map;
        }
        private int MinimalanBrojDanaZaPomeranjeOperacije(TerminDTO noviTermin)
        {
            Lekar lekar = lekariServis.PretraziPoId(noviTermin.Lekar.KorisnickoIme);
            Termin termin = new Termin(noviTermin.IdTermina, VrsteTermina.operacija, noviTermin.Vreme, double.Parse(noviTermin.Trajanje), noviTermin.Datum, new Prostor(), new Pacijent(), lekar);
            TimeSpan vreme;
            int danaPomereno = -1;
            foreach (Termin terminZaPoredjenje in slobodniTerminiServis.DobaviSveSlobodneTermineZaOperacije())
            {
                if (TerminPogodanZaPomeranje(termin, terminZaPoredjenje))
                {
                    vreme = terminZaPoredjenje.Datum.Subtract(termin.Datum);
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
            foreach (Termin terminZaPoredjenje in slobodniTerminiServis.DobaviSveSlobodneTermineZaOperacije())
            {
                if (TerminPogodanZaPomeranje(termin, terminZaPoredjenje))
                {
                    vreme = terminZaPoredjenje.Datum.Subtract(termin.Datum);
                    if ((int)vreme.TotalDays == brojDana)
                    {
                        terminZaPoredjenje.Pacijent = termin.Pacijent;
                        ZakazivanjeOperacije(terminKonverter.SlobodniTerminModelUDTO(terminZaPoredjenje),(int)termin.Trajanje);
                        Ukloni(termin);
                        break;
                    }
                }
            }
        }
        public bool PomeriOperacijuIZakaziNovu(KeyValuePair<TerminDTO, int> odabraniTermin)
        {
            Termin terminKojiSePomera = PretraziPoId(odabraniTermin.Key.IdTermina);
            PomeriTerminUSledeciSlobodan(terminKojiSePomera, odabraniTermin.Value);
            bool povratnaVrednost = ZakazivanjeOperacije(odabraniTermin.Key,(int)odabraniTermin.Key.TrajanjeDouble);
            ProveriTermineZaSpajanje();
            return povratnaVrednost;
        }
        public bool OtkazivanjeOperacije(TerminDTO terminZaOtkazivanje)
        {
            Termin termin = PretraziPoId(terminZaOtkazivanje.IdTermina);

            if (DateTime.Compare(termin.Datum, DateTime.Now) < 0)
            {
                return false;
            }
            Ukloni(termin);
            termin.Pacijent = null;
            termin.Prostor = null;
            slobodniTerminiServis.Dodaj(termin);
            ProveriTermineZaSpajanje();
            return true;
        }
        public bool ZakazivanjeOperacije(TerminDTO noviTermin, int trajanje)
        {
            Pacijent pacijent = naloziPacijenataServis.PretraziPoId(noviTermin.Pacijent.KorisnickoIme);
            Lekar lekar = lekariServis.PretraziPoId(noviTermin.Lekar.KorisnickoIme);
            Termin termin = new Termin(generisiID(), VrsteTermina.operacija, noviTermin.Vreme, double.Parse(noviTermin.Trajanje), noviTermin.Datum, prostoriServis.DodeliProstorZaOperaciju(noviTermin.Datum), pacijent, lekar);
            
            foreach (Termin terminZaUklanaje in slobodniTerminiServis.DobaviSveSlobodneTermineZaOperacije())
            {
                if (terminZaUklanaje.IdTermina.Equals(termin.IdTermina))
                {
                    slobodniTerminiServis.Ukloni(terminZaUklanaje);
                    break;
                }
            }
            if(termin.Trajanje - trajanje > 0)
            {
                Termin ostatak = new Termin(generisiID(), VrsteTermina.operacija, termin.Datum.AddMinutes(trajanje).ToString("HH:mm"), (double)termin.Trajanje - trajanje, termin.Datum.AddMinutes(trajanje),new Prostor(),new Pacijent(), lekar);
                termin.Trajanje = trajanje;
                slobodniTerminiServis.Dodaj(ostatak);
            }
            operacijeRepozitorijum.DodajObjekat(termin);
            return true;
        }
        public string generisiID()
        {
            return Guid.NewGuid().ToString();
        }
    }   
}
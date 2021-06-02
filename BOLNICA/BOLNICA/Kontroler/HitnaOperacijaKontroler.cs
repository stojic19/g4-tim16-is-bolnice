using Bolnica.DTO;
using Bolnica.Konverter;
using Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Kontroler
{
    class HitnaOperacijaKontroler
    {
        NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();
        OperacijeServis operacijeServis = new OperacijeServis();
        TerminKonverter terminKonverter = new TerminKonverter();
        PacijentKonverter pacijentKonverter = new PacijentKonverter();

        public int DobaviBrojZakazanihOperacijaNaDatum(DateTime datum)
        {
            int broj = 0;
            foreach (TerminDTO termin in DobaviSveOperacije())
            {
                if (DateTime.Compare(termin.Datum.Date, datum.Date) == 0)
                {
                    broj += 1;
                }
            }
            return broj;
        }
        public List<TerminDTO> DobaviSveOperacije()
        {
            List<TerminDTO> termini = new List<TerminDTO>();
            foreach(Termin termin in operacijeServis.DobaviSveOperacije())
            {
                termini.Add(terminKonverter.ZakazaniTerminModelUDTO(termin, termin.Pacijent.KorisnickoIme));
            }
            return termini;
        }
        public void DodajGuestNalog(PacijentDTO pacijentZaDodavanje)
        {
            naloziPacijenataServis.DodajNalog(pacijentKonverter.PacijentDTOUModel(pacijentZaDodavanje));
        }

        public List<PacijentDTO> DobaviSveNaloge()
        {
            List<PacijentDTO> pacijenti = new List<PacijentDTO>();
            foreach (Pacijent pacijent in naloziPacijenataServis.SviNalozi())
            {
                pacijenti.Add(pacijentKonverter.PacijentModelUDTO(pacijent));
            }
            return pacijenti;
        }

        public List<TerminDTO> HitnaOperacijaSlobodniTermini(SpecijalizacijeLekara specijalizacijeLekara, int trajanjeOperacije)
        {
            List<TerminDTO> termini = new List<TerminDTO>();
            foreach (Termin termin in operacijeServis.HitnaOperacijaSlobodniTermini(specijalizacijeLekara, trajanjeOperacije))
            {
                termini.Add(terminKonverter.SlobodniTerminModelUDTO(termin));
            }
            return termini;
        }

        public void ZakazivanjeHitneOperacije(TerminDTO terminZaZakazivanje, int trajanjeOperacije)
        {
            operacijeServis.ZakazivanjeHitneOperacije(terminZaZakazivanje, trajanjeOperacije);
        }

        public Dictionary<TerminDTO, int> HitnaOperacijaTerminiZaPomeranje(SpecijalizacijeLekara oblastLekara, int trajanjeOperacije)
        {
            return operacijeServis.HitnaOperacijaTerminiZaPomeranje(oblastLekara, trajanjeOperacije);
        }

        public bool PomeriOperacijuIZakaziNovu(TerminDTO terminZaOperaciju, int brojDanaZaPomeranje, PacijentDTO odabraniPacijent, int trajanjeOperacije)
        {
            return operacijeServis.PomeriOperacijuIZakaziNovu(terminZaOperaciju, brojDanaZaPomeranje, odabraniPacijent, trajanjeOperacije);
        }

        public bool OtkazivanjeOperacije(TerminDTO terminZaOtkazivanje)
        {
            return operacijeServis.OtkazivanjeOperacije(terminZaOtkazivanje);
        }
    }
}

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

        public void DodajGuestNalog(Pacijent pacijentZaDodavanje)
        {
            naloziPacijenataServis.DodajNalog(pacijentZaDodavanje);
        }

        public List<Pacijent> DobaviSveNaloge()
        {
            return naloziPacijenataServis.SviNalozi();
        }

        internal void PrivremenaInicijalizacijaLekara()
        {
            operacijeServis.PrivremenaInicijalizacijaLekara();
        }

        public List<Termin> HitnaOperacijaSlobodniTermini(SpecijalizacijeLekara specijalizacijeLekara, int trajanjeOperacije)
        {
            return operacijeServis.HitnaOperacijaSlobodniTermini(specijalizacijeLekara, trajanjeOperacije);
        }

        public void ZakazivanjeHitneOperacije(Termin terminZaZakazivanje, int trajanjeOperacije)
        {
            operacijeServis.ZakazivanjeHitneOperacije(terminZaZakazivanje, trajanjeOperacije);
        }

        public Dictionary<Termin, int> HitnaOperacijaTerminiZaPomeranje(SpecijalizacijeLekara oblastLekara, int trajanjeOperacije)
        {
            return operacijeServis.HitnaOperacijaTerminiZaPomeranje(oblastLekara, trajanjeOperacije);
        }

        public bool PomeriOperacijuIZakaziNovu(Termin terminZaOperaciju, int brojDanaZaPomeranje, Pacijent odabraniPacijent, int trajanjeOperacije)
        {
            return operacijeServis.PomeriOperacijuIZakaziNovu(terminZaOperaciju, brojDanaZaPomeranje, odabraniPacijent, trajanjeOperacije);
        }

        public bool OtkazivanjeOperacije(Termin terminZaOtkazivanje)
        {
            return operacijeServis.OtkazivanjeOperacije(terminZaOtkazivanje);
        }
    }
}

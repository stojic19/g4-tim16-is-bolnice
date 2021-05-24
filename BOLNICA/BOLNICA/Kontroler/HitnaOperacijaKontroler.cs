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
    }
}

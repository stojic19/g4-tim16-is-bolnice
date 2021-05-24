using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Kontroler
{
    class NaloziPacijenataKontroler
    {
        private NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();

        public List<Pacijent> DobaviSveNaloge()
        {
            return naloziPacijenataServis.SviNalozi();
        }

        public void DodajNalog(Pacijent pacijentZaDodavanje)
        {
            naloziPacijenataServis.DodajNalog(pacijentZaDodavanje);
        }

        public Pacijent PretraziPoId(string idPacijenta)
        {
            return naloziPacijenataServis.PretraziPoId(idPacijenta);
        }

        public void IzmeniNalog(string stariIdPacijenta, Pacijent pacijentZaIzmenu)
        {
            naloziPacijenataServis.IzmeniNalog(stariIdPacijenta, pacijentZaIzmenu);
        }

        public void UkolniNalog(string pacijentZaUklanjanje)
        {
           naloziPacijenataServis.UkolniNalog(pacijentZaUklanjanje);
        }
    }
}

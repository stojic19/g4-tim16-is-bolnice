using Bolnica.DTO;
using Bolnica.Konverter;
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
        PacijentKonverter pacijentKonverter = new PacijentKonverter();

        public List<Pacijent> DobaviSveNalogeNeDTO()
        {
            return naloziPacijenataServis.SviNalozi();
        }

        public List<PacijentDTO> DobaviSveNaloge()
        {
            List<PacijentDTO> pacijenti = new List<PacijentDTO>();
            foreach (Pacijent pacijent in naloziPacijenataServis.SviNalozi())
                pacijenti.Add(pacijentKonverter.PacijentModelUDTO(pacijent));
            return pacijenti;
        }

        public void DodajNalog(PacijentDTO pacijentZaDodavanje)
        {
            naloziPacijenataServis.DodajNalog(pacijentKonverter.PacijentDTOUModel(pacijentZaDodavanje));
        }

        public Pacijent PretraziPoIdNeDTO(string idPacijenta)
        {
            return naloziPacijenataServis.PretraziPoId(idPacijenta);
        }

        public PacijentDTO PretraziPoId(string idPacijenta)
        {
            return pacijentKonverter.PacijentModelUDTO(naloziPacijenataServis.PretraziPoId(idPacijenta));
        }

        public void IzmeniNalog(string stariIdPacijenta, PacijentDTO pacijentZaIzmenu)
        {
            naloziPacijenataServis.IzmeniNalog(stariIdPacijenta, pacijentKonverter.PacijentDTOUModel(pacijentZaIzmenu));
        }

        public void UkolniNalog(string pacijentZaUklanjanje)
        {
           naloziPacijenataServis.UkolniNalog(pacijentZaUklanjanje);
        }

        public bool NalogJeBlokiran(String korisnickoIme)
        {
            return naloziPacijenataServis.NalogJeBlokiran(korisnickoIme);
        }
        public void OdblokirajNalog(String idPacijenta)
        {
            naloziPacijenataServis.OdblokirajNalog(idPacijenta);
        }
        public bool DaLiJeKorisnickoImeJedinstveno(String korisnickoIme)
        {
            return naloziPacijenataServis.DaLiJeKorisnickoImeJedinstveno(korisnickoIme);
        }
        public bool DaLiJeJmbgJedinstven(String jmbg)
        {
            return naloziPacijenataServis.DaLiJeJmbgJedinstven(jmbg);
        }

        public PacijentDTO PretraziPoKorisnickomImenu(String koricnickoIme)
        {
            return pacijentKonverter.PacijentModelUPacijentDTO(naloziPacijenataServis.PretraziPoId(koricnickoIme));
        }
    }
}

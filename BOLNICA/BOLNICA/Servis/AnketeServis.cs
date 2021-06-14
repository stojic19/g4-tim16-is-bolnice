using Bolnica.Model.Enumi;
using Bolnica.Repozitorijum;
using Bolnica.Repozitorijum.Factory;
using Bolnica.Repozitorijum.Interfejsi;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bolnica.Model.Rukovanja
{
    public class AnketeServis
    {
        private AnketeRepozitorijumInterfejs anketeRepozitorijum = AnketeFactory.DobaviRepozitorijum();

        private PreglediServis preglediServis = new PreglediServis();
        private NaloziPacijenataServis naloziPacijentaServis = new NaloziPacijenataServis();
        public bool DostupnaAnketaOBolnici(Pacijent pacijent)
        {
            DateTime novaAnketa = NadjiDatumPoslednjeAnketeOBolnici(pacijent).AddMonths(3);
            if (ProsloJeTriMesecaOdOcene(novaAnketa))
                return true;

            return false;
        }
        private bool ProsloJeTriMesecaOdOcene(DateTime novaAnketa)
        {
            if (DateTime.Compare(DateTime.Now.Date, novaAnketa.Date) >= 0)
                return true;
            return false;
        }

        private DateTime NadjiDatumPoslednjeAnketeOBolnici(Pacijent pacijent)
        {
            List<Anketa> anketePacijenta = SortirajPoDatumuRastuce(anketeRepozitorijum.NadjiSveAnketePacijentaOBolnici(pacijent));

            if (anketePacijenta.Count == 0)
                return DateTime.Now.Date.AddMonths(-3);
            else
                return anketePacijenta[0].OcenioBolnicu;

        }

        public List<Anketa> SortirajPoDatumuRastuce(List<Anketa> nesortiraneAnkete)
        {
            return nesortiraneAnkete.OrderByDescending(user => user.OcenioBolnicu).ToList();
        }

        public void DodajAnketu(Anketa anketa, String idPregleda)
        {
            Pregled pregled = preglediServis.PretraziPoId(idPregleda);
            anketa.Pregled = pregled;
            anketa.Pacijent = naloziPacijentaServis.PretraziPoId(pregled.Termin.Pacijent.KorisnickoIme);
            anketeRepozitorijum.DodajObjekat(anketa);
        }


    }
}

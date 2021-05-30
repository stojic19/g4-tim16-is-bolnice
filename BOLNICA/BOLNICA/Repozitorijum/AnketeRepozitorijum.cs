using Bolnica.Model;
using Bolnica.Model.Enumi;
using Bolnica.Repozitorijum.Interfejsi;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bolnica.Repozitorijum
{
    public class AnketeRepozitorijum: GlavniRepozitorijum<Anketa>, AnketeRepozitorijumInterfejs
    {
        public AnketeRepozitorijum()
        {
            imeFajla = "sveAnkete.xml";
        }

        public List<Anketa> NadjiSveAnketePacijentaOBolnici(Pacijent pacijent)
        {
            List<Anketa> anketePacijenta = new List<Anketa>();
            foreach(Anketa anketa in DobaviSveObjekte())
            {
                if (AnketaPripadaPacijentu(anketa, pacijent)
                    && anketa.Pregled==null)
                    anketePacijenta.Add(anketa);
            }
            return anketePacijenta;
        }
        private bool AnketaPripadaPacijentu(Anketa anketa,Pacijent pacijent)
        {
            if (anketa.Pacijent.KorisnickoIme.Equals(pacijent.KorisnickoIme)) return true;
            return false;
        }
    }
}

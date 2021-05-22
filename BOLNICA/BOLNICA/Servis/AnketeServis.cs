using Bolnica.Model.Enumi;
using Bolnica.Repozitorijum;
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
        public static bool DostupnaAnketaOBolnici(Pacijent pacijent)
        {
            DateTime novaAnketa = NadjiDatumPoslednjeAnketeOBolnici(pacijent).AddMonths(3);
            if (DateTime.Compare(DateTime.Now.Date, novaAnketa.Date) >= 0)
                return true;

            return false;
        }

        public static DateTime NadjiDatumPoslednjeAnketeOBolnici(Pacijent pacijent)
        {
            List<Anketa> anketePacijenta = new List<Anketa>();
            foreach (Anketa anketa in AnketeRepozitorijum.popunjeneAnkete)
            {
                if (anketa.Pacijent.KorisnickoIme.Equals(pacijent.KorisnickoIme) && anketa.Pregled == null)
                {
                    anketePacijenta.Add(anketa);
                }
            }
            if (anketePacijenta.Count == 0)
            {
                return DateTime.Now.Date.AddMonths(-3);
            }


            return SortirajAnketePoDatumu(anketePacijenta)[0].OcenioBolnicu;
        }

        public static List<Anketa> SortirajAnketePoDatumu(List<Anketa> nesortiraniDatumi)
        {
            return nesortiraniDatumi.OrderByDescending(user => user.OcenioBolnicu).ToList();
        }

        
    }
}

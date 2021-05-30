using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Renoviranje
    {
        public String IdRenoviranja { get; set; }
        public Prostor Prostor { get; set; }
        public DateTime PocetniDatum { get; set; }
        public DateTime DatumKraja { get; set; }

        public List<Prostor> ProstoriKojiSeBrisu = new List<Prostor>();
        public List<Prostor> ProstoriKojiSeDodaju = new List<Prostor>();

        public Renoviranje() { }
        public Renoviranje(String id, Prostor prostor, DateTime argStartDay, DateTime argEndDay)
        {
            IdRenoviranja = id;
            Prostor = prostor;
            PocetniDatum = argStartDay;
            DatumKraja = argEndDay;
        }


    }
}

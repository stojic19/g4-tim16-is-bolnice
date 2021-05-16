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
        public Prostor Prostor { get; set; }
        public DateTime PocetniDatum { get; set; }
        public DateTime DatumKraja { get; set; }

        public Renoviranje() { }
        public Renoviranje(Prostor prostor, DateTime argStartDay, DateTime argEndDay)
        {
            Prostor = prostor;
            PocetniDatum = argStartDay;
            DatumKraja = argEndDay;
        }


    }
}

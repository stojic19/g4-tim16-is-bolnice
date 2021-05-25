using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Odsustvo
    {
        private DateTime PocetakOdsustva { get; set; }
        private DateTime KrajOdsustva { get; set; }

        public Odsustvo(DateTime pocetakOdsustva,DateTime krajOdsustva)
        {
            this.PocetakOdsustva = pocetakOdsustva;
            this.KrajOdsustva = krajOdsustva;
        }

    }
}

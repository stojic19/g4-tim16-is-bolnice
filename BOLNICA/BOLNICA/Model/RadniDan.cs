using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class RadniDan
    {
        private DateTime PocetakSmene { get; set; }
        private DateTime KrajSmene { get; set; }

        public RadniDan(DateTime pocetakSmene, DateTime krajSmene)
        {
            this.PocetakSmene = pocetakSmene;
            this.KrajSmene = krajSmene;
        }
    }
}

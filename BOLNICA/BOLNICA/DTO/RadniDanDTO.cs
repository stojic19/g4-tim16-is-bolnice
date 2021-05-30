using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class RadniDanDTO
    {
        private DateTime pocetakSmene;
        private DateTime krajSmene;

        public RadniDanDTO() { }
        public RadniDanDTO(DateTime pocetakSmene, DateTime krajSmene)
        {
            this.PocetakSmene = pocetakSmene;
            this.KrajSmene = krajSmene;
        }

        public DateTime PocetakSmene
        {
            get
            {
                return pocetakSmene;
            }
            set
            {
                pocetakSmene = value;
            }
        }
        public DateTime KrajSmene
        {
            get
            {
                return krajSmene;
            }
            set
            {
                krajSmene = value;
            }
        }
    }
}

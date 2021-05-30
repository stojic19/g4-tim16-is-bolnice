using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class OdsustvoDTO
    {
        private DateTime pocetakOdsustva;
        private DateTime krajOdsustva;
        
        public OdsustvoDTO() { }
        public OdsustvoDTO(DateTime pocetakOdsustva,DateTime krajOdsustva)
        {
            this.PocetakOdsustva = pocetakOdsustva;
            this.KrajOdsustva = krajOdsustva;
        }
        public DateTime PocetakOdsustva
        {
            get
            {
                return pocetakOdsustva;
            }
            set
            {
                pocetakOdsustva = value;
            }
        }
        public DateTime KrajOdsustva
        {
            get
            {
                return krajOdsustva;
            }
            set
            {
                krajOdsustva = value;
            }
        }
    }
}

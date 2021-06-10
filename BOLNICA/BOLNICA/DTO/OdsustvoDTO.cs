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
        private String idOdsustva;
        private DateTime pocetakOdsustva;
        private DateTime krajOdsustva;
        
        public OdsustvoDTO() { }
        public OdsustvoDTO(String idOdsustva, DateTime pocetakOdsustva,DateTime krajOdsustva)
        {
            if (idOdsustva != null)
                this.IdOdsustva = idOdsustva;
            else
                this.IdOdsustva = Guid.NewGuid().ToString();
            this.PocetakOdsustva = pocetakOdsustva;
            this.KrajOdsustva = krajOdsustva;
        }
        public OdsustvoDTO(DateTime pocetakOdsustva, DateTime krajOdsustva)
        {
            this.IdOdsustva = Guid.NewGuid().ToString();
            this.PocetakOdsustva = pocetakOdsustva;
            this.KrajOdsustva = krajOdsustva;
        }
        public String IdOdsustva
        {
            get
            {
                return idOdsustva;
            }
            set
            {
                idOdsustva = value;
            }
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

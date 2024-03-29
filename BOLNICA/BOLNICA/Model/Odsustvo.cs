﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Odsustvo 
    {
        private String idOdsustva;
        private DateTime pocetakOdsustva;
        private DateTime krajOdsustva;
        
        public Odsustvo() { }
        public Odsustvo(DateTime pocetakOdsustva,DateTime krajOdsustva)
        {
            this.IdOdsustva = Guid.NewGuid().ToString();
            this.PocetakOdsustva = pocetakOdsustva;
            this.KrajOdsustva = krajOdsustva;
        }
        public Odsustvo(String idOdsustva, DateTime pocetakOdsustva, DateTime krajOdsustva)
        {
            this.IdOdsustva = idOdsustva;
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

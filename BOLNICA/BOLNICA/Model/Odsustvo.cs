using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

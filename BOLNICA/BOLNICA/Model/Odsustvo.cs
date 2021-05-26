using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Odsustvo : INotifyPropertyChanged
    {
        private DateTime pocetakOdsustva;
        private DateTime krajOdsustva;
        
        public Odsustvo() { }
        public Odsustvo(DateTime pocetakOdsustva,DateTime krajOdsustva)
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

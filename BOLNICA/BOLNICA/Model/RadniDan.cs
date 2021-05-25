using System;
using System.Collections.Generic;
using System.ComponentModel;
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

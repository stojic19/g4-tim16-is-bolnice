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
        private String idRadnogDana;
        private DateTime pocetakSmene;
        private DateTime krajSmene;

        public RadniDan() { }
        public RadniDan(DateTime pocetakSmene, DateTime krajSmene)
        {
            this.IdRadnogDana = Guid.NewGuid().ToString();
            this.PocetakSmene = pocetakSmene;
            this.KrajSmene = krajSmene;
        }
        public RadniDan(String idRadnogDana, DateTime pocetakSmene, DateTime krajSmene)
        {
            this.IdRadnogDana = idRadnogDana;
            this.PocetakSmene = pocetakSmene;
            this.KrajSmene = krajSmene;
        }
        public String  IdRadnogDana
        {
            get
            {
                return idRadnogDana;
            }
            set
            {
                idRadnogDana = value;
            }
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

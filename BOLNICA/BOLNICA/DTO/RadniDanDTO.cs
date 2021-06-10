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
        private String idRadnogDana;
        private DateTime pocetakSmene;
        private DateTime krajSmene;
        private String smena;

        public RadniDanDTO() { }
        public RadniDanDTO(String idRadnogDana, DateTime pocetakSmene, DateTime krajSmene, String smena)
        {
            if (idRadnogDana != null)
                this.IdRadnogDana = idRadnogDana;
            else
                this.IdRadnogDana = Guid.NewGuid().ToString();
            this.PocetakSmene = pocetakSmene;
            this.KrajSmene = krajSmene;
            this.Smena = smena;
        }
        public RadniDanDTO(DateTime pocetakSmene, DateTime krajSmene, String smena)
        {
            this.IdRadnogDana = Guid.NewGuid().ToString();
            this.PocetakSmene = pocetakSmene;
            this.KrajSmene = krajSmene;
            this.Smena = smena;
        }
        public String IdRadnogDana
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
        public String Smena
        {
            get
            {
                return smena;
            }
            set
            {
                smena = value;
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

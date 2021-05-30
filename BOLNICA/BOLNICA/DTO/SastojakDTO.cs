using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class SastojakDTO
    {
        private String naziv;
        private double kolicina;

        public String Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        public Double Kolicina
        {
            get { return kolicina; }
            set { kolicina = value; }
        }

        public SastojakDTO(String naziv, Double kolicina)
        {
            this.naziv = naziv;
            this.kolicina = kolicina;
        }

    }
}

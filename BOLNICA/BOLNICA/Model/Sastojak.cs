using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Sastojak
    {

        public String Naziv { get; set; }
        public double Kolicina { get; set; }

        public Sastojak()
        {
        }

        public Sastojak(string naziv, double kolicina)
        {
            Naziv = naziv;
            Kolicina = kolicina;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Sastojak
    {

        private String naziv;
        private double kolicina;


        public Sastojak()
        {
        }

        public Sastojak(string naziv, double kolicina)
        {
            Naziv = naziv;
            Kolicina = kolicina;
        }

        public string Naziv { get => naziv; set => naziv = value; }
        public double Kolicina { get => kolicina; set => kolicina = value; }
    }
}

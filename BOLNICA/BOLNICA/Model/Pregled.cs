using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    class Pregled
    {

        public String IdPregleda { get; set; }
        public Boolean Odrzan { get; set; }

        public Termin Termin { get; set; }
        public Anamneza Anamneza { get; set; }
        public static List<Recept> Recepti { get; set; } = new List<Recept>();



    }
}

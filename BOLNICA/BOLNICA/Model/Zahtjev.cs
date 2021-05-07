using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    class Zahtjev
    {
        public String IdZahtjeva { get; set; }
        public Lek Lijek { get; set; }
        public bool Odobren { get; set; }
        public String RazlogOdobrenja { get; set; }

        public Zahtjev(String idZahtjeva, Lek lijek, String razlogOdobrenja)
        {
            IdZahtjeva = idZahtjeva;
            Lijek = lijek;
            Odobren = false;
            RazlogOdobrenja = razlogOdobrenja;
        }
    }
}

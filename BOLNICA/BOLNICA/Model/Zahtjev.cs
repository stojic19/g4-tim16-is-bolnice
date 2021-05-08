using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Zahtjev
    {
        public String IdZahtjeva { get; set; }
        public Lek Lijek { get; set; }
        public String RazlogOdbijanja { get; set; }
        public Boolean Obradjen { get; set; }

        public Zahtjev(String idZahtjeva, Lek lijek, String razlogOdbijanja)
        {
            IdZahtjeva = idZahtjeva;
            Lijek = lijek;
            Lijek.Verifikacija = false;
            Obradjen = false;
            RazlogOdbijanja = razlogOdbijanja;
        }
    }
}

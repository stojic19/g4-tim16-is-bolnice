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
        public bool Obradjen { get; set; }
        public String RazlogOdobrenja { get; set; }
        public DateTime datumSlanja { get; set; }


        public Zahtjev(String idZahtjeva, Lek lijek, String razlogOdobrenja, DateTime datumSlanja)
        {
            IdZahtjeva = idZahtjeva;
            Lijek = lijek;
            Obradjen = false;
            RazlogOdobrenja = razlogOdobrenja;
            datumSlanja = datumSlanja;
        }

        public Zahtjev() { }
    }
}

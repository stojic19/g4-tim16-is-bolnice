using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Godisnji
    {
        private int GodinaZaGodisnji { get; set; }
        private int PreostaliBrojSlobodnihDana { get; set; }

        public Godisnji(int godina,int brojSlobodnihDana)
        {
            GodinaZaGodisnji = godina;
            PreostaliBrojSlobodnihDana = brojSlobodnihDana; 
        }
    }
}

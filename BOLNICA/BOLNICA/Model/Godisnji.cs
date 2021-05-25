using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Godisnji
    {
        private int godinaZaGodisnji;
        private int preostaliBrojSlobodnihDana;

        public Godisnji(int godina,int brojSlobodnihDana)
        {
            GodinaZaGodisnji = godina;
            PreostaliBrojSlobodnihDana = brojSlobodnihDana; 
        }

        public int GodinaZaGodisnji
        {
            get
            {
                return godinaZaGodisnji;
            }
            set
            {
                godinaZaGodisnji = value;
            }
        }
        public int PreostaliBrojSlobodnihDana
        {
            get
            {
                return preostaliBrojSlobodnihDana;
            }
            set
            {
                preostaliBrojSlobodnihDana = value;
            }
        }
    }
}

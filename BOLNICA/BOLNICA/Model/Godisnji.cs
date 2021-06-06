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

        public Godisnji() { }
        public Godisnji(int godina, int brojSlobodnihDana)
        {
            GodinaZaGodisnji = godina;
            PreostaliBrojSlobodnihDana = brojSlobodnihDana;
        }
        public void DodajSlobodneDane(int slobodniDani)
        {
            PreostaliBrojSlobodnihDana += slobodniDani;
        }
        public void OduzmiSlobodneDane(int slobodniDani)
        {
            PreostaliBrojSlobodnihDana -= slobodniDani;
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

        public void ProveriSlobodneDaneZaAzuriranje()
        {
            if (GodinaZaGodisnji != DateTime.Now.Year)
            {
                GodinaZaGodisnji = DateTime.Now.Year;
                PreostaliBrojSlobodnihDana += 20;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class ZakazivanjePregledaDTO
    {
        private DateTime datumOd;
        private DateTime datumDo;
        private int prioritet;
        private String korisnickoImePacijenta;
        private LekarDTO izabraniLekar;


        public LekarDTO IzabraniLekar
        {
            get { return izabraniLekar; }
            set{izabraniLekar = value;}
        }

        public String KorisnickoImePacijenta
        {
            get { return korisnickoImePacijenta; }
            set{korisnickoImePacijenta = value; }
        }

        public DateTime DatumOd
        {
            get { return datumOd; }
            set { datumOd = value;}
        }

        public DateTime DatumDo
        {
            get { return datumDo; }
            set {  datumDo = value;}
        }

        public int Prioritet
        {
            get { return prioritet; }
            set{prioritet = value;}
        }
    }
}

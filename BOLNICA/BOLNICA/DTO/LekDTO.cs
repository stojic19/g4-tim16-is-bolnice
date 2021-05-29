using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class LekDTO
    {
        private String idLeka;
        private String nazivLeka;
        private String jacina;
        private int kolicina;

        public String IdLeka
        {
            get { return idLeka; }
            set { idLeka = value; }
        }
        public String NazivLeka
        {
            get { return nazivLeka; }
            set { nazivLeka = value; }
        }
        public String Jacina
        {
            get { return jacina; }
            set { jacina = value; }
        }
        public int Kolicina
        {
            get { return kolicina; }
            set { kolicina = value; }
        }

        public LekDTO(string idLeka, string nazivLeka, string jacina, int kolicina)
        {
            this.idLeka = idLeka;
            this.nazivLeka = nazivLeka;
            this.jacina = jacina;
            this.kolicina = kolicina;
        }

        public LekDTO(string idLeka, string nazivLeka, string jacina)
        {
            this.idLeka = idLeka;
            this.nazivLeka = nazivLeka;
            this.jacina = jacina;
            this.kolicina = 0;
        }
    }
}

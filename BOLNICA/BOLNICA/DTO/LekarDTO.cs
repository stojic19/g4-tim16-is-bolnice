using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class LekarDTO
    {
        private String imeIPrezime;
        private String korisnickoIme;
        private SpecijalizacijeLekara specijalizacija;

        public String ImeIPrezime
        {
            get { return imeIPrezime; }
            set { imeIPrezime = value; }
        }
        public String KorisnickoIme
        {
            get { return korisnickoIme; }
            set { korisnickoIme = value; }
        }
        public SpecijalizacijeLekara Specijalizacija
        {
            get { return specijalizacija; }
            set { specijalizacija = value; }
        }

        public LekarDTO(string imeIPrezimeLekara, string korisnickoIme, SpecijalizacijeLekara specijalizacija)
        {
            this.imeIPrezime = imeIPrezimeLekara;
            this.korisnickoIme = korisnickoIme;
            this.specijalizacija = specijalizacija;
        }
    }
}

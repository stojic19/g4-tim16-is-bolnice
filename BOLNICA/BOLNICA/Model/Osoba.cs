
using System;

namespace Model
{
   public class Osoba
   {
        public String ime { get; set; }
        public String prezime { get; set; }
        public DateTime datumRodjenja { get; set; }
        public String jmbg { get; set; }
        public String adresaStanovanja { get; set; }
        public String kontaktTelefon { get; set; }
        public Uloge uloga { get; set; }
        public String email { get; set; }

        public Nalog nalog { get; set; }

    }
}
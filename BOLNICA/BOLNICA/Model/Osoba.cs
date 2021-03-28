
using System;

namespace Model
{
   public class Osoba
   {
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public String Jmbg { get; set; }
        public String AdresaStanovanja { get; set; }
        public String KontaktTelefon { get; set; }
        public Uloge Uloga { get; set; }
        public String Email { get; set; }

        public Nalog Nalog { get; set; }

    }
}
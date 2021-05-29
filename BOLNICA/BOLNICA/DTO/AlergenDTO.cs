using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class AlergenDTO
    {
        private string idAlergena;
        private LekDTO lek;
        private string opisReakcije;
        private string vremeZaPojavu;

        public String IdAlergena
        {
            get { return idAlergena; }
            set { idAlergena = value; }
        }
        public String OpisReakcije
        {
            get { return opisReakcije; }
            set { opisReakcije = value; }
        }
        public String VremeZaPojavu
        {
            get { return vremeZaPojavu; }
            set { vremeZaPojavu = value; }
        }
        public LekDTO Lek
        {
            get { return lek; }
            set { lek = value; }
        }

        AlergenDTO() { }

        public AlergenDTO(string idAlergena, LekDTO lek, string opisReakcije, string vremeZaPojavu)
        {
            this.idAlergena = idAlergena;
            this.lek = lek;
            this.opisReakcije = opisReakcije;
            this.vremeZaPojavu = vremeZaPojavu;
        }
    }
}

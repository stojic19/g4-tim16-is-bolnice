using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class AlergeniPrikazDTO
    {
        private string idAlergena;
        private string nazivLeka;
        private string opisReakcije;
        private string vremeZaPojavu;

        public String IdAlergena { get => idAlergena; set => idAlergena = value; }
        public String NazivLeka { get => nazivLeka; set => nazivLeka = value; }
        public String OpisReakcije { get => opisReakcije; set => opisReakcije = value; }
        public String VremeZaPojavu { get => vremeZaPojavu; set => vremeZaPojavu = value; }

        public AlergeniPrikazDTO(string idAlergena,string nazivLeka, string opisReakcije, string vremeZaPojavu)
        {
            IdAlergena = idAlergena;
            NazivLeka = nazivLeka;
            OpisReakcije = opisReakcije;
            VremeZaPojavu = vremeZaPojavu;
        }
    }
}

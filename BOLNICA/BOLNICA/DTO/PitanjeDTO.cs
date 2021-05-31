using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class PitanjeDTO
    {
        private String tekstPitanja;
        private int ocena;
        private bool pitanjeOBolnici;

        public String TekstPitanja
        {
            get { return tekstPitanja; }
            set { tekstPitanja = value; }
        }

        public int Ocena
        {
            get { return ocena; }
            set { ocena = value; }
        }


        public bool PitanjeOBolnici
        {
            get { return pitanjeOBolnici; }
            set { pitanjeOBolnici = value; }
        }
        public PitanjeDTO() { }
        public PitanjeDTO(int ocena, string tekstPitanja, bool pitanjeOBolnici)
        {
            this.ocena = ocena;
            this.tekstPitanja = tekstPitanja;
            this.pitanjeOBolnici = pitanjeOBolnici;

        }
    }
}

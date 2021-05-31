using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class AnketaDTO
    {
        private PacijentDTO pacijent;
        private DateTime ocenioBolnicu;
        private PregledDTO pregled;
        private List<PitanjeDTO> pitanjaAnkete;
        private String dodatniKomentar;

        public PacijentDTO Pacijent
        {
            get { return pacijent; }
            set { pacijent = value; }
        }

        public DateTime OcenioBolnicu
        {
            get { return ocenioBolnicu; }
            set { ocenioBolnicu = value; }
        }

        public PregledDTO Pregled
        {
            get { return pregled; }
            set { pregled = value; }
        }

        public List<PitanjeDTO> PitanjaAnkete
        {
            get { return pitanjaAnkete; }
            set { pitanjaAnkete = value; }
        }

        public String DodatniKomentar
        {
            get { return dodatniKomentar; }
            set { dodatniKomentar = value; }
        }

        public AnketaDTO() { }

        public AnketaDTO(PacijentDTO pacijent, DateTime ocenioBolnicu, PregledDTO pregled, List<PitanjeDTO> pitanjaAnkete, string dodatniKomentar)
        {
            this.pacijent = pacijent;
            this.ocenioBolnicu = ocenioBolnicu;
            this.pregled = pregled;
            this.pitanjaAnkete = pitanjaAnkete;
            this.dodatniKomentar = dodatniKomentar;
        }

        public AnketaDTO(List<PitanjeDTO> pitanjaAnkete, string dodatniKomentar)
        {
            this.pitanjaAnkete = pitanjaAnkete;
            this.dodatniKomentar = dodatniKomentar;
        }

    }
}

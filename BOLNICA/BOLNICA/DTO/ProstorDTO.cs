using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class ProstorDTO
    {
        private String idProstora;
        private String nazivProstora;
        private VrsteProstora vrstaProstora;
        private int sprat;
        private float kvadratura;
        private bool jeRenoviranje;
        private List<OpremaDTO> oprema;
        private int brojSlobodnihKreveta = 0;

        public String IdProstora
        {
            get { return idProstora; }
            set { idProstora = value; }
        }

        public String NazivProstora
        {
            get { return nazivProstora; }
            set { nazivProstora = value; }
        }

        public VrsteProstora VrstaProstora
        {
            get { return vrstaProstora; }
            set { vrstaProstora = value; }
        }

        public int Sprat
        {
            get { return sprat; }
            set { sprat = value; }
        }

        public float Kvadratura
        {
            get { return kvadratura; }
            set { kvadratura = value; }
        }

        public bool JeRenoviranje
        {
            get { return jeRenoviranje; }
            set { jeRenoviranje = value; }
        }

        public List<OpremaDTO> Oprema
        {
            get { return oprema; }
            set { oprema = value; }
        }

        public int BrojSlobodnihKreveta
        {
            get { return brojSlobodnihKreveta; }
            set { brojSlobodnihKreveta = value; }
        }

        ProstorDTO() { }

        public ProstorDTO(string idProstora, string nazivProstora, VrsteProstora vrstaProstora, int sprat, float kvadratura,List<OpremaDTO> oprema,bool jeRenoviranje) 
        {
            this.idProstora = idProstora;
            this.nazivProstora = nazivProstora;
            this.vrstaProstora = vrstaProstora;
            this.sprat = sprat;
            this.kvadratura = kvadratura;
            this.oprema = oprema;
            this.jeRenoviranje = jeRenoviranje;
        }
    }
}

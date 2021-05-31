using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class OpremaDTO
    {
        private String idOpreme;
        private String nazivOpreme;
        private VrsteOpreme vrstaOpreme;
        private int kolicina;

        public String IdOpreme
        {
            get { return idOpreme; }
            set { idOpreme = value; }
        }

        public String NazivOpreme
        {
            get { return nazivOpreme; }
            set { nazivOpreme = value; }
        }

        public VrsteOpreme VrstaOpreme
        {
            get { return vrstaOpreme; }
            set { vrstaOpreme = value; }
        }

        public int Kolicina
        {
            get { return kolicina; }
            set { kolicina = value; }
        }

        OpremaDTO() { }

        public OpremaDTO(string idOpreme, string nazivOpreme, VrsteOpreme vrstaOpreme, int kolicina)
        {
            this.idOpreme = idOpreme;
            this.nazivOpreme = nazivOpreme;
            this.vrstaOpreme = vrstaOpreme;
            this.kolicina = kolicina;
        }
    }
}

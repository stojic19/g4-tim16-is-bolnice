using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class AnamnezaDTO
    {
        private String idAnamneze;
        private String idLekara;
        private String imeIPrezimeLekara;
        private String idPacijenta;
        private DateTime datum;
        private String dijagnoza;
        private List<TerapijaDTO> sveTerapije;

        public String IdAnamneze
        {
            get { return idAnamneze; }
            set { idAnamneze = value; }
        }

        public String IdPacijenta
        {
            get { return idPacijenta; }
            set { idPacijenta = value; }
        }

        public String Dijagnoza
        {
            get { return dijagnoza; }
            set { dijagnoza = value; }
        }

        public List<TerapijaDTO> SveTerapije
        {
            get { return sveTerapije; }
            set { sveTerapije = value; }
        }

        public AnamnezaDTO(string idAnamneze, string idPacijenta, string dijagnoza, List<TerapijaDTO> sveTerapije)
        {
            this.idAnamneze = idAnamneze;
            this.idPacijenta = idPacijenta;
            this.dijagnoza = dijagnoza;
            this.sveTerapije = sveTerapije;
        }
    }
}

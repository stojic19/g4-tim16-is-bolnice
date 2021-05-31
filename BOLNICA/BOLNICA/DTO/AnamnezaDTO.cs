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

        public String IdLekara
        {
            get { return idLekara; }
            set { idLekara = value; }
        }

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        public String Lekar
        {
            get { return imeIPrezimeLekara; }
            set { imeIPrezimeLekara = value; }
        }

        public AnamnezaDTO(string idAnamneze, string idPacijenta, string dijagnoza, List<TerapijaDTO> sveTerapije)
        {
            this.idAnamneze = idAnamneze;
            this.idPacijenta = idPacijenta;
            this.dijagnoza = dijagnoza;
            this.sveTerapije = sveTerapije;
        }

        public AnamnezaDTO(string idAnamneze, string imeIPrezimeLekara, DateTime datum, List<TerapijaDTO> sveTerapije, String dijagnoza, String idLekara, String idPacijenta)
        {
            this.idAnamneze = idAnamneze;
            this.imeIPrezimeLekara = imeIPrezimeLekara;
            this.datum = datum;
            this.sveTerapije = sveTerapije;
            this.dijagnoza = dijagnoza;
            this.idLekara = idLekara;
            this.idPacijenta = idPacijenta;
        }

        public AnamnezaDTO()
        {
        }
    }
}

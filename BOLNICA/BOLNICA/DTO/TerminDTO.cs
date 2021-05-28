using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class TerminDTO
    {
        private String idTermina;
        private DateTime datum;
        private String vreme;
        private LekarDTO lekar;
        private String trajanje;
        private String prostor;
        private String tipTermina;
        private String idPacijenta;

        public String IdTermina
        {
            get { return idTermina; }
            set { idTermina = value; }
        }
        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        public String Vreme
        {
            get { return vreme; }
            set { vreme = value; }
        }
        public String IdPacijenta
        {
            get { return idPacijenta; }
            set { idPacijenta = value; }
        }

        public LekarDTO Lekar
        {
            get { return lekar; }
            set { lekar = value; }
        }

        public String Trajanje
        {
            get { return trajanje; }
            set { trajanje = value; }
        }

        public String Prostor
        {
            get { return prostor; }
            set { prostor = value; }
        }
        public String TipTermina
        {
            get { return tipTermina; }
            set { tipTermina = value; }
        }
        public TerminDTO() { }

        public TerminDTO(string idTermina, DateTime datum, string vreme, LekarDTO lekar, string trajanje, string prostor, string tipTermina, string idPacijenta)
        {
            this.idTermina = idTermina;
            this.datum = datum;
            this.vreme = vreme;
            this.lekar = lekar;
            this.trajanje = trajanje;
            this.prostor = prostor;
            this.tipTermina = tipTermina;
            this.idPacijenta = idPacijenta;
        }

        public TerminDTO(string idTermina, DateTime datum, string vreme, LekarDTO lekar, string trajanje, string prostor, string tipTermina)
        {
            this.idTermina = idTermina;
            this.datum = datum;
            this.vreme = vreme;
            this.lekar = lekar;
            this.trajanje = trajanje;
            this.prostor = prostor;
            this.tipTermina = tipTermina;
        }
    }
}

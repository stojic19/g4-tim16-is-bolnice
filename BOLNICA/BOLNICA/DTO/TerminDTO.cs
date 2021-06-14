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
        private PacijentDTO pacijent;
        private Double trajanjeDouble;
       

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

        public PacijentDTO Pacijent
        {
            get { return pacijent; }
            set { pacijent = value; }
        }

        public String Trajanje
        {
            get { return trajanje; }
            set { trajanje = value; }
        }

        public Double TrajanjeDouble
        {
            get { return trajanjeDouble; }
            set { trajanjeDouble = value; }
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

        public TerminDTO(string idTermina, DateTime datum, string vreme, LekarDTO lekar, string trajanje, string prostor, string tipTermina, string idPacijenta, Double trajanjeDouble, PacijentDTO pacijent)
        {
            this.idTermina = idTermina;
            this.datum = datum;
            this.vreme = vreme;
            this.lekar = lekar;
            this.trajanje = trajanje;
            this.prostor = prostor;
            this.tipTermina = tipTermina;
            this.idPacijenta = idPacijenta;
            this.trajanjeDouble = trajanjeDouble;
            this.pacijent = pacijent;
        }

        public TerminDTO(string idTermina, DateTime datum, string vreme, LekarDTO lekar, string trajanje, string prostor, string tipTermina, Double trajanjeDouble)
        {
            this.idTermina = idTermina;
            this.datum = datum;
            this.vreme = vreme;
            this.lekar = lekar;
            this.trajanje = trajanje;
            this.prostor = prostor;
            this.tipTermina = tipTermina;
            this.trajanjeDouble = trajanjeDouble;
        }

        public TerminDTO(DateTime datum, string prostor, string tipTermina)
        {
            this.datum = datum;
            this.prostor = prostor;
            this.tipTermina = tipTermina;
        }
    }
}

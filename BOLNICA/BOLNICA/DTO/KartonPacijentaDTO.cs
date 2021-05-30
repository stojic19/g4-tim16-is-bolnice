using Bolnica.Model.Enumi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class KartonPacijentaDTO
    {
        private BracniStatus bracniStatus;
        private String mestoZaposlenja;
        private String imeRoditelja;
        private String brojKartona;
        private PacijentDTO pacijent;
        private List<AlergenDTO> alergeni;
        private String idPacijenta;

        public BracniStatus BracniStatus
        {
            get { return bracniStatus; }
            set { bracniStatus = value; }
        }

        public String MestoZaposlenja
        {
            get { return mestoZaposlenja; }
            set { mestoZaposlenja = value; }
        }
        public String ImeRoditelja
        {
            get { return imeRoditelja; }
            set { imeRoditelja = value; }
        }

        public String BrojKartona
        {
            get { return brojKartona; }
            set { brojKartona = value; }
        }

        public PacijentDTO Pacijent
        {
            get { return pacijent; }
            set { pacijent = value; }
        }

        public List<AlergenDTO> Alergeni
        {
            get { return alergeni; }
            set { alergeni = value; }
        }

        public String IdPacijenta
        {
            get { return idPacijenta; }
            set { idPacijenta = value; }
        }
        public KartonPacijentaDTO() { }

        public KartonPacijentaDTO(BracniStatus bracniStatus, string mestoZaposlenja, string imeRoditelja, string brojKartona, PacijentDTO pacijent, List<AlergenDTO> alergeni, string idPacijenta)
        {
            this.bracniStatus = bracniStatus;
            this.mestoZaposlenja = mestoZaposlenja;
            this.imeRoditelja = imeRoditelja;
            this.brojKartona = brojKartona;
            this.pacijent = pacijent;
            this.alergeni = alergeni;
            this.idPacijenta = idPacijenta;
        }

        public KartonPacijentaDTO(BracniStatus bracniStatus, string mestoZaposlenja, string imeRoditelja, string brojKartona, List<AlergenDTO> alergeni, string idPacijenta)
        {
            this.bracniStatus = bracniStatus;
            this.mestoZaposlenja = mestoZaposlenja;
            this.imeRoditelja = imeRoditelja;
            this.brojKartona = brojKartona;
            this.alergeni = alergeni;
            this.idPacijenta = idPacijenta;
        }
    }
}

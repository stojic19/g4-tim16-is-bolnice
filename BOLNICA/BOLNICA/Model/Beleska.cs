using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Beleska
    {
        private DateTime datum;
        private String tekst;
        private String idBeleske;
        private Anamneza anamneza;

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        public String Tekst
        {
            get { return tekst; }
            set { tekst = value; }
        }
        public String IdBeleske
        {
            get { return idBeleske; }
            set { idBeleske = value; }
        }
        public Anamneza Anamneza
        {
            get { return anamneza; }
            set { anamneza = value; }
        }

        public Beleska(DateTime datum, string tekst, string idBeleske, Anamneza anamneza)
        {
            this.datum = datum;
            this.tekst = tekst;
            this.idBeleske = idBeleske;
            this.anamneza = anamneza;
        }

        public Beleska() { }
    }
}

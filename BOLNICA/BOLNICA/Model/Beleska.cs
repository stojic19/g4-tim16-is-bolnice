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
        private String id;
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
        public String Id
        {
            get { return id; }
            set { id = value; }
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
            this.id = idBeleske;
            this.anamneza = anamneza;
        }

        public Beleska() { }
    }
}

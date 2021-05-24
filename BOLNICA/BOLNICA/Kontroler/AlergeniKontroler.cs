using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Kontroler
{
    class AlergeniKontroler
    {
        NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();

        public List<Alergeni> DobaviAlergenePoIdPacijenta(String idPacijenta)
        {
            return naloziPacijenataServis.DobaviAlergenePoIdPacijenta(idPacijenta);
        }

        public void UkloniAlergen(string izabranPacijent, Alergeni alergen)
        {
            naloziPacijenataServis.UkloniAlergen(izabranPacijent, alergen);
        }

        public void DodajAlergen(string izabranPacijent, Alergeni alergenZaDodavanje)
        {
            naloziPacijenataServis.DodajAlergen(izabranPacijent, alergenZaDodavanje);
        }

        internal void IzmeniAlergen(string izabranPacijent, Alergeni alergenZaIzmenu)
        {
            naloziPacijenataServis.IzmeniAlergen(izabranPacijent, alergenZaIzmenu);
        }
    }
}

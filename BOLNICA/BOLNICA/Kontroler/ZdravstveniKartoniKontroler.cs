using Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Kontroler
{
    public class ZdravstveniKartoniKontroler
    {
        private ZdravstveniKartoniServis kartoniServis = new ZdravstveniKartoniServis();

        public List<Lek> LekoviBezAlergena(String idIzabranogPacijenta)
        {
            return kartoniServis.DobaviLekoveBezAlergena(idIzabranogPacijenta);
        }
    }
}

using Bolnica.Servis;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Kontroler
{
    class LekariKontroler
    {
        LekariServis lekariServis= new LekariServis();
        
        public List<Lekar> DobaviSveLekare()
        {
            return lekariServis.SviLekari();
        }
    }
}

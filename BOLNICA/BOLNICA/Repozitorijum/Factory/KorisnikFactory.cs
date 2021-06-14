using Bolnica.Repozitorijum.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum.Factory
{
    public class KorisnikFactory
    {
        public static KorisnikRepozitorijumInterfejs DobaviRepozitorijum()
        {
            return new KorisnikRepozitorijum();
        }
    }
}

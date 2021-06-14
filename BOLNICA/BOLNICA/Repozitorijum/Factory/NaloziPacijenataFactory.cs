using Bolnica.Repozitorijum.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum.Factory
{
    public class NaloziPacijenataFactory
    {
        public static NaloziPacijenataRepozitorijumInterfejs DobaviRepozitorijum()
        {
            return new NaloziPacijenataRepozitorijum();
        }
    }
}

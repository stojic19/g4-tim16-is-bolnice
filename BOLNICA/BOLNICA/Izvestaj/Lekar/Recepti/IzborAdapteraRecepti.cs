using Bolnica.Interfejsi.Lekar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Izvestaj.Lekar
{
    public class IzborAdapteraRecepti
    {

        public static IzvestajiRecepataInterfejs DobaviAdapter()
        {
            return new ITextSharpReceptiAdapter();
        }
    }
}

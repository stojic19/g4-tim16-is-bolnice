using Bolnica.Interfejsi.Lekar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Izvestaj.Lekar.Anamneze
{
    public class IzborAdapteraAnamneze
    {
        public static IzvestajiAnamnezaInterfejs DobaviAdapter()
        {
            return new ITextSharpAnamnezeAdapter();
        }
    }
}

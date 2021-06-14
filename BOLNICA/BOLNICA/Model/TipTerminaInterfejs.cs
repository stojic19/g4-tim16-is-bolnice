using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Interfejsi.Lekar
{
    public interface TipTerminaInterfejs
    {
        Prostor DodeliProstorTerminu(DateTime datum);
    }
}

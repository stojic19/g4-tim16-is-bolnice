using Bolnica.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Interfejsi.Lekar
{
    public interface IzvestajiRecepataInterfejs
    {
        void ProslediPodatke(List<ReceptDTO> recepti);
        void ProslediLekara(String lekar);
        void ProslediPacijenta(String pacijent);
        void KreirajIzvestaj();
    }
}

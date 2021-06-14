using Bolnica.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Interfejsi.Lekar
{
    public interface IzvestajiAnamnezaInterfejs
    {
        void ProslediPodatke(List<AnamnezaDTO> anamneze);
        void ProslediLekara(String lekar);
        void ProslediPacijenta(String pacijent);
        void KreirajIzvestaj();
    }
}

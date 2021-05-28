using Bolnica.Model;
using Bolnica.Model.Rukovanja;
using Bolnica.Servis;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Kontroler
{
    public class AnketaKontroler
    {
        private AnketeServis anketeServis = new AnketeServis();
      

        public bool DostupnaAnketaOBolnici(Pacijent pacijent)
        {
            return anketeServis.DostupnaAnketaOBolnici(pacijent);
        }

    } 
}

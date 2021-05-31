using Bolnica.DTO;
using Bolnica.Konverter;
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
        private AnketaKonverter anketaKonverter = new AnketaKonverter();

        public bool DostupnaAnketaOBolnici(Pacijent pacijent)
        {
            return anketeServis.DostupnaAnketaOBolnici(pacijent);
        }
        public void DodajAnketu(AnketaDTO anketadto, String idPregleda)
        {
            Anketa anketa = anketaKonverter.AnketaDTOUModel(anketadto);
            anketeServis.DodajAnketu(anketa, idPregleda);
        }

    } 
}

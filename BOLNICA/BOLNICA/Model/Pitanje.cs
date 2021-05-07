using Bolnica.Model.Enumi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Pitanje
    {
        public String TekstPitanja { get; set; }
        public OcenaPitanja Ocena { get; set; }

        public Pitanje() { }

        public Pitanje(OcenaPitanja ocena, string tekstPitanja)
        {
            Ocena = ocena;
            TekstPitanja = tekstPitanja;
        }
    }
}

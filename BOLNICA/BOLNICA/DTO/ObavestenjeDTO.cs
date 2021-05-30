using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class ObavestenjeDTO
    {
        private string idObavestenja;
        private string naslov;
        private string tekst;
        private DateTime datum;
        private string idPrimaoca;

        public String IdObavestenja { get => idObavestenja; set => idObavestenja = value; }
        public String Naslov { get => naslov; set => naslov = value; }
        public String Tekst { get => tekst; set => tekst = value; }
        public DateTime Datum { get => datum; set => datum = value; }
        public String IdPrimaoca { get => idPrimaoca; set => idPrimaoca = value; }

        public ObavestenjeDTO(string idObavestenja, string naslov, string tekst, DateTime datum, string idPrimaoca)
        {
            IdObavestenja = idObavestenja;
            Naslov = naslov;
            Tekst = tekst;
            Datum = datum;
            IdPrimaoca = idPrimaoca;
        }
        public ObavestenjeDTO(string naslov, string tekst, DateTime datum, string idPrimaoca)
        {
            IdObavestenja = Guid.NewGuid().ToString();
            Naslov = naslov;
            Tekst = tekst;
            Datum = datum;
            IdPrimaoca = idPrimaoca;
        }
        public ObavestenjeDTO() { }

        public string[] DobaviPrimaoce()
        {
            return IdPrimaoca.Split(' ');
        }
    }
}

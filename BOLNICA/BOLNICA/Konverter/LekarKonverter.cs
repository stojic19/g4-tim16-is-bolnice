using Bolnica.DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class LekarKonverter
    {

        public LekarDTO LekarModelUDTO(Lekar lekar)
        {
            return new LekarDTO(lekar.Ime+lekar.Prezime,lekar.KorisnickoIme,lekar.Specijalizacija);
        }
    }
}

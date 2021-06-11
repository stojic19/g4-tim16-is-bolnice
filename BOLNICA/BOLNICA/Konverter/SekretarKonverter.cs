using Bolnica.DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class SekretarKonverter
    {
        public SekretarDTO SekretarModelUDTO(Model.Sekretar sekretar)
        {
            return new SekretarDTO(sekretar.IdOsobe, sekretar.KorisnickoIme, sekretar.Ime, sekretar.Prezime, sekretar.DatumRodjenja, sekretar.Pol, sekretar.Jmbg, sekretar.AdresaStanovanja, sekretar.KontaktTelefon, sekretar.Email, sekretar.Lozinka);
        }
        public Model.Sekretar SekretarDTOUModel(SekretarDTO sekretar)
        {
            return new Model.Sekretar(sekretar.IdOsobe, sekretar.KorisnickoIme, sekretar.Ime, sekretar.Prezime, sekretar.DatumRodjenja, sekretar.Pol, sekretar.Jmbg, sekretar.AdresaStanovanja, sekretar.KontaktTelefon, sekretar.Email, sekretar.Lozinka);
        }
    }
}

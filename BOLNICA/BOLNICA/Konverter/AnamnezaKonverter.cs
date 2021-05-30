using Bolnica.DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class AnamnezaKonverter
    {
        public AnamnezaDTO AnamnezaModelUDTO(Anamneza anamneza)
        {
            if (anamneza == null)
                return new AnamnezaDTO();
            List<TerapijaDTO> terapije = new List<TerapijaDTO>();
            TerapijaKonverter terapijaKonverter = new TerapijaKonverter();
            foreach (Terapija terapija in anamneza.Terapije)
                terapije.Add(terapijaKonverter.TerapijaModelUDTO(terapija));
            return new AnamnezaDTO(anamneza.IdAnamneze, anamneza.IdPacijenta, anamneza.Dijagnoza, terapije);
        }
    }
}

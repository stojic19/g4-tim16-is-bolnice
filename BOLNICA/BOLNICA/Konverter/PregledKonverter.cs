using Bolnica.DTO;
using Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class PregledKonverter
    {
        public PregledDTO PregledModelUDTO(Pregled pregled)
        {
            AnamnezaKonverter anamnezaKonverter = new AnamnezaKonverter();
            TerminKonverter terminKonverter = new TerminKonverter();
            ReceptKonverter receptKonverter = new ReceptKonverter();
            List<ReceptDTO> recepti = new List<ReceptDTO>();
            foreach (Recept recept in pregled.Recepti)
                recepti.Add(receptKonverter.ReceptModelUDTO(recept));
            return new PregledDTO(pregled.IdPregleda, pregled.Odrzan, terminKonverter.ZakazaniTerminModelUDTO(pregled.Termin, pregled.Termin.Pacijent.KorisnickoIme),
                anamnezaKonverter.AnamnezaModelUDTO(pregled.Anamneza), recepti, pregled.OcenjenPregled);
        }
    }
}

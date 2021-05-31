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
        AnamnezaKonverter anamnezaKonverter = new AnamnezaKonverter();
        TerminKonverter terminKonverter = new TerminKonverter();
        ReceptKonverter receptKonverter = new ReceptKonverter();

        public PregledDTO PregledModelUDTO(Pregled pregled)
        {
            List<ReceptDTO> recepti = new List<ReceptDTO>();
            foreach (Recept recept in pregled.Recepti)
                recepti.Add(receptKonverter.ReceptModelUDTO(recept));
            return new PregledDTO(pregled.IdPregleda, pregled.Odrzan, terminKonverter.ZakazaniTerminModelUDTO(pregled.Termin, pregled.Termin.Pacijent.KorisnickoIme),
                anamnezaKonverter.AnamnezaModelUDTO(pregled.Anamneza), recepti, pregled.OcenjenPregled);
        }

        public PregledDTO OsnovniPodaciUDTO(Pregled pregled)
        {
            return new PregledDTO(pregled.IdPregleda, terminKonverter.ZakazaniTerminModelUDTO(pregled.Termin, pregled.Termin.Pacijent.KorisnickoIme));
        }

        public Pregled PregledDTOUModel(PregledDTO pregled)
        {
            List<Recept> recepti = new List<Recept>();
            foreach (ReceptDTO recept in pregled.Recepti)
                recepti.Add(receptKonverter.ReceptDTOuModel(recept));
            return new Pregled(pregled.IdPregleda, terminKonverter.ZakazaniTerminDTOUModel(pregled.Termin),
                anamnezaKonverter.AnamnezaDTOUModel(pregled.Anamneza), recepti, pregled.OcenjenPregled);

        }


    }
}

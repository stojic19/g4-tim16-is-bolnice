using Bolnica.DTO;
using Bolnica.Konverter;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Kontroler
{
    public class PreglediKontroler
    {
        private PreglediServis preglediServis = new PreglediServis();
        private PregledKonverter pregledKonverter = new PregledKonverter();
        ReceptKonverter receptKonverter = new ReceptKonverter();
        AnamnezaKonverter anamnezaKonverter = new AnamnezaKonverter();
        UputKonverter uputKonverter = new UputKonverter();

        public List<Pregled> SortPoDatumuPregleda()
        {
            return preglediServis.SortPoDatumuPregleda();
        }

        public PregledDTO PretraziPoId(String idPregleda)
        {
            return pregledKonverter.PregledModelUDTO(preglediServis.PretraziPoId(idPregleda));
        }


        public String PristupPregledu(String idTermina)
        {
            return preglediServis.PristupPregledu(idTermina).IdPregleda;

        }

        public void UklanjanjePregleda(String terminOtkazanogPregleda)
        {
            preglediServis.UklanjanjePregleda(terminOtkazanogPregleda);
        }

        public Pregled PretragaPoTerminu(String idTermina)
        {
            return preglediServis.PretragaPoTerminu(idTermina);
        }

        public void DodajUput(String idIzabranogPregleda, UputDTO noviUput)
        {
            preglediServis.DodajUput(idIzabranogPregleda, uputKonverter.UputDTOuModel(noviUput));
        }

        public void DodajRecept(String idPregleda, ReceptDTO novRecept)
        {
            preglediServis.DodajRecept(idPregleda, receptKonverter.ReceptDTOuModel(novRecept));
        }

        public void DodajAnamnezu(String idPregleda, AnamnezaDTO novaAnamneza)
        {
            preglediServis.DodajAnamnezu(idPregleda, anamnezaKonverter.AnamnezaSaLekaromUModel(novaAnamneza));
        }

        public void UklanjanjeAnamneze(String idPregleda)
        {
            preglediServis.UklanjanjeAnamneze(idPregleda);
        }

        public Pregled PretragaPoAnamnezi(String idAnamneze)
        {

            return preglediServis.PretragaPoAnamnezi(idAnamneze);

        }

        public List<PregledDTO> DobaviSveObavljenePregledePacijenta(String korisnickoIme)
        {
            List<PregledDTO> obavljeniPregledi = new List<PregledDTO>();
            foreach (Pregled pregled in preglediServis.DobaviSveObavljenePregledePacijenta(korisnickoIme))
                obavljeniPregledi.Add(pregledKonverter.PregledModelUDTO(pregled));
            return obavljeniPregledi;
        }

        public PregledDTO DobaviPregled(String idPregleda)
        {
            return pregledKonverter.OsnovniPodaciUDTO(preglediServis.PretraziPoId(idPregleda));
        }
        public bool ProveraPostojanjaAnamneze(String idPregleda)
        {
            return preglediServis.ProveraPostojanjaAnamneze(idPregleda);
        }

    }
}

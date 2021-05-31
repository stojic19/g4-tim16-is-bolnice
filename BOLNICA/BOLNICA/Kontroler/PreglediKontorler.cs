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
        public List<Pregled> DobaviSvePreglede()
        {
            return preglediServis.DobaviSvePreglede();
        }
        public List<Pregled> SortPoDatumuPregleda()
        {
            return preglediServis.SortPoDatumuPregleda();
        }

        public Pregled PretraziPoId(String idPregleda)
        {
            return preglediServis.PretraziPoId(idPregleda);
        }

        public Pregled PristupPregledu(String idTermina)
        {
            return preglediServis.PristupPregledu(idTermina);

        }

        public void UklanjanjePregleda(String terminOtkazanogPregleda)
        {
            preglediServis.UklanjanjePregleda(terminOtkazanogPregleda);
        }

        public Pregled PretragaPoTerminu(String idTermina)
        {
            return preglediServis.PretragaPoTerminu(idTermina);
        }

        public void DodajUput(String idIzabranogPregleda, Uput noviUput)
        {
            preglediServis.DodajUput(idIzabranogPregleda, noviUput);
        }

        public void DodajRecept(String idPregleda, Recept novRecept)
        {
            preglediServis.DodajRecept(idPregleda, novRecept);
        }

        public void DodajAnamnezu(String idPregleda, Anamneza novaAnamneza)
        {
            preglediServis.DodajAnamnezu(idPregleda, novaAnamneza);
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
    }
}

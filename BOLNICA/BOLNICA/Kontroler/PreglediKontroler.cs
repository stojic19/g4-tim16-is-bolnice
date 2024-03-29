﻿using Bolnica.Model;
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

        public Pregled PristupPregledu(Termin terminPregleda)
        {
            return preglediServis.PristupPregledu(terminPregleda);

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

        public void DodajAnamnezu(Pregled izabranPregled, Anamneza novaAnamneza)
        {
            preglediServis.DodajAnamnezu(izabranPregled, novaAnamneza);
        }

        public void UklanjanjeAnamneze(Pregled izabranPregled)
        {
            preglediServis.UklanjanjeAnamneze(izabranPregled);
        }

        public Pregled PretragaPoAnamnezi(Anamneza izabranaAnamneza)
        {

            return preglediServis.PretragaPoAnamnezi(izabranaAnamneza);

        }
    }
}

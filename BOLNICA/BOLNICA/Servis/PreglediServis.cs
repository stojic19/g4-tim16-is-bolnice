using Bolnica.Repozitorijum;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bolnica.Model.Rukovanja
{
    class PreglediServis
    {
        private PreglediRepozitorijum preglediRepozitorijum = new PreglediRepozitorijum();
        public List<Pregled> DobaviSvePreglede()
        {
            return preglediRepozitorijum.DobaviSvePreglede();
        }

        public List<Pregled> SortPoDatumuPregleda()
        {
            return preglediRepozitorijum.SortPoDatumuPregleda();
        }

        public Pregled PretraziPoId(String idPregleda)
        {
            return preglediRepozitorijum.PretraziPoId(idPregleda);
        }

        public Pregled PristupPregledu(Termin terminPregleda)
        {
            Pregled noviPregled = preglediRepozitorijum.PretragaPoTerminu(terminPregleda.IdTermina);

            if (noviPregled == null)
            {
                noviPregled = new Pregled(Guid.NewGuid().ToString(), terminPregleda);
                preglediRepozitorijum.DodajPregled(noviPregled);

            }

            return noviPregled;

        }
        public void UklanjanjePregleda(String terminOtkazanogPregleda)
        {
            preglediRepozitorijum.UklanjanjePregleda(terminOtkazanogPregleda);
        }
        public Pregled PretragaPoTerminu(String idTermina)
        {
            return preglediRepozitorijum.PretragaPoTerminu(idTermina);
        }
        public void DodajUput(String idIzabranogPregleda, Uput noviUput)
        {
            Pregled pregledZaIzmenu = preglediRepozitorijum.PretraziPoId(idIzabranogPregleda);
            pregledZaIzmenu.Odrzan = true;
            pregledZaIzmenu.Uputi.Add(noviUput);

            preglediRepozitorijum.IzmeniPregled(pregledZaIzmenu);
        }
        public void DodajRecept(String idPregleda, Recept novRecept)
        {
            Pregled pregledZaIzmenu = preglediRepozitorijum.PretraziPoId(idPregleda);
            pregledZaIzmenu.Odrzan = true;
            pregledZaIzmenu.Recepti.Add(novRecept);

            preglediRepozitorijum.IzmeniPregled(pregledZaIzmenu);
        }
        public void DodajAnamnezu(String idIzabranogPregleda, Anamneza novaAnamneza)
        {
            Pregled pregledZaIzmenu = preglediRepozitorijum.PretraziPoId(idIzabranogPregleda);
            pregledZaIzmenu.Odrzan = true;
            pregledZaIzmenu.Anamneza = novaAnamneza;

            preglediRepozitorijum.IzmeniPregled(pregledZaIzmenu);
        }
        public void UklanjanjeAnamneze(String idIzabranogPregleda)
        {
            Pregled pregledZaIzmenu = preglediRepozitorijum.PretraziPoId(idIzabranogPregleda);
            pregledZaIzmenu.Odrzan = true;
            pregledZaIzmenu.Anamneza = null;

            preglediRepozitorijum.IzmeniPregled(pregledZaIzmenu);
        }
        public Pregled PretragaPoAnamnezi(String idAnamneze)
        {
            return preglediRepozitorijum.PretragaPoAnamnezi(idAnamneze);
        }
    }
}

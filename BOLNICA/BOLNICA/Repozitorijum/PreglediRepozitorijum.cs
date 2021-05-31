using Bolnica.Model;
using Bolnica.Repozitorijum.Interfejsi;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Bolnica.Repozitorijum
{
    public class PreglediRepozitorijum : GlavniRepozitorijum<Pregled>, PreglediRepozitorijumInterfejs
    {
        public PreglediRepozitorijum()
        {
            imeFajla = "pregledi.xml";
        }

        public void IzmeniPregled(Pregled pregledZaIzmenu)
        {
            ObrisiObjekat("//ArrayOfPregled/Pregled[IdPregleda='" + pregledZaIzmenu.IdPregleda + "']");
            DodajObjekat(pregledZaIzmenu);
        }

        public List<Pregled> SortPoDatumuPregleda()
        {
            return DobaviSveObjekte().OrderBy(user => user.Termin.Datum).ToList();
        }

        public List<Pregled> DobaviSvePregledePacijenta(String korisnickoImePacijenta)
        {
            List<Pregled> obavljeniPreglediPacijenta = new List<Pregled>();
            foreach (Pregled pregled in DobaviSveObjekte())
            {
                if (pregled.Termin != null)
                {
                    if (pregled.Termin.Pacijent.KorisnickoIme.Equals(korisnickoImePacijenta) && pregled.Odrzan)
                        obavljeniPreglediPacijenta.Add(pregled);
                }
            }
            return obavljeniPreglediPacijenta;
        }
        public void ObrisiPregled(String idPregleda)
        {
            ObrisiObjekat("//ArrayOfPregled/Pregled[IdPregleda='" + idPregleda + "']");
        }

        public Pregled PretragaPoTerminu(String idTermina)
        {
            foreach (Pregled p in DobaviSveObjekte())
            {
                if (p.Termin == null) continue;
                if (p.Termin.IdTermina.Equals(idTermina))
                {
                    return p;
                }
            }

            return null;
        }

        public Pregled PretraziPoAnamnezi(String idAnamneze)
        {
            foreach (Pregled p in DobaviSveObjekte())
            {
                if (p.Anamneza.IdAnamneze.Equals(idAnamneze))
                {
                    return p;
                }
            }

            return null;
        }

        public Pregled DobaviPregledPoId(String idPregleda)
        {
            return PretraziPoId("//ArrayOfPregled/Pregled[IdPregleda='" + idPregleda + "']");
        }
    }
}

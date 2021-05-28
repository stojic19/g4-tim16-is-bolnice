﻿using Bolnica.Model;
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
            ObrisiObjekat("//ArrayOfPregled/Pregled/Termin[IdTermina='" + pregledZaIzmenu.Termin.IdTermina + "']");
            DodajObjekat(pregledZaIzmenu);
        }

        public List<Pregled> SortPoDatumuPregleda()
        {
            return DobaviSveObjekte().OrderBy(user => user.Termin.Datum).ToList();
        }

        public List<Pregled> DobaviSvePregledePacijenta(String korisnickoImePacijenta)
        {
            List<Pregled> obavljeniPreglediPacijenta = new List<Pregled>();
            foreach(Pregled pregled in DobaviSveObjekte())
            {
                if (pregled.Termin.Pacijent.KorisnickoIme.Equals(korisnickoImePacijenta) && pregled.Odrzan)
                    obavljeniPreglediPacijenta.Add(pregled);
            }
            return obavljeniPreglediPacijenta;
        }
    }
}

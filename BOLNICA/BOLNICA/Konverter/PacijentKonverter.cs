﻿using Bolnica.DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    class PacijentKonverter
    {
        public PacijentDTO PacijentModelUDTO(Pacijent pacijent)
        {
            return new PacijentDTO(pacijent.KorisnickoIme, pacijent.Ime, pacijent.Prezime, pacijent.DatumRodjenja, pacijent.Pol, pacijent.Jmbg, pacijent.AdresaStanovanja, pacijent.KontaktTelefon, pacijent.Email, 
                pacijent.VrstaNaloga, pacijent.Lozinka);
        }
        public Pacijent PacijentDTOUModel(PacijentDTO pacijent)
        {
            return new Pacijent(pacijent.KorisnickoIme, pacijent.Ime, pacijent.Prezime, pacijent.DatumRodjenja, pacijent.Pol, pacijent.Jmbg, pacijent.AdresaStanovanja, pacijent.KontaktTelefon, pacijent.Email,
                pacijent.VrstaNaloga, pacijent.Lozinka);
        }
    }
}

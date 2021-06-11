using Bolnica.Interfejsi.Sekretar;
using Bolnica.Model.Rukovanja;
using Bolnica.Repozitorijum;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Servis
{
    class AlergeniServis : CRUDInterfejs<Alergeni>
    {
        private NaloziPacijenataRepozitorijum naloziPacijenataRepozitorijum = new NaloziPacijenataRepozitorijum();
        private LekoviServis lekoviServis = new LekoviServis();
        private Pacijent pacijent;
        public AlergeniServis(String idPacijenta)
        {
            this.pacijent = naloziPacijenataRepozitorijum.PretraziPoId("//ArrayOfPacijent/Pacijent[KorisnickoIme='" + idPacijenta + "']");
        }
        public List<Alergeni> DobaviSve()
        {
            return naloziPacijenataRepozitorijum.DobaviAlergenePacijenta(pacijent.KorisnickoIme);
        }

        public void Dodaj(Alergeni alergen)
        {
            alergen.Lek = lekoviServis.PretraziPoID(alergen.IdAlergena);
            pacijent.DodajAlergen(alergen);
            naloziPacijenataRepozitorijum.IzmeniPacijenta(pacijent);
        }

        public void Izmeni(Alergeni noviAlergen)
        {
            pacijent.IzmeniAlergen(noviAlergen);
            naloziPacijenataRepozitorijum.IzmeniPacijenta(pacijent);
        }

        public Alergeni PretraziPoId(string id)
        {
            foreach(Alergeni alergen in pacijent.DobaviAlergene())
            {
                if(alergen.IdAlergena.Equals(id))
                {
                    return alergen;
                }
            }
            return null;
        }

        public void Ukloni(Alergeni alergen)
        {
            pacijent.UkloniAlergen(alergen);
            naloziPacijenataRepozitorijum.IzmeniPacijenta(pacijent);
        }

        public bool DaLiLekVecPostojiUAlergenimaPacijenta(string idLeka)
        {
            foreach (Alergeni alergeni in DobaviSve())
            {
                if (alergeni.IdAlergena.Equals(idLeka))
                {
                    return true;
                }
            }
            return false;
        }
        public Alergeni DobaviAlergenPacijentaPoId(String idAlergena)
        {
            foreach (Alergeni alergen in DobaviSve())
            {
                if (alergen.IdAlergena.Equals(idAlergena))
                {
                    return alergen;
                }
            }
            return null;
        }
    }
}

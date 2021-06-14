using Bolnica.Interfejsi.Sekretar;
using Bolnica.Model.Rukovanja;
using Bolnica.Repozitorijum;
using Bolnica.Repozitorijum.Factory;
using Bolnica.Repozitorijum.Interfejsi;
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
        private NaloziPacijenataRepozitorijumInterfejs naloziPacijenataRepozitorijum = NaloziPacijenataFactory.DobaviRepozitorijum();
        private LekoviServis lekoviServis = new LekoviServis();
        private string idPacijenta;
        public AlergeniServis(String idPacijenta)
        {
            this.idPacijenta = idPacijenta;
        }
        public List<Alergeni> DobaviSve()
        {
            Pacijent pacijent = naloziPacijenataRepozitorijum.PretraziPoId("//ArrayOfPacijent/Pacijent[KorisnickoIme='" + idPacijenta + "']");
            return naloziPacijenataRepozitorijum.DobaviAlergenePacijenta(pacijent.KorisnickoIme);
        }

        public void Dodaj(Alergeni alergen)
        {
            Pacijent pacijent = naloziPacijenataRepozitorijum.PretraziPoId("//ArrayOfPacijent/Pacijent[KorisnickoIme='" + idPacijenta + "']");
            alergen.Lek = lekoviServis.PretraziPoID(alergen.IdAlergena);
            pacijent.DodajAlergen(alergen);
            naloziPacijenataRepozitorijum.IzmeniPacijenta(pacijent);
        }

        public void Izmeni(Alergeni noviAlergen)
        {
            Pacijent pacijent = naloziPacijenataRepozitorijum.PretraziPoId("//ArrayOfPacijent/Pacijent[KorisnickoIme='" + idPacijenta + "']");
            pacijent.IzmeniAlergen(noviAlergen);
            naloziPacijenataRepozitorijum.IzmeniPacijenta(pacijent);
        }

        public Alergeni PretraziPoId(string id)
        {
            Pacijent pacijent = naloziPacijenataRepozitorijum.PretraziPoId("//ArrayOfPacijent/Pacijent[KorisnickoIme='" + idPacijenta + "']");
            foreach (Alergeni alergen in pacijent.DobaviAlergene())
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
            Pacijent pacijent = naloziPacijenataRepozitorijum.PretraziPoId("//ArrayOfPacijent/Pacijent[KorisnickoIme='" + idPacijenta + "']");
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

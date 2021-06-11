using Bolnica.Interfejsi.Sekretar;
using Bolnica.Repozitorijum;
using Bolnica.Repozitorijum.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Servis
{
    class SekretariServis : CRUDInterfejs<Model.Sekretar>
    {
        private SekretariRepozitorijumInterfejs sekretariRepozitorijum = new SekretariRepozitorijum();

        public List<Model.Sekretar> DobaviSve()
        {
            return sekretariRepozitorijum.DobaviSveObjekte();
        }

        public void Dodaj(Model.Sekretar objekat)
        {
            sekretariRepozitorijum.DodajObjekat(objekat);
        }

        public void Izmeni(Model.Sekretar noviObjekat)
        {
            sekretariRepozitorijum.Izmeni(noviObjekat);
        }

        public Model.Sekretar PretraziPoId(string id)
        {
            return sekretariRepozitorijum.PretraziPoId("//ArrayOfSekretar/Sekretar[KorisnickoIme='" + id + "']");
        }

        public void Ukloni(Model.Sekretar objekat)
        {
            sekretariRepozitorijum.ObrisiObjekat("//ArrayOfSekretar/Sekretar[KorisnickoIme='" + objekat.KorisnickoIme + "']");
        }
    }
}

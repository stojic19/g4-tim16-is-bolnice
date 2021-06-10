using Bolnica.Interfejsi.Sekretar;
using Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Servis
{
    class OdsustvoLekaraServis : CRUDInterfejs<Odsustvo>
    {
        LekariServis lekariServis = new LekariServis();
        String idLekara;
        public OdsustvoLekaraServis(String idLekara)
        {
            this.idLekara = idLekara;
        }
        public List<Odsustvo> DobaviSve()
        {
            return lekariServis.DobaviOdsustvoPoIdLekara(idLekara);
        }

        public void Dodaj(Odsustvo odsustvo)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            lekar.DodajSlobodneDane(odsustvo);
            lekariServis.Izmeni(lekar.KorisnickoIme,lekar);
        }

        public void Izmeni(string stariId, Odsustvo novoOdsustvo)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            lekar.IzmeniSlobodneDane(stariId, novoOdsustvo);
            lekariServis.Izmeni(lekar.KorisnickoIme, lekar);
        }

        public Odsustvo PretraziPoId(string id)
        {
            foreach(Odsustvo odsustvo in DobaviSve())
            {
                if (odsustvo.IdOdsustva.Equals(id))
                    return odsustvo;
            }
            return null;
        }

        public void Ukloni(Odsustvo odsustvo)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            lekar.UkloniSlobodneDane(odsustvo.IdOdsustva);
            lekariServis.Izmeni(lekar.KorisnickoIme, lekar);
        }

        public bool DaLiJeMogucGodisnjiUZadatomPeriodu(Odsustvo odsustvo)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            for (DateTime datum = odsustvo.PocetakOdsustva.Date; DateTime.Compare(datum.Date, odsustvo.KrajOdsustva.Date) <= 0; datum = datum.AddDays(1))
            {
                if (lekar.DaLiRadiNaProsledjenDatum(datum.Date))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

using Bolnica.Interfejsi.Sekretar;
using Bolnica.Model;
using Bolnica.Repozitorijum;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Servis
{
    class LekariServis : CRUDInterfejs<Lekar>
    {
        LekariRepozitorijum lekariRepozitorijum = new LekariRepozitorijum();

        public List<Lekar> DobaviSve()
        {
            return lekariRepozitorijum.DobaviSveObjekte();
        }

        public void Ukloni(Lekar lekar)
        {
            lekariRepozitorijum.ObrisiObjekat("//ArrayOfLekar/Lekar[KorisnickoIme='" + lekar.KorisnickoIme + "']");
        }

        public void Dodaj(Lekar lekar)
        {
            lekariRepozitorijum.DodajObjekat(lekar);
        }

        public void Izmeni(Lekar lekar)
        {
            lekariRepozitorijum.IzmeniLekara(lekar);
        }

        public void ObrisiStareRadneDane()
        {
            List<Lekar> lekari = lekariRepozitorijum.DobaviSveObjekte();
            foreach(Lekar lekar in lekari)
            {
                List<RadniDan> radniDani = lekar.RadniDani;
                foreach(RadniDan radniDan in radniDani)
                {
                    if(DateTime.Compare(radniDan.PocetakSmene,DateTime.Now.AddDays(-1))<0)
                    {
                        lekar.UkloniRadniDan(radniDan);
                    }
                }
                Izmeni( lekar);
            }
        }
        public Lekar PretraziPoId(String idLekara)
        {
            return lekariRepozitorijum.PretraziPoId("//ArrayOfLekar/Lekar[KorisnickoIme='" + idLekara + "']");
        }
        public List<RadniDan> DobaviRadneDanePoIdLekara(string idLekara)
        {
            return PretraziPoId(idLekara).DobaviRadneDane();
        }

        public void ProveriDaLiTrebaDodatiDaneZaGodisnji()
        {
            List<Lekar> lekari = DobaviSve();
            foreach(Lekar lekar in lekari)
            {
                  lekar.ProveriSlobodneDaneZaAzuriranje();
            }
        }

        public List<Odsustvo> DobaviOdsustvoPoIdLekara(string idLekara)
        {
            return PretraziPoId(idLekara).DobaviSlobodneDane();
        }
        public List<Lekar> DobaviSpecijaliste()
        {
            List<Lekar> specijaliste = new List<Lekar>();
            foreach (Lekar l in DobaviSve())
            {
                if (l.Specijalizacija != SpecijalizacijeLekara.nema) specijaliste.Add(l);
            }
            return specijaliste;
        }

        public List<Lekar> DobaviLekareOpstePrakse()
        {
            List<Lekar> lekariOpstePrakse = new List<Lekar>();
            foreach (Lekar l in DobaviSve())
                if (l.Specijalizacija == SpecijalizacijeLekara.nema) lekariOpstePrakse.Add(l);
            return lekariOpstePrakse;
        }


        public String ImeiPrezime(String id)
        {
            foreach (Lekar l in DobaviSve())
            {

                if (l.KorisnickoIme.Equals(id))
                {
                    return l.Ime + " " + l.Prezime;
                }
            }

            return null;
        }
    }
}

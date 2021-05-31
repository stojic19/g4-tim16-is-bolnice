using Bolnica;
using Bolnica.Repozitorijum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Model
{
    public class OpremaServis
    {
        OpremaRepozitorijum opremaRepozitorijum = new OpremaRepozitorijum();
        ProstoriServis prostoriServis = new ProstoriServis();

        public void DodajOpremu(Oprema o)
        {
            opremaRepozitorijum.DodajObjekat(o);
        }

        public Boolean IzmeniOpremu(Oprema novaOprema)
        {
            Oprema o = opremaRepozitorijum.PretraziOpremuPoId(novaOprema.IdOpreme);
            o.NazivOpreme = novaOprema.NazivOpreme;
            o.VrstaOpreme = novaOprema.VrstaOpreme;
            o.Kolicina = novaOprema.Kolicina;

            opremaRepozitorijum.IzmenaOpreme(o);
            return true;
        }

        public void UkloniOpremu(String idOpreme)
        {
            opremaRepozitorijum.ObrisiObjekat("//ArrayOfOprema/Oprema[IdOpreme='" + idOpreme + "']");
        }

        public Boolean ProvjeriValidnostNaziva(String nazivOpreme)
        {
            foreach (Oprema o in opremaRepozitorijum.DobaviSveObjekte())
            {
                if (o.NazivOpreme.Equals(nazivOpreme))
                {
                    System.Windows.MessageBox.Show("Postoji prostor sa takvim nazivom!");
                    return false;
                }
            }
            return true;
        }
        public Oprema PretraziPoId(String idOpreme)
        {
            return opremaRepozitorijum.PretraziOpremuPoId(idOpreme);
        }

        public List<Oprema> SvaOprema()
        {
            return opremaRepozitorijum.DobaviSveObjekte();
        }

        public  void PremjestiKolicinuOpreme(Prostor prostorUKojiPrebacujemo, Oprema opremaKojuPrebacujemo, int kolicina)
        {
            ProvjeriKolicinuKojuPremjestamo(opremaKojuPrebacujemo, kolicina);

            foreach (Oprema oprema in SvaOprema())
            {
                if (oprema.IdOpreme.Equals(opremaKojuPrebacujemo.IdOpreme))
                {
                    oprema.Kolicina -= kolicina;
                    opremaKojuPrebacujemo = oprema;
                }
            }

            if (!prostoriServis.DodajSamoKolicinu(prostorUKojiPrebacujemo, opremaKojuPrebacujemo, kolicina))
            {
                Oprema o = new Oprema(opremaKojuPrebacujemo.IdOpreme, opremaKojuPrebacujemo.NazivOpreme, opremaKojuPrebacujemo.VrstaOpreme, kolicina);
                prostoriServis.DodajOpremuProstoru(prostorUKojiPrebacujemo, o);
            }

            opremaRepozitorijum.IzmenaOpreme(opremaKojuPrebacujemo);
        }

        public bool ProvjeriKolicinuKojuPremjestamo(Oprema oprema, int kolicina)
        {
            if (oprema.Kolicina < kolicina)
            {
                System.Windows.Forms.MessageBox.Show("Neispravna kolicina !", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

    }
}
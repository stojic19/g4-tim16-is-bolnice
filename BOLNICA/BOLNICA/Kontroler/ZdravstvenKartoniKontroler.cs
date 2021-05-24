using Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Kontroler
{
    public class ZdravstvenKartoniKontroler
    {
        ZdravstveniKartoniServis zdravstveniKartoniServis = new ZdravstveniKartoniServis();

        public List<Lek> DobaviLekoveBezAlergena(String idIzabranogPacijenta)
        {
            return zdravstveniKartoniServis.DobaviLekoveBezAlergena(idIzabranogPacijenta);
        }
        public Boolean ProveraAlergicnosti(String idIzabranogPacijenta, String idLeka)
        {
            return zdravstveniKartoniServis.ProveraAlergicnosti(idIzabranogPacijenta, idLeka);
        }

        public void DodajRecept(String idPacijenta, Recept novRecept)
        {
            zdravstveniKartoniServis.DodajRecept(idPacijenta, novRecept);
        }

        public List<Terapija> DobaviSveTerapijePacijenta(String idPacijenta)
        {
            return zdravstveniKartoniServis.DobaviSveTerapijePacijenta(idPacijenta);
        }

        public void DodajAnamnezu(Anamneza novaAnamneza)
        {
            zdravstveniKartoniServis.DodajAnamnezu(novaAnamneza);
        }

        public void DodajUput(String idPacijenta, Uput noviUput)
        {
            zdravstveniKartoniServis.DodajUput(idPacijenta, noviUput);
        }

    }
}

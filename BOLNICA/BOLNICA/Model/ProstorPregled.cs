using Bolnica.Interfejsi.Lekar;
using Bolnica.Kontroler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class ProstorPregled : TipTerminaInterfejs
    {
        ProstoriKontroler prostoriKontroler = new ProstoriKontroler();
        ZakazaniTerminiKontroler zakazaniTerminiKontroler = new ZakazaniTerminiKontroler();

        public Prostor DodeliProstorTerminu(DateTime datum)
        {
            foreach (Prostor prostor in prostoriKontroler.DobaviOrdinacije())
            {
                if (!prostoriKontroler.ProveriZauzetostProstora(prostor.IdProstora, datum))
                {
                    return prostor;
                }
            }

            return null;
        }
    }
}

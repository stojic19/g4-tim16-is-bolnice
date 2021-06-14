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
    public class ProstorOperacija : TipTerminaInterfejs
    {
        ProstoriKontroler prostoriKontroler = new ProstoriKontroler();

        public Prostor DodeliProstorTerminu(DateTime datum)
        {
            foreach (Prostor prostor in prostoriKontroler.DobaviSale())
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

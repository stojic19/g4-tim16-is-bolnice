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
            List<Termin> termini = prostoriKontroler.DobaviZakazaneTermineZaVreme(datum);
            foreach (Prostor prostor in prostoriKontroler.DobaviProstoreModel())
            {
                if (prostor.VrstaProstora == VrsteProstora.sala)
                {
                    bool zauzet = false;
                    foreach (Termin terminZaProveru in termini)
                    {
                        if (terminZaProveru.Prostor.IdProstora.Equals(prostor.IdProstora))
                        {
                            zauzet = true;
                            break;
                        }
                    }
                    if (!zauzet)
                    {
                        return prostor;
                    }
                }
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Interfejsi.Sekretar
{
    interface CRUDInterfejs<T>
    {
        List<T> DobaviSve();

        T PretraziPoId(String id);

        void Ukloni(T objekat);

        void Dodaj(T objekat);

        void Izmeni(string stariId, T noviObjekat);
    }
}

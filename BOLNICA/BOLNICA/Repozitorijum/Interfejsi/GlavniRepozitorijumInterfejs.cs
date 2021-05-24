using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bolnica.Repozitorijum.Interfejsi
{
    public interface GlavniRepozitorijumInterfejs<T>
    {
        List<T> DobaviSveObjekte();

        T PretraziPoId(String obrazacPretrage);

        T KonvertujCvorUObjekat(XmlNode cvor);

        List<T> KonvertujSveCvoroveUObjekte(XmlNodeList cvorovi);

        void ObrisiObjekat(String obrazacZaBrisanje);

        void DodajObjekat(T objekatZaDodavanje);
    }
}

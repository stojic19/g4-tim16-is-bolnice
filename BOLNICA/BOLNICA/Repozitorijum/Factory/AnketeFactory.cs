using Bolnica.Model;
using Bolnica.Repozitorijum.Interfejsi;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bolnica.Repozitorijum.Factory
{
    public class AnketeFactory
    {
        public static AnketeRepozitorijumInterfejs DobaviRepozitorijum()
        {
            return new AnketeRepozitorijum();
        }
    }
}

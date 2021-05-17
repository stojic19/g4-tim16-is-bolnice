using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bolnica.Model.Rukovanja
{
    class PreglediServis
    {

        public static List<Pregled> sviPregledi { get; set; } = new List<Pregled>();
        private static String imeFajla = "pregledi.xml";

        public static Pregled PretraziPoId(String idPregleda)
        {
            foreach (Pregled pregled in sviPregledi)
            {
                if (pregled.IdPregleda.Equals(idPregleda))
                    return pregled;
            }
            return null;
        }
        public static List<Pregled> SortPoDatumuPregleda()
        {
            return sviPregledi.OrderBy(user => user.Termin.Datum).ToList();
        }
        public static Pregled PristupPregledu(Termin terminPregleda)
        {
            Pregled noviPregled = PretragaPoTerminu(terminPregleda.IdTermina);

            if (noviPregled == null)
            {
                noviPregled = new Pregled(Guid.NewGuid().ToString(), terminPregleda);
                sviPregledi.Add(noviPregled);

            }

            return noviPregled;

        }

        public static void UklanjanjePregleda(String terminOtkazanogPregleda)
        {
            Pregled otkazanPregled = PretragaPoTerminu(terminOtkazanogPregleda);

            if (otkazanPregled != null)
            {
                sviPregledi.Remove(otkazanPregled);
                Console.WriteLine("brisem");
            }
        }

        public static Pregled PretragaPoTerminu(String iDTermina)
        {
            foreach (Pregled p in sviPregledi)
            {
                if (p.Termin.IdTermina.Equals(iDTermina))
                {
                    return p;
                }
            }

            return null;
        }

        public static List<Pregled> DeserijalizacijaPregleda()
        {
            if (File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return sviPregledi;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pregled>));
                sviPregledi = (List<Pregled>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sviPregledi;

            }

        }

        internal static void DodajUput(String idIzabranogPregleda, Uput noviUput)
        {
            foreach (Pregled p in sviPregledi)
            {
                if (p.IdPregleda.Equals(idIzabranogPregleda))
                {
                    p.Odrzan = true;
                    p.Uputi.Add(noviUput);
                }

            }
        }

        public static void SerijalizacijaPregleda()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pregled>));
            TextWriter tw = new StreamWriter(imeFajla);
            xmlSerializer.Serialize(tw, sviPregledi);
            tw.Close();

        }

        public static void DodavanjeRecepta(String idPregleda, Recept novRecept)
        {
            foreach (Pregled p in sviPregledi)
            {
                if (p.IdPregleda.Equals(idPregleda))
                {
                    p.Odrzan = true;
                    p.Recepti.Add(novRecept);
                }

            }
        }

        public static void DodavanjeAnamneze(Pregled izabranPregled, Anamneza novaAnamneza)
        {
            foreach (Pregled p in sviPregledi)
            {
                if (p.IdPregleda.Equals(izabranPregled.IdPregleda) && p.Anamneza == null)
                {
                    p.Odrzan = true;
                    p.Anamneza = novaAnamneza;
                }

            }
        }

        public static void UklanjanjeAnamneze(Pregled izabranPregled)
        {
            foreach (Pregled p in sviPregledi)
            {
                if (p.IdPregleda.Equals(izabranPregled.IdPregleda))
                {
                    p.Anamneza = null;
                }

            }
        }

        public static Pregled PretragaPoAnamnezi(Anamneza izabranaAnamneza)
        {

            foreach (Pregled p in sviPregledi)
            {
                try
                {
                    if (p.Anamneza.IdAnamneze.Equals(izabranaAnamneza.IdAnamneze))
                    {
                        return p;
                    }
                }
                catch (ArgumentNullException ane) { }

            }

            return null;

        }

    }
}

using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bolnica.Model
{
    class RukovanjeZdravstvenimKartonima
    {

        

        public static List<ZdravstveniKarton> kartoni = new List<ZdravstveniKarton>();
        public static List<Recept> recepti { get; set; } = new List<Recept>();

        //SAMO PRIVREMENO DOK SE NE UBACE LEKOVI
        public static List<Lek> inicijalniLekovi { get; set; } = new List<Lek>();
        public static void InicijalizacijaLekova()
        {

            inicijalniLekovi.Add(new Lek("1", "L1", "500mg"));
            inicijalniLekovi.Add(new Lek("2", "L2", "20mg"));
            inicijalniLekovi.Add(new Lek("3", "L3", "200mg"));
            inicijalniLekovi.Add(new Lek("4", "L4", "500mg"));
            inicijalniLekovi.Add(new Lek("5", "L5", "10mg"));
        }

        public static Lek pretraziLekPoID(String ID)
        {
            foreach (Lek l in inicijalniLekovi)
            {

                if (l.IDLeka.Equals(ID))
                {
                    return l;
                }
            }

            return null;
        }

        public static String generisiIDRecepta(String id)
        {
            bool pronadjen = false;

            int i = 0;

            foreach (Pacijent p in RukovanjeNalozimaPacijenata.sviNaloziPacijenata)
            {

                if (p.KorisnickoIme.Equals(id))
                {
                    for (i = 0; i < p.ZdravstveniKarton.Recepti.Count; i++)
                    {
                        foreach (Recept r in p.ZdravstveniKarton.Recepti)
                        {
                            if (r.IDRecepta.Equals("R" + i.ToString()))
                            {
                                pronadjen = true;
                                break;
                            }

                        }

                        if (!pronadjen)
                        {
                            return ("R" + i.ToString());

                        }
                        pronadjen = false;
                    }
                }
            }

            return ("R" + i.ToString());
        }

        public static void DodajRecept(Recept r)
        {
            foreach (Pacijent p in RukovanjeNalozimaPacijenata.sviNaloziPacijenata)
            {

                if (p.KorisnickoIme.Equals(r.IDPacijenta))
                {
                    p.ZdravstveniKarton.Recepti.Add(r);
                    KartonLekar.Recepti.Add(r);

                    foreach (Recept sr in p.ZdravstveniKarton.Recepti)
                    {
                        Console.WriteLine("+");
                    }

                }
            }
        }


        public static List<Recept> DeserijalizacijaRecepata()
        {
            if (File.ReadAllText("recepti.xml").Trim().Equals(""))
            {
                return recepti;
            }
            else
            {
                FileStream fileStream = File.OpenRead("recepti.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Recept>));
                recepti = (List<Recept>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return recepti;

            }

        }


            public static void SerijalizacijaRecepata()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Recept>));
            TextWriter tw = new StreamWriter("recepti.xml");
            xmlSerializer.Serialize(tw, recepti);
            tw.Close();

        }

    }
}

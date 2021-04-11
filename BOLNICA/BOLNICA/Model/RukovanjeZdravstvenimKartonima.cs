using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    class RukovanjeZdravstvenimKartonima
    {

        public static List<ZdravstveniKarton> kartoni = new List<ZdravstveniKarton>();
        public static List<Recept> recepti = new List<Recept>();

        

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

                    foreach(Recept sr in p.ZdravstveniKarton.Recepti)
                    {
                        Console.WriteLine("+");
                    }

                }


            }


        }

    }
}

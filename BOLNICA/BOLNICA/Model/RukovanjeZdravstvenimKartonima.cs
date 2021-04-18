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

        public static List<Terapija> dobaviSveTerapijePacijenta(String idPacijenta)
        {
            List<Terapija> pomocna = new List<Terapija>();

            Pacijent p = RukovanjeNalozimaPacijenata.PretraziPoId(idPacijenta);

            foreach(Anamneza a in p.ZdravstveniKarton.Anamneze)
            {
                if (a.IdPacijenta.Equals(p.KorisnickoIme))
                {
                    foreach(Terapija t in a.Terapije)
                    {

                        pomocna.Add(t);
                    }


                }


            }


            return pomocna;
        }

        public static void DodajAnamnezu(Anamneza a)
        {
            foreach (Pacijent p in RukovanjeNalozimaPacijenata.sviNaloziPacijenata)
            {

                if (p.KorisnickoIme.Equals(a.IdPacijenta))
                {
                    p.ZdravstveniKarton.Anamneze.Add(a);
                    KartonLekar.Anamneze.Add(a);

                }
            }
        }

        public static List<Terapija> Privremeno { get; set; }

        public static void NovoPrivremeno()
        {
            Privremeno = new List<Terapija>();
        }

        public static void dodajPrivremeno(Terapija t)
        {

            Privremeno.Add(t);


        }

        public static void obrisiPrivremeno(Terapija t)
        {

            Privremeno.Remove(t);


        }

        public static String generisiIDAnamneze(String id)
        {
            bool pronadjen = false;

            int i = 0;

            foreach (Pacijent p in RukovanjeNalozimaPacijenata.sviNaloziPacijenata)
            {

                if (p.KorisnickoIme.Equals(id))
                {
                    for (i = 0; i < p.ZdravstveniKarton.Anamneze.Count; i++)
                    {
                        foreach (Anamneza a in p.ZdravstveniKarton.Anamneze)
                        {
                            if (a.IdAnamneze.Equals("A" + i.ToString()))
                            {
                                pronadjen = true;
                                break;
                            }

                        }

                        if (!pronadjen)
                        {
                            return ("A" + i.ToString());

                        }
                        pronadjen = false;
                    }
                }
            }

            return ("A" + i.ToString());
        }

        public static String generisiIDTerapije(String id, String anamneza)
        {
            bool pronadjen = false;

            int i = 0;

            for (i = 0; i < Privremeno.Count; i++)
            {


                foreach (Terapija te in Privremeno)
                {
                    if (te.IDTerapije.Equals(anamneza + "T" + i.ToString()))
                    {
                        pronadjen = true;
                        break;
                    }


                }

                if (!pronadjen)
                {
                    return (anamneza + "T" + i.ToString());

                }
                pronadjen = false;
            }

               
            return (anamneza + "T" + i.ToString());
            


        }
    }
}

using Bolnica.Model.Rukovanja;
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



        public static List<ZdravstveniKarton> sviKartoni = new List<ZdravstveniKarton>();

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

        public static List<Lek> LekoviBezAlergena(String idIzabranogPacijenta)
        {
            List<Lek> lekoviBezAlergena = new List<Lek>();


            foreach (Lek l in RukovanjeOdobrenimLekovima.SviLekovi)
            {
                if (!ProveraAlergicnosti(idIzabranogPacijenta, l.IDLeka))
                {
                    lekoviBezAlergena.Add(l);
                }
            }
            return lekoviBezAlergena;
        }

        public static Boolean ProveraAlergicnosti(String idIzabranogPacijenta, String idLeka)
        {
            Pacijent izabranPacijent = RukovanjeNalozimaPacijenata.PretraziPoId(idIzabranogPacijenta);

            foreach (Alergeni a in izabranPacijent.ZdravstveniKarton.Alergeni)
            {
                if (a.IdAlergena.Equals(idLeka))
                {
                    return true;
                }
            }

            return false;
        }


        public static void DodajRecept(String idPacijenta, Recept novRecept)
        {
            foreach (Pacijent p in RukovanjeNalozimaPacijenata.sviNaloziPacijenata)
            {

                if (p.KorisnickoIme.Equals(idPacijenta))
                {
                    p.ZdravstveniKarton.Recepti.Add(novRecept);
                    KartonLekar.Recepti.Add(novRecept);

                }
            }
        }

        public static List<Terapija> dobaviSveTerapijePacijenta(String idPacijenta)
        {
            List<Terapija> pomocna = new List<Terapija>();

            Pacijent p = RukovanjeNalozimaPacijenata.PretraziPoId(idPacijenta);

            foreach (Anamneza a in p.ZdravstveniKarton.Anamneze)
            {
                if (a.IdPacijenta.Equals(p.KorisnickoIme))
                {
                    foreach (Terapija t in a.Terapije)
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

        public static void DodajUput(Uput noviUput)
        {
            foreach (Pacijent p in RukovanjeNalozimaPacijenata.sviNaloziPacijenata)
            {

                if (p.KorisnickoIme.Equals(noviUput.IDPacijenta))
                {
                    p.ZdravstveniKarton.Uputi.Add(noviUput);
                    KartonLekar.Uputi.Add(noviUput);

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

    }
}

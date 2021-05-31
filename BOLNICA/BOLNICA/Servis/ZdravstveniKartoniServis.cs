using Bolnica.Model.Rukovanja;
using Bolnica.Repozitorijum;
using Bolnica.Repozitorijum.Interfejsi;
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
    class ZdravstveniKartoniServis
    {
        NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();
        LekoviRepozitorijumInterfejs lekoviRepozitorijum = new LekoviRepozitorijum();

        public List<Lek> DobaviLekoveBezAlergena(String idIzabranogPacijenta)
        {
            List<Lek> lekoviBezAlergena = new List<Lek>();

            foreach (Lek l in lekoviRepozitorijum.DobaviSveObjekte())
            {
                if (!ProveraAlergicnosti(idIzabranogPacijenta, l.IDLeka))
                {
                    lekoviBezAlergena.Add(l);
                }
            }
            return lekoviBezAlergena;
        }

        public Boolean ProveraAlergicnosti(String idIzabranogPacijenta, String idLeka)
        {
            Pacijent izabranPacijent = naloziPacijenataServis.PretraziPoId(idIzabranogPacijenta);

            foreach (Alergeni a in izabranPacijent.ZdravstveniKarton.Alergeni)
            {
                if (a.IdAlergena.Equals(idLeka))
                {
                    return true;
                }
            }

            return false;
        }


        public void DodajRecept(String idPacijenta, Recept novRecept)
        {
            Pacijent p = naloziPacijenataServis.PretraziPoId(idPacijenta);
            p.ZdravstveniKarton.Recepti.Add(novRecept);

            naloziPacijenataServis.IzmeniNalog(p.KorisnickoIme, p);
        }

        public List<Terapija> DobaviSveTerapijePacijenta(String idPacijenta)
        {
            List<Terapija> pomocna = new List<Terapija>();

            Pacijent p = naloziPacijenataServis.PretraziPoId(idPacijenta);

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

        public void DodajAnamnezu(Anamneza novaAnamneza)
        {
            Pacijent p = naloziPacijenataServis.PretraziPoId(novaAnamneza.IdPacijenta);
            p.ZdravstveniKarton.Anamneze.Add(novaAnamneza);

            naloziPacijenataServis.IzmeniNalog(p.KorisnickoIme, p);

        }

        public void DodajUput(String idPacijenta,Uput noviUput)
        {
            Pacijent p = naloziPacijenataServis.PretraziPoId(idPacijenta);
            p.ZdravstveniKarton.Uputi.Add(noviUput);

            naloziPacijenataServis.IzmeniNalog(p.KorisnickoIme, p);
        }

        //OVO SE SVE BRISE KAD IZMENIS ANAMNEZE

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

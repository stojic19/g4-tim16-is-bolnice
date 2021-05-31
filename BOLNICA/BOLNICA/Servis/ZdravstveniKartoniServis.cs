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

            naloziPacijenataServis.IzmeniPacijentaSaKorisnickim(p.KorisnickoIme, p);
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

            naloziPacijenataServis.IzmeniPacijentaSaKorisnickim(p.KorisnickoIme, p);

        }

        public void DodajUput(String idPacijenta, Uput noviUput)
        {
            Pacijent p = naloziPacijenataServis.PretraziPoId(idPacijenta);
            p.ZdravstveniKarton.Uputi.Add(noviUput);

            naloziPacijenataServis.IzmeniPacijentaSaKorisnickim(p.KorisnickoIme, p);
        }

        public void IzmeniUput(String idPacijenta, Uput izmenjenUput)
        {
            Pacijent p = naloziPacijenataServis.PretraziPoId(idPacijenta);
            
            foreach(Uput u in p.ZdravstveniKarton.Uputi)
            {
                if (u.IDUputa.Equals(izmenjenUput.IDUputa))
                {
                    p.ZdravstveniKarton.Uputi.Remove(u);
                    break;
                }
            }
            p.ZdravstveniKarton.Uputi.Add(izmenjenUput);

            naloziPacijenataServis.IzmeniPacijentaSaKorisnickim(p.KorisnickoIme, p);
        }

        public List<Recept> DobaviReceptePacijenta(String idPacijenta)
        {
            Pacijent p = naloziPacijenataServis.PretraziPoId(idPacijenta);
            List<Recept> receptiPacijenta = new List<Recept>();

            foreach (Recept r in p.ZdravstveniKarton.Recepti)
            {
                receptiPacijenta.Add(r);
            }
            return receptiPacijenta;
        }

        public List<Uput> DobaviUputePacijenta(String idPacijenta)
        {
            Pacijent p = naloziPacijenataServis.PretraziPoId(idPacijenta);
            List<Uput> uputiPacijenta = new List<Uput>();

            foreach (Uput u in p.ZdravstveniKarton.Uputi)
            {
                uputiPacijenta.Add(u);
            }
            return uputiPacijenta;
        }

        public List<Anamneza> DobaviAnamnezePacijenta(String idPacijenta)
        {
            Pacijent p = naloziPacijenataServis.PretraziPoId(idPacijenta);
            List<Anamneza> anamnezePacijenta = new List<Anamneza>();

            foreach (Anamneza a in p.ZdravstveniKarton.Anamneze)
            {
                anamnezePacijenta.Add(a);
            }
            return anamnezePacijenta;
        }

    }
}

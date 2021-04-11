
using System;

namespace Model
{
   public class Osoba
   {
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public String Jmbg { get; set; }
        public String AdresaStanovanja { get; set; }
        public String KontaktTelefon { get; set; }
        public String Email { get; set; }

        public String KorisnickoIme { get; set; }
        public String Lozinka { get; set; }

        public Pol Pol { get; set; }

        public System.Collections.Generic.List<Obavestenje> obavestenje;

        /// <summary>
        /// Property for collection of Obavestenje
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<Obavestenje> Obavestenje
        {
            get
            {
                if (obavestenje == null)
                    obavestenje = new System.Collections.Generic.List<Obavestenje>();
                return obavestenje;
            }
            set
            {
                RemoveAllObavestenje();
                if (value != null)
                {
                    foreach (Obavestenje oObavestenje in value)
                        AddObavestenje(oObavestenje);
                }
            }
        }

        /// <summary>
        /// Add a new Obavestenje in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddObavestenje(Obavestenje newObavestenje)
        {
            if (newObavestenje == null)
                return;
            if (this.obavestenje == null)
                this.obavestenje = new System.Collections.Generic.List<Obavestenje>();
            if (!this.obavestenje.Contains(newObavestenje))
                this.obavestenje.Add(newObavestenje);
        }

        /// <summary>
        /// Remove an existing Obavestenje from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveObavestenje(Obavestenje oldObavestenje)
        {
            if (oldObavestenje == null)
                return;
            if (this.obavestenje != null)
                if (this.obavestenje.Contains(oldObavestenje))
                    this.obavestenje.Remove(oldObavestenje);
        }

        /// <summary>
        /// Remove all instances of Obavestenje from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllObavestenje()
        {
            if (obavestenje != null)
                obavestenje.Clear();
        }
    }
}
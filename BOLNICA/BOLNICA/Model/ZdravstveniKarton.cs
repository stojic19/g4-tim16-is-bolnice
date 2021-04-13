using System;

namespace Model
{
    public class ZdravstveniKarton
    {

        public String IDPacijenta { get; set; }

        public ZdravstveniKarton() { }
        public ZdravstveniKarton(string iDPacijenta)
        {
            IDPacijenta = iDPacijenta;
            Alergeni = new System.Collections.Generic.List<Alergeni>();
        }

        public System.Collections.Generic.List<Alergeni> Alergeni { get; set; }

        public System.Collections.Generic.List<Recept> Recepti { get; set; }

        public System.Collections.Generic.List<Anamneza> anamneza;

        public System.Collections.Generic.List<Anamneza> Anamneza
        {
            get
            {
                if (anamneza == null)
                    anamneza = new System.Collections.Generic.List<Anamneza>();
                return anamneza;
            }
            set
            {
                RemoveAllAnamneza();
                if (value != null)
                {
                    foreach (Anamneza oAnamneza in value)
                        AddAnamneza(oAnamneza);
                }
            }
        }

        public void AddAnamneza(Anamneza newAnamneza)
        {
            if (newAnamneza == null)
                return;
            if (this.anamneza == null)
                this.anamneza = new System.Collections.Generic.List<Anamneza>();
            if (!this.anamneza.Contains(newAnamneza))
                this.anamneza.Add(newAnamneza);
        }

        public void RemoveAnamneza(Anamneza oldAnamneza)
        {
            if (oldAnamneza == null)
                return;
            if (this.anamneza != null)
                if (this.anamneza.Contains(oldAnamneza))
                    this.anamneza.Remove(oldAnamneza);
        }

        public void RemoveAllAnamneza()
        {
            if (anamneza != null)
                anamneza.Clear();
        }

    }
}
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
        }

        public System.Collections.Generic.List<Alergeni> alergeni;

        public System.Collections.Generic.List<Alergeni> Alergeni
        {
            get
            {
                if (alergeni == null)
                    alergeni = new System.Collections.Generic.List<Alergeni>();
                return alergeni;
            }
            set
            {
                RemoveAllAlergeni();
                if (value != null)
                {
                    foreach (Alergeni oAlergeni in value)
                        AddAlergeni(oAlergeni);
                }
            }
        }


        public void AddAlergeni(Alergeni newAlergeni)
        {
            if (newAlergeni == null)
                return;
            if (this.alergeni == null)
                this.alergeni = new System.Collections.Generic.List<Alergeni>();
            if (!this.alergeni.Contains(newAlergeni))
                this.alergeni.Add(newAlergeni);
        }

        public void RemoveAlergeni(Alergeni oldAlergeni)
        {
            if (oldAlergeni == null)
                return;
            if (this.alergeni != null)
                if (this.alergeni.Contains(oldAlergeni))
                    this.alergeni.Remove(oldAlergeni);
        }

        public void RemoveAllAlergeni()
        {
            if (alergeni != null)
                alergeni.Clear();
        }
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
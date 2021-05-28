using System;
using System.ComponentModel;

namespace Model
{
    public class Alergeni
    {
        private string idAlergena;
        private Lek lek;
        private string opisReakcije;
        private string vremeZaPojavu;

        public String IdAlergena { get => idAlergena; set => idAlergena = value; }
        public Lek Lek { get => lek; set => lek = value; }
        public String OpisReakcije { get => opisReakcije; set => opisReakcije = value; }
        public String VremeZaPojavu { get => vremeZaPojavu; set => vremeZaPojavu = value; }
        public Alergeni() { }
        public Alergeni(string idAlergena, string opisReakcije, string vremeZaPojavu)
        {
            IdAlergena = idAlergena;
            OpisReakcije = opisReakcije;
            VremeZaPojavu = vremeZaPojavu;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
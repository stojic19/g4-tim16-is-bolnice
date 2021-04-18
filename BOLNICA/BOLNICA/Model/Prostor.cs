
using System;
using System.ComponentModel;

namespace Model
{
    public class Prostor : INotifyPropertyChanged
    {
        public String IdProstora { get; set; }
        public VrsteProstora VrstaProstora { get; set; }
        public int Sprat { get; set; }
        public float Kvadratura { get; set; }
        public int BrojKreveta { get; set; }
        public Prostor() { }
        public Prostor(string idProstora, VrsteProstora vrstaProstora)
        {
            IdProstora = idProstora;
            VrstaProstora = vrstaProstora;
        }

        public Prostor(string idProstora, VrsteProstora vrstaProstora, int sprat, float kvadratura, int brojKreveta)
        {
            IdProstora = idProstora;
            VrstaProstora = vrstaProstora;
            Sprat = sprat;
            Kvadratura = kvadratura;
            BrojKreveta = brojKreveta;
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
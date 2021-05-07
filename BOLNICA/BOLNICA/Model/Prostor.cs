
using Bolnica.Model;
using System;
using System.Collections.Generic;
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

        public bool JeRenoviranje { get; set; }
        public Renoviranje Renoviranje { get; set; }

        public List<Oprema> Oprema { get; set; }
        public Prostor() { }

        public Prostor(string idProstora, VrsteProstora vrstaProstora, int sprat, float kvadratura, int brojKreveta, bool jeRenoviranje,
                        Renoviranje renoviranje)
        {
            IdProstora = idProstora;
            VrstaProstora = vrstaProstora;
            Sprat = sprat;
            Kvadratura = kvadratura;
            BrojKreveta = brojKreveta;
            Oprema = new List<Oprema>();
            JeRenoviranje = jeRenoviranje;
            Renoviranje = renoviranje;
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
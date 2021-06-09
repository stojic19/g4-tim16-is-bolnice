
using Bolnica.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Model
{
    public class Prostor : INotifyPropertyChanged
    {
        public String IdProstora { get; set; }
        public String NazivProstora { get; set; }
        public VrsteProstora VrstaProstora { get; set; }
        public int Sprat { get; set; }
        public float Kvadratura { get; set; }
        public bool JeRenoviranje { get; set; }
        public List<Oprema> Oprema { get; set; }

        public int BrojSlobodnihKreveta = 0;
        
        public Prostor() { }

        public Prostor(String idProstora,String nazivProstora, VrsteProstora vrstaProstora, int sprat, float kvadratura, List<Oprema> oprema,bool jeRenoviranje)
        {
            IdProstora = idProstora;
            NazivProstora = nazivProstora;
            VrstaProstora = vrstaProstora;
            Sprat = sprat;
            Kvadratura = kvadratura;
            Oprema = oprema;          
            JeRenoviranje = jeRenoviranje;         
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
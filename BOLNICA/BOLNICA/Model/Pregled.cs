using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Pregled : INotifyPropertyChanged
    {
        public String IdPregleda { get; set; }
        public Boolean Odrzan { get; set; } = false;
        public int Zloupotrebio { get; set; }
        public Boolean Blokiran { get; set; }
        public Termin Termin { get; set; }
        public Anamneza Anamneza { get; set; } = null;
        public List<Recept> Recepti { get; set; } = new List<Recept>();
        public List<Uput> Uputi { get; set; } = new List<Uput>();
        public List<Alergeni> Alergeni { get; set; } = new List<Alergeni>();
        public bool OcenjenPregled { get; set; }

        public Pregled() { }

        public Pregled(string idPregleda, Termin termin)
        {
            this.IdPregleda = idPregleda;
            this.Termin = termin;
            OcenjenPregled = false;
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

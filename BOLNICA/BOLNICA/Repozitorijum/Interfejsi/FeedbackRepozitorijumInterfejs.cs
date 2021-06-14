using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum.Interfejsi
{
    public interface FeedbackRepozitorijumInterfejs : GlavniRepozitorijumInterfejs<Feedback>
    {
        void Izmeni(Feedback feedback);
    }
}

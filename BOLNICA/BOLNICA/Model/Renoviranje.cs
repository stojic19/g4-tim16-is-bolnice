using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Renoviranje
    {
        public String RoomId { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }

        public Renoviranje() { }
        public Renoviranje(string argRoomId, DateTime argStartDay, DateTime argEndDay)
        {
            RoomId = argRoomId;
            StartDay = argStartDay;
            EndDay = argEndDay;
        }


    }
}

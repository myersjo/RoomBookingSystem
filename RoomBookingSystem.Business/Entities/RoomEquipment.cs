using System;
using System.Collections.Generic;
using System.Text;

namespace RoomBookingSystem.Business.Entities
{
    public class RoomEquipment
    {
        public string RoomId { get; set; }
        public Room Room { get; set; }

        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RoomBookingSystem.Business.Entities
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<RoomEquipment> RoomEquipment { get; set; }
    }
}

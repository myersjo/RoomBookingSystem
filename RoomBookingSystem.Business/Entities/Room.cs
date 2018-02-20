using System.Collections.Generic;
using System.Reflection.Metadata;

namespace RoomBookingSystem.Business.Entities
{
    public class Room
    {
        public string ID { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; }

        public ICollection<RoomEquipment> RoomEquipment { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace RoomBookingSystem.Business.Entities
{
    public class Booking
    {
        public string RoomId { get; set; }
        public Room Room { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int RequiredCapacity { get; set; }
        public DateTime BookingCreated { get; set; }
        public string UserId { get; set; }
        [Key]
        public int BookingReference { get; set; }
    }
}

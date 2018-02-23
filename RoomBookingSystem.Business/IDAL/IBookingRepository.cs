using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RoomBookingSystem.Business.Entities;

namespace RoomBookingSystem.Business.IDAL
{
    public interface IBookingRepository
    {
        void CreateBookingAsync(Booking booking);
        Task<ICollection<Booking>> GetAllBookingsForRoom(string id);
    }
}

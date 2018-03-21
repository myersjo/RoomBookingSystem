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
        Task<Booking> GetBooking(int reference);
        Task<ICollection<Booking>> GetAllBookingsForRoom(string id);
        Task<ICollection<Booking>> GetAllBookingsForUser(string id);
        void DeleteBooking(Booking booking);
        void SaveChanges();
    }
}

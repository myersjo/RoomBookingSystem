using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RoomBookingSystem.Business.Entities;

namespace RoomBookingSystem.Business.Bookings
{
    public interface IBookingManager
    {
        /** Create a booking using the details in request and return the booking */
        Task<Booking> CreateBookingAsync(Booking request);
        
        /** Get all bookings for the given user */
        Task<ICollection<Booking>> GetAllBookingsForUser(string userId);
        
        /** Delete booking booking */
        Task<bool> DeleteBooking(int reference);
    }
}

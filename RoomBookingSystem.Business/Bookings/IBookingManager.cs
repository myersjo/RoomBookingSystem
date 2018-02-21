using System;
using System.Collections.Generic;
using System.Text;
using RoomBookingSystem.Business.Entities;

namespace RoomBookingSystem.Business.Bookings
{
    public interface IBookingManager
    {
        /** Create a booking using the details in request and return the booking */
        Booking CreateBooking(Booking request);

        /** Get a booking using the details in booking */
        Booking GetBooking(Booking booking);
        /** Get all bookings for the given user */
        ICollection<Booking> GetAllBookingsForUser(string userId);

        /** Update booking and return the update booking */
        Booking UpdateBooking(Booking booking);

        /** Delete booking and return the booking reference if successful, -1 if not */
        int DeleteBooking(Booking booking);
    }
}

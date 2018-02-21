using System;
using System.Collections.Generic;
using System.Text;
using RoomBookingSystem.Business.IDAL;
using Microsoft.Extensions.Logging;
using RoomBookingSystem.Business.Entities;

namespace RoomBookingSystem.Business.Bookings
{
    /** Business logic for managing bookings */
    public class BookingManager : IBookingManager
    {
        private IBookingRepository _repo;
        private ILogger<BookingManager> _logger;

        public BookingManager(IBookingRepository repo, ILoggerFactory loggerFactory)
        {
            _repo = repo;
            _logger = loggerFactory.CreateLogger<BookingManager>();
        }

        public Booking CreateBooking(Booking request)
        {
            throw new NotImplementedException();
        }

        public Booking GetBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public ICollection<Booking> GetAllBookingsForUser(string userId)
        {
            throw new NotImplementedException();
        }

        public Booking UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public int DeleteBooking(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}

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
        private IBookingRepository _bookingRepo;
        private ILogger<BookingManager> _logger;
        private IRoomRepository _roomRepo;

        public BookingManager(IBookingRepository bookingRepo, 
                                IRoomRepository roomRepo,
                                ILoggerFactory loggerFactory)
        {
            _bookingRepo = bookingRepo;
            _roomRepo = roomRepo;
            _logger = loggerFactory.CreateLogger<BookingManager>();
        }

        public Booking CreateBooking(Booking request)
        {
            // Find a suitable free room
            var rooms = _roomRepo.GetAllRoomsAsync();
            // Generate a booking reference
            // Create booking
            // Send response
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

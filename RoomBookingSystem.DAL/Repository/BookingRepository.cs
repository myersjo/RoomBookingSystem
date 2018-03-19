using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RoomBookingSystem.Business.Entities;
using RoomBookingSystem.Business.IDAL;
using RoomBookingSystem.DAL.Context;

namespace RoomBookingSystem.DAL.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private ApplicationDbContext _context;
        private ILogger<BookingRepository> _logger;

        public BookingRepository(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<BookingRepository>();
        }

        public async void CreateBookingAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        /** Returns all bookings for room id sorted by startTime */
        public async Task<ICollection<Booking>> GetAllBookingsForRoom(string id)
        {
            return await _context.Bookings.Where(x => x.RoomId == id).OrderBy(t => t.StartTime).ToListAsync();
        }

        public async Task<ICollection<Booking>> GetAllBookingsForUser(string id)
        {
            return await _context.Bookings
                .Where(x => x.UserId == id && x.StartTime > DateTime.Now)
                .OrderBy(t => t.StartTime)
                .Include(booking => booking.Room)
                .Include(booking => booking.Room.Location)
                .ToListAsync();
        }
    }
}

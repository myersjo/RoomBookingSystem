using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RoomBookingSystem.Business.Entities;
using RoomBookingSystem.Business.IDAL;
using RoomBookingSystem.DAL.Context;

namespace RoomBookingSystem.DAL.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private ApplicationDbContext _context;
        private ILogger<BookingRepository> _logger;

        public RoomRepository(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<BookingRepository>();
        }

        public async Task<ICollection<Room>> GetAllRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }
    }
}

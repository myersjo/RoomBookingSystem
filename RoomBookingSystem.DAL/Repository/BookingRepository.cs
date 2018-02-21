﻿using System;
using System.Collections.Generic;
using System.Text;
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
    }
}

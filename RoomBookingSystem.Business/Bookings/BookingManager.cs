﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<Booking> CreateBookingAsync(Booking request)
        {
            // Find a suitable free room
            //var rooms = await _roomRepo.GetAllRoomsAsync();
            var rooms = await _roomRepo.GetAllRoomsWithCapacity(request.RequiredCapacity);
            foreach (var room in rooms)
            {
                var bookings = await _bookingRepo.GetAllBookingsForRoom(room.ID);
                if (isRoomFree(request.StartTime, request.EndTime, bookings))
                {
                    request.Room = room;
                    request.RoomId = room.ID;
                    request.Room.Location = await _roomRepo.GetLocationByRoomId(room.ID);
                    break; // free room found
                }
            }
            if (request.RoomId == null)
            {
                // No free room found
                _logger.LogInformation($"No room free from {request.StartTime} to {request.EndTime} ");
                // TODO: Return more detail about why the failure occurred
                return null;
            }
            // Booking reference auto generated by EF/DB when persisted
            // Create booking
            try
            {
                request.BookingCreated = DateTime.Now;
                _bookingRepo.CreateBookingAsync(request);
                _bookingRepo.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            // Send response
            return request;
        }
        
        /** Returns all bookings for the given userId or null if there is an error */
        public async Task<ICollection<Booking>> GetAllBookingsForUser(string userId)
        {
            try
            {
                return await _bookingRepo.GetAllBookingsForUser(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        
        /** Deletes the booking with booking reference reference. Returns true if successful, else false */
        public async Task<bool> DeleteBooking(int reference)
        {
            try
            {
                var booking = await _bookingRepo.GetBooking(reference);
                if (booking == null)
                    return false;
                _bookingRepo.DeleteBooking(booking);
                _bookingRepo.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
            return true;
        }

        #region Helpers

        private bool isRoomFree(DateTime startTime, DateTime endTime, ICollection<Booking> bookings)
        {
            // booking endTime is before startTime or booking startTime is after endTime, move on
            foreach (var booking in bookings)
            {
                // booking starts between requested startTime and endTime
                if (booking.StartTime >= startTime && booking.StartTime < endTime)
                    return false;
                // booking ends between requested startTime and endTime
                else if (booking.EndTime > startTime && booking.EndTime <= endTime)
                    return false;

            }
            return true;
        }
        #endregion

    }
}

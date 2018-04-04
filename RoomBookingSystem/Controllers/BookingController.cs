using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoomBookingSystem.Business.Bookings;
using RoomBookingSystem.Business.Entities;

namespace RoomBookingSystem.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Booking")]
    public class BookingController : Controller
    {
        private IBookingManager _bookingManager;
        private ILogger<BookingController> _logger;

        public BookingController(IBookingManager bookingManager,
                                    ILoggerFactory loggerFactory)
        {
            _bookingManager = bookingManager;
            _logger = loggerFactory.CreateLogger<BookingController>();
        }
        // GET: api/Booking
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var id = User.FindFirst("emails")?.Value;
            if (id == null)
            {
                return Unauthorized();
            }
            var bookings = await _bookingManager.GetAllBookingsForUser(id);
            return Ok(bookings);
        }
        
        // POST: api/Booking
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Booking request)
        {
            request.UserId = User.FindFirst("emails")?.Value;
            var booking = await _bookingManager.CreateBookingAsync(request);
            if (booking == null)
            {
                return new OkObjectResult(new { Status = "notCreated", Reason = "noSuitableFreeRoom" });
            }
            //return Ok();
            return CreatedAtAction("Get", booking);
        }
        
        // DELETE: api/Booking/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var success = await _bookingManager.DeleteBooking(id);
                if (success)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(500);
            }
        }
    }
}

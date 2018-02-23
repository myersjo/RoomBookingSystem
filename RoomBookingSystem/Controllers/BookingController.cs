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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Booking/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Booking
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Booking request)
        {
            var booking = await _bookingManager.CreateBookingAsync(request);
            if (booking == null)
            {
                return 
            }
            //return Ok();
            return CreatedAtAction("Get", new { id = booking.BookingReference }, booking);
        }
        
        // PUT: api/Booking/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

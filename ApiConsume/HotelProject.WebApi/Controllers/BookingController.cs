using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
         private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            _bookingService.TInsert(booking);
            return Ok("Add a Booking");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            _bookingService.TDelete(values);
            return Ok("Delete a Booking");

        }

        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok("Update a Booking");
        }

        [HttpGet("{id}")]
        public IActionResult GetBookingById(int id)
        {
            var values = _bookingService.TGetById(id);
            return Ok(values);
        }
        [HttpPut("BookingStatusChangeApproved")]
        public IActionResult BookingStatusChangeApproved(Booking booking)
        {
            _bookingService.TBookingStatusChangeApproved(booking);
            return Ok("Booking Status Change Approved");
        }
        [HttpPut("BookingStatusChangeApproved2")]
        public IActionResult BookingStatusChangeApproved2(int id)
        {
            _bookingService.TBookingStatusChangeApproved2(id);
            return Ok("Booking Status Change Approved");
        }

    }
}

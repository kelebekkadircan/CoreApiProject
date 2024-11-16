using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            _contactService.TInsert(contact);
            return Ok("Add a Contact");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var values = _contactService.TGetById(id);
            _contactService.TDelete(values);
            return Ok("Delete a Contact");

        }

        [HttpPut("UpdateContact")]
        public IActionResult UpdateContact(Contact contact)
        {
            _contactService.TUpdate(contact);
            return Ok("Update a Contact");
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var values = _contactService.TGetById(id);
            return Ok(values);
        }
        //[HttpPut("BookingStatusChangeApproved")]
        //public IActionResult BookingStatusChangeApproved(Booking booking)
        //{
        //    _contactService.TBookingStatusChangeApproved(booking);
        //    return Ok("Booking Status Change Approved");
        //}
        //[HttpPut("BookingStatusChangeApproved2")]
        //public IActionResult BookingStatusChangeApproved2(int id)
        //{
        //    _contactService.TBookingStatusChangeApproved2(id);
        //    return Ok("Booking Status Change Approved");
        //}

    }
}

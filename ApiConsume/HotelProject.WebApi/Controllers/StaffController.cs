using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }


        [HttpGet]
        public IActionResult StaffList()
        {
            var values = _staffService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddStaff(Staff staff)
        {
            _staffService.TInsert(staff);
            return Ok("Add a Staff");
        }
        [HttpDelete]
        public IActionResult DeleteStaff(int id)
        {
            var values = _staffService.TGetById(id);
            _staffService.TDelete(values);
            return Ok("Delete a Staff");

        }

        [HttpPut]
        public IActionResult UpdateStaff(Staff staff)
        {
            _staffService.TUpdate(staff);
            return Ok("Update a Staff");
        }

        [HttpGet("{id}")]
        public IActionResult GetStaffById(int id)
        {
            var values   = _staffService.TGetById(id);
            return Ok(values);
        }



    }
}

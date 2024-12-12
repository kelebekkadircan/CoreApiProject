using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly ILogger<StaffController> _logger;


        public StaffController(IStaffService staffService, ILogger<StaffController> logger)
        {
            _staffService = staffService;
            _logger = logger;

        }


        [HttpGet]
        public IActionResult StaffList()
        {
            _logger.LogTrace("LogTrace => Staff Sayfasına Giriş Yapıldı");
            _logger.LogDebug("LogTrace => Staff Sayfasına Giriş Yapıldı");
            _logger.LogInformation("LogTrace => Staff Sayfasına Giriş Yapıldı");
            _logger.LogWarning("LogTrace => Staff Sayfasına Giriş Yapıldı");
            _logger.LogError("LogTrace => Staff Sayfasına Giriş Yapıldı");

            var values = _staffService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddStaff(Staff staff)
        {
            _staffService.TInsert(staff);
            return Ok("Add a Staff");
        }
        [HttpDelete("{id}")]
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

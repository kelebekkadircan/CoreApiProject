using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _ServiceService;

        public ServiceController(IServiceService ServiceService)
        {
            _ServiceService = ServiceService;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _ServiceService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddService(Service Service)
        {
            _ServiceService.TInsert(Service);
            return Ok("Add a Service");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var values = _ServiceService.TGetById(id);
            _ServiceService.TDelete(values);
            return Ok("Delete a Service");

        }

        [HttpPut]
        public IActionResult UpdateService(Service Service)
        {
            _ServiceService.TUpdate(Service);
            return Ok("Update a Service");
        }

        [HttpGet("{id}")]
        public IActionResult GetServiceById(int id)
        {
            var values = _ServiceService.TGetById(id);
            return Ok(values);
        }

    }
}

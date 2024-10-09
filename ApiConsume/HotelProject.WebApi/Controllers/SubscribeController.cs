using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _SubscribeService;

        public SubscribeController(ISubscribeService SubscribeService)
        {
            _SubscribeService = SubscribeService;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _SubscribeService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddSubscribe(Subscribe Subscribe)
        {
            _SubscribeService.TInsert(Subscribe);
            return Ok("Add a Subscribe");
        }
        [HttpDelete]
        public IActionResult DeleteSubscribe(int id)
        {
            var values = _SubscribeService.TGetById(id);
            _SubscribeService.TDelete(values);
            return Ok("Delete a Subscribe");

        }

        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe Subscribe)
        {
            _SubscribeService.TUpdate(Subscribe);
            return Ok("Update a Subscribe");
        }

        [HttpGet("{id}")]
        public IActionResult GetSubscribeById(int id)
        {
            var values = _SubscribeService.TGetById(id);
            return Ok(values);
        }

    }
}

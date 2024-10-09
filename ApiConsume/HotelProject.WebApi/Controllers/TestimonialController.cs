using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _TestimonialService;

        public TestimonialController(ITestimonialService TestimonialService)
        {
            _TestimonialService = TestimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _TestimonialService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddTestimonial(Testimonial Testimonial)
        {
            _TestimonialService.TInsert(Testimonial);
            return Ok("Add a Testimonial");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _TestimonialService.TGetById(id);
            _TestimonialService.TDelete(values);
            return Ok("Delete a Testimonial");

        }

        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial Testimonial)
        {
            _TestimonialService.TUpdate(Testimonial);
            return Ok("Update a Testimonial");
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonialById(int id)
        {
            var values = _TestimonialService.TGetById(id);
            return Ok(values);
        }

    }
}

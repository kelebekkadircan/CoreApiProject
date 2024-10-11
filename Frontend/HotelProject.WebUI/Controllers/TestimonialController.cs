using HotelProject.WebUI.Models.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class TestimonialController : Controller
    {


        private readonly IHttpClientFactory _clientFactory;

        public TestimonialController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }



        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:27029/api/Testimonial");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<TestimonialViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]

        public IActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddTestimonial(AddTestimonialViewModel addTestimonialViewModel)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(addTestimonialViewModel);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:27029/api/Testimonial", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:27029/api/Testimonial/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:27029/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTestimonialViewModel>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialViewModel updateViewModel)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateViewModel);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:27029/api/Testimonial", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }



    }
}

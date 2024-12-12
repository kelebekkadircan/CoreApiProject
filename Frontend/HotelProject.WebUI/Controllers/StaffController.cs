using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public StaffController(IHttpClientFactory clientFactory , ILogger<StaffController> logger)
        {
            _clientFactory = clientFactory;

        }



        public async Task<IActionResult> Index()
        {
        



            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:27029/api/Staff");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<StafViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]

        public IActionResult AddStaff()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddStaff(AddStaffViewModel addStaffViewModel)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(addStaffViewModel);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:27029/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:27029/api/Staff/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:27029/api/Staff/{id}");
            if ( responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel updateViewModel)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateViewModel);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:27029/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}

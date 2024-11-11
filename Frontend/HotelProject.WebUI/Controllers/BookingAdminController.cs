using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {

        private readonly IHttpClientFactory _clientFactory;

        public BookingAdminController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:27029/api/Booking");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> ApprovedReservation(ApprovedBookingDto approvedBookingDto)
        {

            approvedBookingDto.Status = "Onaylandı";
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(approvedBookingDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:27029/api/Booking/BookingStatusChangeApproved", content);
            if (response.IsSuccessStatusCode) {
                return RedirectToAction("Index" , "Default");
            }


            return View();
        }


    }
}

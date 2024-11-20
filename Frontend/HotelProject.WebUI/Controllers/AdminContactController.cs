using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public AdminContactController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {




            var client2 = _clientFactory.CreateClient();
            var response2 = await client2.GetAsync("http://localhost:27029/api/Contact/GetContactCount");
            if (response2.IsSuccessStatusCode)
            {
                var jsonData2 = await response2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<int>(jsonData2);
                ViewBag.a = values2;
            }

            var client3 = _clientFactory.CreateClient();
            var response3 = await client3.GetAsync("http://localhost:27029/api/SendMessage/SendMessageCount");
            if (response3.IsSuccessStatusCode)
            {
                var jsonData3 = await response2.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<int>(jsonData3);
                ViewBag.b = values3;
            }

            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:27029/api/Contact");


            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(values);
            }

            return View();



            
        }
        public async Task<IActionResult> SendBox()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:27029/api/SendMessage");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendMessageDto>>(jsonData);
                return View(values);
            }
            return View();

        }




        [HttpGet]

        public IActionResult AddSendMessage()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto createSendMessageDto)
        {
            createSendMessageDto.Date = DateTime.Now;
            createSendMessageDto.SenderMail = "admin@gmail.com";
            createSendMessageDto.SenderName="Admin";
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSendMessageDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:27029/api/SendMessage", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","AdminContact");
            }
            return View();

        }


        public PartialViewResult SideBarAdminContactPartial()
        {
            return PartialView();
        }
        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> MessageDetails(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:27029/api/Contact/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultContactDto>(jsonData);
                return View(values);
            }


            return View();
        }
        public async Task<IActionResult> SendMessageDetails(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:27029/api/SendMessage/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultSendMessageDto>(jsonData);
                return View(values);
            }


            return View();
        }


        


    }
}

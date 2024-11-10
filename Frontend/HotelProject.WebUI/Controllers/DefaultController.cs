﻿using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class DefaultController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public  PartialViewResult _SubscribePartial()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> _SubscribePartial(CreateSubscribeDto createSubscribeDto)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createSubscribeDto);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                await client.PostAsync("http://localhost:27029/api/Subscribe", content);
                
                RedirectToAction("Index","Default");
                
            }

            return View();
        }
    
    }
}

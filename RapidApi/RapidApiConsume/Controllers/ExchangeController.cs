using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using RapidApiConsume.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;


namespace RapidApiConsume.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ExchangeRateViewModel> exchangeRateViewModels = new List<ExchangeRateViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?locale=en-gb&currency=TRY"),
                Headers =
    {
        { "x-rapidapi-key", "21b0ac46ffmsh090a0d3b37e5142p1cb984jsnd310a0908030" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var rates = JsonConvert.DeserializeObject<ExchangeRateViewModel>(body);
                return View(rates.exchange_rates.ToList());
            }

        }
    } 
}

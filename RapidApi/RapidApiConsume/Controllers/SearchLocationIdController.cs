using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using RapidApiConsume.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIdController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {       
                if(!string.IsNullOrEmpty(cityName))
                {
                    List<BookingApiLocationSearchViewModel> locationSearch = new List<BookingApiLocationSearchViewModel>();
                    var client = new HttpClient();
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={cityName}"),
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
                        locationSearch = JsonConvert.DeserializeObject<List<BookingApiLocationSearchViewModel>>(body);
                        return View(locationSearch.Take(1).ToList());


                    }
                }
                else
                {
                List<BookingApiLocationSearchViewModel> locationSearch = new List<BookingApiLocationSearchViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name=Berlin"),
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
                    locationSearch = JsonConvert.DeserializeObject<List<BookingApiLocationSearchViewModel>>(body);
                    return View(locationSearch.Take(1).ToList());


                }
            }
            
                   
        }
    }
}

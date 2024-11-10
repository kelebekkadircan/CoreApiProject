using HotelProject.WebUI.Dtos.AboutDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _AboutUsPartial : ViewComponent
    {

        private readonly IHttpClientFactory _clientFactory;

        public _AboutUsPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:27029/api/About");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }

            return View();
        }

    }
}

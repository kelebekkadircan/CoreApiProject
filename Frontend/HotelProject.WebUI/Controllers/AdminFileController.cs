using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminFileController : Controller
    {

        //private readonly IHttpClientFactory _clientFactory;

        //public AdminFileController(IHttpClientFactory clientFactory)
        //{
        //    _clientFactory = clientFactory;
        //}


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile formFile)
        {
            var stream = new MemoryStream();
            await formFile.CopyToAsync(stream);
            var bytes = stream.ToArray();   


            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(formFile.ContentType);
            MultipartFormDataContent multiContent = new MultipartFormDataContent();
            multiContent.Add(byteArrayContent, "file", formFile.FileName);
            var client = new HttpClient();
            var response = await client.PostAsync("http://localhost:27029/api/FileImage", multiContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","AdminContact");
            }
            else
            {
                return View();
            }



        }
    }
}

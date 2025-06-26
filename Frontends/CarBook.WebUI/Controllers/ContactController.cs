using CarBook.Dto.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "İletişim";
            ViewBag.v2 = "Bize Yazın";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            createContactDto.SendDate = DateTime.Now;
            var jsondata = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7279/api/Contacts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

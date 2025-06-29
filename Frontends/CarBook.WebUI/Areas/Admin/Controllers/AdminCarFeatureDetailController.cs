using CarBook.Dto.CarFeatureDtos;
using CarBook.Dto.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index/{id}")]
        public async Task<IActionResult> AdminCarDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7279/api/CarFeature/GetCarFeaturesByCarID?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureDto> resultCarFeatureDtos)
        {
            foreach (var item in resultCarFeatureDtos)
            {
                if (item.Available)
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync($"https://localhost:7279/api/CarFeature/CarFeatureChangeAvailableToTrue?id={item.CarFeatureID}");

                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync($"https://localhost:7279/api/CarFeature/CarFeatureChangeAvailableToFalse?id={item.CarFeatureID}");
                }
            }
            return RedirectToAction("Index", "AdminCar");
        }
    }
}
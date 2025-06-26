using CarBook.Dto.BannerDtos;
using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7279/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int v1 = random.Next(0, 101);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.CarCount = values.CarCount;
                ViewBag.Percent = v1;
            }

            var responseMessage2 = await client.GetAsync("https://localhost:7279/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                int v2 = random.Next(0, 101);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.LocationCount = values2.LocationCount;
                ViewBag.Percent2 = v2;
            }

            var responseMessage3 = await client.GetAsync("https://localhost:7279/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                int v3 = random.Next(0, 101);
                var jsonData3 = await responseMessage2.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.AuthorCount = values3.AuthorCount;
                ViewBag.Percent3 = v3;
            }

            var responseMessage4 = await client.GetAsync("https://localhost:7279/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int v4 = random.Next(0, 101);
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.BlogCount = values4.BlogCount;
                ViewBag.Percent4 = v4;
            }

            var responseMessage5 = await client.GetAsync("https://localhost:7279/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                int v5 = random.Next(0, 101);
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.BrandCount = values5.BrandCount;
                ViewBag.Percent5 = v5;

            }

            var responseMessage6 = await client.GetAsync("https://localhost:7279/GetAvgRentPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                int v6 = random.Next(0, 101);
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
                ViewBag.AvgRentPriceForDaily = values6.AvgRentPriceForDaily.ToString("0.00");
                ViewBag.Percent6 = v6;

            }

            var responseMessage7 = await client.GetAsync("https://localhost:7279/GetAvgRentPriceForWeekly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                int v7 = random.Next(0, 101);
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
                ViewBag.AvgRentPriceForWeekly = values7.AvgRentPriceForWeekly.ToString("0.00");
                ViewBag.Percent7 = v7;
            }

            var responseMessage8 = await client.GetAsync("https://localhost:7279/GetAvgRentPriceForMonthly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                int v8 = random.Next(0, 101);
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
                ViewBag.AvgRentPriceForMonthly = values8.AvgRentPriceForMonthly.ToString("0.00");
                ViewBag.Percent8 = v8;
            }

            var responseMessage9 = await client.GetAsync("https://localhost:7279/GetCarCountByTransmissionIsAuto");
            if (responseMessage9.IsSuccessStatusCode)
            {
                int v9 = random.Next(0, 101);
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
                ViewBag.CarCountByTransmissionIsAuto = values9.CarCountByTransmissionIsAuto;
                ViewBag.Percent9 = v9;
            }

            var responseMessage10 = await client.GetAsync("https://localhost:7279/GetBrandNameByMaxCar");
            if (responseMessage10.IsSuccessStatusCode)
            {
                int v10 = random.Next(0, 101);
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                var values10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);
                ViewBag.BrandNameByMaxCar = values10.BrandNameByMaxCar;
                ViewBag.Percent10 = v10;

            }

            var responseMessage11 = await client.GetAsync("https://localhost:7279/GetBlogTitleByMaxBlogComment");
            if (responseMessage11.IsSuccessStatusCode)
            {
                int v11 = random.Next(0, 101);
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
                var values11 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);
                ViewBag.BlogTitleByMaxBlogComment = values11.BlogTitleByMaxBlogComment;
                ViewBag.Percent11 = v11;
            }

            var responseMessage12 = await client.GetAsync("https://localhost:7279/GetCarCountByKmSmallerThen1000");
            if (responseMessage12.IsSuccessStatusCode)
            {
                int v12 = random.Next(0, 101);
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var values12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);
                ViewBag.CarCountByKmSmallerThen1000 = values12.CarCountByKmSmallerThen1000;
                ViewBag.Percent12 = v12;
            }

            var responseMessage13 = await client.GetAsync("https://localhost:7279/GetCarCountByFuelGasolineOrDiesel");
            if (responseMessage13.IsSuccessStatusCode)
            {
                int v13 = random.Next(0, 101);
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var values13 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData13);
                ViewBag.CarCountByFuelGasolineOrDiesel = values13.CarCountByFuelGasolineOrDiesel;
                ViewBag.Percent13 = v13;
            }

            var responseMessage14 = await client.GetAsync("https://localhost:7279/GetCarCountByFuelElectric");
            if (responseMessage14.IsSuccessStatusCode)
            {
                int v14 = random.Next(0, 101);
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var values14 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData14);
                ViewBag.CarCountByFuelElectric = values14.CarCountByFuelElectric;
                ViewBag.Percent14 = v14;
            }

            var responseMessage15 = await client.GetAsync("https://localhost:7279/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseMessage15.IsSuccessStatusCode)
            {
                int v15 = random.Next(0, 101);
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                var values15 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData15);
                ViewBag.CarBrandAndModelByRentPriceDailyMax = values15.CarBrandAndModelByRentPriceDailyMax;
                ViewBag.Percent15 = v15;
            }

            var responseMessage16 = await client.GetAsync("https://localhost:7279/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseMessage16.IsSuccessStatusCode)
            {
                int v16 = random.Next(0, 101);
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
                var values16 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData16);
                ViewBag.CarBrandAndModelByRentPriceDailyMin = values16.CarBrandAndModelByRentPriceDailyMin;
                ViewBag.Percent16 = v16;
            }

            return View();
        }
    }
}

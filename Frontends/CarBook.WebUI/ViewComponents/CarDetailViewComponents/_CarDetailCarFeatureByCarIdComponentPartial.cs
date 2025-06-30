using CarBook.Dto.CarFeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UdemyCarBook.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailCarFeatureByCarIdComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _CarDetailCarFeatureByCarIdComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.carid = id;
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7279/api/CarFeature/GetCarFeaturesByCarID?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarFeatureDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}

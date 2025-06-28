using CarBook.Dto.BlogDtos;
using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsMainComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesssage = await client.GetAsync($"https://localhost:7279/api/Blogs/{id}");
            if (responseMesssage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesssage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetBlogByIdDto>(jsonData);

                var responseMesssage2 = await client.GetAsync($"https://localhost:7279/api/Comments/GetCountCommentsByBlog?id={id}");
                if (responseMesssage2.IsSuccessStatusCode)
                {
                    var jsonData2 = await responseMesssage2.Content.ReadAsStringAsync();
                    var values2 = JsonConvert.DeserializeObject<GetCountCommentsByBlogDto>(jsonData2);
                    ViewBag.CommentCount = values2.CountCommentsByBlog;
                }

                return View(values);
            }

            
            return View();
        }
    }
}

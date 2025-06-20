using CarBook.Dto.ServiceDtos;
using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class ServicesController : Controller
    {

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AdminUILayoutViewComponents
{
    public class _NavbarAdminUILayoutViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

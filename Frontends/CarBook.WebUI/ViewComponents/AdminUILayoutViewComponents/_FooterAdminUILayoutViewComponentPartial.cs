using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AdminUILayoutViewComponents
{
    public class _FooterAdminUILayoutViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

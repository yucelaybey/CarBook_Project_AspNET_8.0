using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AdminUILayoutViewComponents
{
    public class _HeadAdminUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

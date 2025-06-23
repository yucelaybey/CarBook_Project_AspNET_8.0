using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AdminUILayoutViewComponents
{
    public class _SidebarAdminUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

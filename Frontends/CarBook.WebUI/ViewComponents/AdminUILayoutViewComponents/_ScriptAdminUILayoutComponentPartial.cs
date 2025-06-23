using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AdminUILayoutViewComponents
{
    public class _ScriptAdminUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

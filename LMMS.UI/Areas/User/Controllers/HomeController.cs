using Microsoft.AspNetCore.Mvc;

namespace LMMS.UI.Areas.User.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

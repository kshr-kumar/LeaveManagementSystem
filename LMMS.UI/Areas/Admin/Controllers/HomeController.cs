﻿using Microsoft.AspNetCore.Mvc;

namespace LMMS.UI.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}

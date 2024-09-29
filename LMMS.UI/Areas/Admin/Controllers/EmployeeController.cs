using LMMS.Services.Interfaces;
using LMMS.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LMMS.UI.Areas.Admin.Controllers
{
    public class EmployeeController : BaseController
    {
        IEmpService _empService;
        IAuthService _authService;
        public EmployeeController(IEmpService empService, IAuthService authService)
        {
            _empService = empService;
            _authService = authService;
        }
        public IActionResult Index()
        {
            var emp = _empService.GetUsers();
            return View(emp);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Core.Entities.User

                {
                    Name = model.Name,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Password = model.Password,
                    CreatedDate = DateTime.Now

                };

                var isCreated = _authService.CreateUser(user, "User");
                if (isCreated)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "Error Not Created");
            }
            return View();
        }


    }
}

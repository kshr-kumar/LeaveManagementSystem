using LMMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LMMS.UI.Areas.Admin.Controllers
{
    public class EmpLeaveController : BaseController
    {
        IEmpLeaveService _empLeaveService;
        public EmpLeaveController(IEmpLeaveService empLeaveService)
        {
            _empLeaveService = empLeaveService;
        }
        public IActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            var emp = _empLeaveService.GetEmpLeave();
            if (startDate.HasValue && endDate.HasValue)
            {
                var start = DateOnly.FromDateTime(startDate.Value);
                var end = DateOnly.FromDateTime(endDate.Value);

                emp = emp.Where(l => l.LeaveStartDate >= start && l.LeaveStartDate <= end).ToList();
            }
            return View(emp);
        }
    }
}

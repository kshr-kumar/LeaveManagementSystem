using LMMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LMMS.UI.Areas.Admin.Controllers
{
    public class LeaveTypeController : BaseController
    {
        ILeaveTypeService _leaveTypeService;
        public LeaveTypeController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }
        public IActionResult Index()
        {
            var leave = _leaveTypeService.GetLeaveTypes();
            return View(leave);
        }
    }
}

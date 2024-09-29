using LMMS.Core.Entities;
using LMMS.Services.Interfaces;
using LMMS.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMMS.UI.Areas.User.Controllers
{
    public class ApplyLeaveController : BaseController
    {
        IAplyLeavService _aplyLeavService;
        ILeaveTypeService _LeaveTypeService;
        IEmpLeaveBalanceService _empLeaveBalanceService;
    
        public ApplyLeaveController(IAplyLeavService aplyLeavService , ILeaveTypeService LeaveTypeService, IEmpLeaveBalanceService empLeaveBalanceService)
        {
            _LeaveTypeService = LeaveTypeService;
            _aplyLeavService = aplyLeavService;
            _empLeaveBalanceService = empLeaveBalanceService;
            
        }
        public IActionResult Index()
        {
               
            return View();
        }

        public IActionResult pendingLeave()
        {
            var currentUserId = CurrentUser.Id;
            var leave = _empLeaveBalanceService.GetAvailableBalance()
                .Where(u => u.Id == currentUserId);

            return View(leave);
        }


        public IActionResult Leave()
        {
            ViewBag.LeaveTypes = _LeaveTypeService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Leave(ApplyLeaveViewModel model)
        {
            ModelState.Remove("EmployeeLeaveId");
            ModelState.Remove("LeaveTypeName");
            ModelState.Remove("Name");

            var startDate = model.LeaveStartDate.ToDateTime(TimeOnly.MinValue);
            var endDate = model.LeaveEndDate.ToDateTime(TimeOnly.MinValue);
            var diff = (endDate - startDate).TotalDays;

            if (endDate < startDate)
            {
                TempData["ErrorMessage"] = "End date must be greater than or equal to start date.";
                return RedirectToAction("Leave");
            }

            var currentUserId = CurrentUser.Id;
            var leavebalance = _empLeaveBalanceService.GetAvailableBalance()
                .Where(u => u.Id == currentUserId && u.LeaveTypeId == model.LeaveTypeId)
                .Select(l=>l.AvailableDays)
                .FirstOrDefault();

            if (diff > leavebalance)
            {
                TempData["leavebalance"] = "You do not have enough leave balance to apply for the requested days.";
                return RedirectToAction("Leave");
            }



            if (ModelState.IsValid)
            {
                if (endDate >= startDate)
                {
                    EmployeeLeaf emp = new EmployeeLeaf
                    {
                        Id = CurrentUser.Id,
                        LeaveTypeId = model.LeaveTypeId,
                        LeaveStartDate = model.LeaveStartDate,
                        LeaveEndDate = model.LeaveEndDate,
                        DaysTaken = diff > 0 ? (int)diff : 1                        
                    };

                    var isCreated = _aplyLeavService.ApplyLeave(emp);
                    if (isCreated)
                    {
                        TempData["Success"] = "Success";
                        return RedirectToAction("Leave");
                    }
                       
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

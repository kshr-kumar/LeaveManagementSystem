using LMMS.Core.Entities;
using LMMS.Models;
using LMMS.Repositories.Interfaces;
using LMMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMMS.Services.Implementation
{
    
    public class EmpLeaveBalanceService : Service<EmployeeLeaveBalance> , IEmpLeaveBalanceService
    {

        private readonly IRepository<EmployeeLeaveBalance> _empLeaveBalRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<LeaveType> _leaveTypeRepo;
        public EmpLeaveBalanceService(IRepository<EmployeeLeaveBalance> empLeaveBalRepo, IRepository<User> userRepo, IRepository<LeaveType> leaveTypeRepo) : base(empLeaveBalRepo)
        {
            _empLeaveBalRepo = empLeaveBalRepo;
            _userRepo = userRepo;
            _leaveTypeRepo = leaveTypeRepo;
        }

        public IEnumerable<EmpLeaveBalanceModel> GetAvailableBalance()
        {
            var data = (from el in _empLeaveBalRepo.GetAll()
                        join lt in _leaveTypeRepo.GetAll()
                        on el.LeaveTypeId equals lt.LeaveTypeId
                        join us in _userRepo.GetAll()
                        on el.Id equals us.Id
                        select new EmpLeaveBalanceModel
                        {
                            EmployeeLeaveBalanceId = el.EmployeeLeaveBalanceId,
                            Id = us.Id,
                            Name = us.Name ?? "Unknown",
                            LeaveTypeId = lt.LeaveTypeId,
                            LeaveTypeName = lt.LeaveTypeName ?? "N/A",
                            AvailableDays = el.AvailableDays
                        }).ToList();
            return data;
        }

        
    }
}

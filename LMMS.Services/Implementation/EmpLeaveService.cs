using LMMS.Core.Entities;
using LMMS.Models;
using LMMS.Repositories.Interfaces;
using LMMS.Services.Interfaces;



namespace LMMS.Services.Implementation
{
    public class EmpLeaveService : Service<EmployeeLeaf>, IEmpLeaveService
    {
        private readonly IRepository<EmployeeLeaf> _empLeaveRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<LeaveType> _leaveTypeRepo;
        public EmpLeaveService(IRepository<EmployeeLeaf> empLeaveRepo, IRepository<User> userRepo, IRepository<LeaveType> leaveTypeRepo)
            : base(empLeaveRepo)
        {
            _empLeaveRepo = empLeaveRepo;
            _userRepo = userRepo;
            _leaveTypeRepo = leaveTypeRepo; 
        }
        public IEnumerable<EmpLeaveModel> GetEmpLeave()
        {

            var emp = (from el in _empLeaveRepo.GetAll()
                       join lt in _leaveTypeRepo.GetAll()
                       on el.LeaveTypeId equals lt.LeaveTypeId
                       join us in _userRepo.GetAll()
                       on el.Id equals us.Id
                       select new EmpLeaveModel
                       {
                           EmployeeLeaveId = el.EmployeeLeaveId,
                           Id = us.Id,
                           Name = us.Name ?? "Unknown",
                           LeaveTypeId = lt.LeaveTypeId,
                           LeaveTypeName = lt.LeaveTypeName ?? "N/A",
                           LeaveStartDate = el.LeaveStartDate,
                           LeaveEndDate = el.LeaveEndDate,
                           DaysTaken = el.DaysTaken
                       })
                       .OrderByDescending(el => el.LeaveStartDate)
                       .ToList();


            return emp;
        }
    }
}

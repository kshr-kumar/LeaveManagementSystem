using LMMS.Core.Entities;
using LMMS.Repositories.Interfaces;
using LMMS.Services.Interfaces;


namespace LMMS.Services.Implementation
{
    public class AplyLeavService : Service<EmployeeLeaf>, IAplyLeavService
    {
        private readonly IEmpLeaveRepository _leaveRepo;
        public AplyLeavService(IEmpLeaveRepository repo) : base(repo)
        {
            _leaveRepo = repo;
           
        }

        public bool ApplyLeave(EmployeeLeaf emp)
        {
            return _leaveRepo.ApplyLeave(emp);
        }
    }
}

using LMMS.Core.Entities;
using LMMS.Services.Interfaces;
using LMMS.Repositories.Interfaces;
using LMMS.Models;

namespace LMMS.Services.Implementation
{
    public class LeaveTypeService : Service<LeaveType> ,  ILeaveTypeService
    {
        IRepository<LeaveType> _leavetypeRepo;
        public LeaveTypeService(IRepository<LeaveType> leavetypeRepo) : base(leavetypeRepo)
        {
            _leavetypeRepo = leavetypeRepo;
        }

        public IEnumerable<LeaveTypeModel> GetLeaveTypes()
        {
            var data = _leavetypeRepo.GetAll().Select(p => new LeaveTypeModel
            {
                LeaveTypeId = p.LeaveTypeId,
                LeaveTypeName = p.LeaveTypeName,
                MaxDaysPerYear = p.MaxDaysPerYear

            });
            return data;
        }


    }
}

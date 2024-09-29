using LMMS.Core.Entities;
using LMMS.Models;

namespace LMMS.Services.Interfaces
{
    public interface ILeaveTypeService : IService<LeaveType>
    {
        public IEnumerable<LeaveTypeModel> GetLeaveTypes();


    }
}

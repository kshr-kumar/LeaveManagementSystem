using LMMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMMS.Repositories.Interfaces
{
    public interface IEmpLeaveRepository : IRepository<EmployeeLeaf>
    {
        bool ApplyLeave(EmployeeLeaf emp);
    }
}

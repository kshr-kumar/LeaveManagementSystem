using LMMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMMS.Services.Interfaces
{
    public interface IAplyLeavService : IService<EmployeeLeaf>
    {
        bool ApplyLeave(EmployeeLeaf emp);
    }
}

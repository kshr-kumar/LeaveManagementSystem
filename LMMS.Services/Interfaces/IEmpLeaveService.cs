using LMMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMMS.Services.Interfaces
{
    public interface IEmpLeaveService
    {
        public IEnumerable<EmpLeaveModel> GetEmpLeave();
    }
}

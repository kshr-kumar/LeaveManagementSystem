using LMMS.Core.Entities;
using LMMS.Models;

namespace LMMS.Services.Interfaces
{
    public interface IEmpService: IService<User>
    {
        public IEnumerable<UserModel> GetUsers(); 

    }
}

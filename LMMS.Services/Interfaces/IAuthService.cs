using LMMS.Core.Entities;
using LMMS.Models;

namespace LMMS.Services.Interfaces
{
    public interface IAuthService : IService<User>
    {
        bool CreateUser(User user, string Role);
        UserModel ValidateUser(string email, string password);
    }
}

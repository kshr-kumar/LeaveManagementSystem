using LMMS.Core.Entities;
using LMMS.Models;

namespace LMMS.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        bool CreateUser(User user, string Role);

        UserModel validateUser(string Email, string password);

    }
}

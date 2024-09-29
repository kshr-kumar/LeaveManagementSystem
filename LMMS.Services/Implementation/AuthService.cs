using LMMS.Core.Entities;
using LMMS.Models;
using LMMS.Repositories.Interfaces;
using LMMS.Services.Interfaces;

namespace LMMS.Services.Implementation
{
    public class AuthService : Service<User>, IAuthService
    {
        IUserRepository _userRepo;
        public AuthService(IUserRepository repository) : base(repository)
        {
            _userRepo = repository;
        }
        public bool CreateUser(User user, string Role)
        {
            return _userRepo.CreateUser(user, Role);
        }

        public UserModel ValidateUser(string email, string password)
        {
            return _userRepo.validateUser(email, password);
        }
    }
}

using LMMS.Core.Entities;
using LMMS.Models;
using LMMS.Repositories.Interfaces;
using LMMS.Services.Interfaces;


namespace LMMS.Services.Implementation
{
    public class EmpService : Service<User>, IEmpService
    {
        IRepository<User> _empRepository;
        public EmpService(IRepository<User> empRepository) : base(empRepository)
        {
            _empRepository = empRepository;
            
        }
        public IEnumerable<UserModel> GetUsers()
        {
            var data = _empRepository.GetAll().Select(p => new UserModel
            {
                Id = p.Id,
                Email = p.Email,
                Name = p.Name,
                PhoneNumber = p.PhoneNumber
            });
            return data;

        }



    }
}

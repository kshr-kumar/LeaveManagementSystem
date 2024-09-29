using LMMS.Core;
using LMMS.Core.Entities;
using LMMS.Repositories.Interfaces;


namespace LMMS.Repositories.Implementation
{
    public class EmpLeaveRepository : Repository<EmployeeLeaf>, IEmpLeaveRepository
    {

        public EmpLeaveRepository(AppDbContext db) : base(db)
        {
            
        }
        public bool ApplyLeave(EmployeeLeaf emp)
        {
            try
            {
                if (emp != null)
                {

                    _db.EmployeeLeaves.Add(emp);
                    _db.SaveChanges();
                    return true;

                }
            }
            catch(Exception ex)
            {

            }
            return false;

        }
    }
}

using LMMS.Core;
using LMMS.Core.Entities;
using LMMS.Repositories.Implementation;
using LMMS.Repositories.Interfaces;
using LMMS.Services.Implementation;
using LMMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LMMS.Services
{
    public static class ConfigureDependencies
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //database connection
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DbConnection")));


            //repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<LeaveType>, Repository<LeaveType>>();
            services.AddScoped<IRepository<EmployeeLeaf>, Repository<EmployeeLeaf>>();
            services.AddScoped<IEmpLeaveRepository, EmpLeaveRepository>();
            services.AddScoped<IRepository<EmployeeLeaveBalance>, Repository<EmployeeLeaveBalance>>();


            //services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmpService, EmpService>();
            services.AddScoped<ILeaveTypeService, LeaveTypeService>();
            services.AddScoped<IEmpLeaveService, EmpLeaveService>();
            services.AddScoped<IAplyLeavService, AplyLeavService>();
            services.AddScoped<IEmpLeaveBalanceService, EmpLeaveBalanceService>();

        }
    }
}

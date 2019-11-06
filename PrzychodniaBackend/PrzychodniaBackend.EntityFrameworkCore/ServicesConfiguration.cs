using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrzychodniaBackend.EntityFrameworkCore.Repositories.PatientRepo;
using PrzychodniaBackend.EntityFrameworkCore.Repositories.UserRepo;

namespace PrzychodniaBackend.EntityFrameworkCore
{
    public static class ServicesConfiguration
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddDbContext<AppContext>(options =>
                options.UseSqlServer("Server=localhost;Database=PrzychodniaDB;Trusted_Connection=True;"));
        }
    }
}
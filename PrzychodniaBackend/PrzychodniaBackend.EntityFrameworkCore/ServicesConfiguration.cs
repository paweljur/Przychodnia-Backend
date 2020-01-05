using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrzychodniaBackend.EntityFrameworkCore.Repositories;
using PrzychodniaBackend.EntityFrameworkCore.Repositories.Interfaces;

namespace PrzychodniaBackend.EntityFrameworkCore
{
    public static class ServicesConfiguration
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IVisitRepository, VisitRepository>();
            services.AddScoped<ILabTestOrderRepository, LabTestOrderRepository>();
            services.AddScoped<ILabTestResultRepository, LabTestResultRepository>();
            services.AddDbContext<AppContext>(options =>
                options.UseSqlServer("Server=localhost;Database=PrzychodniaDB;Trusted_Connection=True;"));
        }
    }
}
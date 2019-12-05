using Microsoft.Extensions.DependencyInjection;
using PrzychodniaBackend.Application.DoctorService;
using PrzychodniaBackend.Application.Laboratory;
using PrzychodniaBackend.Application.RegistrationService;
using PrzychodniaBackend.Application.UserService;
using PrzychodniaBackend.EntityFrameworkCore;

namespace PrzychodniaBackend.Application
{
    public static class ServicesConfiguration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService.UserService>();
            services.AddScoped<IRegistrationService, RegistrationService.RegistrationService>();
            services.AddScoped<IDoctorService, DoctorService.DoctorService>();
            services.AddScoped<ILaboratoryService, LaboratoryService>();
            services.AddDatabase();
        }
    }
}

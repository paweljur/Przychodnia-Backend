using Microsoft.Extensions.DependencyInjection;
using PrzychodniaBackend.Core.Application.UserService;
using PrzychodniaBackend.Core.Domain;

namespace PrzychodniaBackend.Core.Application
{
    public static class ServicesConfiguration
    {
        public static void AddCoreApp(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IUserService, UserService.UserService>();
            services.AddCoreDomain(connectionString);
        }
    }
}

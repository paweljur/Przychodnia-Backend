using Microsoft.Extensions.DependencyInjection;
using PrzychodniaBackend.Application.UserService;

namespace PrzychodniaBackend.Application
{
    public static class ServicesConfiguration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService.UserService>();
        }
    }
}

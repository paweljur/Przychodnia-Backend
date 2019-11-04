using Microsoft.Extensions.DependencyInjection;
using PrzychodniaBackend.Application.UserService;
using PrzychodniaBackend.EntityFrameworkCore;

namespace PrzychodniaBackend.Application
{
    public static class ServicesConfiguration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService.UserService>();
            services.AddDatabase();
        }
    }
}

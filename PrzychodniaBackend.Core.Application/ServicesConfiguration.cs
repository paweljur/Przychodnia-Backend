using Microsoft.Extensions.DependencyInjection;
using PrzychodniaBackend.Core.Application.UserService;
using PrzychodniaBackend.Core.Domain.Repositories.UserRepository;

namespace PrzychodniaBackend.Core.Application
{
    public static class ServicesConfiguration
    {
        public static void AddCoreDomain(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService.UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

    }
}

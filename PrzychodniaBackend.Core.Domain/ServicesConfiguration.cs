using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrzychodniaBackend.Core.Domain.Repositories.UserRepository;

namespace PrzychodniaBackend.Core.Domain
{
    public static class ServicesConfiguration
    {
        public static void AddCoreDomain(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<CoreContext>(options => options.UseSqlServer(connectionString));
        }

    }
}
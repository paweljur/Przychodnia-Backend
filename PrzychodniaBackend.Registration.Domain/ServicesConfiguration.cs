using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PrzychodniaBackend.Registration.Domain
{
    public static class ServicesConfiguration
    {
        public static void AddRegistrationDomain(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RegistrationContext>(options => options.UseSqlServer(connectionString));
        }

    }
}

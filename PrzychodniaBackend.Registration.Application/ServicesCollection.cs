using Microsoft.Extensions.DependencyInjection;
using PrzychodniaBackend.Registration.Domain;

namespace PrzychodniaBackend.Registration.Application
{
    public static class ServicesConfiguration
    {
        public static void AddRegistrationApp(this IServiceCollection services, string connectionString)
        {
            services.AddRegistrationDomain(connectionString);
        }
    }
}

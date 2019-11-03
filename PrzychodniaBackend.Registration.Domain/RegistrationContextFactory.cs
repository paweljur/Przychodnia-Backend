using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PrzychodniaBackend.Registration.Domain
{
    class RegistrationContextFactory : IDesignTimeDbContextFactory<RegistrationContext>
    {
        public RegistrationContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../PrzychodniaBackend.Api"))
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<RegistrationContext>();
            optionsBuilder.UseSqlServer(config["ConnectionString:PrzychodniaDB"]);

            return new RegistrationContext(optionsBuilder.Options);
        }
    }
}

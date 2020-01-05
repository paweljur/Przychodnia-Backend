using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PrzychodniaBackend.EntityFrameworkCore
{
    internal class CoreContextFactory : IDesignTimeDbContextFactory<AppContext>
    {
        public AppContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=PrzychodniaDB;Trusted_Connection=True;");

            return new AppContext(optionsBuilder.Options);
        }
    }
}
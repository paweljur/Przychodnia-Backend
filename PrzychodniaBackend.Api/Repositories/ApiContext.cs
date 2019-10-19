using Microsoft.EntityFrameworkCore;
using PrzychodniaBackend.Api.Entities;

namespace PrzychodniaBackend.Api.Repositories
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}

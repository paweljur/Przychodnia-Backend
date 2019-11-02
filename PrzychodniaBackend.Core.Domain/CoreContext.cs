using Microsoft.EntityFrameworkCore;
using PrzychodniaBackend.Core.Domain.Entities;

#nullable disable
namespace PrzychodniaBackend.Core.Domain
{
    public class CoreContext : DbContext
    {
        public DbSet<IcdCode> IcdCodes { get; set; }
        public DbSet<User> Users { get; set; }

        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Core");
        }
    }
}
using Microsoft.EntityFrameworkCore;

#nullable disable
namespace PrzychodniaBackend.Registration.Domain
{
    public class RegistrationContext : DbContext
    {
        private DbSet<Appointment> Appointments { get; set; }
        private DbSet<Doctor> Doctors { get; set; }

        public RegistrationContext(DbContextOptions<RegistrationContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Registration");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

#nullable disable
namespace PrzychodniaBackend.EntityFrameworkCore
{
    internal class AppContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PatientEntity> Patients { get; set; }
        public DbSet<AppointmentEntity> Appointment { get; set; }

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }
    }
}

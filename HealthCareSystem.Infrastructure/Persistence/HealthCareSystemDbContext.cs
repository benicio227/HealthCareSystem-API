using HealthCareSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.Infrastructure.Persistence
{
    public class HealthCareSystemDbContext : DbContext
    {
        public HealthCareSystemDbContext(DbContextOptions<HealthCareSystemDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments {  get; set; }
        public DbSet<DoctorGoogleToken> DoctorGoogleTokens {  get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);

            model.ApplyConfigurationsFromAssembly(typeof(HealthCareSystemDbContext).Assembly);
        }
    }
}

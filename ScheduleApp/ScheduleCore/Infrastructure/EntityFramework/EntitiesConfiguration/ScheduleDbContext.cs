using Microsoft.EntityFrameworkCore;
using ScheduleCore.Domain.Entities;
using ScheduleCore.Entities;
using ScheduleCore.EntitiesConfiguration;

namespace ScheduleCore.Infrastructure.EntityFramework.EntitiesConfiguration
{
    internal class ScheduleDbContext : DbContext
    {
        public ScheduleDbContext(DbContextOptions<ScheduleDbContext> options) : base(options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ClientInformation> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Address> Adresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AppointmentConfiguration().Configure(modelBuilder.Entity<Appointment>());
            new ClientInformacionConfiguration().Configure(modelBuilder.Entity<ClientInformation>());
            new ServiceConfiguration().Configure(modelBuilder.Entity<Service>());
            new AddressConfiguration().Configure(modelBuilder.Entity<Address>());

        }
    }
}

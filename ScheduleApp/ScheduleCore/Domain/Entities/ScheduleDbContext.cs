using Microsoft.EntityFrameworkCore;
using ScheduleCore.Domain.Entities;

namespace ScheduleCore.Entities
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


        }
    }
}

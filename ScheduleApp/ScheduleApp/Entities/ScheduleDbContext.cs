using Microsoft.EntityFrameworkCore;

namespace ScheduleApp.Entities
{
    public class ScheduleDbContext : DbContext
    {
        public ScheduleDbContext(DbContextOptions<ScheduleDbContext> options) : base(options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ClientInformations> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Adress> Adresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Appointment>()
                .Property(a => a.AppointmentStart)
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.AppointmentEnd)
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.Remarks)
                .IsRequired(false);

            modelBuilder.Entity<ClientInformations>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<ClientInformations>()
                .Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<ClientInformations>()
                .Property(a => a.PhoneNumber)
                .IsRequired();

            modelBuilder.Entity<ClientInformations>()
                .Property(a => a.Remarks)
                .IsRequired(false);

            modelBuilder.Entity<Service>()
                .Property(a => a.ServiceName)
                .IsRequired();

            modelBuilder.Entity<Service>()
                .Property(a => a.Price)
                .IsRequired();

            modelBuilder.Entity<Service>()
                .Property(a => a.Description)
                .IsRequired(false);

            modelBuilder.Entity<Adress>()
                .Property(a => a.Street)
                .IsRequired();

            modelBuilder.Entity<Adress>()
                .Property(a => a.PostalCode)
                .IsRequired();

            modelBuilder.Entity<Adress>()
                .Property(a => a.City)
                .IsRequired();

            modelBuilder.Entity<Adress>()
                .Property(a => a.Number)
                .IsRequired();

        }
    }
}

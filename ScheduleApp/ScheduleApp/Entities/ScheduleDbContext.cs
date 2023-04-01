using Microsoft.EntityFrameworkCore;

namespace ScheduleApp.Entities
{
    public class ScheduleDbContext : DbContext
    {
        public ScheduleDbContext(DbContextOptions<ScheduleDbContext> options) : base(options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Adress> Adresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .Property(a => a.Service)
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.Client)
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.AppointmentEnd)
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.AppointmentEnd)
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.Remarks)
                .IsRequired(false);

            modelBuilder.Entity<Client>()
                .Property(a => a.Adress)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Client>()
                .Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Client>()
                .Property(a => a.PhoneNumber)
                .IsRequired();
                
            modelBuilder.Entity<Client>()
                .Property(a => a.Adress)
                .IsRequired();

            modelBuilder.Entity<Client>()
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

            modelBuilder.Entity<Adress>()
                .Property(a => a.Client)
                .IsRequired();
        }
    }
}

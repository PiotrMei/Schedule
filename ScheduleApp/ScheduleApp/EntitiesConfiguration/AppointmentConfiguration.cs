using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleApp.Entities;

namespace ScheduleApp.EntitiesConfiguration
{
    internal sealed class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder
                .Property(a => a.AppointmentStart)
                .IsRequired();

            builder
                .Property(a => a.AppointmentEnd)
                .IsRequired();

            builder
                .Property(a => a.Remarks)
                .IsRequired(false);
        }
    }
}

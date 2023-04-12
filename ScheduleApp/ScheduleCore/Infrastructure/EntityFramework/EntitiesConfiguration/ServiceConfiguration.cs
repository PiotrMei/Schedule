using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleApp.Entities;

namespace ScheduleApp.EntitiesConfiguration
{
    internal sealed class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder
                .Property(a => a.ServiceName)
                .IsRequired();

            builder
                .Property(a => a.Price)
                .IsRequired();

            builder
                .Property(a => a.Description)
                .IsRequired(false);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleApp.Entities;

namespace ScheduleApp.EntitiesConfiguration
{
    internal sealed class AddressConfiguration : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder
                .Property(a => a.Street)
                .IsRequired();

            builder
                .Property(a => a.PostalCode)
                .IsRequired();

            builder
                .Property(a => a.City)
                .IsRequired();

            builder
                .Property(a => a.Number)
                .IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleApp.Entities;

namespace ScheduleApp.EntitiesConfiguration
{
    internal sealed class ClientInformacionConfiguration : IEntityTypeConfiguration<ClientInformation>
    {
        public void Configure(EntityTypeBuilder<ClientInformation> builder)
        {
            builder
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(25);

            builder
                .Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(25);

            builder
                .Property(a => a.PhoneNumber)
                .IsRequired();

            builder
                .Property(a => a.Remarks)
                .IsRequired(false);
        }
    }
}

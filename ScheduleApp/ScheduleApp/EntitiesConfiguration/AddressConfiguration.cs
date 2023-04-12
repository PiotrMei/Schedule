﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleCore.Entities;

namespace ScheduleCore.EntitiesConfiguration
{
    internal sealed class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
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

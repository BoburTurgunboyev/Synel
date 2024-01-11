using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Synel.Domain.Entities;

namespace Synel.Infrastructure.Configration
{
    public class EmployeeConfigration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Id).IsRequired();

            builder.Property(e => e.PayrollNumber).IsRequired().HasMaxLength(50);

            builder.Property(e => e.Forenames).HasMaxLength(100);

            builder.Property(e => e.Surname).IsRequired().HasMaxLength(100);


            builder.Property(e => e.Telephone).HasMaxLength(20);

            builder.Property(e => e.Mobile).HasMaxLength(20);

            builder.Property(e => e.Address).HasMaxLength(255);

            builder.Property(e => e.Address2).HasMaxLength(255);

            builder.Property(e => e.Postcode).HasMaxLength(20);

            builder.Property(e => e.Email).HasMaxLength(255);

        }
    }
}

using Domain.VirtualMachines.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class VMContractEntityTypeConfiguration : IEntityTypeConfiguration<VMContract>
    {
        public void Configure(EntityTypeBuilder<VMContract> builder)
        {
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.VMId).IsRequired();
            builder.Property(p => p.StartDate).IsRequired();
            builder.Property(p => p.EndDate).IsRequired();
        }
    }
}
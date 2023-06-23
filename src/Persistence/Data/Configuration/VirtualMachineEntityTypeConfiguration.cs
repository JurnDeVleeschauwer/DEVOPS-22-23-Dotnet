using Domain.Common;
using Domain.VirtualMachines;
using Domain.VirtualMachines.Contract;
using Domain.VirtualMachines.VirtualMachine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class VirtualMachineEntityTypeConfiguration : IEntityTypeConfiguration<VirtualMachine>
    {
        public void Configure(EntityTypeBuilder<VirtualMachine> builder)
        {
            /*
            builder.Property(p => p.Hardware.Memory).IsRequired();
            builder.Property(p => p.Hardware.Storage).IsRequired();
            builder.Property(p => p.Hardware.Amount_vCPU).IsRequired();
            builder.Property(p => p.Contract);
            builder.Property(p => p.Connection).IsRequired();
            builder.Property(p => p.BackUp.Type).IsRequired();
            builder.Property(p => p.BackUp.LastBackup).IsRequired();
            builder.Property(p => p.Statistics).IsRequired();
            */

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.OperatingSystem).IsRequired();
            builder.Property(p => p.Mode).IsRequired();
            builder.OwnsOne(p => p.Hardware);
            builder.HasOne<VMContract>(p => p.Contract).WithOne().HasForeignKey<VMContract>(c => c.VMId);
            builder.OwnsOne(p => p.Connection);
            builder.OwnsOne(p => p.BackUp);
            builder.HasOne(p => p.Statistics);
        }
    }
}
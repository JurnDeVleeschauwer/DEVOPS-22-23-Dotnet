using Domain.Projecten;
using Domain.Users;
using Domain.VirtualMachines.VirtualMachine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            // builder.Property(p => p.User).IsRequired();
            //builder.HasOne<User>(p => p.User).WithMany().HasForeignKey(u => u.Id).IsRequired();
            builder.HasOne<User>(p => p.User);
            builder.HasMany<VirtualMachine>(p => p.VirtualMachines).WithOne();
        }
    }
}
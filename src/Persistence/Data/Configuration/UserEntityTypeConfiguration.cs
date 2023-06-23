using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.PhoneNumber).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.HasOne(p => p.Contactpersoon);
            builder.Property(p => p.FirstName).IsRequired();
            builder.Property(p => p.Role).IsRequired();
            builder.Property(p => p.Type).IsRequired();
            builder.Property(p => p.BedrijfsNaam);
            builder.Property(p => p.TypeExtern);
            builder.Property(p => p.Course);


        }
    }
}
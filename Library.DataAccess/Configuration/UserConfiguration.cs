using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.UserName)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(u => u.PasswordHash)
                   .IsRequired();

            builder.Property(u => u.SecurityStamp)
                   .IsRequired();

            builder.HasMany(u => u.BookInstances)
                  .WithOne(bi => bi.User)
                  .HasForeignKey(bi => bi.UserId)
                  .OnDelete(DeleteBehavior.Restrict); 

        }
    }
}

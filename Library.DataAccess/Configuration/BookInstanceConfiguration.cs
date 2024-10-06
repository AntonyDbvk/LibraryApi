using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Configuration
{
    public class BookInstanceConfiguration : IEntityTypeConfiguration<BookInstance>
    {
        public void Configure(EntityTypeBuilder<BookInstance> builder)
        {

            builder.HasKey(bi => bi.Id);

            builder.HasOne(bi => bi.Book)
                   .WithMany() 
                   .HasForeignKey(bi => bi.BookId)
                   .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(bi => bi.User)
                   .WithMany(u => u.BookInstances)
                   .HasForeignKey(bi => bi.UserId)
                   .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}

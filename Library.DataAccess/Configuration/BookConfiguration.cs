using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(b => b.ISBN)
                   .IsRequired()
                   .HasMaxLength(13);

            builder.HasIndex(b => b.ISBN)
                   .IsUnique();

            builder.HasOne(b => b.Author) 
                   .WithMany(a => a.Books)
                   .HasForeignKey(b => b.AuthorId);
        }
    }
}
